using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGSCHAT
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ServerClass instance = new ServerClass();
            // Error instance.Serv = this;
            ServerClass.Connect();
        }
    }
}
