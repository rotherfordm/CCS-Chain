namespace Wallet_DesuCoin
{
    partial class OpenWallet
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtOpenWalletPK = new System.Windows.Forms.TextBox();
            this.txtOpenWallet = new System.Windows.Forms.RichTextBox();
            this.btnOpenWallet = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtOpenWalletPK);
            this.panel2.Controls.Add(this.txtOpenWallet);
            this.panel2.Controls.Add(this.btnOpenWallet);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(990, 463);
            this.panel2.TabIndex = 3;
            // 
            // txtOpenWalletPK
            // 
            this.txtOpenWalletPK.Location = new System.Drawing.Point(22, 106);
            this.txtOpenWalletPK.Multiline = true;
            this.txtOpenWalletPK.Name = "txtOpenWalletPK";
            this.txtOpenWalletPK.Size = new System.Drawing.Size(511, 31);
            this.txtOpenWalletPK.TabIndex = 5;
            // 
            // txtOpenWallet
            // 
            this.txtOpenWallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOpenWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpenWallet.Location = new System.Drawing.Point(22, 156);
            this.txtOpenWallet.Name = "txtOpenWallet";
            this.txtOpenWallet.Size = new System.Drawing.Size(950, 289);
            this.txtOpenWallet.TabIndex = 4;
            this.txtOpenWallet.Text = "";
            // 
            // btnOpenWallet
            // 
            this.btnOpenWallet.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenWallet.Location = new System.Drawing.Point(539, 106);
            this.btnOpenWallet.Name = "btnOpenWallet";
            this.btnOpenWallet.Size = new System.Drawing.Size(143, 31);
            this.btnOpenWallet.TabIndex = 2;
            this.btnOpenWallet.Text = "Open Wallet";
            this.btnOpenWallet.UseVisualStyleBackColor = true;
            this.btnOpenWallet.Click += new System.EventHandler(this.btnOpenWallet_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(481, 29);
            this.label7.TabIndex = 1;
            this.label7.Text = "Enter your wallet private key (ECDSA key, 65 digits) ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(303, 34);
            this.label6.TabIndex = 0;
            this.label6.Text = "Open an Existing Wallet";
            // 
            // OpenWallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "OpenWallet";
            this.Size = new System.Drawing.Size(997, 477);
            this.Load += new System.EventHandler(this.OpenWallet_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox txtOpenWallet;
        private System.Windows.Forms.Button btnOpenWallet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOpenWalletPK;
    }
}
