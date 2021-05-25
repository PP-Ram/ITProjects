using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace MasterSignal
{
    public partial class frmTrend : Form
    {
        Utilities util = new Utilities();
        DataObject db = new DataObject();
        public frmTrend()
        {
            InitializeComponent();
        }

        private void frmSnipper_Load(object sender, System.EventArgs e)
        {
            Left = Top = 10;
            MaximizeBox = MinimizeBox = false;
            Text = Utilities.AppName; 
            dgTrends.RowHeadersVisible = false;
            dgTrends.AllowUserToAddRows = false;
            SetupGrid();
        }

        private void SetupGrid()
        {
            dgTrends.DataSource = db.GetTrendAll();
            int[] widhts = { 25, 80, 60, 60, 60, 60, 0 };
            for (int i = 0; i <= dgTrends.Columns.Count - 1; i++)
                dgTrends.Columns[i].Width = widhts[i];
            
            for (int i = 0; i <= dgTrends.Rows.Count - 1; i++)
            {
                dgTrends.Rows[i].Cells[1].Style.Font = util.getFont(11);
                for (int j = 1; j <= dgTrends.Rows[i].Cells.Count - 1; j++)
                    dgTrends.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgTrends.Rows.Count >= 1)
            {
                dgTrends.EnableHeadersVisualStyles = false;
                dgTrends.Columns[4].HeaderCell.Style.BackColor = Color.Red;
                dgTrends.Columns[5].HeaderCell.Style.BackColor = Color.Blue;
                dgTrends.Columns[0].ReadOnly = true;
                dgTrends.Columns[1].ReadOnly = true;
                dgTrends.Columns[6].Visible = false;
                dgTrends.Columns[3].Visible = false;
            }
        }
        private void dgTrends_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string colHeader = dgTrends.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (colHeader != "")
            {
                string rowHeader = dgTrends.Columns[e.ColumnIndex].HeaderText.ToString();
                string val = dgTrends.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                db.UpdateCurTrend(rowHeader, colHeader, val);
            }
        }

        private void ResetAll(object sender, System.EventArgs e)
        {
            string strQuery = "";
            if (chkBlue.Checked && chkRed.Checked)
                strQuery = " Blue = 'y' AND Red = 'y'";
            else if (chkBlue.Checked)
                strQuery = " Blue = 'y' ";
            else if (chkRed.Checked)
                strQuery = " Red = 'y' ";

            DataTable ds = db.GetTrendAll();
            ds.DefaultView.RowFilter = strQuery;
            dgTrends.DataSource = ds;
        }

        private void btnShowall_Click(object sender, System.EventArgs e)
        {
            SetupGrid();
        }
    }
}
