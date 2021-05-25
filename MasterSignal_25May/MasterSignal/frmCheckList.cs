using System;
using System.Drawing;
using System.Windows.Forms;

namespace MasterSignal
{
    public partial class frmCheckList : Form
    {
        public frmCheckList()
        {
            InitializeComponent();
        }
        DataObject db = new DataObject();
        private void frmRelHistory_Load(object sender, EventArgs e)
        {
            var dg = dgCheckList;
            dg.AllowUserToAddRows = false;
            dg.RowHeadersVisible = false;
            dg.ReadOnly = true;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg.RowTemplate.Resizable = DataGridViewTriState.True;
            dg.RowTemplate.MinimumHeight = 50;

            dg.Rows.Clear();
            dg.DataSource = db.GetCLList("d");
            dg.Columns[0].Width = 400;
            dg.Columns[1].Width = 100;

            foreach (DataGridViewColumn c in dg.Columns)
                c.DefaultCellStyle.Font = new Font("Arial", 16, GraphicsUnit.Pixel);
        }

        private void radWeek_CheckedChanged(object sender, EventArgs e)
        {
            dgCheckList.DataSource = db.GetCLList("w");
        }

        private void radMonth_CheckedChanged(object sender, EventArgs e)
        {
            dgCheckList.DataSource = db.GetCLList("m");
        }

        private void radDay_CheckedChanged(object sender, EventArgs e)
        {
            dgCheckList.DataSource = db.GetCLList("d");
        }
    }
}
