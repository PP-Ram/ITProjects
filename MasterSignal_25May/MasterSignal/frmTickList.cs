using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MasterSignal
{
    public partial class frmTickList : Form
    {
        DataObject db = new DataObject();
        Utilities util = new Utilities();
        string strDate;
        public frmTickList()
        {
            InitializeComponent();
        }
        private void frmTickList_Load(object sender, EventArgs e)
        {
            SetupScreen();
            LoadTickOption();
        }

        private void SetupScreen()
        {
            this.Text = Utilities.AppName;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            strDate = DateTime.Now.ToString(Utilities.DateFormat);
            lblTickHeading.Text += strDate;
            btnSave.Enabled = false;
        }

        private void LoadTickOption()
        {
            StringBuilder sb = db.GetTickByDate(strDate, false);
            string[] tempVal = sb.ToString().Split(',');
            if (tempVal.Length > 2)
            {
                lblOne.BackColor = getColor(tempVal[1]);
                lblTwo.BackColor = getColor(tempVal[2]);
                lblThree.BackColor = getColor(tempVal[3]);
                lblFour.BackColor = getColor(tempVal[4]);
                lblFive.BackColor = getColor(tempVal[5]);
                lblSix.BackColor = getColor(tempVal[6]);

                chkOne.Checked = tempVal[1] == "True";
                chkTwo.Checked = tempVal[2] == "True";
                chkThree.Checked = tempVal[3] == "True";
                chkFour.Checked = tempVal[4] == "True";
                chkFive.Checked = tempVal[5] == "True";
                chkSix.Checked = tempVal[6] == "True";
            }
            else
            {
                chkOne.Checked = chkTwo.Checked = chkThree.Checked = chkFour.Checked = chkFive.Checked = chkSix.Checked = false;
                lblOne.BackColor = lblTwo.BackColor = lblThree.BackColor = lblFour.BackColor = lblFive.BackColor = lblSix.BackColor = Color.LightSalmon;
            }
        }

        private void frmTickList_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            string mainStr = strDate + "," + chkOne.Checked + "," + chkTwo.Checked + "," + chkThree.Checked + "," 
                            + chkFour.Checked + "," + chkFive.Checked + "," + chkSix.Checked;
            db.AddOrUpdateTick(mainStr);
        }

        private void chk_checked(object sender, EventArgs e)
        {
            chkOne_CheckedChanged(sender, e);
        }

        private void chkOne_CheckedChanged(object sender, EventArgs e)
        {
            switch (((CheckBox)sender).Name)
            {
                case "chkOne":
                    lblOne.BackColor = getColor(chkOne.Checked);
                    break;
                case "chkTwo":
                    lblTwo.BackColor = getColor(chkTwo.Checked);
                    break;
                case "chkThree":
                    lblThree.BackColor = getColor(chkThree.Checked);
                    break;
                case "chkFour":
                    lblFour.BackColor = getColor(chkFour.Checked);
                    break;
                case "chkFive":
                    lblFive.BackColor = getColor(chkFive.Checked);
                    break;
                case "chkSix":
                    lblSix.BackColor = getColor(chkSix.Checked);
                    break;
            }
            btnSave.Enabled = (chkOne.Checked && chkTwo.Checked && chkThree.Checked && chkFour.Checked && chkFive.Checked && chkSix.Checked);
        }
        private Color getColor(object opt)
        {
            return Convert.ToBoolean(opt) ? Color.LightGreen : Color.LightSalmon;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            util.SaveToRepository();
        }
    }
}
