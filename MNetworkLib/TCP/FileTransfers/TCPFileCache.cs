using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MNetworkLib.TCP.FileTransfers {

    public class TCPFileCache {

        public string TargetFile { get; set; }

        public FileStream FileStream { get; set; }

        public List<TCPFileTile> Data { get; set; } = new List<TCPFileTile>();

        public long CurrentIndex { get; set; } = 0;

        public long ReceivedBytes { get; set; } = 0;

        public TCPFileCache(string filename) {

            FileStream = new FileStream(filename + ".tmpdwn", FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
            TargetFile = filename;

        }

        public void FinalSave() {

            FileStream.Flush();
            FileStream.Dispose();

            File.Move(TargetFile + ".tmpdwn", TargetFile);

        }

        public void AddData(TCPFileTile tile) {

            if(Data.Count == 0) {
                
                if (CurrentIndex == 0) {
                    
                    if(tile.Index == 0) {

                        WriteTo(tile.Data);

                    } else {

                        Data.Add(tile);

                    }

                } else {

                    if(tile.Index == CurrentIndex + 1) {

                        WriteTo(tile.Data);

                    } else {

                        Data.Add(tile);

                    }

                }

            } else {

                if(CurrentIndex + 1 == tile.Index) {

                    Data.Insert(0, tile);

                    while(Data.Count > 0 && Data[0].Index == CurrentIndex + 1) {

                        WriteTo(Data[0].Data);
                        Data.RemoveAt(0);

                    }

                } else {

                    int current = 0;

                    while(Data[current].Index < tile.Index) {

                        current++;
                        if(current == Data.Count) {
                            break;
                        }

                    }

                    Data.Insert(current, tile);

                }

            }

        }

        private void WriteTo(byte[] data) {

            ReceivedBytes += data.Length;
            FileStream.Write(data, 0, data.Length);

        }

    }

}
