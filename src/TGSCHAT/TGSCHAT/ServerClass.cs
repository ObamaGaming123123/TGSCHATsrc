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
        public static ServerForm formObject = null;
        public static Hashtable clientsList = new Hashtable();
        public static bool RestartConnection = false;
        public static TcpListener serverSocket;
        public static TcpClient clientSocket;
        public static string hostname;
        public static string myIP;
        public static void MainText(string Text)
        {
            formObject.textBox1.Text = formObject.textBox1.Text + Text + Environment.NewLine;
        }
        public static void Connect(int counter = 0)
        {
            MainText("Starting Server");
            IPAddress localAddr = IPAddress.Parse("10.36.100.250");
            serverSocket = new TcpListener(localAddr,8888);

            var dt = DateTime.Now;
            clientSocket = default(TcpClient);
            serverSocket.Start();
            MainText("Chat Server Started ....");

            hostname = Dns.GetHostName(); // Retrive the Name of HOST  
            MainText("ComputerName: " + hostname);
            // Get the IP  
            myIP = Dns.GetHostByName(hostname).AddressList[0].ToString();
            MainText("ServerName: " + myIP);
            MainText("----------------------------------");

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

                MainText(dataFromClient + " Joined\t" + dt.ToString("HH:mm:ss"));


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
                        ServerClass.MainText("From client - " + clNo + " : " + dataFromClient);
                        rCount = Convert.ToString(requestCount);

                        Program.broadcast(dataFromClient, clNo, true);
                        LastNameForDc = dataFromClient;
                    }
                    catch
                    {
                        ServerClass.MainText(clNo + " Has Discconected \t Time:" + dt.ToString("HH:mm:ss"));
                        Program.broadcast(clNo + " Discconected ", clNo, false);
                        clientsList.Remove(clNo);
                        break;
                    }
                }
            }//end while
        }//end doChat
    } //end class handleClinet
}
