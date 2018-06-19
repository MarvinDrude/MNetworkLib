using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MNetworkLib.TCP {

    /// <summary>
    /// TCPClient used to conenct to and communicate with tcp server
    /// </summary>
    public class TCPClient : TCPBase {

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="ssl"></param>
        public TCPClient(string address = "localhost", ushort port = 27789, X509Certificate2 ssl = null) {

            IPAddress adr = null;

            if(!IPAddress.TryParse(address, out adr)) {
                throw new Exception("IPAddress not recognizable");
            }

            Address = adr;
            Port = port;
            SSL = ssl;

        }

    }

}
