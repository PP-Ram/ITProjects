namespace MasterSignal
{
    partial class frmTickList
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
            this.lblOne = new System.Windows.Forms.Label();
            this.lblTwo = new System.Windows.Forms.Label();
            this.lblSix = new System.Windows.Forms.Label();
            this.lblTickHeading = new System.Windows.Forms.Label();
            this.lblThree = new System.Windows.Forms.Label();
            this.grpTick = new System.Windows.Forms.GroupBox();
            this.chkSix = new System.Windows.Forms.CheckBox();
            this.chkFive = new System.Windows.Forms.CheckBox();
            this.chkFour = new System.Windows.Forms.CheckBox();
            this.chkThree = new System.Windows.Forms.CheckBox();
            this.chkTwo = new System.Windows.Forms.CheckBox();
            this.chkOne = new System.Windows.Forms.CheckBox();
            this.lblFive = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFour = new System.Windows.Forms.Label();
            this.grpTick.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOne
            // 
            this.lblOne.AutoSize = true;
            this.lblOne.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOne.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblOne.Location = new System.Drawing.Point(25, 26);
            this.lblOne.Name = "lblOne";
            this.lblOne.Size = new System.Drawing.Size(331, 25);
            this.lblOne.TabIndex = 0;
            this.lblOne.Text = "1. Did you check the Day Market Data ?";
            // 
            // lblTwo
            // 
            this.lblTwo.AutoSize = true;
            this.lblTwo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTwo.Location = new System.Drawing.Point(25, 83);
            this.lblTwo.Name = "lblTwo";
            this.lblTwo.Size = new System.Drawing.Size(382, 25);
            this.lblTwo.TabIndex = 0;
            this.lblTwo.Text = "2. Enter DD details in Trading view TextEdit ?";
            // 
            // lblSix
            // 
            this.lblSix.AutoSize = true;
            this.lblSix.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSix.Location = new System.Drawing.Point(25, 311);
            this.lblSix.Name = "lblSix";
            this.lblSix.Size = new System.Drawing.Size(276, 25);
            this.lblSix.TabIndex = 0;
            this.lblSix.Text = "6. Prepare any question to ask ?";
            // 
            // lblTickHeading
            // 
            this.lblTickHeading.AutoSize = true;
            this.lblTickHeading.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTickHeading.Location = new System.Drawing.Point(129, 12);
            this.lblTickHeading.Name = "lblTickHeading";
            this.lblTickHeading.Size = new System.Drawing.Size(127, 32);
            this.lblTickHeading.TabIndex = 0;
            this.lblTickHeading.Text = "Tick List : ";
            // 
            // lblThree
            // 
            this.lblThree.AutoSize = true;
            this.lblThree.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblThree.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblThree.Location = new System.Drawing.Point(25, 137);
            this.lblThree.Name = "lblThree";
            this.lblThree.Size = new System.Drawing.Size(243, 28);
            this.lblThree.TabIndex = 0;
            this.lblThree.Text = "3. Place the paper trade ?";
            // 
            // grpTick
            // 
            this.grpTick.Controls.Add(this.lblFour);
            this.grpTick.Controls.Add(this.chkSix);
            this.grpTick.Controls.Add(this.chkFive);
            this.grpTick.Controls.Add(this.chkFour);
            this.grpTick.Controls.Add(this.chkThree);
            this.grpTick.Controls.Add(this.chkTwo);
            this.grpTick.Controls.Add(this.chkOne);
            this.grpTick.Controls.Add(this.lblFive);
            this.grpTick.Controls.Add(this.lblThree);
            this.grpTick.Controls.Add(this.lblSix);
            this.grpTick.Controls.Add(this.lblTwo);
            this.grpTick.Controls.Add(this.lblOne);
            this.grpTick.Location = new System.Drawing.Point(29, 55);
            this.grpTick.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTick.Name = "grpTick";
            this.grpTick.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTick.Size = new System.Drawing.Size(503, 376);
            this.grpTick.TabIndex = 1;
            this.grpTick.TabStop = false;
            // 
            // chkSix
            // 
            this.chkSix.AutoSize = true;
            this.chkSix.Location = new System.Drawing.Point(453, 318);
            this.chkSix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSix.Name = "chkSix";
            this.chkSix.Size = new System.Drawing.Size(18, 17);
            this.chkSix.TabIndex = 1;
            this.chkSix.UseVisualStyleBackColor = true;
            this.chkSix.CheckedChanged += new System.EventHandler(this.chk_checked);
            // 
            // chkFive
            // 
            this.chkFive.AutoSize = true;
            this.chkFive.Location = new System.Drawing.Point(453, 261);
            this.chkFive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkFive.Name = "chkFive";
            this.chkFive.Size = new System.Drawing.Size(18, 17);
            this.chkFive.TabIndex = 1;
            this.chkFive.UseVisualStyleBackColor = true;
            this.chkFive.CheckedChanged += new System.EventHandler(this.chk_checked);
            // 
            // chkFour
            // 
            this.chkFour.AutoSize = true;
            this.chkFour.Location = new System.Drawing.Point(453, 204);
            this.chkFour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkFour.Name = "chkFour";
            this.chkFour.Size = new System.Drawing.Size(18, 17);
            this.chkFour.TabIndex = 1;
            this.chkFour.UseVisualStyleBackColor = true;
            this.chkFour.CheckedChanged += new System.EventHandler(this.chk_checked);
            // 
            // chkThree
            // 
            this.chkThree.AutoSize = true;
            this.chkThree.Location = new System.Drawing.Point(453, 147);
            this.chkThree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkThree.Name = "chkThree";
            this.chkThree.Size = new System.Drawing.Size(18, 17);
            this.chkThree.TabIndex = 1;
            this.chkThree.UseVisualStyleBackColor = true;
            this.chkThree.CheckedChanged += new System.EventHandler(this.chk_checked);
            // 
            // chkTwo
            // 
            this.chkTwo.AutoSize = true;
            this.chkTwo.Location = new System.Drawing.Point(453, 90);
            this.chkTwo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkTwo.Name = "chkTwo";
            this.chkTwo.Size = new System.Drawing.Size(18, 17);
            this.chkTwo.TabIndex = 1;
            this.chkTwo.UseVisualStyleBackColor = true;
            this.chkTwo.CheckedChanged += new System.EventHandler(this.chk_checked);
            // 
            // chkOne
            // 
            this.chkOne.AutoSize = true;
            this.chkOne.Location = new System.Drawing.Point(453, 33);
            this.chkOne.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkOne.Name = "chkOne";
            this.chkOne.Size = new System.Drawing.Size(18, 17);
            this.chkOne.TabIndex = 1;
            this.chkOne.UseVisualStyleBackColor = true;
            this.chkOne.CheckedChanged += new System.EventHandler(this.chkOne_CheckedChanged);
            // 
            // lblFive
            // 
            this.lblFive.AutoSize = true;
            this.lblFive.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFive.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblFive.Location = new System.Drawing.Point(25, 254);
            this.lblFive.Name = "lblFive";
            this.lblFive.Size = new System.Drawing.Size(196, 25);
            this.lblFive.TabIndex = 0;
            this.lblFive.Text = "5. Fill the Time sheet ?";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(149, 439);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(229, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save to DataBase";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFour
            // 
            this.lblFour.AutoSize = true;
            this.lblFour.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFour.Location = new System.Drawing.Point(25, 197);
            this.lblFour.Name = "lblFour";
            this.lblFour.Size = new System.Drawing.Size(348, 25);
            this.lblFour.TabIndex = 0;
            this.lblFour.Text = "4. Send the message, What is live trade ?";
            // 
            // frmTickList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 484);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpTick);
            this.Controls.Add(this.lblTickHeading);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTickList";
            this.Text = "frmTickList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTickList_FormClosed_1);
            this.Load += new System.EventHandler(this.frmTickList_Load);
            this.CursorChanged += new System.EventHandler(this.chk_checked);
            this.grpTick.ResumeLayout(false);
            this.grpTick.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOne;
        private System.Windows.Forms.Label lblTwo;
        private System.Windows.Forms.Label lblSix;
        private System.Windows.Forms.Label lblTickHeading;
        private System.Windows.Forms.Label lblThree;
        private System.Windows.Forms.GroupBox grpTick;
        private System.Windows.Forms.Label lblFive;
        private System.Windows.Forms.CheckBox chkSix;
        private System.Windows.Forms.CheckBox chkFive;
        private System.Windows.Forms.CheckBox chkFour;
        private System.Windows.Forms.CheckBox chkThree;
        private System.Windows.Forms.CheckBox chkTwo;
        private System.Windows.Forms.CheckBox chkOne;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFour;
    }
}