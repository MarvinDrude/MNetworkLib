using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MNetworkLib.TCP.FileTransfers {

    /// <summary>
    /// Class to receive files over tcp
    /// </summary>
    public class TCPFileTransferClient : TCPClient {
       
        /// <summary>
        /// Queue of incoming files
        /// </summary>
        public Queue<TCPFileProgress> Incoming { get; private set; }

        /// <summary>
        /// Queue of incoming files
        /// </summary>
        public Queue<TCPFileTransferData> Outcoming { get; private set; }

        /// <summary>
        /// TCP Client used to transfer file data in
        /// </summary>
        public TCPClient FileTransfer { get; set; }

        /// <summary>
        /// Port of receiver socket
        /// </summary>
        public ushort TransferPort { get; set; } = 27790;
        
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="adr"></param>
        /// <param name="port"></param>
        /// <param name="ssl"></param>
        /// <param name="logging"></param>
        public TCPFileTransferClient(string adr, ushort port, X509Certificate2 ssl = null, ushort trfPort = 27790, bool logging = false)
            : base(adr, port, ssl, logging) {

            TransferPort = trfPort;

            Incoming = new Queue<TCPFileProgress>();
            Outcoming = new Queue<TCPFileTransferData>();
            
            InitEvents();
            InitSockets();

        }

        /// <summary>
        /// Initialize sockets for file stream
        /// </summary>
        private void InitSockets() {

            FileTransfer = new TCPClient(AddressString, TransferPort, SSL, Logging);

            FileTransfer.OnMessage += (message) => {

                using(MemoryStream ms = new MemoryStream(message.Content)) {

                    long id = TCPReaderWriter.ReadLong(ms, false);
                    long index = TCPReaderWriter.ReadLong(ms, false);

                    byte[] data = TCPReaderWriter.Read(ms, (uint)message.Content.Length - 16);

                    TCPFileProgress progress = Incoming.Peek();

                    if(progress.TransferData.ID == id) {

                        progress.Cache.AddData(new TCPFileTile() {
                            ID = id,
                            Data = data,
                            Index = index
                        });

                    }

                }

            };

        }

        /// <summary>
        /// Initializes the events
        /// </summary>
        private void InitEvents() {

            OnMessage += (message) => {

                TCPFileCode code = (TCPFileCode)message.Content[0];
                string json = Encoding.UTF8.GetString(message.Content.Skip(1).ToArray());
                
                if(code == TCPFileCode.Enqueue) {

                    TCPFileTransferData data = JsonConvert.DeserializeObject<TCPFileTransferData>(json);

                    Incoming.Enqueue(new TCPFileProgress() {
                        Cache = new TCPFileCache(data.FullFileName),
                        TransferData = data
                    });

                    using(MemoryStream ms = new MemoryStream()) {

                        TCPReaderWriter.WriteNumber(ms, data.ID, false);
                        Send(TCPFileCode.Reply, ms.ToArray());

                    }
                    
                }

            };

        }

        private void Send(TCPFileCode code, byte[] content) {

            using(MemoryStream ms = new MemoryStream()) {

                ms.WriteByte((byte)code);
                ms.Write(content, 0, content.Length);

                Send(new TCPMessage() {
                    Content = ms.ToArray()
                });

            }

        }

    }

}
