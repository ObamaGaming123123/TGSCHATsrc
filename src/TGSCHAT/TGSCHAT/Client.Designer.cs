﻿
namespace TGSCHAT
{
    partial class Client
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
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(12, 411);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(111, 27);
            this.Send.TabIndex = 2;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 450);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.MainChat);
            this.Controls.Add(this.PreText);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox PreText;
        private System.Windows.Forms.TextBox MainChat;
        private System.Windows.Forms.Button Send;
    }
}