namespace MasterSignal
{
    partial class frmPaymentHistory
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
            this.dgInvoice = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgItem = new System.Windows.Forms.DataGridView();
            this.radInvoice = new System.Windows.Forms.RadioButton();
            this.rdoInvoiceItem = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAccNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgInvoice
            // 
            this.dgInvoice.AllowUserToAddRows = false;
            this.dgInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvoice.Location = new System.Drawing.Point(27, 47);
            this.dgInvoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgInvoice.Name = "dgInvoice";
            this.dgInvoice.ReadOnly = true;
            this.dgInvoice.RowHeadersVisible = false;
            this.dgInvoice.RowHeadersWidth = 51;
            this.dgInvoice.Size = new System.Drawing.Size(645, 316);
            this.dgInvoice.TabIndex = 17;
            this.dgInvoice.Text = "dataGridView1";
            this.dgInvoice.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgInvoice_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(290, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 37);
            this.label1.TabIndex = 14;
            this.label1.Text = "Payment History";
            // 
            // dgItem
            // 
            this.dgItem.AllowUserToAddRows = false;
            this.dgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItem.Location = new System.Drawing.Point(27, 420);
            this.dgItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgItem.Name = "dgItem";
            this.dgItem.ReadOnly = true;
            this.dgItem.RowHeadersVisible = false;
            this.dgItem.RowHeadersWidth = 51;
            this.dgItem.Size = new System.Drawing.Size(645, 340);
            this.dgItem.TabIndex = 17;
            this.dgItem.Text = "dataGridView2";
            // 
            // radInvoice
            // 
            this.radInvoice.AutoSize = true;
            this.radInvoice.Checked = true;
            this.radInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radInvoice.Location = new System.Drawing.Point(63, 29);
            this.radInvoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radInvoice.Name = "radInvoice";
            this.radInvoice.Size = new System.Drawing.Size(95, 29);
            this.radInvoice.TabIndex = 18;
            this.radInvoice.TabStop = true;
            this.radInvoice.Text = "Invoice";
            this.radInvoice.UseVisualStyleBackColor = true;
            // 
            // rdoInvoiceItem
            // 
            this.rdoInvoiceItem.AutoSize = true;
            this.rdoInvoiceItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rdoInvoiceItem.Location = new System.Drawing.Point(275, 29);
            this.rdoInvoiceItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoInvoiceItem.Name = "rdoInvoiceItem";
            this.rdoInvoiceItem.Size = new System.Drawing.Size(161, 29);
            this.rdoInvoiceItem.TabIndex = 19;
            this.rdoInvoiceItem.Text = "Payment Items";
            this.rdoInvoiceItem.UseVisualStyleBackColor = true;
            this.rdoInvoiceItem.CheckedChanged += new System.EventHandler(this.rdoInvoiceItem_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoInvoiceItem);
            this.groupBox1.Controls.Add(this.radInvoice);
            this.groupBox1.Location = new System.Drawing.Point(137, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(469, 80);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAccNo);
            this.groupBox2.Controls.Add(this.dgItem);
            this.groupBox2.Controls.Add(this.dgInvoice);
            this.groupBox2.Location = new System.Drawing.Point(41, 171);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(731, 787);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblAccNo
            // 
            this.lblAccNo.AutoSize = true;
            this.lblAccNo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAccNo.Location = new System.Drawing.Point(27, 388);
            this.lblAccNo.Name = "lblAccNo";
            this.lblAccNo.Size = new System.Drawing.Size(55, 23);
            this.lblAccNo.TabIndex = 18;
            this.lblAccNo.Text = "label2";
            // 
            // frmPaymentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 1021);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPaymentHistory";
            this.Text = "frmPaymentHistory";
            this.Load += new System.EventHandler(this.frmPaymentHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgInvoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgItem;
        private System.Windows.Forms.RadioButton radInvoice;
        private System.Windows.Forms.RadioButton rdoInvoiceItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblAccNo;
    }
}