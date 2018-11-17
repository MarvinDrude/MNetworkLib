using System;
using System.Collections.Generic;
using System.Text;

namespace MNetworkLib.TCP.FileTransfers {

    /// <summary>
    /// Data object needed to provide all 
    /// </summary>
    public class TCPFileTransferData {

        /// <summary>
        /// The file name withouth extension for exmaple 'nice_picture'
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Extension of the file for example 'txt'
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Full file name for example 'debug.txt'
        /// Created on the fly every time it is called
        /// </summary>
        public string FullFileName => FileName + "." + Extension;

        /// <summary>
        /// The source path the file is coming from
        /// </summary>
        public string SrcPath { get; set; }

        /// <summary>
        /// The destination path of the file
        /// </summary>
        public string DestPath { get; set; }

        /// <summary>
        /// Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Date and time of the creation of the file
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Date and time of last accessed event
        /// </summary>
        public DateTime Accessed { get; set; }

        /// <summary>
        /// Date and time of last changed event
        /// </summary>
        public DateTime Written { get; set; }
        
        /// <summary>
        /// Size of the file
        /// </summary>
        public long Size { get; set; }

    }

}
