namespace MasterSignal
{
    partial class frmChart
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
            this.dgTradeSummery = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.grpSummery = new System.Windows.Forms.GroupBox();
            this.comMonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comLiveAccount = new System.Windows.Forms.ComboBox();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTradeDetail = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblProfit = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblOpen = new System.Windows.Forms.Label();
            this.grpTradeDetails = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtTradeDetail = new System.Windows.Forms.TextBox();
            this.lnkShowPlan = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgTradeSummery)).BeginInit();
            this.grpSummery.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpTradeDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgTradeSummery
            // 
            this.dgTradeSummery.AllowUserToAddRows = false;
            this.dgTradeSummery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTradeSummery.Location = new System.Drawing.Point(9, 73);
            this.dgTradeSummery.Name = "dgTradeSummery";
            this.dgTradeSummery.RowHeadersWidth = 51;
            this.dgTradeSummery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTradeSummery.Size = new System.Drawing.Size(543, 396);
            this.dgTradeSummery.TabIndex = 0;
            this.dgTradeSummery.Text = "dataGridView1";
            this.dgTradeSummery.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTradeSummery_CellValueChanged_1);
            this.dgTradeSummery.SelectionChanged += new System.EventHandler(this.DgTradeSummery_SelectionChanged);
            this.dgTradeSummery.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgTradeSummery_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(167, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trade Report and Chart";
            // 
            // grpSummery
            // 
            this.grpSummery.Controls.Add(this.lnkShowPlan);
            this.grpSummery.Controls.Add(this.comMonth);
            this.grpSummery.Controls.Add(this.label3);
            this.grpSummery.Controls.Add(this.label2);
            this.grpSummery.Controls.Add(this.comLiveAccount);
            this.grpSummery.Controls.Add(this.btnShowReport);
            this.grpSummery.Location = new System.Drawing.Point(19, 53);
            this.grpSummery.Name = "grpSummery";
            this.grpSummery.Size = new System.Drawing.Size(561, 121);
            this.grpSummery.TabIndex = 15;
            this.grpSummery.TabStop = false;
            // 
            // comMonth
            // 
            this.comMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.comMonth.FormattingEnabled = true;
            this.comMonth.Location = new System.Drawing.Point(176, 78);
            this.comMonth.Name = "comMonth";
            this.comMonth.Size = new System.Drawing.Size(130, 27);
            this.comMonth.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(38, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Month of Trade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(38, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Trade Accounts";
            // 
            // comLiveAccount
            // 
            this.comLiveAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comLiveAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.comLiveAccount.FormattingEnabled = true;
            this.comLiveAccount.Location = new System.Drawing.Point(176, 29);
            this.comLiveAccount.Name = "comLiveAccount";
            this.comLiveAccount.Size = new System.Drawing.Size(294, 27);
            this.comLiveAccount.TabIndex = 16;
            // 
            // btnShowReport
            // 
            this.btnShowReport.BackColor = System.Drawing.Color.Khaki;
            this.btnShowReport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowReport.Location = new System.Drawing.Point(340, 76);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(131, 29);
            this.btnShowReport.TabIndex = 15;
            this.btnShowReport.Text = "Display Trades";
            this.btnShowReport.UseVisualStyleBackColor = false;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTradeDetail);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lblProfit);
            this.groupBox1.Controls.Add(this.lblClose);
            this.groupBox1.Controls.Add(this.lblOpen);
            this.groupBox1.Controls.Add(this.dgTradeSummery);
            this.groupBox1.Location = new System.Drawing.Point(19, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 519);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // lblTradeDetail
            // 
            this.lblTradeDetail.AutoSize = true;
            this.lblTradeDetail.Location = new System.Drawing.Point(9, 476);
            this.lblTradeDetail.Name = "lblTradeDetail";
            this.lblTradeDetail.Size = new System.Drawing.Size(0, 15);
            this.lblTradeDetail.TabIndex = 18;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Khaki;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.Location = new System.Drawing.Point(445, 476);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 29);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add New Trade";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAddTrade_click);
            // 
            // lblProfit
            // 
            this.lblProfit.AutoSize = true;
            this.lblProfit.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProfit.Location = new System.Drawing.Point(389, 30);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(81, 20);
            this.lblProfit.TabIndex = 17;
            this.lblProfit.Text = "Profit/Loss";
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblClose.Location = new System.Drawing.Point(199, 30);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(102, 20);
            this.lblClose.TabIndex = 17;
            this.lblClose.Text = "Close Balance";
            // 
            // lblOpen
            // 
            this.lblOpen.AutoSize = true;
            this.lblOpen.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOpen.Location = new System.Drawing.Point(20, 30);
            this.lblOpen.Name = "lblOpen";
            this.lblOpen.Size = new System.Drawing.Size(103, 20);
            this.lblOpen.TabIndex = 17;
            this.lblOpen.Text = "Open Balance";
            // 
            // grpTradeDetails
            // 
            this.grpTradeDetails.Controls.Add(this.btnCancel);
            this.grpTradeDetails.Controls.Add(this.btnOK);
            this.grpTradeDetails.Controls.Add(this.txtTradeDetail);
            this.grpTradeDetails.Location = new System.Drawing.Point(603, 190);
            this.grpTradeDetails.Name = "grpTradeDetails";
            this.grpTradeDetails.Size = new System.Drawing.Size(307, 151);
            this.grpTradeDetails.TabIndex = 17;
            this.grpTradeDetails.TabStop = false;
            this.grpTradeDetails.Text = "Information About Trade";
            this.grpTradeDetails.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(249, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(199, 122);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(42, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // txtTradeDetail
            // 
            this.txtTradeDetail.Location = new System.Drawing.Point(6, 26);
            this.txtTradeDetail.Multiline = true;
            this.txtTradeDetail.Name = "txtTradeDetail";
            this.txtTradeDetail.Size = new System.Drawing.Size(295, 86);
            this.txtTradeDetail.TabIndex = 0;
            // 
            // lnkShowPlan
            // 
            this.lnkShowPlan.AutoSize = true;
            this.lnkShowPlan.Location = new System.Drawing.Point(476, 41);
            this.lnkShowPlan.Name = "lnkShowPlan";
            this.lnkShowPlan.Size = new System.Drawing.Size(62, 15);
            this.lnkShowPlan.TabIndex = 18;
            this.lnkShowPlan.TabStop = true;
            this.lnkShowPlan.Text = "Show Plan";
            this.lnkShowPlan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkShowPlan_LinkClicked);
            // 
            // frmChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 737);
            this.Controls.Add(this.grpTradeDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSummery);
            this.Controls.Add(this.label1);
            this.Name = "frmChart";
            this.Text = "frmChart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTradeSummery)).EndInit();
            this.grpSummery.ResumeLayout(false);
            this.grpSummery.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpTradeDetails.ResumeLayout(false);
            this.grpTradeDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgTradeSummery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpSummery;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.ComboBox comLiveAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblProfit;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblOpen;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpTradeDetails;
        private System.Windows.Forms.TextBox txtTradeDetail;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblTradeDetail;
        private System.Windows.Forms.LinkLabel lnkShowPlan;
    }
}