using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace MNetworkLib.TCP {

    /// <summary>
    /// TCP Base which is used by client and server
    /// </summary>
    public abstract class TCPBase {

        /// <summary>
        /// Socket handling underlying communication
        /// </summary>
        public Socket Socket { get; protected set; }

        /// <summary>
        /// Whether its currently running or not
        /// </summary>
        public bool Running { get; protected set; }

        /// <summary>
        /// IP Address to use
        /// </summary>
        public IPAddress Address { get; protected set; }

        /// <summary>
        /// Port to use
        /// </summary>
        public ushort Port { get; protected set; }

        /// <summary>
        /// Thread to listen
        /// </summary>
        public Thread ListenThread { get; protected set; }
        
        /// <summary>
        /// Certificate to use for SSL
        /// </summary>
        public X509Certificate2 SSL { get; protected set; }

        /// <summary>
        /// Certificate protocol
        /// </summary>
        public SslProtocols SSLProtocol { get; set; } = SslProtocols.Tls12;

    }

}
