using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MasterSignal
{
    public partial class frmChart : Form
    {
        public frmChart()
        {
            InitializeComponent();
        }
        private static readonly DataObject db = new DataObject();
        private static readonly Utilities util = new Utilities();
        private static readonly Chart c1 = new Chart();
        private void frmChart_Load(object sender, EventArgs e)
        {
            MaximizeBox = MinimizeBox = false;
            var dg = dgTradeSummery;
            dg.Font = util.getFont(10);
            dg.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dg.EnableHeadersVisualStyles = dg.AllowUserToAddRows = false;
           
            ShowReport();
            Text = Utilities.AppName;
        }
        private void ShowReport()
        {
            comLiveAccount.DataSource = db.GetLiveAccounts();
            comLiveAccount.DisplayMember = "FullValue";
            comLiveAccount.ValueMember = "ID";

            for (int i = 0; i >= -11; i--)
                comMonth.Items.Add(DateTime.Now.AddMonths(i).ToString("MMMM"));

            comMonth.SelectedIndex = 0;
            LoadGrid();
        }
        private void ShowChart()
        {
            c1.ChartAreas.Clear();
            c1.Series.Clear();
            WindowState = FormWindowState.Maximized;
            Controls.Remove(c1);
            c1.Size = new Size(750, 700);

            c1.ChartAreas.Add(new ChartArea("First"));
            c1.DataBindTable(db.GetChartData(comLiveAccount.Text, comMonth.Text, "1").DefaultView, "TradeDay");
            c1.Series[0].ChartType = SeriesChartType.RangeColumn;
           // c1.Series[0].ChartArea = "First";
            c1.Series[0].IsValueShownAsLabel = true;

            foreach (DataPoint pt in c1.Series[0].Points)
                pt.Color = (pt.YValues[0] >= 0) ? Color.Green : Color.Red;
            
            c1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            c1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            c1.ChartAreas.Add(new ChartArea("Second"));
            DataTable dt = db.GetChartData(comLiveAccount.Text, comMonth.Text, "2");
            double[] Values = new double[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                Values[i] = Convert.ToDouble(dt.Rows[i][0]);

            Series s2 = new Series();
            s2.Points.DataBindY(Values);
            s2.ChartType = SeriesChartType.Line;
            s2.ChartArea = "Second";
            c1.ChartAreas[1].AxisX.MajorGrid.LineWidth = 0;
            s2.BorderWidth = 2;

            c1.Series.Add(s2);
            Controls.Add(c1);

            c1.Left = 600;
            c1.Top = 10;
        }
        private void LoadGrid()
        {
            dgTradeSummery.CellValueChanged -= new DataGridViewCellEventHandler(dgTradeSummery_CellValueChanged_1);
            var dg = dgTradeSummery;
            dg.DataSource = db.GetLiveTradeAll(comLiveAccount.Text, comMonth.Text);
            dg.EnableHeadersVisualStyles = false;
            
            var s = dg.Columns;
            s[0].Width = 0;
            s[1].Width = 40;
            s[1].HeaderText = "Sno";
            s[3].Width = 60;
            s[4].Width = s[5].Width = 50;
            s[4].HeaderText = "Date";
            s[6].Width = 80;
            s[6].DefaultCellStyle.Alignment = s[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg.RowHeadersVisible = s[8].Visible = s[9].Visible = s[5].Visible = false;
            int i = 0;
            if (dg.Rows.Count >= 1)
            {
                for (int rn = 0; rn <= dg.Rows.Count - 1; rn++)
                {
                    DataGridViewCellCollection ss = dg.Rows[rn].Cells;
                    ss[1].Value = ++i;
                    double val = Convert.ToDouble(ss[6].Value);
                    ss[6].Style.BackColor = val == 0 ? Color.White : val > 0 ? Color.LightGreen : Color.Salmon;
                    ss[3].Style.ForeColor = ss[3].Value.ToString().ToLower() == "buy" ? Color.Green : Color.Red;
                    ss[7].ReadOnly = true;
                    ss[7].Style.Format = "N2";
                }
                dg.FirstDisplayedScrollingRowIndex = dg.RowCount - 1;
                ShowChart();
            }

            DataTable dt = db.GetLiveTradeMaster(comLiveAccount.Text, comMonth.Text);
            if (dt.Rows.Count >= 1)
            {
                lblOpen.Text = "Open Balance : " + dt.Rows[0][2];
                lblClose.Text = "Close Balance : " + dt.Rows[0][3];

                double profit = Convert.ToDouble(dt.Rows[0][3]) - Convert.ToDouble(dt.Rows[0][2]);
                lblProfit.Text = "Profit : " + Math.Round(profit, 2).ToString();
                lblProfit.ForeColor = profit <= 0 ? Color.Red : Color.Green;

                //if (dg.Rows.Count >= 1)
                //{
                //    c1.ChartAreas[1].AxisY.Minimum = Convert.ToDouble(dt.Rows[0][2]) - 1000;
                //    c1.ChartAreas[1].AxisY.Maximum = Convert.ToDouble(dt.Rows[0][3]) + 1000;
                //}
                if (dgTradeSummery.SelectedRows.Count == 1)
                    lblTradeDetail.Text = db.GetLiveTradeByID(dgTradeSummery.SelectedRows[0].Cells[0].Value.ToString());
            }
            dgTradeSummery.CellValueChanged += new DataGridViewCellEventHandler(dgTradeSummery_CellValueChanged_1);

        }
        private void btnShowReport_Click_1(object sender, EventArgs e)
        {
            dgTradeSummery.CellValueChanged -= new DataGridViewCellEventHandler(dgTradeSummery_CellValueChanged_1);
            btnAdd.Enabled = comMonth.SelectedIndex == 0;
            LoadGrid();
            dgTradeSummery.CellValueChanged += new DataGridViewCellEventHandler(dgTradeSummery_CellValueChanged_1);

        }
        private void dgTradeSummery_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            var q = dgTradeSummery;
            if (e.RowIndex <= q.Rows.Count - 1)
            {
                if (e.ColumnIndex >= 2)
                {
                    string colHeader = q.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string rowHeader = q.Columns[e.ColumnIndex].HeaderText.ToString();
                    string val = q.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    db.UpdateLiveTrade(rowHeader, colHeader, val);

                    if (e.ColumnIndex == 6)
                    {
                        double preValue = e.RowIndex == 0 ?
                             Convert.ToDouble(lblOpen.Text.Substring(15)) :
                             Convert.ToDouble(q.Rows[e.RowIndex - 1].Cells[7].Value);

                        q.Rows[e.RowIndex].Cells[7].Value = preValue + Convert.ToDouble(val);
                    }
                    if (e.ColumnIndex == 7)
                        db.UpdateCloseBalanace(val, comLiveAccount.Text, comMonth.Text);
                }
            }
        }
        private void btnAddTrade_click(object sender, EventArgs e)
        {
            grpTradeDetails.Visible = true;
            grpTradeDetails.Top = 300;
            grpTradeDetails.Left = 300;
            btnOK.Visible = true;
        }
        private string glbSelID = "0";
        private void dgTradeSummery_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            grpTradeDetails.Visible = true;
            glbSelID = dgTradeSummery.SelectedRows[0].Cells[0].Value.ToString();
            txtTradeDetail.Text = db.GetLiveTradeByID(glbSelID);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            grpTradeDetails.Visible = false;
            txtTradeDetail.Text = "";
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            string acc = comLiveAccount.Text;
            grpTradeDetails.Text = acc;
            
            dgTradeSummery.SelectionChanged -= new System.EventHandler(DgTradeSummery_SelectionChanged);
            if (glbSelID == "0")
                db.InsertLiveTrade(comLiveAccount.Text, comMonth.Text, txtTradeDetail.Text);
            else
                db.UpdateLiveTradeByID(txtTradeDetail.Text, glbSelID);
            LoadGrid();
            grpTradeDetails.Visible = false;

            dgTradeSummery.SelectionChanged +=new System.EventHandler(DgTradeSummery_SelectionChanged);
        }
        private void DgTradeSummery_SelectionChanged(object sender, EventArgs e)
        {
            if (dgTradeSummery.SelectedRows.Count == 1)
                lblTradeDetail.Text = db.GetLiveTradeByID(dgTradeSummery.SelectedRows[0].Cells[0].Value.ToString());
        }
        private void LnkShowPlan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grpTradeDetails.Visible = true;
            btnOK.Visible = false;
            string acc = comLiveAccount.Text;
            grpTradeDetails.Text = acc;
            grpTradeDetails.Top = lnkShowPlan.Top;
            grpTradeDetails.Left = lnkShowPlan.Left;
            txtTradeDetail.Text = "";
            foreach (DataRow item in db.GetTradePlan(acc.Substring(0, 1)).Rows)
            {
                txtTradeDetail.AppendText(item[0].ToString());
                txtTradeDetail.AppendText(Environment.NewLine);
            }
        }
    }
}
