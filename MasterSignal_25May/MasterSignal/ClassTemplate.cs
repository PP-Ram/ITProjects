using System.Collections.Generic;

namespace MasterSignal
{
    public class Website
    {
        public Website() { }

        public int id;
        public string Type;
        public string Title;
        public string Link;
    }
    public class EconomicNews
    {
        public EconomicNews() { }

        public int id;
        public string Country;
        public string NewsDate;
        public string Priority;
        public string ShortDetails;
        public string Day;
        public string Month;
    }
    public class LiveTrades
    {
        public LiveTrades() { Action = ForexAction.Buy; }

        public int id;
        public string AccName;
        public string Pair;
        public ForexAction Action;
        public string TradeDay;
        public string TradeMonth;
        public TradeResult Result;
        public string Units;
        public string Balance;
        public string Desc;
        public string CreatedBy;
        public int AccID;
    }
    public class SeasonalData
    {
        public SeasonalData() { }

        public int id;
        public string Pair;
        public string CurMonth;
        public string NextMonth;
    }
    public class PossibleSignal
    {
        public PossibleSignal() { }
        public PossibleSignal(TimeFrame tf, string pPair, ChartPattern cp, ForexAction fp, string cd, string ia, string cb)
        {
            TimeFrame = tf;
            Pair = pPair;
            Pattern = cp;
            Action = fp;
            cDate = cd;
            IsActive = ia;
            CreatedBy = cb;
        }

        public int ID;
        public TimeFrame TimeFrame;
        public string Pair;
        public ChartPattern Pattern;
        public ForexAction Action;
        public string cDate;
        public string IsActive;
        public string CreatedBy;
        public string WithTrend;
        public string Notes;
    }
    public class Login
    {
        public Login() { }
        public int ID;
        public string DisplayName;
        public string Email;
        public string Phone;
        public string CreatedDate;
        public bool PaymentReceived;
        public string Password;
        public bool isActive;
        public RoleType RoleType;
    }
    public class LoginEvents
    {
        public LoginEvents(string pDate, string pAction, string pLogBy) { LogDate = pDate; UserAction = pAction; LoggedInBy = pLogBy; }
        public int ID;
        public string LogDate;
        public string UserAction;
        public string LoggedInBy;

    }
    public class DayTendPair
    {
        public DayTendPair() { }
        public int ID;
        public string Pair;
        public string Trend;
        public string Red;
        public string Blue;
        public string IsActive;
    }

    public class Invoice
    {
        public Invoice()
        {
            invItem = new Dictionary<int, string>();
        }
        public int ID;
        public string InvoiceCode;
        public string InvDate;
        public string TotalAmt;
        public string AccId;
        public string IsActive;
        public IDictionary<int, string> invItem;
    }
    public static class LoggedInUser
    {
        public static string name;
        public static RoleType Role;
    }
}

