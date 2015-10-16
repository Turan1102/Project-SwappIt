using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.code;
using System.Data;
using System.Data.SqlClient;

namespace Backend
{
    public partial class SellShift : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Fill();
            }

        }

        private void Fill()
        {
            this.fillIndividualDD();
        }

        protected void SellShift_Click(object sender, EventArgs e)
        {
            this.createShiftSessions();
            LinkButton btn = (LinkButton)(sender);
            switch (btn.CommandArgument)
            {
                case "0":
                        Response.Redirect("SellShift.aspx?shiftType=0");
                    break;
                case "1":
                        Response.Redirect("SellShift.aspx?shiftType=1");
                    break;
                case "2":
                        Response.Redirect("SellShift.aspx?shiftType=2");
                    break;
                case "decline":
                    Response.Redirect("SellShift.aspx");
                    return;
            }
        }

        private string GetTradeTypeFromRadios(string shiftType)
        {
            string result = "-1";
            switch (shiftType)
            {
                case "0":
                    if (radioTrade1.Checked)
                    {
                        result = "0";
                    }
                    if (radioSellTrade1.Checked)
                    {
                        result = "1";
                    }
                    break;
                case "1":
                    if (radioTrade2.Checked)
                    {
                        result = "0";
                    }
                    if (radioSellTrade2.Checked)
                    {
                        result = "1";
                    }
                    break;
                case "2":
                    if (radioTrade3.Checked)
                    {
                        result = "0";
                    }
                    if (radioSellTrade3.Checked)
                    {
                        result = "1";
                    }
                    break;
            }
            return result;
        }


        private void createShiftSessions()
        {

            Session["shiftDate0"] = shiftDate0.Value;
            Session["startTime0"] = startTime0.Value;
            Session["endTime0"] = endTime0.Value;
            Session["tradeType0"] = convertTradeTypeToString(this.GetTradeTypeFromRadios("0"));
            this.createSqlParameterSession("0", shiftDate0.Value, startTime0.Value, endTime0.Value);

            Session["shiftDate1"] = shiftDate1.Value;
            Session["startTime1"] = startTime1.Value;
            Session["endTime1"] = endTime1.Value;
            Session["tradeType1"] = convertTradeTypeToString(this.GetTradeTypeFromRadios("1"));
            this.createSqlParameterSession("1", shiftDate1.Value, startTime1.Value, endTime1.Value);

            Session["shiftDate2"] = shiftDate2.Value;
            Session["startTime2"] = startTime2.Value;
            Session["endTime2"] = endTime2.Value;
            Session["tradeType2"] = convertTradeTypeToString(this.GetTradeTypeFromRadios("2"));
            this.createSqlParameterSession("2", shiftDate2.Value, startTime2.Value, endTime2.Value);

            Session["IndividualDD"] = individualDD.Items;
        }

        private void createSqlParameterSession(string shiftType, string date, string timeStart, string timeEnd)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("Date", date));
            p.Add(new SqlParameter("StartTime", timeStart));
            p.Add(new SqlParameter("EndTime", timeEnd));
            p.Add(new SqlParameter("SIID", ui.Siid));
            p.Add(new SqlParameter("EIID", ui.Id));
            p.Add(new SqlParameter("Type", shiftType));
            p.Add(new SqlParameter("IsTrade", (this.GetTradeTypeFromRadios(shiftType) != "-1" ? "1" : "0")));
            p.Add(new SqlParameter("TradeType", this.GetTradeTypeFromRadios(shiftType)));
            Session["SqlParameter" + shiftType] = p;
        }

        protected void SellShiftToAllButton_Click(object sender, EventArgs e)
        {

            List<SqlParameter> p = (List<SqlParameter>)Session["SqlParameter0"];
            string SQL = "INSERT INTO Shift (SIID, EIID, Date, StartTime, EndTime, Type, IsTrade, TradeType) VALUES (@SIID, @EIID, @Date, @StartTime, @EndTime, @Type, @IsTrade, @TradeType)";
            db.ExecuteInsert(SQL, p);         

        }

        protected void SellShiftToIndividualButton_Click(object sender, EventArgs e)
        {

            List<SqlParameter> p = (List<SqlParameter>)Session["SqlParameter1"];
            string SQL = "INSERT INTO Shift (SIID, EIID, Date, StartTime, EndTime, Type, IsTrade, TradeType) VALUES (@SIID, @EIID, @Date, @StartTime, @EndTime, @Type, @IsTrade, @TradeType)";
            int primaryKey = db.ExecuteInsert(SQL, p);

            p.Clear();
            foreach (ListItem i in (ListItemCollection)Session["IndividualDD"])
            {
                if (i.Selected)
                {
                    p.Add(new SqlParameter("SIID", ui.Siid));
                    p.Add(new SqlParameter("ShiftId", primaryKey));
                    p.Add(new SqlParameter("EIID", i.Value));

                    string SQL1 = "INSERT INTO ShiftToIndividual (SIID, ShiftId, EIID) VALUES (@SIID, @ShiftId, @EIID)";

                    db.ExecuteInsert(SQL1, p);
                    p.Clear();
                }
            }

        }

        protected void SellShiftToCloseResponsibleButton_Click(object sender, EventArgs e)
        {
            List<SqlParameter> p = (List<SqlParameter>)Session["SqlParameter2"];
            string SQL = "INSERT INTO Shift (SIID, EIID, Date, StartTime, EndTime, Type, IsTrade, TradeType) VALUES (@SIID, @EIID, @Date, @StartTime, @EndTime, @Type, @IsTrade, @TradeType)";

            int primaryKey = db.ExecuteInsert(SQL, p);
            p.Clear();

            string SQL1 = "SELECT IID FROM Employee WHERE CloseResponsible= 1 AND SIID=" + ui.Siid + " AND IID !=" + ui.Id;
            DataTable dt = db.GetDataSet(SQL1).Table;
            foreach (DataRow r in dt.Rows)
            {
                p.Add(new SqlParameter("SIID", ui.Siid));
                p.Add(new SqlParameter("ShiftId", primaryKey));
                p.Add(new SqlParameter("EIID", r["IID"].ToString()));

                string SQL2 = "INSERT INTO ShiftToIndividual (SIID, ShiftId, EIID) VALUES (@SIID, @ShiftId, @EIID)";

                db.ExecuteInsert(SQL2, p);
                p.Clear();
            }
        }

        private void fillIndividualDD()
        {

            if (Session["IndividualDD"] != null)
            {
                foreach (ListItem i in (ListItemCollection)Session["IndividualDD"])
                {
                    individualDD.Items.Add(i);
                }
            }
            else
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("SIID", ui.Siid));
                DataTable dt = db.GetDataSet("SELECT * FROM Employee WHERE SIID=@SIID ORDER BY Firstname", p).Table;

                foreach (DataRow r in dt.Rows)
                {
                    individualDD.Items.Add(new ListItem(r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString(), r["IID"].ToString()));
                }
            }

        }
           
    }
}