namespace Aeternum_Explorer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumBlocks = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPrevHash = new System.Windows.Forms.Label();
            this.dtgTransactions = new MetroFramework.Controls.MetroGrid();
            this.txtPendingSearch = new MetroFramework.Controls.MetroTextBox();
            this.btnRefresh = new MetroFramework.Controls.MetroButton();
            this.cbTransactions = new MetroFramework.Controls.MetroComboBox();
            this.transactionAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txSender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txRecvr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aeternum Explorer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of blocks:";
            // 
            // lblNumBlocks
            // 
            this.lblNumBlocks.AutoSize = true;
            this.lblNumBlocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumBlocks.Location = new System.Drawing.Point(181, 87);
            this.lblNumBlocks.Name = "lblNumBlocks";
            this.lblNumBlocks.Size = new System.Drawing.Size(51, 16);
            this.lblNumBlocks.TabIndex = 1;
            this.lblNumBlocks.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Previous Hash:";
            // 
            // lblPrevHash
            // 
            this.lblPrevHash.AutoSize = true;
            this.lblPrevHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrevHash.Location = new System.Drawing.Point(181, 124);
            this.lblPrevHash.Name = "lblPrevHash";
            this.lblPrevHash.Size = new System.Drawing.Size(51, 16);
            this.lblPrevHash.TabIndex = 1;
            this.lblPrevHash.Text = "label2";
            // 
            // dtgTransactions
            // 
            this.dtgTransactions.AllowUserToAddRows = false;
            this.dtgTransactions.AllowUserToDeleteRows = false;
            this.dtgTransactions.AllowUserToResizeRows = false;
            this.dtgTransactions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtgTransactions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgTransactions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transactionAddress,
            this.txSender,
            this.txRecvr,
            this.txAmount});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTransactions.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgTransactions.EnableHeadersVisualStyles = false;
            this.dtgTransactions.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dtgTransactions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtgTransactions.Location = new System.Drawing.Point(42, 222);
            this.dtgTransactions.Name = "dtgTransactions";
            this.dtgTransactions.ReadOnly = true;
            this.dtgTransactions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTransactions.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgTransactions.RowHeadersVisible = false;
            this.dtgTransactions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTransactions.Size = new System.Drawing.Size(702, 292);
            this.dtgTransactions.TabIndex = 2;
            // 
            // txtPendingSearch
            // 
            // 
            // 
            // 
            this.txtPendingSearch.CustomButton.Image = null;
            this.txtPendingSearch.CustomButton.Location = new System.Drawing.Point(162, 1);
            this.txtPendingSearch.CustomButton.Name = "";
            this.txtPendingSearch.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtPendingSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPendingSearch.CustomButton.TabIndex = 1;
            this.txtPendingSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPendingSearch.CustomButton.UseSelectable = true;
            this.txtPendingSearch.CustomButton.Visible = false;
            this.txtPendingSearch.Lines = new string[0];
            this.txtPendingSearch.Location = new System.Drawing.Point(554, 187);
            this.txtPendingSearch.MaxLength = 32767;
            this.txtPendingSearch.Name = "txtPendingSearch";
            this.txtPendingSearch.PasswordChar = '\0';
            this.txtPendingSearch.PromptText = "Search...";
            this.txtPendingSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPendingSearch.SelectedText = "";
            this.txtPendingSearch.SelectionLength = 0;
            this.txtPendingSearch.SelectionStart = 0;
            this.txtPendingSearch.ShortcutsEnabled = true;
            this.txtPendingSearch.Size = new System.Drawing.Size(190, 29);
            this.txtPendingSearch.TabIndex = 3;
            this.txtPendingSearch.UseSelectable = true;
            this.txtPendingSearch.WaterMark = "Search...";
            this.txtPendingSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPendingSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPendingSearch.TextChanged += new System.EventHandler(this.txtPendingSearch_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(11, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(69, 35);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseSelectable = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbTransactions
            // 
            this.cbTransactions.FormattingEnabled = true;
            this.cbTransactions.ItemHeight = 23;
            this.cbTransactions.Items.AddRange(new object[] {
            "Confirmed Transactions",
            "Pending Transactions"});
            this.cbTransactions.Location = new System.Drawing.Point(41, 187);
            this.cbTransactions.Name = "cbTransactions";
            this.cbTransactions.Size = new System.Drawing.Size(249, 29);
            this.cbTransactions.TabIndex = 5;
            this.cbTransactions.UseSelectable = true;
            this.cbTransactions.SelectedIndexChanged += new System.EventHandler(this.cbTransactions_SelectedIndexChanged);
            // 
            // transactionAddress
            // 
            this.transactionAddress.DataPropertyName = "address";
            this.transactionAddress.HeaderText = "Address";
            this.transactionAddress.Name = "transactionAddress";
            this.transactionAddress.ReadOnly = true;
            this.transactionAddress.Width = 200;
            // 
            // txSender
            // 
            this.txSender.DataPropertyName = "from";
            this.txSender.HeaderText = "Sender";
            this.txSender.Name = "txSender";
            this.txSender.ReadOnly = true;
            this.txSender.Width = 200;
            // 
            // txRecvr
            // 
            this.txRecvr.DataPropertyName = "to";
            this.txRecvr.HeaderText = "Receiver";
            this.txRecvr.Name = "txRecvr";
            this.txRecvr.ReadOnly = true;
            this.txRecvr.Width = 200;
            // 
            // txAmount
            // 
            this.txAmount.DataPropertyName = "value";
            this.txAmount.HeaderText = "Amount";
            this.txAmount.Name = "txAmount";
            this.txAmount.ReadOnly = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 537);
            this.Controls.Add(this.cbTransactions);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtPendingSearch);
            this.Controls.Add(this.dtgTransactions);
            this.Controls.Add(this.lblPrevHash);
            this.Controls.Add(this.lblNumBlocks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumBlocks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPrevHash;
        private MetroFramework.Controls.MetroGrid dtgTransactions;
        private MetroFramework.Controls.MetroTextBox txtPendingSearch;
        private MetroFramework.Controls.MetroButton btnRefresh;
        private MetroFramework.Controls.MetroComboBox cbTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn txSender;
        private System.Windows.Forms.DataGridViewTextBoxColumn txRecvr;
        private System.Windows.Forms.DataGridViewTextBoxColumn txAmount;
    }
}