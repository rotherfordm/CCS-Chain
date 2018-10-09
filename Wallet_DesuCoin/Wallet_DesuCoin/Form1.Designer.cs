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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAccBalance = new System.Windows.Forms.Label();
            this.txtLbl = new System.Windows.Forms.Label();
            this.link_lbl_send_trans = new System.Windows.Forms.LinkLabel();
            this.link_lbl_Open_Wallet = new System.Windows.Forms.LinkLabel();
            this.link_lbl_Create_Wallet = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAddressUsed = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblAccBalance);
            this.panel1.Controls.Add(this.txtLbl);
            this.panel1.Controls.Add(this.link_lbl_send_trans);
            this.panel1.Controls.Add(this.link_lbl_Open_Wallet);
            this.panel1.Controls.Add(this.link_lbl_Create_Wallet);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 87);
            this.panel1.TabIndex = 0;
            // 
            // lblAccBalance
            // 
            this.lblAccBalance.AutoSize = true;
            this.lblAccBalance.Font = new System.Drawing.Font("Bahnschrift SemiBold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccBalance.Location = new System.Drawing.Point(797, 22);
            this.lblAccBalance.Name = "lblAccBalance";
            this.lblAccBalance.Size = new System.Drawing.Size(35, 40);
            this.lblAccBalance.TabIndex = 9;
            this.lblAccBalance.Text = "0";
            // 
            // txtLbl
            // 
            this.txtLbl.AutoSize = true;
            this.txtLbl.Font = new System.Drawing.Font("Bahnschrift SemiBold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLbl.Location = new System.Drawing.Point(851, 22);
            this.txtLbl.Name = "txtLbl";
            this.txtLbl.Size = new System.Drawing.Size(163, 40);
            this.txtLbl.TabIndex = 8;
            this.txtLbl.Text = "Aeternum";
            // 
            // link_lbl_send_trans
            // 
            this.link_lbl_send_trans.ActiveLinkColor = System.Drawing.Color.WhiteSmoke;
            this.link_lbl_send_trans.AutoSize = true;
            this.link_lbl_send_trans.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.link_lbl_send_trans.LinkColor = System.Drawing.Color.Black;
            this.link_lbl_send_trans.Location = new System.Drawing.Point(617, 32);
            this.link_lbl_send_trans.Name = "link_lbl_send_trans";
            this.link_lbl_send_trans.Size = new System.Drawing.Size(163, 24);
            this.link_lbl_send_trans.TabIndex = 7;
            this.link_lbl_send_trans.TabStop = true;
            this.link_lbl_send_trans.Text = "Send Transaction";
            this.link_lbl_send_trans.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_lbl_send_trans_LinkClicked);
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
            this.panelMain.BackgroundImage = global::Wallet_DesuCoin.Properties.Resources.Chain_link_icon_Opacity;
            this.panelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMain.Location = new System.Drawing.Point(12, 93);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1001, 482);
            this.panelMain.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(270, 585);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address Used: ";
            // 
            // lblAddressUsed
            // 
            this.lblAddressUsed.AutoSize = true;
            this.lblAddressUsed.Font = new System.Drawing.Font("Bahnschrift SemiLight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressUsed.Location = new System.Drawing.Point(417, 585);
            this.lblAddressUsed.Name = "lblAddressUsed";
            this.lblAddressUsed.Size = new System.Drawing.Size(182, 24);
            this.lblAddressUsed.TabIndex = 3;
            this.lblAddressUsed.Text = "No Address Loaded";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1025, 611);
            this.Controls.Add(this.lblAddressUsed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aeternum Wallet";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.LinkLabel link_lbl_Create_Wallet;
        private System.Windows.Forms.LinkLabel link_lbl_Open_Wallet;
        private System.Windows.Forms.LinkLabel link_lbl_send_trans;
        private System.Windows.Forms.Label txtLbl;
        private System.Windows.Forms.Label lblAccBalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAddressUsed;
    }
}

