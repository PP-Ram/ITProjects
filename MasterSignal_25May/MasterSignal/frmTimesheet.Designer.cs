namespace MasterSignal
{
    partial class frmTimesheet
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
            this.dg_Timesheet = new System.Windows.Forms.DataGridView();
            this.lblHeading = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Timesheet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_Timesheet
            // 
            this.dg_Timesheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Timesheet.Location = new System.Drawing.Point(6, 24);
            this.dg_Timesheet.Margin = new System.Windows.Forms.Padding(2);
            this.dg_Timesheet.Name = "dg_Timesheet";
            this.dg_Timesheet.RowHeadersVisible = false;
            this.dg_Timesheet.RowHeadersWidth = 62;
            this.dg_Timesheet.Size = new System.Drawing.Size(1079, 293);
            this.dg_Timesheet.TabIndex = 12;
            this.dg_Timesheet.Text = "dataGridView1";
            this.dg_Timesheet.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_TS_CellValueChanged);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHeading.Location = new System.Drawing.Point(451, 18);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(119, 30);
            this.lblHeading.TabIndex = 14;
            this.lblHeading.Text = "Time Sheet";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(410, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save to DataBase";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dg_Timesheet);
            this.groupBox1.Location = new System.Drawing.Point(7, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1092, 384);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // frmTimesheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 457);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblHeading);
            this.Name = "frmTimesheet";
            this.Text = "Time sheet";
            this.Load += new System.EventHandler(this.frmTimesheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Timesheet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_Timesheet;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}