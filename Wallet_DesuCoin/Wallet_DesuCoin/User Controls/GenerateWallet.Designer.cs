namespace Wallet_DesuCoin
{
    partial class GenerateWallet
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
            this.txtGenWallet = new System.Windows.Forms.RichTextBox();
            this.btnGenWallet = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtGenWallet);
            this.panel2.Controls.Add(this.btnGenWallet);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(990, 463);
            this.panel2.TabIndex = 2;
            // 
            // txtGenWallet
            // 
            this.txtGenWallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGenWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenWallet.Location = new System.Drawing.Point(22, 156);
            this.txtGenWallet.Name = "txtGenWallet";
            this.txtGenWallet.Size = new System.Drawing.Size(950, 289);
            this.txtGenWallet.TabIndex = 4;
            this.txtGenWallet.Text = "";
            // 
            // btnGenWallet
            // 
            this.btnGenWallet.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenWallet.Location = new System.Drawing.Point(23, 106);
            this.btnGenWallet.Name = "btnGenWallet";
            this.btnGenWallet.Size = new System.Drawing.Size(143, 31);
            this.btnGenWallet.TabIndex = 2;
            this.btnGenWallet.Text = "Generate Now";
            this.btnGenWallet.UseVisualStyleBackColor = true;
            this.btnGenWallet.Click += new System.EventHandler(this.btnGenWallet_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(554, 29);
            this.label7.TabIndex = 1;
            this.label7.Text = "Generate a new wallet: Private Key -> Public Key -> Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 34);
            this.label6.TabIndex = 0;
            this.label6.Text = "Create a New Wallet";
            // 
            // GenerateWallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "GenerateWallet";
            this.Size = new System.Drawing.Size(997, 477);
            this.Load += new System.EventHandler(this.GenerateWallet_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox txtGenWallet;
        private System.Windows.Forms.Button btnGenWallet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}
