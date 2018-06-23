using MNetworkLib.Common;
using MNetworkLib.TCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNetworkLib.Test {

    class Program {

        static void Main(string[] args) {

            Logger.AddDefaultConsoleLogging();

            TCPServer server = new TCPServer();
            server.Start();

            TCPClient client = new TCPClient("192.168.2.113", logging: false);
            client.Connect();

        }

    }

}
