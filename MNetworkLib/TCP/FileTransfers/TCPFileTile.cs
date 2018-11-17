using System;
using System.Collections.Generic;
using System.Text;

namespace MNetworkLib.TCP.FileTransfers {

    public class TCPFileTile {

        public long ID { get; set; }

        public long Index { get; set; }

        public byte[] Data { get; set; }

    }

    public class TCPFileMessage {

        public int Code { get; set; }

        public long ID { get; set; }

    }

}
