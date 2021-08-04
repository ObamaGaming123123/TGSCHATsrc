﻿using System;
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
    public partial class ChatStart : Form
    {
        public ChatStart()
        {
            InitializeComponent();
        }

        private void ChatStart_Load(object sender, EventArgs e)
        {

        }

        private void ClientnServer_Click(object sender, EventArgs e)
        {

        }

        private void ClientStart_Click(object sender, EventArgs e)
        {
            ClientForm Client = new ClientForm();
            this.Hide();
            Client.ShowDialog();     
            this.Show();
        }

        private void ServerStart_Click(object sender, EventArgs e)
        {
            ServerForm ServerForm = new();
            this.Hide();
            ServerForm.ShowDialog();
            this.Show();
        }
    }
}
