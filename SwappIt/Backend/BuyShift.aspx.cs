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
    public partial class BuyShift : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Fill();

            if (Request["shiftid"] != null)
            {
                if (Request["command"] == "buy")
                {
                    this.FillFinalBuyShiftTable();
                }
                if (Request["command"] == "trade")
                {
                    this.FillFinalTradeShiftTable();
                }
            }

            if (Request["command"] == "buyCompleye")
            {
                // fill kvittering
            }
            if (Request["command"] == "tradeComplete")
            {
                // fill kvittering
            }

        }

        private void FillFinalBuyShiftTable()
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("shiftId", Request["shiftid"].ToString())); 
            DataTable dt = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, s.IID, s.Date, s.StartTime, s.EndTime, s.Type, s.IsTrade FROM Employee e, Shift s WHERE s.IID = @shiftid AND s.EIID = e.IID", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                string shiftType = convertShiftTypeToString(r["Type"].ToString());
                string date = "";
                int dateindex = r["Date"].ToString().IndexOf(' ');
                if (dateindex > 0)
                {
                    date = r["Date"].ToString().Substring(0, dateindex);
                }

                tableOut3.Text += "<tr>" +
                            "   <td>" + shiftType + "</td>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + date + "</td>" +
                            "   <td>" + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                            "</tr>";

            }

            tableOut3.Text += "<tr>";

            LinkBtnBuyShift.CommandArgument = Request["shiftid"].ToString();
        }

        private void FillFinalTradeShiftTable()
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("shiftId", Request["shiftid"].ToString()));
            DataTable dt = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, s.IID, s.Date, s.StartTime, s.EndTime, s.Type, s.IsTrade FROM Employee e, Shift s WHERE s.IID = @shiftid AND s.EIID = e.IID", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                string shiftType = convertShiftTypeToString(r["Type"].ToString());
                string date = "";
                int dateindex = r["Date"].ToString().IndexOf(' ');
                if (dateindex > 0)
                {
                    date = r["Date"].ToString().Substring(0, dateindex);
                }

                tableOut4.Text += "<tr>" +
                            "   <td>" + shiftType + "</td>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + date + "</td>" +
                            "   <td>" + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                            "</tr>";

            }

            tableOut4.Text += "<tr>";

            LinkBtnTradeShift.CommandArgument = Request["shiftid"].ToString();
        }

        private void Fill()
        {

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("SIID", ui.Siid)); // skal vi evt. tjekke om s.inactive = 0????
            p.Add(new SqlParameter("EIID", ui.Id));
            DataTable dt = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, s.IID, s.Date, s.StartTime, s.EndTime, s.Type, s.IsTrade FROM Employee e, Shift s WHERE s.EIID = e.IID AND s.SIID=@SIID AND s.EIID != @EIID AND s.Type=0 AND s.Inactive=0 ORDER BY Date;", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                string shiftType = convertShiftTypeToString(r["Type"].ToString());
                // kode til at fjerne den ekstra string: 00:00:0000 der medfølger date fra database
                string date = "";
                int dateindex = r["Date"].ToString().IndexOf(' ');
                if (dateindex > 0)
                {
                    date = r["Date"].ToString().Substring(0, dateindex);
                }

                tableOut1.Text += "<tr>" +
                            "   <td>" + shiftType + "</td>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + date + "</td>" +
                            "   <td>" + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                            "   <td>" + "<a href=\"BuyShift.aspx?shiftid=" + r["IID"].ToString() + "&command=" + (r["IsTrade"].ToString() == "0" ? "buy" : "trade") + "\" class=\"btn " + (r["IsTrade"].ToString() == "0" ? "green" : "yellow") + "\"><i class=\"\"></i> " + (r["IsTrade"].ToString() == "0" ? "Køb" : "Byt") + " </a>" + "</td>" +
                            "</tr>";

            }

            tableOut2.Text += "<tr>";

            p.Clear();
            p.Add(new SqlParameter("SIID", ui.Siid)); // skal vi evt. tjekke om s.inactive = 0????
            p.Add(new SqlParameter("EIID", ui.Id));
            DataTable dt2 = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, s.IID, s.Date, s.StartTime, s.EndTime, s.Type, s.IsTrade FROM Employee e, Shift s, shiftToIndividual si WHERE s.EIID = e.IID AND s.SIID = @SIID AND s.EIID != @EIID AND (s.Type=1 OR s.Type=2) AND si.ShiftId = s.IID AND si.EIID = @EIID AND s.Inactive=0 ORDER BY Date;", p).Table;
            foreach (DataRow r in dt2.Rows)
            {
                string shiftType = convertShiftTypeToString(r["Type"].ToString());
                // kode til at fjerne den ekstra string: 00:00:0000 der medfølger date fra database
                string date = "";
                int dateindex = r["Date"].ToString().IndexOf(' ');
                if (dateindex > 0)
                {
                    date = r["Date"].ToString().Substring(0, dateindex);
                }

                tableOut2.Text += "<tr>" +
                            "   <td>" + shiftType + "</td>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + date + "</td>" +
                            "   <td>" + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                            "   <td>" + "<a href=\"BuyShift.aspx?shiftid=" + r["IID"].ToString() + "&command=" + (r["IsTrade"].ToString() == "0" ? "buy" : "trade") + "\" class=\"btn " + (r["IsTrade"].ToString() == "0" ? "green" : "yellow") + "\"><i class=\"\"></i> " + (r["IsTrade"].ToString() == "0" ? "Køb" : "Byt") + " </a>" + "</td>" +
                            "</tr>";
            }

        }



        protected void BuyShift_Execute(object sender, EventArgs e)
        {

                LinkButton btn = (LinkButton)(sender);
                if (btn.CommandArgument != "decline")
                {
                    string shiftId = btn.CommandArgument;
                    if (!CheckIfAlreadyBought(shiftId))
                    {
                        List<SqlParameter> p = new List<SqlParameter>();
                        p.Add(new SqlParameter("ShiftID", shiftId));
                        string SQL1 = "UPDATE Shift SET Inactive=1 WHERE IID=@ShiftID";
                        db.ExecuteUpdate(SQL1, p);

                        p.Clear();
                        p.Add(new SqlParameter("ShiftID", shiftId));
                        p.Add(new SqlParameter("EIID", ui.Id));
                        string SQL2 = "INSERT INTO BuyShiftComplete (ShiftId, BuyerEIID) VALUES (@ShiftID, @EIID)";
                        db.ExecuteInsert(SQL2, p);

                        Response.Redirect("BuyShift.aspx?command=buyComplete&shiftid="+shiftId);

                    }
                }
                else
                {
                    Response.Redirect("BuyShift.aspx");
                }
        }

        protected void TradeShift_Execute(object sender, EventArgs e)
        {

            if (validateShiftDate.IsValid)
            {
                LinkButton btn = (LinkButton)(sender);
                if (btn.CommandArgument != "decline")
                {
                    string shiftId = btn.CommandArgument;
                    if (!CheckIfAlreadyBought(shiftId))
                    {

                        string date = shiftDate.Value;
                        string timeStart = startTime.Value;
                        string timeEnd = endTime.Value;

                        List<SqlParameter> p = new List<SqlParameter>();
                        p.Add(new SqlParameter("Date", date));
                        p.Add(new SqlParameter("StartTime", timeStart));
                        p.Add(new SqlParameter("EndTime", timeEnd));
                        p.Add(new SqlParameter("SIID", ui.Siid));
                        p.Add(new SqlParameter("EIID", ui.Id));
                        p.Add(new SqlParameter("Type", "4"));

                        string SQL1 = "INSERT INTO Shift (SIID, EIID, Date, StartTime, EndTime, Type) VALUES (@SIID, @EIID, @Date, @StartTime, @EndTime, @Type)";
                        int responseShiftId = db.ExecuteInsert(SQL1, p);

                        string note = shiftNote.Value;

                        p.Clear();
                        p.Add(new SqlParameter("ResponseEIID", ui.Id));
                        p.Add(new SqlParameter("ResponseShiftId", responseShiftId));
                        p.Add(new SqlParameter("RequestShiftId", shiftId));
                        p.Add(new SqlParameter("Note", note));

                        string SQL2 = "INSERT INTO ResponseTrade (ResponseEIID, ResponseShiftId, RequestShiftId, Note) VALUES (@ResponseEIID, @ResponseShiftId, @RequestShiftId, @Note)";
                        db.ExecuteInsert(SQL2, p);

                        Response.Redirect("BuyShift.aspx?command=tradeComplete&resquestShiftId=" + shiftId + "&responseShiftId="+responseShiftId);
                    }
                }
                else
                {
                    Response.Redirect("BuyShift.aspx");
                }
            }

        }


        

        // nødvendigt at tjekke om en vagt allerede er købt, så man ikke kan trykke 'køb' for 2. gang 
        // (hvis nu fx siden ikke reloader og derfor vagten ikke forsvinder fra tabellen)
        private Boolean CheckIfAlreadyBought(string shiftId)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("ShiftID", shiftId));
            DataTable dt = db.GetDataSet("SELECT ShiftID FROM BuyShiftComplete WHERE ShiftID=@ShiftID;", p).Table;

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        protected void validateShiftDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (shiftDate.Value != "")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }


    }
}