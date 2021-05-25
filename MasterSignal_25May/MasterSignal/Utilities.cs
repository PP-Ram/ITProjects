using System.Diagnostics;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace MasterSignal
{
    public class Utilities
    {
        public const string AppName = "Smart Forex App";
        public const string DateFormat = "dd-MMM-yyyy";
        public Utilities() { }
        public string GetConfigValue(string v)
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            return appSettings[v].ToString();
        }
        public void showMessage(string v, string type = "i")
        {
            MessageBoxIcon mi = (type == "i") ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(v, AppName, MessageBoxButtons.OK, mi);
        }
        public DialogResult showQuestion(string v)
        {
            return MessageBox.Show(v, AppName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        public void colorListViewHeader(ref ListView list, Color backColor, Color foreColor)
        {
            list.OwnerDraw = true;
            list.DrawColumnHeader +=
                new DrawListViewColumnHeaderEventHandler
                (
                    (sender, e) => headerDraw(sender, e, backColor, foreColor)
                );
            list.DrawItem += new DrawListViewItemEventHandler(bodyDraw);
        }
        private static void headerDraw(object sender, DrawListViewColumnHeaderEventArgs e, Color backColor, Color foreColor)
        {
            using (SolidBrush backBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            using (SolidBrush foreBrush = new SolidBrush(foreColor))
            {
                e.Graphics.DrawString(e.Header.Text, e.Font, foreBrush, e.Bounds);
            }
        }
        private static void bodyDraw(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        public ChartPattern CovertPattern(string pPattern)
        {
            return pPattern == "CBR" ? ChartPattern.ContinousBar :
                    pPattern == "TT" ? ChartPattern.TrainTrack :
                    pPattern == "DD" ? ChartPattern.DoubleDay :
                    ChartPattern.Stack3;
        }
        public string monthName(int count = 0)
        {
            return DateTime.Now.AddMonths(count).ToString("MMM");
        }
        public string Getime(TimeZone ptimeZone)
        {
            var tiZone = TimeZoneInfo.FindSystemTimeZoneById(ptimeZone.ToString().Replace('_', ' '));
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, tiZone).ToString("HH:mm:ss");
        }
        public Color getColor(ForexAction fa)
        {
            return fa == ForexAction.Sell ? Color.LightSalmon : Color.LightGreen;
        }
        public Font getFont(int size)
        {
            return new Font("Arial", size, FontStyle.Bold);
        }
        public Bitmap getPicture(TradePicture tp)
        {
            return new Bitmap("images/" + tp.ToString() + ".png");
        }
        public void SaveToRepository()
        {
            var ps1File = @"C:\SmartForexApp\Github_CheckIn.ps1";
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted \"{ps1File}\"",
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(startInfo);
        }
    }
    public enum RoleType
    {
        Admin = 1,
        User = 2,
        Customer = 3
    }
    public enum ForexAction
    {
        Buy = 1,
        Sell = 2,
        Cancel = 3,
        Default = 4
    }
    public enum TimeFrame
    {
        Week = 1,
        Day = 2,
        Hour4 = 3,
        Hour1 = 4,
        Minute15 = 5
    }
    public enum ChartPattern
    {
        DoubleDay = 1,
        TrainTrack = 2,
        ContinousBar = 3,
        Stack3 = 4,
        SingleTestBar = 5
    }
    public enum VideoType
    {
        Motivational = 1,
        Psychology = 2,
        Trading = 3,
        All = 4
    }
    public enum ENewsPriority
    {
        HIGH = 1,
        MEDIUM = 2,
        LOW = 3,
        ALL = 4
    }
    public enum TradeResult
    {
        Win = 1,
        Loss = 2,
        Breakeven = 3
    }
    public enum MarketData
    {
        MajDay = 1,
        MajWeek = 2,
        MinDay = 3,
        MinWeek = 4
    }
    public enum FXTrend
    {
        Up = 1,
        Down = 2,
        NoTrend = 5
    }
    public enum TimeZone
    {
        GMT_Standard_Time,
        US_Eastern_Standard_Time,
        India_Standard_Time
    }
    public enum TradePicture
    {
        Bars,
        Pattern,
        TradingFlowChart,
        NFPDates_2021,
        MeetingDetails,
        LogoDetail,
        Con_pattern,
        Rev_pattern,
        SFA_Logo,
        Youtube,
        FinNews,
        CL,
        Clock,
        TradeGoal01,
        Refresh,
        BreakOut,
        Seasonal
    }
}
public class ListViewItemComparer : System.Collections.IComparer
{
    private int col;
    public ListViewItemComparer()
    {
        col = 0;
    }
    public ListViewItemComparer(int column)
    {
        col = column;
    }
    public int Compare(object x, object y)
    {
        return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
    }
}