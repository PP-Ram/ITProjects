namespace MasterSignal
{
    partial class frmConfimDialog
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
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDHead = new System.Windows.Forms.Label();
            this.lblDPair = new System.Windows.Forms.Label();
            this.lblDTimeFrame = new System.Windows.Forms.Label();
            this.lblDAction = new System.Windows.Forms.Label();
            this.lblDPattern = new System.Windows.Forms.Label();
            this.rdoBuy = new System.Windows.Forms.RadioButton();
            this.rdoSell = new System.Windows.Forms.RadioButton();
            this.lblcp = new System.Windows.Forms.Label();
            this.lbltp = new System.Windows.Forms.Label();
            this.lblac = new System.Windows.Forms.Label();
            this.lblpa = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuy
            // 
            this.btnBuy.BackColor = System.Drawing.Color.Silver;
            this.btnBuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuy.Location = new System.Drawing.Point(35, 259);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(85, 28);
            this.btnBuy.TabIndex = 1;
            this.btnBuy.Text = "With Trend";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnSell
            // 
            this.btnSell.BackColor = System.Drawing.Color.LightGray;
            this.btnSell.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSell.Location = new System.Drawing.Point(156, 259);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(94, 28);
            this.btnSell.TabIndex = 2;
            this.btnSell.Text = "Against Trend";
            this.btnSell.UseVisualStyleBackColor = false;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(284, 259);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDHead
            // 
            this.lblDHead.AutoSize = true;
            this.lblDHead.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDHead.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDHead.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDHead.Location = new System.Drawing.Point(78, 4);
            this.lblDHead.Name = "lblDHead";
            this.lblDHead.Size = new System.Drawing.Size(111, 25);
            this.lblDHead.TabIndex = 4;
            this.lblDHead.Text = "Add Pattern";
            // 
            // lblDPair
            // 
            this.lblDPair.AutoSize = true;
            this.lblDPair.Location = new System.Drawing.Point(18, 21);
            this.lblDPair.Name = "lblDPair";
            this.lblDPair.Size = new System.Drawing.Size(81, 15);
            this.lblDPair.TabIndex = 5;
            this.lblDPair.Text = "Currency Pair:";
            // 
            // lblDTimeFrame
            // 
            this.lblDTimeFrame.AutoSize = true;
            this.lblDTimeFrame.Location = new System.Drawing.Point(18, 46);
            this.lblDTimeFrame.Name = "lblDTimeFrame";
            this.lblDTimeFrame.Size = new System.Drawing.Size(72, 15);
            this.lblDTimeFrame.TabIndex = 6;
            this.lblDTimeFrame.Text = "Time Frame:";
            // 
            // lblDAction
            // 
            this.lblDAction.AutoSize = true;
            this.lblDAction.Location = new System.Drawing.Point(18, 71);
            this.lblDAction.Name = "lblDAction";
            this.lblDAction.Size = new System.Drawing.Size(45, 15);
            this.lblDAction.TabIndex = 6;
            this.lblDAction.Text = "Action:";
            // 
            // lblDPattern
            // 
            this.lblDPattern.AutoSize = true;
            this.lblDPattern.Location = new System.Drawing.Point(18, 96);
            this.lblDPattern.Name = "lblDPattern";
            this.lblDPattern.Size = new System.Drawing.Size(48, 15);
            this.lblDPattern.TabIndex = 6;
            this.lblDPattern.Text = "Pattern:";
            // 
            // rdoBuy
            // 
            this.rdoBuy.AutoSize = true;
            this.rdoBuy.BackColor = System.Drawing.Color.LightGreen;
            this.rdoBuy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoBuy.Location = new System.Drawing.Point(128, 70);
            this.rdoBuy.Name = "rdoBuy";
            this.rdoBuy.Size = new System.Drawing.Size(46, 21);
            this.rdoBuy.TabIndex = 7;
            this.rdoBuy.TabStop = true;
            this.rdoBuy.Text = "Buy";
            this.rdoBuy.UseVisualStyleBackColor = false;
            // 
            // rdoSell
            // 
            this.rdoSell.AutoSize = true;
            this.rdoSell.BackColor = System.Drawing.Color.SandyBrown;
            this.rdoSell.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoSell.Location = new System.Drawing.Point(194, 70);
            this.rdoSell.Name = "rdoSell";
            this.rdoSell.Size = new System.Drawing.Size(46, 21);
            this.rdoSell.TabIndex = 8;
            this.rdoSell.TabStop = true;
            this.rdoSell.Text = "Sell";
            this.rdoSell.UseVisualStyleBackColor = false;
            // 
            // lblcp
            // 
            this.lblcp.AutoSize = true;
            this.lblcp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblcp.Location = new System.Drawing.Point(128, 19);
            this.lblcp.Name = "lblcp";
            this.lblcp.Size = new System.Drawing.Size(21, 17);
            this.lblcp.TabIndex = 5;
            this.lblcp.Text = "vc";
            // 
            // lbltp
            // 
            this.lbltp.AutoSize = true;
            this.lbltp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbltp.Location = new System.Drawing.Point(128, 45);
            this.lbltp.Name = "lbltp";
            this.lbltp.Size = new System.Drawing.Size(21, 17);
            this.lbltp.TabIndex = 5;
            this.lbltp.Text = "vc";
            // 
            // lblac
            // 
            this.lblac.AutoSize = true;
            this.lblac.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblac.Location = new System.Drawing.Point(128, 71);
            this.lblac.Name = "lblac";
            this.lblac.Size = new System.Drawing.Size(21, 17);
            this.lblac.TabIndex = 5;
            this.lblac.Text = "vc";
            // 
            // lblpa
            // 
            this.lblpa.AutoSize = true;
            this.lblpa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblpa.Location = new System.Drawing.Point(127, 98);
            this.lblpa.Name = "lblpa";
            this.lblpa.Size = new System.Drawing.Size(21, 17);
            this.lblpa.TabIndex = 5;
            this.lblpa.Text = "vc";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNotes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblpa);
            this.groupBox1.Controls.Add(this.lblac);
            this.groupBox1.Controls.Add(this.lbltp);
            this.groupBox1.Controls.Add(this.lblcp);
            this.groupBox1.Controls.Add(this.rdoSell);
            this.groupBox1.Controls.Add(this.rdoBuy);
            this.groupBox1.Controls.Add(this.lblDPattern);
            this.groupBox1.Controls.Add(this.lblDAction);
            this.groupBox1.Controls.Add(this.lblDTimeFrame);
            this.groupBox1.Controls.Add(this.lblDPair);
            this.groupBox1.Location = new System.Drawing.Point(32, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 217);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(124, 126);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(189, 76);
            this.txtNotes.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Notes:";
            // 
            // frmConfimDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 298);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDHead);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnBuy);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmConfimDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConfimDialog";
            this.Load += new System.EventHandler(this.frmConfimDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDHead;
        private System.Windows.Forms.Label lblDPair;
        private System.Windows.Forms.Label lblDTimeFrame;
        private System.Windows.Forms.Label lblDAction;
        private System.Windows.Forms.Label lblDPattern;
        private System.Windows.Forms.RadioButton rdoBuy;
        private System.Windows.Forms.RadioButton rdoSell;
        private System.Windows.Forms.Label lblcp;
        private System.Windows.Forms.Label lbltp;
        private System.Windows.Forms.Label lblac;
        private System.Windows.Forms.Label lblpa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label1;
    }
}