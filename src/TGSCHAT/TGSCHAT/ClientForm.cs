using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGSCHAT
{
    public partial class ClientForm : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        int Closing = 0, Connected = 0;
        public ClientForm()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
        }
        private void msg()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                MainChat.Text = MainChat.Text + Environment.NewLine + " >> " + readData;
        }

        private void MainChat_TextChanged(object sender, EventArgs e)
        {

        }
        private void getMessage()
        {
            while (true)
            {
                if (Connected == 1)
                {
                    try
                    {
                        serverStream = clientSocket.GetStream();
                        byte[] inStream = new byte[4096];
                        serverStream.Read(inStream, 0, inStream.Length);
                        string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                        readData = "" + returndata;
                        msg(); ;
                    }
                    catch
                    {
                        System.Windows.Forms.Application.Exit();
                        System.Environment.Exit(0);
                    }
                }
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            try
            {
                clientSocket.Connect("10.36.100.250", 8888);
            }
            catch
            {
                // Connection failed
                MainChat.Text = "Connection Failed!";
            }

            if (clientSocket.Connected == true)
            {
                // Connection Succeeded
                readData = "Conected to Chat Server ...";
                Connected = 1;
                msg();
                serverStream = clientSocket.GetStream();

                byte[] outStream = System.Text.Encoding.ASCII.GetBytes("James" + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                Thread ctThread = new Thread(getMessage);
                ctThread.Start();
            }
        }

        private void Leave_Click(object sender, EventArgs e)
        {
            Connected = 0;
            serverStream.Close();
            clientSocket.Close();
            System.Windows.Forms.Application.Exit();
            System.Environment.Exit(0);
        }

        private void Send_Click(object sender, EventArgs e)
        {
            //Send Button
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(PreText.Text + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            PreText.Text = "";
        }
    }
}
