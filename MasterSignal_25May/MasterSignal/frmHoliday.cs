using System;
using System.Drawing;
using System.Windows.Forms;

namespace MasterSignal
{
    public partial class frmHoliday : Form
    {
        DataObject db;
        Utilities util;
        public frmHoliday()
        {
            InitializeComponent();
            SetupInitial();
        }
        private void SetupInitial()
        {
            MaximizeBox = false;
            MinimizeBox = false;
            Text = Utilities.AppName;
            db = new DataObject();
            util = new Utilities();
        }
        private void FrmPaperTrade_Load(object sender, EventArgs e)
        {
            var q = dgPaperTrade;
            
            q.DataSource = db.GetHolidayAll();
            q.Columns.Remove("IsValid");
            q.Columns[0].Width = 30;
            q.Columns[1].Width = 60;
            q.Columns[2].Width = 100; 
            q.Columns[4].Width = 200;
            q.Columns[0].ReadOnly = true;
            q.Columns[5].Visible= false;
            q.AllowUserToAddRows = false;

            q.FirstDisplayedScrollingRowIndex = q.RowCount - 1;
            q.ColumnHeadersDefaultCellStyle.Font = new Font(q.Font, FontStyle.Bold);
        }

        private void DgPaperTrade_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgPaperTrade.Rows[e.RowIndex];
            string colName = dgPaperTrade.Columns[e.ColumnIndex].HeaderText.ToString();
            string strVal = dr.Cells[e.ColumnIndex].Value.ToString();
            strVal = colName == "CurPair" ? strVal.ToUpper() : strVal;
            
            //Updated to Database
            db.UpdateHD(colName, strVal, dr.Cells[0].Value.ToString());
            if (colName == "Notes") FrmPaperTrade_Load(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            util.SaveToRepository();
        }
    }
}
