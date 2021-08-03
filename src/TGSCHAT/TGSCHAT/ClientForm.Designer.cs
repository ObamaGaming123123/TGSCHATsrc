
namespace TGSCHAT
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PreText = new System.Windows.Forms.TextBox();
            this.MainChat = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.Button();
            this.Leave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PreText
            // 
            this.PreText.Location = new System.Drawing.Point(129, 411);
            this.PreText.Name = "PreText";
            this.PreText.Size = new System.Drawing.Size(455, 27);
            this.PreText.TabIndex = 0;
            // 
            // MainChat
            // 
            this.MainChat.Location = new System.Drawing.Point(129, 12);
            this.MainChat.Multiline = true;
            this.MainChat.Name = "MainChat";
            this.MainChat.Size = new System.Drawing.Size(455, 387);
            this.MainChat.TabIndex = 1;
            this.MainChat.TextChanged += new System.EventHandler(this.MainChat_TextChanged);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(12, 411);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(111, 27);
            this.Send.TabIndex = 2;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(12, 378);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(111, 27);
            this.Connect.TabIndex = 3;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Leave
            // 
            this.Leave.Location = new System.Drawing.Point(590, 411);
            this.Leave.Name = "Leave";
            this.Leave.Size = new System.Drawing.Size(111, 28);
            this.Leave.TabIndex = 4;
            this.Leave.Text = "Leave";
            this.Leave.UseVisualStyleBackColor = true;
            this.Leave.Click += new System.EventHandler(this.Leave_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 450);
            this.Controls.Add(this.Leave);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.MainChat);
            this.Controls.Add(this.PreText);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox PreText;
        private System.Windows.Forms.TextBox MainChat;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Button Leave;
    }
}