using MNetworkLib.Common;
using MNetworkLib.TCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MNetworkLib.Test {

    class Program {

        static void Main(string[] args) {

            Logger.AddDefaultConsoleLogging();

            TCPServer server = new TCPServer();

            server.OnMessage += (cl, me) => {

                Logger.Write("TEST", cl.UID + ": " + me.ToStringContent());

                cl.Send(new TCPMessage() {
                    Content = Encoding.UTF8.GetBytes("This is a message from the server")
                });

            };

            server.Start();

            TCPClient client = new TCPClient("192.168.2.113", logging: false);

            client.OnHandshake += () => {
                client.Send(new TCPMessage() {
                    Content = Encoding.UTF8.GetBytes("This is a test")
                });
            };

            client.OnMessage += (me) => {

                Logger.Write("TEST", "Server: " + me.ToStringContent());

            };

            client.Connect();

        }

    }

}
