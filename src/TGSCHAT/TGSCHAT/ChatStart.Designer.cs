
namespace TGSCHAT
{
    partial class ChatStart
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ClientStart = new System.Windows.Forms.Button();
            this.ClientnServer = new System.Windows.Forms.Button();
            this.ServerStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClientStart
            // 
            this.ClientStart.Location = new System.Drawing.Point(12, 18);
            this.ClientStart.Name = "ClientStart";
            this.ClientStart.Size = new System.Drawing.Size(149, 51);
            this.ClientStart.TabIndex = 0;
            this.ClientStart.Text = "Client";
            this.ClientStart.UseVisualStyleBackColor = true;
            this.ClientStart.Click += new System.EventHandler(this.ClientStart_Click);
            // 
            // ClientnServer
            // 
            this.ClientnServer.Location = new System.Drawing.Point(12, 132);
            this.ClientnServer.Name = "ClientnServer";
            this.ClientnServer.Size = new System.Drawing.Size(149, 51);
            this.ClientnServer.TabIndex = 1;
            this.ClientnServer.Text = "Client n Host";
            this.ClientnServer.UseVisualStyleBackColor = true;
            this.ClientnServer.Click += new System.EventHandler(this.ClientnServer_Click);
            // 
            // ServerStart
            // 
            this.ServerStart.Location = new System.Drawing.Point(12, 75);
            this.ServerStart.Name = "ServerStart";
            this.ServerStart.Size = new System.Drawing.Size(149, 51);
            this.ServerStart.TabIndex = 2;
            this.ServerStart.Text = "Host";
            this.ServerStart.UseVisualStyleBackColor = true;
            // 
            // ChatStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 205);
            this.Controls.Add(this.ServerStart);
            this.Controls.Add(this.ClientnServer);
            this.Controls.Add(this.ClientStart);
            this.Name = "ChatStart";
            this.Text = "Start";
            this.Load += new System.EventHandler(this.ChatStart_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ClientStart;
        private System.Windows.Forms.Button ClientnServer;
        private System.Windows.Forms.Button ServerStart;
    }
}

