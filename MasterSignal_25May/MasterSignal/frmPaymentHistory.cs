using System;
using System.Windows.Forms;

namespace MasterSignal
{
    public partial class frmPaymentHistory : Form
    {
        DataObject db;
        public frmPaymentHistory()
        {
            InitializeComponent();
        }

        private void SetupInit()
        {
            MaximizeBox = false;
            MinimizeBox = false;
            Text = Utilities.AppName;
            Top = 50;
            db = new DataObject();
            dgInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void frmPaymentHistory_Load(object sender, EventArgs e)
        {
            SetupInit();
            LoadHeader(true);
        }

        private void LoadHeader(bool isHeader)
        {
            dgInvoice.DataSource = isHeader ? db.GetPHheader() : db.GetPHheaderItem();
            int strSearchVal = isHeader ? 0 : 1;
            if (dgInvoice.Rows.Count >= 1)
            {
                dgInvoice.Rows[0].Selected = true;
                showItemGrid(dgInvoice.Rows[0].Cells[0].Value.ToString(),isHeader);
            }
            if (strSearchVal==0)
            {
                dgInvoice.Columns[0].Width = 50;
                dgInvoice.Columns[2].Width = 200;
                dgInvoice.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void showItemGrid(string selID, bool isHeader)
        {
            dgItem.DataSource = isHeader ? db.GetPHdetails(selID) : db.GetPHItemdetails(selID);
            dgItem.Columns[0].Visible = false;
            dgItem.Columns[1].Width = 200;
            dgItem.Columns[2].Width = dgItem.Columns[3].Width = 75;
            dgItem.Columns[4].DefaultCellStyle.Alignment = dgItem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
        }

        private void dgInvoice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           // int strSearchVal = !rdoInvoiceItem.Checked ? 0 : 1;
            string selID = dgInvoice.SelectedRows[0].Cells[0].Value.ToString();
            showItemGrid(selID, !rdoInvoiceItem.Checked);
        }

        private void rdoInvoiceItem_CheckedChanged(object sender, EventArgs e)
        {
            LoadHeader(!rdoInvoiceItem.Checked);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
