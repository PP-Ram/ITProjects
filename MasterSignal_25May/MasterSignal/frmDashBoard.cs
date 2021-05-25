using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MasterSignal
{
    public partial class frmDashBoard : Form
    {
        public Login loginDetail;
        private Utilities util;
        private DataObject db;
        private List<PossibleSignal> posSignal;
        private bool IsNFPToday;
        public frmDashBoard()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeObjects();
            GetLoginDetails();
            ResetForm();
            LoadListHeader();
            LoadDashBoard();
            SetNFPandQuote();
            SetSingleTB();
            LoadRBcross(true);
        }
        private void LoadRBcross(bool RBcross)
        {
            ListViewItem lv1;
            lstDayTrend.Items.Clear();
            foreach (DayTendPair dt in db.GetTrendCross(RBcross))
            {
                lv1 = new ListViewItem(dt.Pair);
                var s = lv1.SubItems;
                s.Add(dt.Blue);
                s.Add(dt.Red);
                lv1.BackColor = (dt.Trend.ToLower() == "down" ? Color.LightSalmon : Color.LightGreen);
                lstDayTrend.Items.Add(lv1);
            }
        }
        private void SetSingleTB()
        {
            DataTable dt = db.GetSingleBar();
            ListViewItem lv1;
            lstSingleBar.Items.Clear();
            for (int rcount = 0; rcount < dt.Rows.Count; rcount++)
            {
                DataRow dr = dt.Rows[rcount];
                int totLen = dr.ItemArray.Length - 3;
                string flag = dr.ItemArray[totLen].ToString().Remove(0, 3);
                int chkValue = (flag == "Week") ? 40 : 15;
                for (int ia = 2; ia < totLen; ia++)
                {
                    if (Math.Abs(Convert.ToInt32(dr.ItemArray[ia])) <= chkValue)
                    {
                        lv1 = new ListViewItem(dt.Columns[ia].ColumnName);
                        lv1.SubItems.Add(flag);
                        lstSingleBar.Items.Add(lv1);
                    }
                }
            }
            lblsingleBar.Text = "Single Test Bar (" + lstSingleBar.Items.Count.ToString() + ")";
        }
        private void InitializeObjects()
        {
            util = new Utilities();
            db = new DataObject();
            posSignal = new List<PossibleSignal>();
            IsNFPToday = false;
            label12.Text += " - " + DateTime.Now.ToString("MMMM");
        }
        private void SetNFPandQuote()
        {
            if (db.IsNFPToday())
            {
                IsNFPToday = true;
                lbl_HighNewslist.Text += " NFP NEWS TODAY - Check USD Trades";
            }

            grp_quote.Top = grp_Signal.Top + grp_Signal.Height + 10;
            grp_quote.Left = 100;
            lbl_quote.Text = db.GetQuoteByID();
            if (lbl_quote.Text.Length >= 75)
            {
                lbl_quote.Font = util.getFont(14);
            }

            LoadTodayNews(ENewsPriority.HIGH);
            LoadSeasonal();
        }
        private void SetupAppforUserRole()
        {
            if (loginDetail.RoleType == RoleType.Customer)
            {
                dg_pattern.Enabled = false;
                mi_addTrade.Enabled = false;
                lnk_MarketData.Enabled = false;
                lnkTick.Visible = false;
            }
        }
        private void LoadSeasonal()
        {
            foreach (SeasonalData sData in db.GetSeasonalDataAll())
            {
                ListViewItem lv1 = new ListViewItem(sData.Pair);
                var s = lv1.SubItems;
                s.Add(sData.CurMonth);
                s.Add(sData.NextMonth);
                s[0].Font = util.getFont(13);
                s[1].BackColor = GetColor(sData.CurMonth);
                s[2].BackColor = GetColor(sData.NextMonth);
                lv1.UseItemStyleForSubItems = false;
                lstSeasonal.Items.Add(lv1);
            }
            lstSeasonal.Columns[1].TextAlign = lstSeasonal.Columns[2].TextAlign = HorizontalAlignment.Center;
        }
        private Color GetColor(string value)
        {
            return (Convert.ToInt32(value) >= 0 ? Color.LightGreen : Color.LightSalmon);
        }
        private void LoadTodayNews(ENewsPriority priority)
        {
            lstNews.Items.Clear();
            ListViewItem lv1;
            List<EconomicNews> lstEc = db.GetENewsByToday();

            foreach (EconomicNews tempNews in lstEc)
            {
                if (tempNews.Priority == priority.ToString() || priority == ENewsPriority.ALL)
                {
                    lv1 = new ListViewItem(tempNews.NewsDate.Substring(11, 5));
                    lv1.SubItems.Add(tempNews.Priority);
                    lv1.SubItems.Add(tempNews.Country);
                    lv1.SubItems.Add(tempNews.ShortDetails);
                    lstNews.Items.Add(lv1);
                    lv1.ForeColor = tempNews.Priority == "HIGH" ? Color.Red : Color.Black;
                }
            }
            lblNewsCount.Text = "High: " + lstEc.FindAll(t => t.Priority == ENewsPriority.HIGH.ToString()).Count.ToString()
                                + "  Medium: " + lstEc.FindAll(t => t.Priority == ENewsPriority.MEDIUM.ToString()).Count.ToString();
        }
        private void LoadAllNewsFilter(ENewsPriority priority)
        {
            lstAllNews.Items.Clear();
            foreach (EconomicNews tempNews in db.GetENewsAll(priority))
            {
                ListViewItem lv1;
                lv1 = new ListViewItem(tempNews.NewsDate.Substring(3, 2) + " - " + tempNews.NewsDate.Substring(11, 5));
                lv1.SubItems.Add(tempNews.Priority);
                lv1.SubItems.Add(tempNews.Country);
                lv1.SubItems.Add(tempNews.ShortDetails);

                lstAllNews.Items.Add(lv1);
                if (tempNews.NewsDate.Substring(3, 2) == DateTime.Now.ToString("dd"))
                {
                    lv1.BackColor = Color.LightBlue;
                    lstAllNews.TopItem = lv1;
                }
                lv1.ForeColor = tempNews.Priority == "HIGH" ? Color.Red : Color.Black;
            }
        }
        private void GetLoginDetails()
        {
            lblName.Text = "Name: " + loginDetail.DisplayName + " (" + loginDetail.RoleType.ToString().Substring(0, 1) + ")     Date: " + DateTime.Now.ToString("dd/MMM/yyyy");
            timeUK.Interval = 1000;
            timeUK.Start();

            SetupAppforUserRole();
            posSignal = db.GetPossibleSiganlAll();
        }
        private void LoadDashBoard()
        {
            FillList(lstWeek, getActivePS(TimeFrame.Week));
            FillList(lstDay, getActivePS(TimeFrame.Day));
        }
        private void FillList(ListView lstView, List<PossibleSignal> lstPS)
        {
            lstView.Items.Clear();
            foreach (PossibleSignal tps in lstPS)
            {
                ListViewItem lv1 = new ListViewItem(tps.ID.ToString()); //ID
                var s = lv1.SubItems;
                s.Add(tps.cDate);                    //Date
                s.Add(tps.Pair);                     //pair
                s.Add(tps.Pattern.ToString());       //pattern
                s.Add(tps.WithTrend);                //Trend
                s.Add((tps.IsActive == "1") ? "Active" : "Previous"); //status
                lv1.BackColor = util.getColor(tps.Action);      //Color
                lv1.ToolTipText = tps.Notes;                     //Notes
                lstView.Items.Add(lv1);
            }
            lstView.ShowItemToolTips = true;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            posSignal = db.GetPossibleSiganlAll();
            LoadDashBoard();
        }
        private void ResetForm()
        {
            pic_education.Visible = false;
            pic_education.Width = 700;
            pic_education.Height = 600;
            pic_education.Top = 70;
            pic_education.Left = 100;

            dg_majorData.Top = 60;
            dg_majorData.Width = 1220;
            dg_majorData.Height = 300;

            dg_summeryData.Top = dg_pattern.Top = 400;
            dg_summeryData.Left = lblSummary.Left = 30;
            dg_summeryData.Width = 460;
            dg_summeryData.Height = dg_pattern.Height = 230;

            lblSummary.Top = lblPatternGrid.Top = 370;
            lblSummary.BackColor = lblPatternGrid.BackColor = btn_SaveCalculate.BackColor;
            dg_summeryData.AllowUserToAddRows = dg_summeryData.RowHeadersVisible = grp_grid.Visible = grp_Youtube.Visible = false;

            dg_pattern.Left = lblPatternGrid.Left = 650;
            dg_pattern.Width = 600;
            lblPatternGrid.Text = "Pattern";

            grp_grid.Left = 30;
            grp_grid.Top = 70;
            grp_grid.Width = 1300;
            grp_grid.Height = 1200;

            dg_pattern.Font = label2.Font;
            dg_pattern.RowTemplate.Height = 50;

            btn_SaveCalculate.Top = 450;
            btn_SaveCalculate.Left = 510;
            rad_MinDay.Left += 500;
            rad_MinWeek.Left += 500;

            lblGeneral.Left += 100;
            lblGeneral.Text = "Major Day Movements";
            btn_SaveCalculate.Text = "Show Pattern";

            rad_MinDay.Top = rad_MinWeek.Top;

            pic_logo.SizeMode = pic_youTube.SizeMode = pic_finnews.SizeMode = PictureBoxSizeMode.Zoom;
            pic_logo.Image = util.getPicture(TradePicture.SFA_Logo);
            pic_youTube.Image = util.getPicture(TradePicture.Youtube);
            pic_finnews.Image = util.getPicture(TradePicture.FinNews);
            pic_CL.Image = util.getPicture(TradePicture.CL);
            pic_TimeSheet.Image = util.getPicture(TradePicture.Clock);
            pic_Refresh.Image = util.getPicture(TradePicture.Refresh);

            grp_news.Top = 80;
            grp_news.Left = 100;
            grp_Signal.Top = grp_Youtube.Top = grpSeasonal.Top = grp_news.Top;
            grp_Signal.Left = grp_Youtube.Left = grp_news.Left;

            grpLink.Top = grpSeasonal.Top + grpSeasonal.Height;
            grpLink.Left = grpSeasonal.Left;
            grp_quote.Width = grp_Signal.Width;

            ToolTip tTip = new ToolTip();
            tTip.SetToolTip(lblHeading, "Click here to go DashBoard Page.");
            tTip.SetToolTip(pic_logo, "Click here to view Day/Week Date.");
            tTip.SetToolTip(pic_youTube, "Click here to view YouTube Trading Video.");
            tTip.SetToolTip(pic_finnews, "Click here to view Financial news.");
            tTip.SetToolTip(lbl_youtubeHeader, "Double Click the link to open YouTube video.");
            tTip.SetToolTip(pic_CL, "Click the check List will show.");
            tTip.SetToolTip(pic_Refresh, "Click here to Refresh Dashboard.");
            tTip.SetToolTip(pic_TimeSheet, "Click here to enter the IN/OUT time.");

            lblHeading.Cursor = pic_CL.Cursor = pic_logo.Cursor = pic_youTube.Cursor = pic_finnews.Cursor = Cursors.Hand;

            lbl_HighNewslist.Text = DateTime.Now.ToString("dd-MMM") + " " + lbl_HighNewslist.Text;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            Text = Utilities.AppName;
            lnkTick.Left = btn_SaveCalculate.Left;
            lnkTick.Top = btn_SaveCalculate.Top + 150;
        }
        private void SetupView()
        {
            grp_Signal.Visible = false;
            grp_news.Visible = false;
            pic_education.Visible = false;
            grp_grid.Visible = false;
            grpLink.Visible = true;
            grp_quote.Visible = true;
            grpSeasonal.Visible = true;
            grp_Youtube.Visible = false;
            pic_education.SizeMode = PictureBoxSizeMode.StretchImage;
            grpLink.Visible = false;
        }
        private void ForexOptionItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickName = e.ClickedItem.Name.ToLower();
            SetupView();
            switch (clickName)
            {
                case "mi_signal":
                    grp_Signal.Visible = true;
                    LoadDashBoard();
                    break;
                case "mi_major":
                case "mi_signal1":
                    Pic_logo_Click(sender, e);
                    break;
                case "mi_news":
                    grp_news.Visible = true;
                    grp_news.BringToFront();
                    LoadAllNewsFilter(ENewsPriority.ALL);
                    break;
                case "mi_exit":
                    ExitApp();
                    break;
                case "mi_bar":
                    pic_education.Visible = true;
                    pic_education.Image = util.getPicture(TradePicture.Bars);
                    break;
                case "mi_pattern":
                    pic_education.Visible = true;
                    pic_education.Image = util.getPicture(TradePicture.Pattern);
                    break;
                case "mi_flowchart":
                    pic_education.Visible = true;
                    pic_education.Image = util.getPicture(TradePicture.TradingFlowChart);
                    break;
                case "mi_nfpdate":
                    pic_education.Visible = true;
                    pic_education.Image = util.getPicture(TradePicture.NFPDates_2021);
                    break;
                case "mi_meeting":
                    pic_education.Visible = true;
                    pic_education.Image = util.getPicture(TradePicture.MeetingDetails);
                    break;
                case "mi_about":
                    pic_education.Visible = true;
                    pic_education.Image = util.getPicture(TradePicture.LogoDetail);
                    break;
                case "mi_breakout":
                    pic_education.Visible = true;
                    pic_education.Image = util.getPicture(TradePicture.BreakOut);
                    break;
                case "mi_seasonal":
                    pic_education.Visible = true;
                    pic_education.Image = util.getPicture(TradePicture.Seasonal);
                    break;
                    
                case "mi_holiday":
                    grp_Signal.Visible = true;
                    frmHoliday frm = new frmHoliday();
                    frm.ShowDialog();
                    break;
                case "mi_trend":
                    grp_Signal.Visible = true;
                    frmTrend frm1 = new frmTrend();
                    frm1.ShowDialog();
                    break;
                case "mi_paysumreport":
                    grp_Signal.Visible = true;
                    frmChart frm2 = new frmChart();
                    frm2.ShowDialog();
                    break;
                case "mi_withdraw":
                    grp_Signal.Visible = true;
                    frmPayment frm3 = new frmPayment();
                    frm3.ShowDialog();
                    break;
                case "mi_payhistory":
                    grp_Signal.Visible = true;
                    frmPaymentHistory frm4 = new frmPaymentHistory();
                    frm4.ShowDialog();
                    break;
                case "mi_conpat":
                    pic_education.Visible = true;
                    pic_education.Image = util.getPicture(TradePicture.Con_pattern);
                    break;
                case "mi_revpat":
                    pic_education.Visible = true;
                    pic_education.Image = util.getPicture(TradePicture.Rev_pattern);
                    break;
                case "mi_mionr":
                    break;
                case "mi_tradingvideo":
                    grp_Youtube.Visible = true;
                    LoadYoutubeVideos(VideoType.All);
                    break;
                case "mi_tradref":
                    grpLink.Visible = true;
                    grpLink.Top = 150;
                    grpLink.Left = 150;
                    break;
                case "mi_tradingtarget":
                    pic_education.Visible = true;
                    pic_education.Image = util.getPicture(TradePicture.TradeGoal01);
                    break;
            }
        }
        private void ExitApp()
        {
            if (util.showQuestion("Are you sure, you want to exit the APP without saving?") == DialogResult.OK)
                Application.Exit();
        }
        private void LoadYoutubeVideos(VideoType type)
        {
            lst_youtube.Items.Clear();
            ListViewItem lv1;
            foreach (Website ts in db.GetWSYoutubeAll(type))
            {
                lv1 = new ListViewItem(ts.Type);
                lv1.SubItems.Add(ts.Title);
                lv1.SubItems.Add(ts.Link);
                lv1.ForeColor = ts.Type =="Motivational" ? Color.DarkBlue : ts.Type == "Psychology" ? Color.Coral : Color.DarkGreen ;
                lst_youtube.Items.Add(lv1);
            }
        }
        private void SetupMarketDate()
        {
            grp_quote.Visible = false;
            grp_grid.Visible = true;
            grpSeasonal.Visible = false;
            grpLink.Visible = false;
            dg_majorData.RowHeadersVisible = false;
            rdo_DayData.Checked = true;
            SetColorandLabel(MarketData.MajDay);
        }
        private void LoadMarketDataDB(MarketData md)
        {
            var q = dg_majorData;
            q.DataSource = db.GetMarketData(md);
            q.Columns.Remove("ID");
            q.Columns.Remove("TimeType");
            q.Columns.Remove("IsActive");
            q.Columns.Remove("CreatedBy");
            q.Columns[0].ReadOnly = true;
            q.AllowUserToAddRows = false;

            q.Columns[0].Width = 65;
            for (int i = 1; i <= 20; i++)
                q.Columns[i].Width = 56;
            q.FirstDisplayedScrollingRowIndex = q.RowCount - 1;
        }
        private void SetPatterColHeader(int rowid, string txt, ChartPattern tooltxt)
        {
            var s = dg_pattern.Rows[rowid].Cells[0];
            s.Value = txt;
            s.ToolTipText = tooltxt.ToString();
        }
        private void IdentifyPattern()
        {
            var p = dg_pattern;
            var q = dg_majorData;
            DataTable result = new DataTable();
            for (int i = 0; i <= 5; i++)
            {
                if (i <= 3) result.Rows.Add();
                result.Columns.Add();
            }
            p.DataSource = result;
            SetPatterColHeader(0, "TT", ChartPattern.TrainTrack);
            SetPatterColHeader(1, "DD", ChartPattern.DoubleDay);
            SetPatterColHeader(2, "CBR", ChartPattern.ContinousBar);
            SetPatterColHeader(3, "S3", ChartPattern.Stack3);
            for (int i = 1; i <= 4; i++)
                p.Columns[i].Width = 103;

            int TotalRowCount = q.Rows.Count;
            int lastRow = TotalRowCount - 1;
            int PreviousRow = lastRow - 1;
            int col = 1;
            //TT

            for (int colCount = 1; colCount <= 20; colCount++)
            {
                int lastValue = Convert.ToInt32(q.Rows[lastRow].Cells[colCount].Value);
                int previousValue = Convert.ToInt32(q.Rows[PreviousRow].Cells[colCount].Value);
                if ((lastValue > 0 && previousValue < 0) || (lastValue < 0 && previousValue > 0))
                {
                    if ((Math.Abs(lastValue) > Math.Abs(previousValue) * 0.90) &&
                        (Math.Abs(lastValue) < Math.Abs(previousValue) * 1.10))
                    {
                        p.Rows[0].Cells[col].Value = q.Columns[colCount].HeaderText;
                        p.Rows[0].Cells[col].Style.BackColor = (lastValue < previousValue) ? Color.OrangeRed : Color.LightGreen;
                        col++;
                    }
                }
                if (col == 6) { break; }
            }

            //Double DD
            col = 1;
            for (int colCount = 1; colCount <= 20; colCount++)
            {
                int lastValue = Convert.ToInt32(q.Rows[lastRow].Cells[colCount].Value);
                int previousValue = Convert.ToInt32(q.Rows[PreviousRow].Cells[colCount].Value);
                if ((Math.Abs(lastValue) < 15 && Math.Abs(previousValue) < 15))
                {
                    p.Rows[1].Cells[col].Value = q.Columns[colCount].HeaderText;
                    col++;
                }
                if (col == 6) { break; }
            }

            //CB continues bar
            col = 1;
            if (rdo_DayData.Checked == true || rad_MinDay.Checked == true)
            {
                if (TotalRowCount >= 7)
                {
                    for (int colCount = 1; colCount <= 20; colCount++)
                    {
                        int val1 = Convert.ToInt32(q.Rows[lastRow - 1].Cells[colCount].Value);
                        int val2 = Convert.ToInt32(q.Rows[lastRow - 2].Cells[colCount].Value);
                        int val3 = Convert.ToInt32(q.Rows[lastRow - 3].Cells[colCount].Value);
                        int val4 = Convert.ToInt32(q.Rows[lastRow - 4].Cells[colCount].Value);
                        int val5 = Convert.ToInt32(q.Rows[lastRow - 5].Cells[colCount].Value);
                        int val6 = Convert.ToInt32(q.Rows[lastRow - 6].Cells[colCount].Value);
                        int CheckValue = Convert.ToInt32(q.Rows[lastRow].Cells[colCount].Value);
                        int cbCount = 5;
                        if ((val1 >= 0 && val2 >= 0 && val3 >= 0 && val4 >= 0 && val5 >= 0 && val6 >= 0) ||
                            (val1 <= 0 && val2 <= 0 && val3 <= 0 && val4 <= 0 && val5 <= 0 && val6 <= 0))
                        {
                            for (int i = 6; i <= lastRow; i++)
                            {
                                if ((val1 >= 0 && val2 > 0) && Convert.ToInt32(q.Rows[lastRow - i].Cells[colCount].Value) > 0)
                                {
                                    cbCount++;
                                }
                                else { break; }
                            }

                            for (int i = 6; i <= lastRow; i++)
                            {
                                if ((val1 <= 0 && val2 < 0) && Convert.ToInt32(q.Rows[lastRow - i].Cells[colCount].Value) < 0)
                                {
                                    cbCount++;
                                }
                                else { break; }
                            }
                            if ((val1 > 0 && CheckValue < 0) || (val1 < 0 && CheckValue > 0))
                            {
                                p.Rows[2].Cells[col].Value = q.Columns[colCount].HeaderText + "(" + cbCount + ")";
                                p.Rows[2].Cells[col].Style.BackColor = (val1 >= 0 && val2 > 0) ? Color.OrangeRed : Color.LightGreen;
                                col++;
                            }
                        }
                        if (col == 6) { break; }
                    }
                }
            }
            else
            {
                if (TotalRowCount >= 5)
                {
                    for (int colCount = 1; colCount <= 20; colCount++)
                    {
                        int val1 = Convert.ToInt32(q.Rows[lastRow - 1].Cells[colCount].Value);
                        int val2 = Convert.ToInt32(q.Rows[lastRow - 2].Cells[colCount].Value);
                        int val3 = Convert.ToInt32(q.Rows[lastRow - 3].Cells[colCount].Value);
                        int val4 = Convert.ToInt32(q.Rows[lastRow - 4].Cells[colCount].Value);
                        int CheckValue = Convert.ToInt32(q.Rows[lastRow].Cells[colCount].Value);
                        int cbCount = 3;
                        if ((val1 >= 0 && val2 >= 0 && val3 >= 0 && val4 >= 0) ||
                            (val1 <= 0 && val2 <= 0 && val3 <= 0 && val4 <= 0))
                        {
                            for (int i = 4; i <= lastRow; i++)
                            {
                                if ((val1 >= 0 && val2 > 0) && Convert.ToInt32(q.Rows[lastRow - i].Cells[colCount].Value) > 0)
                                {
                                    cbCount++;
                                }
                                else { break; }
                            }

                            for (int i = 4; i <= lastRow; i++)
                            {
                                if ((val1 <= 0 && val2 < 0) && Convert.ToInt32(q.Rows[lastRow - i].Cells[colCount].Value) < 0)
                                {
                                    cbCount++;
                                }
                                else { break; }
                            }
                            if ((val1 > 0 && CheckValue < 0) || (val1 < 0 && CheckValue > 0))
                            {
                                p.Rows[2].Cells[col].Value = dg_majorData.Columns[colCount].HeaderText + "(" + cbCount + ")";
                                p.Rows[2].Cells[col].Style.BackColor = (val1 >= 0 && val2 > 0) ? Color.OrangeRed : Color.LightGreen;
                                col++;
                            }
                        }
                        if (col == 6) { break; }
                    }
                }
            }

            //S3
            col = 1;
            if (TotalRowCount >= 4)
            {
                for (int colCount = 1; colCount <= 20; colCount++)
                {
                    int val1 = Convert.ToInt32(q.Rows[lastRow].Cells[colCount].Value);
                    int val2 = Convert.ToInt32(q.Rows[lastRow - 1].Cells[colCount].Value);
                    int val3 = Convert.ToInt32(q.Rows[lastRow - 2].Cells[colCount].Value);
                    int valMain = Convert.ToInt32(q.Rows[lastRow - 3].Cells[colCount].Value);
                    int valMain2 = 0;
                    if (TotalRowCount >= 6)
                    {
                        valMain2 = Convert.ToInt32(q.Rows[lastRow - 4].Cells[colCount].Value);
                    }

                    if ((valMain > 0 && (val1 <= 0 && val2 <= 0 && val3 <= 0)) ||
                         (valMain < 0 && (val1 >= 0 && val2 >= 0 && val3 >= 0)))
                    {
                        q.Rows[lastRow].Cells[colCount].Style.Font = util.getFont(10);
                        q.Rows[lastRow - 1].Cells[colCount].Style.Font = util.getFont(10);
                        q.Rows[lastRow - 2].Cells[colCount].Style.Font = util.getFont(10);
                        q.Rows[lastRow - 3].Cells[colCount].Style.Font = util.getFont(10);

                        q.Columns[colCount].HeaderCell.Style.Font = util.getFont(9);
                        q.Columns[colCount].HeaderCell.ToolTipText = "Check chart Possible S3";

                        int aval1 = Math.Abs(val1);
                        int aval2 = Math.Abs(val2);
                        int aval3 = Math.Abs(val3);
                        int avalMain = Math.Abs(valMain);
                        int avalMain2 = Math.Abs(valMain2);

                        if ((avalMain < (aval1 + aval2 + aval3 + (avalMain / 10)) && avalMain > (aval1 + aval2 + aval3 - (avalMain / 10)))
                            || (((valMain > 0 && valMain2 > 0) || (valMain < 0 && valMain2 < 0)) &&
                                (avalMain + avalMain2) < (aval1 + aval2 + aval3 + (avalMain / 10)) && (avalMain + avalMain2) > (aval1 + aval2 + aval3 - (avalMain / 10))))
                        {
                            p.Rows[3].Cells[col].Value = q.Columns[colCount].HeaderText;
                            p.Rows[3].Cells[col].Style.BackColor = (valMain < 0) ? Color.OrangeRed : Color.LightGreen;
                            col++;
                        }
                    }
                    if (col == 6) { break; }
                }
            }
            for (int i = 0; i <= dg_pattern.RowCount - 1; i++)
            {
                p.Rows[i].Cells[0].Style.Font = util.getFont(17);
                p.Rows[i].Cells[0].Style.BackColor = Color.LightGray;
            }
            p.Columns[0].Width = 70;
            p.ReadOnly = true;
        }
        private void CalculateSummeryTableMinor()
        {
            DataTable dt = new DataTable();
            var s = dg_summeryData;
            dt.Columns.Add("Date");
            dt.Columns.Add("CHF");
            dt.Columns.Add("SGD");
            dt.Columns.Add("SPX");
            dt.Columns.Add("WTI");
            dt.Columns.Add("GLD");
            s.ReadOnly = true;

            for (int row = 0; row < dg_majorData.Rows.Count; row++)
            {
                DataGridViewRow dvRow = dg_majorData.Rows[row];
                string headerText = dvRow.Cells[0].Value.ToString();
                if (headerText != "")
                {
                    int CHF = 0, SGD = 0;
                    for (int col = 3; col <= 7; col++)
                        CHF += GetVal(dvRow, col);
                    CHF -= GetVal(dvRow, 8);

                    for (int col = 9; col <= 14; col++)
                        SGD += GetVal(dvRow, col);

                    dt.Rows.Add(headerText, CHF * -1, SGD * -1, GetVal(dvRow, 17), GetVal(dvRow, 18), GetVal(dvRow, 20));
                }
            }
            string sumAll = "Total,";
            for (int i = 1; i <= dt.Columns.Count-1; i++)
            {
                int sumValue = 0;
                for (int row = 0; row <= dt.Rows.Count - 1; row++)
                    sumValue += Convert.ToInt32(dt.Rows[row][i]);
                sumAll += sumValue + ",";
            }
            dt.Rows.Add(sumAll.Trim(',').Split(","));

            s.DataSource = dt;
            s.Columns[0].Width = 65;
            int rowTot = s.RowCount - 1;
            s.Rows[rowTot].Cells[0].Style.Font = util.getFont(11);

            for (int i = 1; i <= dt.Columns.Count-1; i++)
            {
                s.Columns[i].Width = 54;
                s.Rows[rowTot].Cells[i].Style.Font = util.getFont(11);
            }

            s.FirstDisplayedScrollingRowIndex = rowTot;
            lblSummary.Text = "Summery(" + (rowTot).ToString() + ")";
        }
        private void CalculateSummeryTable()
        {
            DataTable result = new DataTable();
            var s = dg_summeryData;

            string[] cur = { "Date", "EUR", "GBP", "AUD", "NZD", "USD", "CAD", "JPY" };
            for (int ic = 0; ic < cur.Length; ic++)
                result.Columns.Add(cur[ic]);
            s.ReadOnly = true;

            for (int row = 0; row < dg_majorData.Rows.Count; row++)
            {
                DataGridViewRow dr = dg_majorData.Rows[row];
                string headerText = dr.Cells[0].Value.ToString();
                if (headerText != "")
                {
                    int eur = 0, gbp = 0, aud, nzd, usd, cad, jpy = 0;
                    for (int col = 1; col <= 6; col++)
                        eur += GetVal(dr, col);

                    for (int col = 7; col <= 11; col++)
                        gbp += GetVal(dr, col);

                    gbp -= GetVal(dr, 1);
                    aud = GetVal(dr, 12) + GetVal(dr, 13) + GetVal(dr, 14) - GetVal(dr, 2) - GetVal(dr, 7);
                    nzd = GetVal(dr, 15) + GetVal(dr, 16) + GetVal(dr, 17) - GetVal(dr, 3) - GetVal(dr, 8);
                    usd = GetVal(dr, 18) + GetVal(dr, 20) - GetVal(dr, 5) - GetVal(dr, 10) - GetVal(dr, 12) - GetVal(dr, 15);
                    cad = GetVal(dr, 19) - GetVal(dr, 18) - GetVal(dr, 17) - GetVal(dr, 9) - GetVal(dr, 4) - GetVal(dr, 14);
                    jpy = -GetVal(dr, 19) - GetVal(dr, 6) - GetVal(dr, 11) - GetVal(dr, 13) - GetVal(dr, 16);

                    result.Rows.Add(headerText, eur, gbp, aud, nzd, usd, cad, jpy);
                }
            }

            string sumAll = "Total,";
            for (int i = 1; i <= 7; i++)
            {
                int sumValue = 0;
                for (int row = 0; row <= result.Rows.Count - 1; row++)
                    sumValue += Convert.ToInt32(result.Rows[row][i]);
                sumAll += sumValue + ",";
            }
            result.Rows.Add(sumAll.Trim(',').Split(","));

            s.DataSource = result;
            int rowTot = s.RowCount - 1;
            s.Columns[0].Width = 60;
            s.Rows[rowTot].Cells[0].Style.Font = util.getFont(11);

            for (int i = 1; i <= 7; i++)
            {
                s.Columns[i].Width = 54;
                s.Rows[rowTot].Cells[i].Style.Font = util.getFont(11);
            }
            s.FirstDisplayedScrollingRowIndex = rowTot;
            lblSummary.Text = "Summery(" + (rowTot).ToString() + ")";
        }
        public int GetVal(DataGridViewRow dv, int id)
        {
            return Convert.ToInt16(dv.Cells[id].Value);
        }
        private List<PossibleSignal> getActivePS(TimeFrame tf)
        {
            return posSignal.FindAll(t => t.TimeFrame == tf && t.IsActive == "1");
        }
        private void HighlightWeekleyOption()
        {
            dg_majorData.EnableHeadersVisualStyles = false;
            foreach (PossibleSignal ts in getActivePS(TimeFrame.Week))
                for (int colCount = 1; colCount <= dg_majorData.Columns.Count - 1; colCount++)
                    if (dg_majorData.Columns[colCount].HeaderText == ts.Pair.Substring(0, 6))
                    {
                        dg_majorData.Columns[colCount].HeaderCell.Style.BackColor = GetColor(ts.Action);
                        break;
                    }
        }
        public Color GetColor(ForexAction fa)
        {
            return fa == ForexAction.Sell ? Color.Red : Color.Green;
        }
        private void PaintColor(DataGridView dg)
        {
            for (int row = 0; row < dg.Rows.Count; row++)
                for (int col = 1; col < dg.Columns.Count; col++)
                    if (dg.Rows[row].Cells[col].Value != null)
                    {
                        dg.Rows[row].Cells[col].Style.BackColor = GetVal(dg.Rows[row], col) < 0 ? Color.LightSalmon : Color.LightGreen;
                        dg.Rows[row].Cells[col].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
        }
        private void LoadListHeader()
        {
            Text = Utilities.AppName;
            var w = lstWeek.Columns;
            // Set to details view.
            w.Add("ID", 0, HorizontalAlignment.Left);
            w.Add("Date", 80, HorizontalAlignment.Left);
            w.Add("Currency", 110, HorizontalAlignment.Left);
            w.Add("Pattern", 120, HorizontalAlignment.Left);
            w.Add("Trend", 70, HorizontalAlignment.Left);
            w.Add("Status", 80, HorizontalAlignment.Left);
            lstWeek.ColumnClick += new ColumnClickEventHandler(ColumnClick);
            SetGridProperty(lstWeek);

            w = lstDay.Columns;
            w.Add("ID", 0, HorizontalAlignment.Left);
            w.Add("Date", 60, HorizontalAlignment.Left);
            w.Add("Currency", 80, HorizontalAlignment.Left);
            w.Add("Pattern", 80, HorizontalAlignment.Left);
            w.Add("Trend", 70, HorizontalAlignment.Left);
            SetGridProperty(lstDay);

            w = lstNews.Columns;
            w.Add("UK-Time", 80, HorizontalAlignment.Left);
            w.Add("Priority", 80, HorizontalAlignment.Left);
            w.Add("Country", 80, HorizontalAlignment.Left);
            w.Add("Short Details", 400, HorizontalAlignment.Left);
            SetGridProperty(lstNews);

            w = lstSingleBar.Columns;
            w.Add("Pair", 100, HorizontalAlignment.Left);
            w.Add("TimeFrame", 100, HorizontalAlignment.Left);
            SetGridProperty(lstSingleBar);

            w = lstAllNews.Columns;
            w.Add("UK-DateTime", 100, HorizontalAlignment.Left);
            w.Add("Priority", 80, HorizontalAlignment.Left);
            w.Add("Country", 70, HorizontalAlignment.Left);
            w.Add("Short Details", 400, HorizontalAlignment.Left);
            SetGridProperty(lstAllNews);

            w = lstSeasonal.Columns;
            w.Add("Pair", 80, HorizontalAlignment.Left);
            w.Add(util.monthName(), 70, HorizontalAlignment.Left);
            w.Add(util.monthName(1), 70, HorizontalAlignment.Left);
            lstSeasonal.View = View.Details;
            lstSeasonal.FullRowSelect = true;
            lstSeasonal.GridLines = true;

            w = lst_youtube.Columns;
            w.Add("Type", 90, HorizontalAlignment.Left);
            w.Add("Title", 200, HorizontalAlignment.Left);
            w.Add("Video Link", 400, HorizontalAlignment.Left);
            SetGridProperty(lst_youtube);

            w = lstDayTrend.Columns;
            w.Add("Pair", 100, HorizontalAlignment.Left);
            w.Add("BlueLine", 100, HorizontalAlignment.Left);
            w.Add("RedLine", 100, HorizontalAlignment.Left);
            SetGridProperty(lstDayTrend);

            grp_Signal.Visible = true;
            grp_news.Visible = false;
        }
        private void SetGridProperty(ListView lv)
        {
            lv.View = View.Details;
            util.colorListViewHeader(ref lv, Color.LightGray, Color.Black);
            lv.FullRowSelect = true;
            lv.GridLines = true;
        }
        private void ColumnClick(object o, ColumnClickEventArgs e)
        {
            this.lstWeek.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }
        private void TimeUK_Tick(object sender, EventArgs e)
        {
            lblTime2.Text = "Time: UK - " + util.Getime(TimeZone.GMT_Standard_Time)
                            + "  US - " + util.Getime(TimeZone.US_Eastern_Standard_Time)
                            + "  IND - " + util.Getime(TimeZone.India_Standard_Time);
            lbl_HighNewslist.Visible = !(lbl_HighNewslist.Visible && IsNFPToday);
        }
        private void RadNewsChanged(object sender, EventArgs e)
        {
            ENewsPriority nPri = radHigh.Checked ? ENewsPriority.HIGH : radMedium.Checked ?
                                ENewsPriority.MEDIUM : ENewsPriority.ALL;
            LoadAllNewsFilter(nPri);
        }
        private void SetFirstHeaderColor(MarketData md)
        {
            Color col = md.ToString().Contains('D') ? Color.Magenta : Color.Yellow;
            for (int rowcount = 0; rowcount <= dg_majorData.RowCount - 1; rowcount++)
                dg_majorData.Rows[rowcount].Cells[0].Style.BackColor = col;

            for (int rowcount = 0; rowcount <= dg_summeryData.RowCount - 1; rowcount++)
                dg_summeryData.Rows[rowcount].Cells[0].Style.BackColor = col;
        }
        private void Btn_SaveCalculate_Click(object sender, EventArgs e)
        {
            if (rdo_DayData.Checked || rdo_WeekData.Checked)
                CalculateSummeryTable();
            else
                CalculateSummeryTableMinor();
            IdentifyPattern();
            PaintGrid();
        }
        private void Dg_pattern_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dg_pattern.CurrentCell != null)
            {
                string curPair = dg_pattern.CurrentCell.Value.ToString();
                if (curPair.Length >= 4)
                {
                    string color = dg_pattern.CurrentCell.Style.BackColor.Name.ToString();
                    ForexAction strAction = (color == "LightGreen") ? ForexAction.Buy : ForexAction.Sell;
                    TimeFrame tFrame = (rdo_DayData.Checked == true || rad_MinDay.Checked == true) ? TimeFrame.Day : TimeFrame.Week;
                    ChartPattern pattern = util.CovertPattern(dg_pattern.Rows[dg_pattern.CurrentCell.RowIndex].Cells[0].Value.ToString());

                    frmConfimDialog frm = new frmConfimDialog();
                    frm.newPOS = new PossibleSignal(tFrame, curPair, pattern, strAction, DateTime.Now.ToString("dd-MMM"), "1", loginDetail.DisplayName);
                    frm.ShowDialog();
                    BtnAdd_Click(sender, e);
                }
            }
        }
        private void Dg_majorData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dg_majorData.CurrentCell.ColumnIndex != 1) //Desired Column
            {
                if (e.Control is TextBox tb)
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                e.Handled = true;
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel ln = (LinkLabel)sender;
            OpenLink(Convert.ToInt16(ln.Text.Substring(0, 1)));
        }
        private void OpenLink(int lineID)
        {
            string[] lines = db.GetWebSitesAll().Split(',');
            Process.Start(new ProcessStartInfo(lines[lineID - 1]) { UseShellExecute = true });
        }
        private void LblHeading_Click(object sender, EventArgs e)
        {
            SetupView();
            grp_Signal.Visible = true;
            LoadDashBoard();
            grpSingleBar.Visible = true;
            SetSingleTB();
        }
        private void Pic_logo_Click(object sender, EventArgs e)
        {
            SetupView();
            SetupMarketDate();
            grpSingleBar.Visible = false;
        }
        private void Lst_youtube_DoubleClick(object sender, EventArgs e)
        {
            string url = lst_youtube.SelectedItems[0].SubItems[2].Text;
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
        private void Rad_YouTubeClick(object sender, EventArgs e)
        {
            VideoType mot = rad_motivation.Checked ? VideoType.Motivational :
                            rad_tradeOption.Checked ? VideoType.Trading :
                            rad_pshcology.Checked ? VideoType.Psychology :
                            VideoType.All;
            LoadYoutubeVideos(mot);
        }
        private void ChkShowAllW_CheckedChanged(object sender, EventArgs e)
        {
            List<PossibleSignal> lpos = chkShowAllW.Checked ? posSignal.FindAll(t => t.TimeFrame == TimeFrame.Week)
                                            : posSignal.FindAll(t => t.TimeFrame == TimeFrame.Week && t.IsActive == "1");
            FillList(lstWeek, lpos);
        }
        private void ChkNewsAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadTodayNews(chkNewsAll.Checked ? ENewsPriority.ALL : ENewsPriority.HIGH);
        }
        private void LnkTick_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTickList frmtick = new frmTickList();
            frmtick.ShowDialog();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (db.AnyTickNotComplete(DateTime.Now.ToString(Utilities.DateFormat)) == true)
            {
                if (util.showQuestion("All the option not Ticked, Do you want Quit Application?") == DialogResult.OK)
                    db.InsertEvents(new LoginEvents(DateTime.Now.ToString(), "Logged Out User", loginDetail.DisplayName));
                else
                    e.Cancel = true;
            }
        }
        private void Dg_majorData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var q = dg_majorData;
            if (e.RowIndex <= q.Rows.Count - 1)
            {
                string colHeader = q.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (colHeader != "")
                {
                    string rowHeader = q.Columns[e.ColumnIndex].HeaderText.ToString();
                    string val = q.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    db.UpdateMData(getMD(), rowHeader, colHeader, val);
                }
            }
        }
        private MarketData getMD()
        {
            return rdo_WeekData.Checked ? MarketData.MajWeek :
                 rdo_DayData.Checked ? MarketData.MajDay :
                rad_MinDay.Checked ? MarketData.MinDay : MarketData.MinWeek;
        }
        private void RadMajorDay(object sender, EventArgs e)
        {
            if (rdo_DayData.Checked == true)
            {
                SetColorandLabel(MarketData.MajDay);
                lblGeneral.Text = "Major Day Movements";
            }
        }
        private void RdoMajorWeek(object sender, EventArgs e)
        {
            if (rdo_WeekData.Checked == true)
            { 
                SetColorandLabel(MarketData.MajWeek);
               lblGeneral.Text = "Major Week Movements";
            }
    }
        private void RdoMinorDay(object sender, EventArgs e)
        {
            if (rad_MinDay.Checked == true)
            {
                SetColorandLabel(MarketData.MinDay);
                lblGeneral.Text = "Minor Day Movements";
            }
        }
        private void RadMinorWeek(object sender, EventArgs e)
        {
            if (rad_MinWeek.Checked == true)
            {
                SetColorandLabel(MarketData.MinWeek);
                lblGeneral.Text = "Minor Week Movements";
            }
        }
        private void SetColorandLabel(MarketData md)
        {
            LoadMarketDataDB(md);
            if (md == MarketData.MajWeek || md == MarketData.MajDay)
            {
                CalculateSummeryTable();
                lblGeneral.ForeColor= btn_SaveCalculate.BackColor = Color.DarkCyan;
            }
            else
            {
                CalculateSummeryTableMinor();
                lblGeneral.ForeColor = btn_SaveCalculate.BackColor = Color.Cyan;
            }
            PaintGrid();
            HighlightWeekleyOption();
            btn_SaveCalculate.Text = "Show Pattern";
            dg_summeryData.Visible = true;
            lblPatternGrid.BackColor = lblSummary.BackColor = btn_SaveCalculate.BackColor;
            IdentifyPattern();
        }
        private void PaintGrid()
        {
            PaintColor(dg_majorData);
            PaintColor(dg_summeryData);
            SetFirstHeaderColor(getMD());
        }
        private void LstWeek_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateStatus(lstWeek.FocusedItem.SubItems);
            FillList(lstWeek, getActivePS(TimeFrame.Week));
        }
        private void UpdateStatus(ListViewItem.ListViewSubItemCollection sitems)
        {
            if (util.showQuestion("Do you want to change the Status?") == DialogResult.OK)
            {
                db.UpdatePosSignal(sitems[0].Text, sitems[5].Text == "Active" ? "0" : "1");
                chkShowAllW.Checked = false;
                posSignal = db.GetPossibleSiganlAll();
                LoadDashBoard();
            }
        }
        private void LstDay_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateStatus(lstDay.FocusedItem.SubItems);
            FillList(lstDay, getActivePS(TimeFrame.Day));
        }
        private void Pic_YoutubeClick(object sender, EventArgs e)
        {
            SetupView();
            grp_Youtube.Visible = true;
            LoadYoutubeVideos(VideoType.All);
            rad_motivation.ForeColor = Color.DarkBlue;
            rad_pshcology.ForeColor = Color.Coral;
            rad_tradeOption.ForeColor = Color.DarkGreen;
        }
        private void Pic_NewsClick(object sender, EventArgs e)
        {
            SetupView();
            grp_news.Visible = true;
            grp_news.BringToFront();
            LoadAllNewsFilter(ENewsPriority.ALL);
        }
        private void ChkTrendAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadRBcross(chkTrendAll.Checked);
        }
        private void Pic_CLclick(object sender, EventArgs e)
        {
            SetupView();
            grp_Signal.Visible = true;
            frmCheckList frm = new frmCheckList();
            frm.ShowDialog();
        }
        private void Pic_ClockClick(object sender, EventArgs e)
        {
            Form fpopup = new frmTimesheet();
            fpopup.ShowDialog();
        }
        private void Pic_RefreshClick(object sender, EventArgs e)
        {
            posSignal = db.GetPossibleSiganlAll();
            LoadDashBoard();
        }

        private void lstSingleBar_MouseClick(object sender, MouseEventArgs e)
        {
            frmConfimDialog frm = new frmConfimDialog();
            var si = lstSingleBar.FocusedItem.SubItems;
            frm.newPOS = new PossibleSignal(TimeFrame.Week, si[0].Text, ChartPattern.SingleTestBar, ForexAction.Buy, DateTime.Now.ToString("dd-MMM"), "1", loginDetail.DisplayName);
            frm.ShowDialog();
        }
    }
}
