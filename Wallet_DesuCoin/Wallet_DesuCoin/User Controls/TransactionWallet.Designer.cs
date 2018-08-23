namespace Wallet_DesuCoin
{
    partial class TransactionWallet
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
            this.txtTransConfirm = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTransRecip = new System.Windows.Forms.TextBox();
            this.txtTransValue = new System.Windows.Forms.TextBox();
            this.txtTransSender = new System.Windows.Forms.TextBox();
            this.txtTransData = new System.Windows.Forms.RichTextBox();
            this.btnSignTransact = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtTransConfirm);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtTransRecip);
            this.panel2.Controls.Add(this.txtTransValue);
            this.panel2.Controls.Add(this.txtTransSender);
            this.panel2.Controls.Add(this.txtTransData);
            this.panel2.Controls.Add(this.btnSignTransact);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(990, 463);
            this.panel2.TabIndex = 4;
            // 
            // txtTransConfirm
            // 
            this.txtTransConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransConfirm.Location = new System.Drawing.Point(22, 358);
            this.txtTransConfirm.Name = "txtTransConfirm";
            this.txtTransConfirm.Size = new System.Drawing.Size(950, 91);
            this.txtTransConfirm.TabIndex = 14;
            this.txtTransConfirm.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(586, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 35);
            this.button1.TabIndex = 13;
            this.button1.Text = "Send Transaction";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiLight", 13.8F);
            this.label4.Location = new System.Drawing.Point(22, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 29);
            this.label4.TabIndex = 12;
            this.label4.Text = "Block Chain Node:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(233, 321);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 22);
            this.textBox1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiLight", 13.8F);
            this.label3.Location = new System.Drawing.Point(25, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Value :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiLight", 13.8F);
            this.label2.Location = new System.Drawing.Point(25, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "Recipient : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiLight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Sender :";
            // 
            // txtTransRecip
            // 
            this.txtTransRecip.Location = new System.Drawing.Point(157, 93);
            this.txtTransRecip.Name = "txtTransRecip";
            this.txtTransRecip.Size = new System.Drawing.Size(582, 22);
            this.txtTransRecip.TabIndex = 7;
            this.txtTransRecip.Text = "3456787654345678";
            // 
            // txtTransValue
            // 
            this.txtTransValue.Location = new System.Drawing.Point(157, 125);
            this.txtTransValue.Name = "txtTransValue";
            this.txtTransValue.Size = new System.Drawing.Size(582, 22);
            this.txtTransValue.TabIndex = 6;
            this.txtTransValue.Text = "678";
            // 
            // txtTransSender
            // 
            this.txtTransSender.Enabled = false;
            this.txtTransSender.Location = new System.Drawing.Point(157, 60);
            this.txtTransSender.Name = "txtTransSender";
            this.txtTransSender.Size = new System.Drawing.Size(582, 22);
            this.txtTransSender.TabIndex = 5;
            // 
            // txtTransData
            // 
            this.txtTransData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransData.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransData.Location = new System.Drawing.Point(22, 156);
            this.txtTransData.Name = "txtTransData";
            this.txtTransData.Size = new System.Drawing.Size(950, 154);
            this.txtTransData.TabIndex = 4;
            this.txtTransData.Text = "";
            // 
            // btnSignTransact
            // 
            this.btnSignTransact.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignTransact.Location = new System.Drawing.Point(775, 85);
            this.btnSignTransact.Name = "btnSignTransact";
            this.btnSignTransact.Size = new System.Drawing.Size(143, 35);
            this.btnSignTransact.TabIndex = 2;
            this.btnSignTransact.Text = "Sign Transaction";
            this.btnSignTransact.UseVisualStyleBackColor = true;
            this.btnSignTransact.Click += new System.EventHandler(this.btnSignTransact_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 34);
            this.label6.TabIndex = 0;
            this.label6.Text = "Send Transaction";
            // 
            // TransactionWallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "TransactionWallet";
            this.Size = new System.Drawing.Size(997, 477);
            this.Load += new System.EventHandler(this.TransactionWallet_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox txtTransData;
        private System.Windows.Forms.Button btnSignTransact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTransRecip;
        private System.Windows.Forms.TextBox txtTransValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtTransConfirm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox txtTransSender;
    }
}
