namespace Wallet_DesuCoin
{
    partial class frmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.link_lbl_Open_Wallet = new System.Windows.Forms.LinkLabel();
            this.link_lbl_Create_Wallet = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.link_lbl_send_trans = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.link_lbl_send_trans);
            this.panel1.Controls.Add(this.link_lbl_Open_Wallet);
            this.panel1.Controls.Add(this.link_lbl_Create_Wallet);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 87);
            this.panel1.TabIndex = 0;
            // 
            // link_lbl_Open_Wallet
            // 
            this.link_lbl_Open_Wallet.ActiveLinkColor = System.Drawing.Color.WhiteSmoke;
            this.link_lbl_Open_Wallet.AutoSize = true;
            this.link_lbl_Open_Wallet.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.link_lbl_Open_Wallet.LinkColor = System.Drawing.Color.Black;
            this.link_lbl_Open_Wallet.Location = new System.Drawing.Point(370, 32);
            this.link_lbl_Open_Wallet.Name = "link_lbl_Open_Wallet";
            this.link_lbl_Open_Wallet.Size = new System.Drawing.Size(191, 24);
            this.link_lbl_Open_Wallet.TabIndex = 6;
            this.link_lbl_Open_Wallet.TabStop = true;
            this.link_lbl_Open_Wallet.Text = "Open Existing Wallet";
            this.link_lbl_Open_Wallet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_lbl_Open_Wallet_LinkClicked);
            // 
            // link_lbl_Create_Wallet
            // 
            this.link_lbl_Create_Wallet.ActiveLinkColor = System.Drawing.Color.WhiteSmoke;
            this.link_lbl_Create_Wallet.AutoSize = true;
            this.link_lbl_Create_Wallet.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.link_lbl_Create_Wallet.LinkColor = System.Drawing.Color.Black;
            this.link_lbl_Create_Wallet.Location = new System.Drawing.Point(131, 32);
            this.link_lbl_Create_Wallet.Name = "link_lbl_Create_Wallet";
            this.link_lbl_Create_Wallet.Size = new System.Drawing.Size(175, 24);
            this.link_lbl_Create_Wallet.TabIndex = 5;
            this.link_lbl_Create_Wallet.TabStop = true;
            this.link_lbl_Create_Wallet.Text = "Create New Wallet";
            this.link_lbl_Create_Wallet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_lbl_Create_Wallet_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(809, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Send Transaction";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(617, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Account Balance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Home";
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(12, 93);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1001, 482);
            this.panelMain.TabIndex = 1;
            // 
            // link_lbl_send_trans
            // 
            this.link_lbl_send_trans.ActiveLinkColor = System.Drawing.Color.WhiteSmoke;
            this.link_lbl_send_trans.AutoSize = true;
            this.link_lbl_send_trans.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.link_lbl_send_trans.LinkColor = System.Drawing.Color.Black;
            this.link_lbl_send_trans.Location = new System.Drawing.Point(809, 32);
            this.link_lbl_send_trans.Name = "link_lbl_send_trans";
            this.link_lbl_send_trans.Size = new System.Drawing.Size(163, 24);
            this.link_lbl_send_trans.TabIndex = 7;
            this.link_lbl_send_trans.TabStop = true;
            this.link_lbl_send_trans.Text = "Send Transaction";
            this.link_lbl_send_trans.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_lbl_send_trans_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1025, 587);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wallet";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.LinkLabel link_lbl_Create_Wallet;
        private System.Windows.Forms.LinkLabel link_lbl_Open_Wallet;
        private System.Windows.Forms.LinkLabel link_lbl_send_trans;
    }
}

