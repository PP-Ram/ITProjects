using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace MasterSignal
{
    public class DataObject
    {
        Utilities util = new Utilities();
        DataTable dt;
        private SQLiteConnection GetConnection()
        {
            SQLiteConnection con = new SQLiteConnection(string.Format(DBSQL.conStr, util.GetConfigValue("DBFilePath")));
            con.Open();
            return con;
        }
        private string getSqlString(string pdata)
        {
            string rstr = "";
            foreach (string str in pdata.Split(','))
                rstr += "'" + str + "',";
            return rstr.Trim(',');
        }
        private StringBuilder GetDataSetSB(string sql, bool withColumn = true)
        {
            using var cmd = new SQLiteCommand(sql, GetConnection());
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            if (withColumn == true)
            {
                var columnNames = Enumerable.Range(0, rdr.FieldCount).Select(rdr.GetName).ToList();
                sb.Append(string.Join(",", columnNames));
                sb.AppendLine();
            }
            while (rdr.Read())
            {
                string singleRow = "";
                for (int i = 1; i < rdr.FieldCount; i++)
                    singleRow += rdr.GetString(i) + ",";
                sb.AppendLine(singleRow);
            }
            return sb;
        }
        
        internal void UpdateTimeSheet(string rowHeader, string colHeader, string val)
        {
            string mainsql = string.Format(DBSQL.sqlTimeSheetUpdate, rowHeader, val, colHeader);
            using var cmd = new SQLiteCommand(mainsql, GetConnection());
            cmd.ExecuteNonQuery();

        }
        //Ticks
        public StringBuilder GetTickByDate(string pData, bool wCol)
        {
            return GetDataSetSB(string.Format(DBSQL.sqlTickByDate, pData), wCol);
        }
        public bool AnyTickNotComplete(string pData)
        {
            StringBuilder sb = GetDataSetSB(string.Format(DBSQL.sqlTickByDate, pData), false);
            return sb.ToString().Contains("False");
        }
        internal void UpdateCurTrend(string rowHeader, string colHeader, string val)
        {
            string mainSQL = string.Format(DBSQL.sqlTrendUpdate, rowHeader, val, colHeader);
            using var cmd = new SQLiteCommand(mainSQL, GetConnection());
            cmd.ExecuteNonQuery();
        }
        public void AddOrUpdateTick(string pData)
        {
            string sqlInsert = "INSERT INTO tblTickOption(CurDate,opt1,opt2,opt3,opt4,opt5,opt6) values(";
            string sqlDelete = "DELETE FROM tblTickOption WHERE lower(CurDate) = '" + pData.Split(',')[0].ToLower() + "'";

            using var cmd = new SQLiteCommand(GetConnection());
            cmd.CommandText = sqlDelete;
            cmd.ExecuteNonQuery();

            cmd.CommandText = sqlInsert + getSqlString(pData) + ")";
            cmd.ExecuteNonQuery();
        }
        //Quotes
        public string GetQuoteByID()
        {
            return GetDataSetSB(string.Format(DBSQL.sqlQuotesById), false).ToString();
        }
        //WebSites
        public string GetWebSitesAll()
        {
            using var cmd = new SQLiteCommand(DBSQL.sqlWebSitesAll, GetConnection());
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            string singleRow = "";
            while (rdr.Read())
                singleRow += rdr.GetString(0) + ",";
            return singleRow;
        }
        public List<Website> GetWSYoutubeAll(VideoType type)
        {
            List<Website> lstWebsites = new List<Website>();
            Website lstWebsite;
            string mainsql = (type == VideoType.All) ? DBSQL.sqlWSYouTubeAll : string.Format(DBSQL.sqlWebSitesByType, type);
            using var cmd = new SQLiteCommand(mainsql, GetConnection());

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lstWebsite = new Website
                {
                    id = rdr.GetInt32(0),
                    Type = rdr.GetString(1),
                    Title = rdr.GetString(2),
                    Link = rdr.GetString(3)
                };
                lstWebsites.Add(lstWebsite);
            }
            return lstWebsites;
        }
        //ENews
        public List<EconomicNews> GetENewsAll(ENewsPriority priority)
        {
            string mainsql = (priority == ENewsPriority.ALL) ? DBSQL.sqlENewsAll : string.Format(DBSQL.sqlENewsByPriority, priority);
            using var cmd = new SQLiteCommand(mainsql, GetConnection());

            return GetClassObjets(cmd.ExecuteReader());
        }
        private static List<EconomicNews> GetClassObjets(SQLiteDataReader rdr)
        {
            List<EconomicNews> lstEconomicNews = new List<EconomicNews>();
            EconomicNews economicNew;
            while (rdr.Read())
            {
                economicNew = new EconomicNews
                {
                    id = rdr.GetInt32(0),
                    NewsDate = rdr.GetString(1),
                    Country = rdr.GetString(2),
                    Priority = rdr.GetString(3),
                    ShortDetails = rdr.GetString(4)
                };
                economicNew.Day = economicNew.NewsDate.Substring(3, 2);
                economicNew.Month = economicNew.NewsDate.Substring(11, 5);
                lstEconomicNews.Add(economicNew);
            }
            return lstEconomicNews;
        }

        internal void UpdateLiveTrade(string rowHeader, string colHeader, string val)
        {
            string mainsql = string.Format(DBSQL.sqlUpdateLT, rowHeader, val, colHeader);
            using var cmd = new SQLiteCommand(mainsql, GetConnection());
            cmd.ExecuteNonQuery();
        }

        internal void InsertLiveTrade(string accName, string traMonth, string desc)
        {
            string mainSQL = string.Format(DBSQL.sqlInsertLiveTrades, accName, traMonth, desc);
            using var cmd = new SQLiteCommand(mainSQL, GetConnection());
            cmd.ExecuteNonQuery();
        }

        internal void UpdateCloseBalanace(string val, string acname, string mname)
        {
            string mainsql = string.Format(DBSQL.sqlUpdateMLT, val, acname, mname);
            using var cmd = new SQLiteCommand(mainsql, GetConnection());
            cmd.ExecuteNonQuery();
        }

        public List<EconomicNews> GetENewsByToday()
        {
            string mainSQL = string.Format(DBSQL.sqlENewsByDay, DateTime.Now.ToString("dd"));
            using var cmd = new SQLiteCommand(mainSQL, GetConnection());
            return GetClassObjets(cmd.ExecuteReader());
        }
        //LiveTrades
        public DataTable GetLiveTradeAll(string acc, string mon)
        {
            DataTable dt = new DataTable();
            string mainSQL = string.Format(DBSQL.sqlLiveTradesAll, acc, mon);
            using var cmd = new SQLiteCommand(mainSQL, GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        internal void UpdateLiveTradeByID(string id, string updateVal)
        {
            string mainsql = string.Format(DBSQL.sqlUpdateLiveTradesByID, id, updateVal);
            using var cmd = new SQLiteCommand(mainsql, GetConnection());
            cmd.ExecuteNonQuery();
        }
        
        public string GetLiveTradeByID(string id)
        {
            DataTable dt = new DataTable();
            string mainSQL = string.Format(DBSQL.sqlLiveTradesByID, id);
            using var cmd = new SQLiteCommand(mainSQL, GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt.Rows[0].ItemArray[0].ToString();
        }
        public DataTable GetLiveTradeMaster(string acc, string mon)
        {
            DataTable dt = new DataTable();
            string mainSQL = string.Format(DBSQL.sqlLiveTradesMaster, acc, mon);
            using var cmd = new SQLiteCommand(mainSQL, GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        public DataTable GetChartData(string acc, string mon, string type)
        {
            DataTable dt = new DataTable();

            string mainSQL = string.Format(type == "1" ? DBSQL.sqlChartData1 : DBSQL.sqlChartData2, acc, mon);
            using var cmd = new SQLiteCommand(mainSQL, GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        //Seasonal Data
        public List<SeasonalData> GetSeasonalDataAll()
        {
            List<SeasonalData> lstSeasonalData = new List<SeasonalData>();
            SeasonalData sData;
            string mainSql = string.Format(DBSQL.sqlSeasonalAll, DateTime.Now.ToString("MMM"), DateTime.Now.AddMonths(1).ToString("MMM"));
            using var cmd = new SQLiteCommand(mainSql, GetConnection());
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                sData = new SeasonalData
                {
                    id = rdr.GetInt32(0),
                    Pair = rdr.GetString(1),
                    CurMonth = rdr.GetString(2),
                    NextMonth = rdr.GetString(3)
                };

                lstSeasonalData.Add(sData);
            }
            return lstSeasonalData;
        }
        //NFPDate
        public bool IsNFPToday()
        {
            string mainSql = string.Format(DBSQL.sqlNfpDateToday, DateTime.Now.ToString("dd-MMM"));
            using var cmd = new SQLiteCommand(mainSql, GetConnection());
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            return rdr.HasRows;
        }
        //Possible Signal
        public List<PossibleSignal> GetPossibleSiganlAll()
        {
            List<PossibleSignal> lstPsignal = new List<PossibleSignal>();
            PossibleSignal pSignal;
            using var cmd = new SQLiteCommand(DBSQL.sqlPosSignalAll, GetConnection());
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                pSignal = new PossibleSignal
                {
                    ID = rdr.GetInt32(0),
                    TimeFrame = (TimeFrame)Enum.Parse(typeof(TimeFrame), rdr.GetString(1), true),
                    Pair = rdr.GetString(2),
                    Pattern = (ChartPattern)Enum.Parse(typeof(ChartPattern), rdr.GetString(3), true),
                    Action = (ForexAction)Enum.Parse(typeof(ForexAction), rdr.GetString(4), true),
                    cDate = rdr.GetString(5),
                    IsActive = rdr.GetString(6),
                    CreatedBy = rdr.GetString(7),
                    WithTrend = rdr.GetString(8),
                    Notes = rdr.GetString(9)
                };

                lstPsignal.Add(pSignal);
            }
            return lstPsignal;
        }
        public bool InsertPosSignal(PossibleSignal ps)
        {
            string mainSQL = string.Format(DBSQL.sqlInsertPS, ps.TimeFrame, ps.Pair,
                ps.Pattern, ps.Action, ps.cDate, ps.IsActive, ps.CreatedBy, ps.WithTrend, ps.Notes);
            using var cmd = new SQLiteCommand(mainSQL, GetConnection());
            cmd.ExecuteNonQuery();
            return true;
        }
        public void UpdatePosSignal(string pid, string paction)
        {
            string mainSQL = string.Format(DBSQL.sqlUpdatePS, paction, pid);
            using var cmd = new SQLiteCommand(mainSQL, GetConnection());
            cmd.ExecuteNonQuery();
        }
        //User Details
        public Login GetUserDetails(string UName)
        {
            Login login = new Login();
            using var cmd = new SQLiteCommand(string.Format(DBSQL.sqlUserByName, UName), GetConnection());
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                login = new Login
                {
                    ID = rdr.GetInt32(0),
                    DisplayName = rdr.GetString(1),
                    Password = rdr.GetString(2),
                    Email = rdr.GetString(3),
                    Phone = rdr.GetString(4),
                    RoleType = (RoleType)Enum.Parse(typeof(RoleType), rdr.GetString(5), true),
                    CreatedDate = rdr.GetString(6),
                    isActive = rdr.GetString(7) == "True",
                    PaymentReceived = rdr.GetString(8) == "True"
                };
            }
            return login;
        }
        public bool IsValidUSer(string UName, string pwd)
        {
            using var cmd = new SQLiteCommand(string.Format(DBSQL.sqlUserValid, UName, pwd), GetConnection());
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            return rdr.HasRows;
        }
        public bool IsUserActive(string UName)
        {
            Login login = new Login();
            string mainsql = string.Format(DBSQL.sqlUserIsActive, UName);
            using var cmd = new SQLiteCommand(mainsql, GetConnection());
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            return rdr.HasRows;
        }
        //Login events
        public bool InsertEvents(LoginEvents le)
        {
            string mainSQL = string.Format(DBSQL.sqlInsertLoginEvent, le.LogDate, le.UserAction, le.LoggedInBy);
            using var cmd = new SQLiteCommand(mainSQL, GetConnection());
            cmd.ExecuteNonQuery();
            return true;
        }
        public void SetupInitialDB(string v)
        {
            InsertEmptyRowDay(MarketData.MajDay, v);
            InsertEmptyRowDay(MarketData.MinDay, v);
            string day = DateTime.Now.ToString("ddd").ToLower();
            if (day == "sun" || day == "sat" || day == "mon")
            {
                InsertEmptyRowWeek(MarketData.MajWeek, v);
                InsertEmptyRowWeek(MarketData.MinWeek, v);
            }
        }
        private void InsertEmptyRowDay(MarketData md, string name)
        {
            DateTime ExitingDate = Convert.ToDateTime(GetLastTradingDate(md) + DateTime.Now.ToString("yyyy"));
            DateTime NewDate = DateTime.Now.ToString("ddd") == "Tue" ? ExitingDate.AddDays(3) : ExitingDate.AddDays(1);
            if (NewDate.AddDays(1) < DateTime.Now)
            {
                string day = NewDate.ToString("ddd").ToLower();
                if (day != "sun" && day != "sat")
                    InsertMDataEmptyRow(md, name, NewDate.ToString("dd-MMM"));
            }
        }
        private void InsertEmptyRowWeek(MarketData md, string name)
        {
            DateTime ExitingDate = Convert.ToDateTime(GetLastTradingDate(md) + "-" + DateTime.Now.ToString("yyyy"));
            DateTime NewDate = ExitingDate.AddDays(13);
            if (NewDate < DateTime.Now)
            {
                string dateStr = ExitingDate.AddDays(7).ToString("dd-MMM");
                if (md == MarketData.MajWeek || md == MarketData.MinWeek)
                    dateStr = dateStr.ToUpper();

                InsertMDataEmptyRow(md, name, dateStr);
            }
        }
        //Major and Minor data
        public DataTable GetMarketData(MarketData md)
        {
            dt = new DataTable();
            string mainsql = string.Format(DBSQL.sqlMarketDataActive, getTableName(md), md);
            using var cmd = new SQLiteCommand(mainsql, GetConnection());
            dt.Load(cmd.ExecuteReader());

            return dt;
        }
        public void UpdateMData(MarketData md, string pair, string date, string value)
        {
            string mainsql = string.Format(DBSQL.sqlMDataUpdate, getTableName(md), pair, value, getFieldName(md), date, md);
            using var cmd = new SQLiteCommand(mainsql, GetConnection());
            cmd.ExecuteNonQuery();
        }
        private string getTableName(MarketData md)
        {
            return (md == MarketData.MajDay || md == MarketData.MajWeek) ? "tblMajorCurrencyPair" : "tblMinorCurrencyPair";
        }
        private string getFieldName(MarketData md)
        {
            return (md == MarketData.MajDay || md == MarketData.MajWeek) ? "MajorDate" : "MinorDate";
        }
        public bool InsertMDataEmptyRow(MarketData md, string user, string PDate)
        {
            string mainSQL = string.Format(DBSQL.sqlInsertMDEmpty, getTableName(md), getFieldName(md), PDate, md, user);
            using var cmd = new SQLiteCommand(mainSQL, GetConnection());
            cmd.ExecuteNonQuery();
            return true;
        }
        public DataTable GetTimesheets()
        {
            dt = new DataTable();
            using var cmd = new SQLiteCommand(DBSQL.sqlTimesheetAll, GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        public string GetLastTradingDate(MarketData md)
        {
            string mainSQL = string.Format(DBSQL.sqlGetLastTraDate, getFieldName(md), getTableName(md), md);
            using var cmd = new SQLiteCommand(mainSQL, GetConnection());
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            string rtrValue = "";
            while (rdr.Read())
            {
                rtrValue = rdr.GetString(0);
            }
            return rtrValue;
        }
        public DataTable GetHolidayAll()
        {
            dt = new DataTable();
            using var cmd = new SQLiteCommand(string.Format(DBSQL.sqlGetHDs, "1"), GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        public void UpdateHD(string colName, string colValue, string id)
        {
            string mainsql = string.Format(DBSQL.sqlHDUpdate, colName, colValue, id);
            SQLiteCommand cmd = new SQLiteCommand(mainsql, GetConnection());
            cmd.ExecuteNonQuery();
            if (colName == "Notes")
            {
                cmd = new SQLiteCommand(DBSQL.sqlHDInsert, GetConnection());
                cmd.ExecuteNonQuery();
            }
        }
      
        public DataTable GetTrendAll()
        {
            dt = new DataTable();
            using var cmd = new SQLiteCommand(DBSQL.sqlTrendsGetAll, GetConnection());
            dt.Load(cmd.ExecuteReader());

            return dt;
        }

        public List<DayTendPair> GetTrendCross(bool RBcross)
        {
            DayTendPair dt;
            List<DayTendPair> lstDT = new List<DayTendPair>();
            using var cmd = new SQLiteCommand(RBcross ? DBSQL.sqlTrendCross : DBSQL.sqlTrendCrossBlue, GetConnection());
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dt = new DayTendPair
                {
                    ID = rdr.GetInt32(0),
                    Pair = rdr.GetString(1),
                    Trend = rdr.GetString(2),
                    Red = rdr.GetString(4).ToUpper(),
                    Blue = rdr.GetString(5).ToUpper()
                };
                lstDT.Add(dt);
            }
            return lstDT;
        }
        public DataTable GetdisbursementAll(string accid)
        {
            dt = new DataTable();
            using var cmd = new SQLiteCommand(string.Format(DBSQL.sqlPayDisbursementAll, accid), GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        public DataTable GetAccCodeAll()
        {
            dt = new DataTable();
            using var cmd = new SQLiteCommand(DBSQL.sqlLiveAccAll, GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public DataTable GetSingleBar()
        {
            dt = new DataTable();
            using var cmd = new SQLiteCommand(DBSQL.sqlSingleBar, GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public void AddInvoice(Invoice newInv)
        {
            long rowID;
            using SQLiteConnection con = GetConnection();
            SQLiteTransaction transaction = null;
            transaction = con.BeginTransaction();

            string mainSQL = string.Format(DBSQL.sqlInsertInvoice, newInv.InvoiceCode, newInv.InvDate, newInv.TotalAmt, newInv.AccId);
            SQLiteCommand cmd = new SQLiteCommand(mainSQL, con);
            cmd.ExecuteNonQuery();
            rowID = con.LastInsertRowId;
            SQLiteCommand cmdItem;
            foreach (KeyValuePair<int, string> kvp in newInv.invItem)
            {
                cmdItem = new SQLiteCommand(string.Format(DBSQL.sqlInsertInvItem, rowID, kvp.Key, kvp.Value), con);
                cmdItem.ExecuteNonQuery();
            }
            transaction.Commit();
        }

        public DataTable GetPHheader()
        {
            dt = new DataTable();
            using var cmd = new SQLiteCommand(DBSQL.sqlPHheader, GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        public DataTable GetPHdetails(string invid)
        {
            dt = new DataTable();
            using var cmd = new SQLiteCommand(string.Format(DBSQL.sqlPHdetails, invid), GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        internal DataTable GetPHheaderItem()
        {
            dt = new DataTable();
            using var cmd = new SQLiteCommand(DBSQL.sqlPHItem, GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        public DataTable GetPHItemdetails(string dName)
        {
            dt = new DataTable();
            using var cmd = new SQLiteCommand(string.Format(DBSQL.sqlPHItemDetail, dName.ToLower()), GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        public DataTable GetCLList(string cltime)
        {
            dt = new DataTable();
            using var cmd = new SQLiteCommand(string.Format(DBSQL.sqlCLGetAll, cltime), GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        public DataTable GetTradePlan(string id)
        {
            dt = new DataTable();
            using var cmd = new SQLiteCommand(string.Format(DBSQL.sqlTradePlanByAccID, id), GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        public DataTable GetLiveAccounts()
        {
            dt = new DataTable();
            using var cmd = new SQLiteCommand(DBSQL.sqlLiveAccAll, GetConnection());
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
    }

    public class DBSQL
    {
        public const string conStr = @"URI=file:{0}";

        public const string sqlTickByDate = "SELECT * FROM tblTickOption WHERE CurDate = '{0}'";
        public const string sqlQuotesById = "SELECT * FROM tblQuotesOfDay WHERE ID=(SELECT ABS(RANDOM()) % (SELECT count(*) FROM tblQuotesOfDay))";
        public const string sqlWebSitesAll = "SELECT link FROM tblWebsites WHERE type ='Website'";
        public const string sqlWSYouTubeAll = "SELECT * FROM tblWebsites WHERE type in ('Trading', 'Psychology', 'Motivational') ORDER BY type";
        public const string sqlWebSitesByType = "SELECT * FROM tblWebsites WHERE Type='{0}'";
        public const string sqlENewsAll = "SELECT * FROM tblEconomicNews";
        public const string sqlENewsByPriority = "SELECT * FROM tblEconomicNews WHERE Priority='{0}'";
        public const string sqlENewsByDay = "SELECT * FROM tblEconomicNews WHERE substr(newsdate,4,2)='{0}'";
        public const string sqlLiveTradesMaster = "SELECT * FROM tblMasterLiveTrade WHERE AccountName='{0}' and MonthName='{1}'";
        public const string sqlLiveTradesAll = "SELECT * FROM tblLiveTrades WHERE Account='{0}' and TradeMonth='{1}' ORDER BY ID ";
        public const string sqlLiveTradesByID = "SELECT Desc FROM tblLiveTrades WHERE ID={0} ";

        public const string sqlUpdateLiveTradesByID = "UPDATE tblLiveTrades SET Desc='{0}' WHERE ID = '{1}'" ;
        public const string sqlInsertLiveTrades = "INSERT INTO tblLiveTrades(Account, TradeMonth, Desc) VALUES ('{0}','{1}','{2}')";
        public const string sqlChartData1 = "SELECT round(Units) as Units,TradeDay FROM tblLiveTrades WHERE Account='{0}' and TradeMonth='{1}' ORDER BY ID ";
        public const string sqlChartData2 = "SELECT round(Balance) as Balance FROM tblLiveTrades WHERE Account='{0}' and TradeMonth='{1}' and Balance is not null ORDER BY ID ";
        public const string sqlUpdateLT = "UPDATE tblLiveTrades SET {0}='{1}' WHERE ID = '{2}' ";
        public const string sqlUpdateMLT = "UPDATE tblMasterLiveTrade SET CloseBalance='{0}' WHERE AccountName ='{1}' AND MonthName= '{2}' ";
        public const string sqlSeasonalAll = "SELECT id,pair,{0},{1} FROM tblSeasonalData";
        public const string sqlNfpDateToday = "SELECT * FROM tblNFPDates WHERE nfpDate='{0}'";
        public const string sqlPosSignalAll = "SELECT * FROM tblPossibleSignal ORDER BY [Action], [IsActive]";
        public const string sqlInsertPS = "INSERT INTO tblPossibleSignal(TimeType,Pair,Pattern,Action,PatDate," +
                            "IsActive,CreatedBy,WithTrend,Notes) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')";
        public const string sqlUpdatePS = "UPDATE tblPossibleSignal SET [IsActive]='{0}' WHERE ID={1}";
        public const string sqlUserByName = "SELECT * FROM tblAppUsers WHERE UserName='{0}'";
        public const string sqlUserValid = "SELECT * FROM tblAppUsers WHERE UserName='{0}' AND Password='{1}'";
        public const string sqlUserIsActive = "SELECT * FROM tblAppUsers WHERE UserName='{0}' AND IsActive='Yes'";
        public const string sqlInsertLoginEvent = "INSERT INTO tblLoginEvents(Date,Action,LoggedInBy) VALUES('{0}','{1}','{2}')";
        public const string sqlTimesheetAll = "SELECT * FROM TimesheetView";
        public const string sqlTimeSheetUpdate = "UPDATE tblTimeSheet SET [{0}]='{1}' WHERE ID = '{2}' AND IsActive=1";
        public const string sqlMarketDataActive = "SELECT * FROM {0} WHERE IsActive='1' AND lower(TimeType)=lower('{1}')";
        public const string sqlMDataUpdate = "UPDATE {0} SET [{1}]='{2}' WHERE [{3}] = '{4}' AND lower(TimeType)=lower('{5}')";
        public const string sqlInsertMDEmpty = "INSERT INTO {0} ([{1}] ,TimeType, CreatedBy) VALUES('{2}','{3}','{4}')";
        public const string sqlGetLastTraDate = "SELECT {0} FROM {1} WHERE id = (SELECT MAX(id) FROM {1} WHERE TimeType = '{2}')";
        public const string sqlGetHDs = "SELECT * FROM tblHolidays WHERE isValid={0}";
        public const string sqlHDUpdate = "UPDATE tblHolidays SET [{0}]='{1}' WHERE ID='{2}'";
        public const string sqlHDInsert = "INSERT INTO tblHolidays(id) VALUES(null)";
        public const string sqlLiveAccAll = "SELECT ID, ID || '-' || AccountName || '-' || AccountNo AS FullValue FROM tblLiveAccounts WHERE isActive=1";
        public const string sqlLiveFormatName = "SELECT id, substr(AccountName,1,4) || ' - ' || substr(accountNo, length(accountNo)-3,3) " +
                                    " || ' - ' || substr(Broker,1,3) AS DsipName FROM tblLiveAccounts WHERE IsActive = 1";
        public const string sqlTrendsGetAll = "SELECT * FROM tblTrend WHERE IsActive=1";
        public const string sqlTrendCross = "SELECT * FROM tblTrend WHERE IsActive=1 AND Red='y' AND Blue='y' ";
        public const string sqlTrendCrossBlue = "SELECT * FROM tblTrend WHERE IsActive=1 AND Blue='y' ";
        public const string sqlTrendUpdate = "UPDATE tblTrend SET {0} = '{1}' WHERE ID = {2}";
        public const string sqlSingleBar = " SELECT * FROM tblMajorCurrencyPair WHERE timetype = 'MajWeek' AND isactive = 1 ORDER BY id DESC LIMIT 1";
        public const string sqlPayDisbursementAll = "SELECT id,ItemName,Percentage,'' ActualValue FROM tblPayDisbursments WHERE accid={0} ORDER BY sortorder";
        public const string sqlInsertInvoice = "INSERT INTO tblPayInvoice(InvoiceCode,InvDate,TotalAmt,Accid) VALUES('{0}','{1}','{2}','{3}')";
        public const string sqlInsertInvItem = "INSERT INTO tblPayInvoiceItem(InvID,DisID,Amount) VALUES('{0}','{1}','{2}')";
        public const string sqlPHheader = "SELECT ti.ID, la.AccountName, ti.invoiceCode, ti.InvDate,  printf('%.2f', ti.totalAmt) AS totalAmt " +
                        "FROM tblPayInvoice ti INNER JOIN tblLiveAccounts la ON ti.AccId = la.ID " +
                        "WHERE ti.IsActive= '1'";
        public const string sqlPHdetails = "SELECT pi.DisID, pd.ItemName, pd.percentage,  printf('%.2f', pi.Amount) AS Amount, pi.AmountINR FROM tblPayInvoiceitem pi " +
                            "INNER JOIN tblPayDisbursments pd ON pd.ID = pi.DisID WHERE pi.InvID={0} ";
        public const string sqlPHItem = "SELECT Distinct ItemName FROM tblPayDisbursments WHERE IsActive=1";
        public const string sqlPHItemDetail = "SELECT pi.DisID,pn.InvDate AS InvoiceDate, pn.InvoiceCode As Code,  pd.percentage,  printf('%.2f', pi.Amount) AS Amount, pi.AmountINR FROM tblPayInvoiceitem pi " + 
                            " INNER JOIN tblPayDisbursments pd ON pd.ID = pi.DisID " +
                            " INNER JOIN tblPayInvoice pn ON pn.ID = pi.InvID " +
                            " WHERE pi.DisID in (SELECT ID FROM tblPayDisbursments WHERE lower(Itemname)= '{0}') ";
        public const string sqlCLGetAll = "SELECT Desc, Responsible FROM tblCheckList WHERE IsActive = 1 AND TimeFrame='{0}'";
        public const string sqlTradePlanByAccID = "SELECT Desc FROM tblCheckList WHERE Responsible = '{0}' AND IsActive=1";
    }
}