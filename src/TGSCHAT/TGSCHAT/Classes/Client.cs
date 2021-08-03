using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TGSCHAT.Classes
{
    //Client Class for sending and recieving

    class Client
    {
        private static System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        private static NetworkStream serverStream = default(NetworkStream);
        private static string readData = null;

        public static void Send(string Message)
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(Message + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }
        public static void Receive()
        {

        }
        private void getMessage()
        {

        }
    }
}
