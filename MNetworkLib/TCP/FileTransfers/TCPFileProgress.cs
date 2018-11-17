using System;
using System.Collections.Generic;
using System.Text;

namespace MNetworkLib.TCP.FileTransfers {

    public class TCPFileProgress {

        public delegate void ProgressHandler(double progress);

        public event ProgressHandler OnProgress;

        public delegate void FinishHandler();

        public event FinishHandler OnFinish;

        public TCPFileTransferData TransferData { get; set; }

        public TCPFileCache Cache { get; set; }

        public TCPFileProgress() {



        }

    }

}
