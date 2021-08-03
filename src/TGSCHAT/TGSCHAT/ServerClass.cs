using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TGSCHAT
{
    public class ServerClass
    {
        public ServerClass Serv = null;
        public static Hashtable clientsList = new Hashtable();
        public static bool RestartConnection = false;
        public static TcpListener serverSocket;
        public static TcpClient clientSocket;
        public static string hostname;
        public static string myIP;
        static void Main(string[] args)
        {
            Connect();
        }
        public static void Connect(int counter = 0)
        {
            serverSocket = new TcpListener(8888);

            var dt = DateTime.Now;
            clientSocket = default(TcpClient);
            serverSocket.Start();
            Console.WriteLine("Chat Server Started ....");

            hostname = Dns.GetHostName(); // Retrive the Name of HOST  
            Console.WriteLine("ComputerName: " + hostname);
            // Get the IP  
            myIP = Dns.GetHostByName(hostname).AddressList[0].ToString();
            Console.WriteLine("ServerName: " + myIP);
            Console.WriteLine("----------------------------------");

            Console.ReadKey();

            while ((true))
            {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();

                byte[] bytesFrom = new byte[4096];
                string dataFromClient = null;

                NetworkStream networkStream = clientSocket.GetStream();
                int bytesRead = networkStream.Read(bytesFrom, 0, 1024);
                dataFromClient = Encoding.ASCII.GetString(bytesFrom, 0, bytesRead);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                clientsList.Add(dataFromClient, clientSocket);

                broadcast(dataFromClient + " Joined ", dataFromClient, false);

                Console.WriteLine(dataFromClient + " Joined\t" + dt.ToString("HH:mm:ss"));


                handleClinet client = new handleClinet();
                client.startClient(clientSocket, dataFromClient, clientsList, serverSocket);
            }
        }
        public static void broadcast(string msg, string uName, bool flag)
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = null;
                try
                {
                    broadcastStream = broadcastSocket.GetStream();
                }
                catch
                {
                    goto End;
                }
                Byte[] broadcastBytes = null;

                if (flag == true)
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(uName + ": " + msg);
                }
                else
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(msg);
                }
                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            End:;
            }
        }  //end broadcast function
    }//end Main class


    public class handleClinet
    {
        TcpClient clientSocket;
        string clNo;
        Hashtable clientsList;
        private Thread ctThread;
        bool Dissconnected = false;
        TcpListener ServerSocket;


        public void startClient(TcpClient inClientSocket, string clineNo, Hashtable cList, TcpListener serverSocket)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            ServerSocket = serverSocket;
            this.clientsList = cList;
            ctThread = new Thread(doChat);
            ctThread.Start();
        }
        private void doChat()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
            string rCount = null;
            requestCount = 0;
            string LastNameForDc = null;
            var dt = DateTime.Now;

            while ((true))
            {
                if (Dissconnected == false)
                {
                    try
                    {
                        requestCount = requestCount + 1;
                        NetworkStream networkStream = clientSocket.GetStream();
                        int penis = networkStream.Read(bytesFrom, 0, 1024);
                        dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom, 0, penis);
                        dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                        Console.WriteLine("From client - " + clNo + " : " + dataFromClient);
                        rCount = Convert.ToString(requestCount);

                        Program.broadcast(dataFromClient, clNo, true);
                        LastNameForDc = dataFromClient;
                    }
                    catch
                    {
                        Console.WriteLine(clNo + " Has Discconected \t Time:" + dt.ToString("HH:mm:ss"));
                        Program.broadcast(clNo + " Discconected ", clNo, false);
                        clientsList.Remove(clNo);
                        Thread.CurrentThread.Abort();
                    }
                }
            }//end while
        }//end doChat
    } //end class handleClinet
}
