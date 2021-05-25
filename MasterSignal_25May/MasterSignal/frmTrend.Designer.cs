namespace MasterSignal
{
    partial class frmTrend
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
            this.lblHead = new System.Windows.Forms.Label();
            this.dgTrends = new System.Windows.Forms.DataGridView();
            this.chkBlue = new System.Windows.Forms.CheckBox();
            this.chkRed = new System.Windows.Forms.CheckBox();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnShowall = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgTrends)).BeginInit();
            this.grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHead.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblHead.Location = new System.Drawing.Point(214, 9);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(207, 28);
            this.lblHead.TabIndex = 0;
            this.lblHead.Text = "Major Currency Trend";
            // 
            // dgTrends
            // 
            this.dgTrends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTrends.Location = new System.Drawing.Point(102, 136);
            this.dgTrends.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgTrends.Name = "dgTrends";
            this.dgTrends.RowHeadersWidth = 51;
            this.dgTrends.Size = new System.Drawing.Size(443, 700);
            this.dgTrends.TabIndex = 1;
            this.dgTrends.Text = "dataGridView1";
            this.dgTrends.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTrends_CellValueChanged);
            // 
            // chkBlue
            // 
            this.chkBlue.AutoSize = true;
            this.chkBlue.ForeColor = System.Drawing.Color.Blue;
            this.chkBlue.Location = new System.Drawing.Point(24, 35);
            this.chkBlue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkBlue.Name = "chkBlue";
            this.chkBlue.Size = new System.Drawing.Size(133, 24);
            this.chkBlue.TabIndex = 2;
            this.chkBlue.Text = "Blue Live Touch";
            this.chkBlue.UseVisualStyleBackColor = true;
            this.chkBlue.Click += new System.EventHandler(this.ResetAll);
            // 
            // chkRed
            // 
            this.chkRed.AutoSize = true;
            this.chkRed.ForeColor = System.Drawing.Color.Red;
            this.chkRed.Location = new System.Drawing.Point(184, 35);
            this.chkRed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkRed.Name = "chkRed";
            this.chkRed.Size = new System.Drawing.Size(131, 24);
            this.chkRed.TabIndex = 3;
            this.chkRed.Text = "Red Line Touch";
            this.chkRed.UseVisualStyleBackColor = true;
            this.chkRed.Click += new System.EventHandler(this.ResetAll);
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnShowall);
            this.grpFilter.Controls.Add(this.chkRed);
            this.grpFilter.Controls.Add(this.chkBlue);
            this.grpFilter.Location = new System.Drawing.Point(102, 37);
            this.grpFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpFilter.Size = new System.Drawing.Size(443, 85);
            this.grpFilter.TabIndex = 6;
            this.grpFilter.TabStop = false;
            // 
            // btnShowall
            // 
            this.btnShowall.Location = new System.Drawing.Point(345, 31);
            this.btnShowall.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowall.Name = "btnShowall";
            this.btnShowall.Size = new System.Drawing.Size(86, 31);
            this.btnShowall.TabIndex = 4;
            this.btnShowall.Text = "Show All";
            this.btnShowall.UseVisualStyleBackColor = true;
            this.btnShowall.Click += new System.EventHandler(this.btnShowall_Click);
            // 
            // frmTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(678, 863);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.dgTrends);
            this.Controls.Add(this.lblHead);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTrend";
            this.Text = "frmSnipper";
            this.Load += new System.EventHandler(this.frmSnipper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTrends)).EndInit();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.DataGridView dgTrends;
        private System.Windows.Forms.CheckBox chkBlue;
        private System.Windows.Forms.CheckBox chkRed;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Button btnShowall;
    }
}