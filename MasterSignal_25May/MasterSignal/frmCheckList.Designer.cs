namespace MasterSignal
{
    partial class frmCheckList
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
            this.radDay = new System.Windows.Forms.RadioButton();
            this.radWeek = new System.Windows.Forms.RadioButton();
            this.radMonth = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgCheckList = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCheckList)).BeginInit();
            this.SuspendLayout();
            // 
            // radDay
            // 
            this.radDay.AutoSize = true;
            this.radDay.Checked = true;
            this.radDay.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radDay.Location = new System.Drawing.Point(21, 22);
            this.radDay.Name = "radDay";
            this.radDay.Size = new System.Drawing.Size(54, 24);
            this.radDay.TabIndex = 0;
            this.radDay.TabStop = true;
            this.radDay.Text = "Day";
            this.radDay.UseVisualStyleBackColor = true;
            this.radDay.CheckedChanged += new System.EventHandler(this.radDay_CheckedChanged);
            // 
            // radWeek
            // 
            this.radWeek.AutoSize = true;
            this.radWeek.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radWeek.Location = new System.Drawing.Point(142, 22);
            this.radWeek.Name = "radWeek";
            this.radWeek.Size = new System.Drawing.Size(65, 24);
            this.radWeek.TabIndex = 1;
            this.radWeek.Text = "Week";
            this.radWeek.UseVisualStyleBackColor = true;
            this.radWeek.CheckedChanged += new System.EventHandler(this.radWeek_CheckedChanged);
            // 
            // radMonth
            // 
            this.radMonth.AutoSize = true;
            this.radMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radMonth.Location = new System.Drawing.Point(271, 22);
            this.radMonth.Name = "radMonth";
            this.radMonth.Size = new System.Drawing.Size(73, 24);
            this.radMonth.TabIndex = 2;
            this.radMonth.Text = "Month";
            this.radMonth.UseVisualStyleBackColor = true;
            this.radMonth.CheckedChanged += new System.EventHandler(this.radMonth_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radMonth);
            this.groupBox1.Controls.Add(this.radWeek);
            this.groupBox1.Controls.Add(this.radDay);
            this.groupBox1.Location = new System.Drawing.Point(217, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 65);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(343, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 30);
            this.label1.TabIndex = 14;
            this.label1.Text = "Check List";
            // 
            // dgCheckList
            // 
            this.dgCheckList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCheckList.Location = new System.Drawing.Point(72, 161);
            this.dgCheckList.Name = "dgCheckList";
            this.dgCheckList.Size = new System.Drawing.Size(728, 416);
            this.dgCheckList.TabIndex = 17;
            this.dgCheckList.Text = "dataGridView1";
            // 
            // frmCheckList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 620);
            this.Controls.Add(this.dgCheckList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCheckList";
            this.Text = "Check List";
            this.Load += new System.EventHandler(this.frmRelHistory_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCheckList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radDay;
        private System.Windows.Forms.RadioButton radWeek;
        private System.Windows.Forms.RadioButton radMonth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgCheckList;
    }
}