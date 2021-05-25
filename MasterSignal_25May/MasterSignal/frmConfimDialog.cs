using System;
using System.Drawing;
using System.Windows.Forms;

namespace MasterSignal
{
    public partial class frmConfimDialog : Form
    {
        Utilities util = new Utilities();
        public PossibleSignal newPOS;
        DataObject db = new DataObject();

        public frmConfimDialog()
        {
            InitializeComponent();
        }

        private void frmConfimDialog_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            Text = Utilities.AppName;
            rdoBuy.Checked = true;
            displayScreen();
        }

        private void displayScreen()
        {
            lblcp.Text = newPOS.Pair.ToString();
            lbltp.Text = newPOS.TimeFrame.ToString();
            lblac.Text = newPOS.Action.ToString();
            lblac.BackColor = lblac.Text.ToLower() == "sell" ? Color.LightSalmon : Color.LightGreen;
            lblpa.Text = newPOS.Pattern.ToString();

            if (newPOS.Pattern == ChartPattern.DoubleDay || newPOS.Pattern == ChartPattern.SingleTestBar)
            {
                lblac.Visible = false;
                rdoBuy.Visible = true;
                rdoSell.Visible = true;
            }
            else
            {
                lblac.Visible = true;
                rdoBuy.Visible = false;
                rdoSell.Visible = false;
            }
            lblDHead.Text = "Add new " + newPOS.TimeFrame.ToString() + " Pattern";
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            InsertNewPos("Yes");
        }

        private void InsertNewPos(string v)
        {
            if (newPOS.Pattern == ChartPattern.DoubleDay || newPOS.Pattern == ChartPattern.SingleTestBar)
                newPOS.Action = rdoBuy.Checked == true ? ForexAction.Buy : ForexAction.Sell;
            
            newPOS.WithTrend = v;
            newPOS.Notes = txtNotes.Text;
            db.InsertPosSignal(newPOS);

            util.showMessage("Pattern added sucessfully.");

            Close();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            InsertNewPos("No");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
