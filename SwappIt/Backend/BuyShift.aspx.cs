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
            tableOut3.Text = "";
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("shiftId", Request["shiftid"].ToString()));
            DataTable dt = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, s.IID, s.Date, s.StartTime, s.EndTime, s.Type, s.IsTrade, s.Note FROM Employee e, Shift s WHERE s.IID = @shiftid AND s.EIID = e.IID", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                string shiftType = (r["IsTrade"].ToString() == "1" ? "Byttevagt til " + this.convertShiftTypeToString(r["Type"].ToString().ToLower()) : this.convertShiftTypeToString(r["Type"].ToString().ToLower()));
                string shiftDate = dateFormater(r["Date"].ToString());

                tableOut3.Text += "<tr>" +
                            "   <td>" + shiftType + "</td>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + shiftDate + " kl. " + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                            "   <td>" + (r["Note"].ToString() != "" ? r["Note"].ToString() : " - ") +"</td>" +
                            "</tr>";

            }

            tableOut3.Text += "<tr>";

            LinkBtnBuyShift.CommandArgument = Request["shiftid"].ToString();
        }

        private void FillFinalTradeShiftTable()
        {
            tableOut4.Text = "";
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("shiftId", Request["shiftid"].ToString()));
            DataTable dt = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, s.IID, s.Date, s.StartTime, s.EndTime, s.Type, s.IsTrade, s.Note FROM Employee e, Shift s WHERE s.IID = @shiftid AND s.EIID = e.IID", p).Table;
            
            foreach (DataRow r in dt.Rows)
            {
                string shiftType = (r["IsTrade"].ToString() == "1" ? "Byttevagt til " + this.convertShiftTypeToString(r["Type"].ToString().ToLower()) : this.convertShiftTypeToString(r["Type"].ToString().ToLower()));
                string shiftDate = dateFormater(r["Date"].ToString());

                tableOut4.Text += "<tr>" +
                            "   <td>" + shiftType + "</td>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + shiftDate + " kl. " + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                            "   <td>" + (r["Note"].ToString() != "" ? r["Note"].ToString() : " - ") + "</td>" +
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
            DataTable dt = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, s.IID, s.Date, s.StartTime, s.EndTime, s.Type, s.IsTrade, s.TradeType FROM Employee e, Shift s WHERE s.EIID = e.IID AND s.SIID=@SIID AND s.EIID != @EIID AND s.Type=0 AND s.Inactive=0 ORDER BY Date;", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                string shiftType = (r["IsTrade"].ToString() == "1" ? "Byttevagt til " + this.convertShiftTypeToString(r["Type"].ToString().ToLower()) : this.convertShiftTypeToString(r["Type"].ToString().ToLower()));
                string shiftDate = dateFormater(r["Date"].ToString());

                tableOut1.Text += "<tr>" +
                            "   <td>" + shiftType + "</td>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + shiftDate + " kl. " + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>";

                if (r["IsTrade"].ToString() != "0")
                {
                    switch (r["TradeType"].ToString())
                    {
                        case "0":
                            tableOut1.Text += "   <td>" + "<a href=\"BuyShift.aspx?shiftid=" + r["IID"].ToString() + "&command=trade\" class=\"btn yellow\"><i class=\"\"></i> Byt </a>" + "</td>";
                            break;
                        case "1":
                            tableOut1.Text += "   <td>" + "<a href=\"BuyShift.aspx?shiftid=" + r["IID"].ToString() + "&command=trade\" class=\"btn yellow\"><i class=\"\"></i> Byt </a>";
                            tableOut1.Text += "<a href=\"BuyShift.aspx?shiftid=" + r["IID"].ToString() + "&command=buy\" class=\"btn green\"><i class=\"\"></i> Køb </a>" + "</td>";
                            break;
                    }
                }
                else
                {
                    tableOut1.Text += "   <td>" + "<a href=\"BuyShift.aspx?shiftid=" + r["IID"].ToString() + "&command=buy\" class=\"btn green\"><i class=\"\"></i> Køb </a>" + "</td>";
                }
                tableOut1.Text += "</tr>";

            }


            p.Clear();
            p.Add(new SqlParameter("SIID", ui.Siid)); // skal vi evt. tjekke om s.inactive = 0????
            p.Add(new SqlParameter("EIID", ui.Id));
            DataTable dt2 = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, s.IID, s.Date, s.StartTime, s.EndTime, s.Type, s.IsTrade, s.TradeType FROM Employee e, Shift s, shiftToIndividual si WHERE s.EIID = e.IID AND s.SIID = @SIID AND s.EIID != @EIID AND (s.Type=1 OR s.Type=2) AND si.ShiftId = s.IID AND si.EIID = @EIID AND s.Inactive=0 ORDER BY Date;", p).Table;
            foreach (DataRow r in dt2.Rows)
            {
                string shiftType = (r["IsTrade"].ToString() == "1" ? "Byttevagt til " + this.convertShiftTypeToString(r["Type"].ToString().ToLower()) : this.convertShiftTypeToString(r["Type"].ToString().ToLower()));
                string shiftDate = dateFormater(r["Date"].ToString());

                tableOut2.Text += "<tr>" +
                            "   <td>" + shiftType + "</td>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + shiftDate + " kl. " + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>";
                if (r["IsTrade"].ToString() == "1")
                {
                    switch (r["TradeType"].ToString())
                    {
                        case "0":
                            tableOut2.Text += "   <td>" + "<a href=\"BuyShift.aspx?shiftid=" + r["IID"].ToString() + "&command=trade\" class=\"btn yellow\"><i class=\"\"></i> Byt </a>" + "</td>";
                            break;
                        case "1":
                            tableOut2.Text += "   <td>" + "<a href=\"BuyShift.aspx?shiftid=" + r["IID"].ToString() + "&command=trade\" class=\"btn yellow\"><i class=\"\"></i> Byt </a>";
                            tableOut2.Text += "<a href=\"BuyShift.aspx?shiftid=" + r["IID"].ToString() + "&command=buy\" class=\"btn green\"><i class=\"\"></i> Køb </a>" + "</td>";
                            break;
                    }
                }
                else
                {
                    tableOut2.Text += "   <td>" + "<a href=\"BuyShift.aspx?shiftid=" + r["IID"].ToString() + "&command=buy\" class=\"btn green\"><i class=\"\"></i> Køb </a>" + "</td>";
                }
                tableOut2.Text += "</tr>";

            }
        }



        protected void BuyShift_Execute(object sender, EventArgs e)
        {

                LinkButton btn = (LinkButton)(sender);
                if (btn.CommandArgument != "decline")
                {
                    string shiftId = btn.CommandArgument;
                    if (!CheckIfShiftBought(shiftId))
                    {
                        this.ToggleShiftInactive(shiftId);

                        List<SqlParameter> p = new List<SqlParameter>();
                        p.Add(new SqlParameter("ShiftID", shiftId));
                        p.Add(new SqlParameter("EIID", ui.Id));
                        db.ExecuteInsert("INSERT INTO BuyShiftComplete (ShiftId, BuyerEIID) VALUES (@ShiftID, @EIID)", p);

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

            LinkButton btn = (LinkButton)(sender);
            if (btn.CommandArgument != "decline")
            {
                if (validateShiftNote.IsValid)
                {
                    string shiftId = btn.CommandArgument;
                    if (!CheckIfShiftBought(shiftId))
                    {

                        this.ToggleShiftInactive(shiftId);

                        List<SqlParameter> p = new List<SqlParameter>();
                        p.Clear();
                        p.Add(new SqlParameter("ShiftID", shiftId));
                        p.Add(new SqlParameter("EIID", ui.Id));
                        db.ExecuteInsert("INSERT INTO BuyShiftComplete (ShiftId, BuyerEIID) VALUES (@ShiftID, @EIID)", p);


                        string note = shiftNote.Value;

                        p.Clear();
                        p.Add(new SqlParameter("ResponseEIID", ui.Id));
                        p.Add(new SqlParameter("RequestShiftId", shiftId));
                        p.Add(new SqlParameter("Note", note));
                        db.ExecuteInsert("INSERT INTO ResponseTrade (ResponseEIID, RequestShiftId, ResponseNote) VALUES (@ResponseEIID, @RequestShiftId, @Note)", p);

                        Response.Redirect("BuyShift.aspx?command=tradeComplete&resquestShiftId=" + shiftId);
                    }
                }
            }
            else
            {
                Response.Redirect("BuyShift.aspx");
            }

        }

        protected void validateShiftNote_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (shiftNote.Value != "")
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