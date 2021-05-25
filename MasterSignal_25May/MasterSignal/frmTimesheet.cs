using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MasterSignal
{
    public partial class frmTimesheet : Form
    {
        DataObject db = new DataObject();
        Utilities util = new Utilities();
        public frmTimesheet()
        {
            InitializeComponent();
        }

        private void dg_TS_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var q = dg_Timesheet;
            if (e.RowIndex <= q.Rows.Count - 1)
            {
                string colHeader = q.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (colHeader != "")
                {
                    string rowHeader = q.Columns[e.ColumnIndex].HeaderText.ToString();
                    string val = q.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    db.UpdateTimeSheet(rowHeader, colHeader, val);
                }
            }
        }
        private void frmTimesheet_Load(object sender, System.EventArgs e)
        {
            var q = dg_Timesheet;
            lblHeading.Text += " - " + DateTime.Now.ToString("MMMM");
            int day = DateTime.Now.Day;
            q.DataSource = db.GetTimesheets();
            q.Columns[0].Visible = false;
            q.Columns[1].Width = 100;
            int colCount = q.ColumnCount;

            for (int i = 2; i <= colCount - 1; i++)
            {
                q.Columns[i].Width = 90;
                if (i - 1 > day)
                    q.Columns[i].Visible = false;
            }
            foreach (var item in getSundays())
                q.Columns[item + 1].Visible = false;

            q.Columns[1].Frozen = true;
            var q1 = q.ColumnHeadersDefaultCellStyle;
            q1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            q1.Font = new Font(q.Font, FontStyle.Bold);
            q1.BackColor = Color.LightGray;
            q.EnableHeadersVisualStyles = false;
            q.HorizontalScrollingOffset = 100 * day;
            q.AllowUserToAddRows = false;
        
            for (int i = 0; i <= q.RowCount - 1; i++)
            {
                q.Rows[i].Cells[1].Style.Font = util.getFont(10);
                q.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
                q.Rows[i].Cells[day + 1].Style.BackColor = Color.LightBlue;
            }
        }

        public static List<int> getSundays()
        {
            List<int> lstWEnds = new List<int>();
            int intMonth = DateTime.Now.Month;
            int intYear = DateTime.Now.Year;
            DateTime bMonth = new DateTime(intYear, intMonth, 1);
            for (int i = 1; i < DateTime.DaysInMonth(intYear, intMonth) + 1; i++)
            {
                DayOfWeek tVal = bMonth.AddDays(i - 1).DayOfWeek;
                if (tVal == DayOfWeek.Sunday || tVal == DayOfWeek.Saturday)
                    lstWEnds.Add(i);
            }
            return lstWEnds;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            util.SaveToRepository();
        }
    }
}
