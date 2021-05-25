using System;
using System.Drawing;
using System.Windows.Forms;

namespace MasterSignal
{
    public partial class frmPayment : Form
    {
        DataObject db;
        public frmPayment()
        {
            InitializeComponent();
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            db = new DataObject();
            MaximizeBox = false;
            MinimizeBox = false;
            Text = Utilities.AppName;
            LoadCombobox();
        }

        private void LoadCombobox()
        {
            var c = cmbAccounts;
            c.SelectedIndexChanged -=
            new System.EventHandler(cmbAccounts_SelectedIndexChanged);

            c.Items.Clear();
            c.DataSource = db.GetAccCodeAll();
            c.DisplayMember = "FullValue";
            c.ValueMember = "id";
            c.SelectedIndex = 0;
            LoadDisbursements();
            c.SelectedIndexChanged +=
            new System.EventHandler(cmbAccounts_SelectedIndexChanged);
        }

        private void LoadDisbursements()
        {
            var q = dgDisbursement;
            q.DataSource = db.GetdisbursementAll(cmbAccounts.SelectedValue.ToString());

            q.AllowUserToAddRows = false;
            q.RowHeadersVisible = false;
            q.Columns[0].Width = 40;
            q.Columns[2].Width = q.Columns[1].Width = 100;
             
            foreach (DataGridViewRow dr in q.Rows)
            {
                var s = dr.Cells[3].Style;
                s.BackColor = Color.LightGray;
                s.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            double invamt = Convert.ToDouble(txtAmount.Text);
            foreach(DataGridViewRow dr in dgDisbursement.Rows)
                dr.Cells[3].Value = Convert.ToInt16(dr.Cells[2].Value) * invamt / 100;
            dgDisbursement.Columns["ActualValue"].DefaultCellStyle.Format = "N3";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Invoice newInvoice = new Invoice
            {
                AccId = cmbAccounts.SelectedValue.ToString(),
                InvoiceCode = "Inv-" + cmbAccounts.Text,
                TotalAmt = txtAmount.Text,
                InvDate = daTimeInvoice.Text.ToString()
            };
            foreach (DataGridViewRow dr in dgDisbursement.Rows)
                newInvoice.invItem.Add(Convert.ToInt32(dr.Cells[0].Value),Convert.ToString(dr.Cells[3].Value));

            db.AddInvoice(newInvoice);
            MessageBox.Show("Invoice Payment withdraw added.", Utilities.AppName);
        }

        private void cmbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDisbursements();
        }
    }
}
