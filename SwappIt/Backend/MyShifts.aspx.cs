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
    public partial class MyShifts : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            FillBoughtShiftsTable();
            FillSoldShiftsTable();
            FillCurrentSellingShifts();

            if (Request["command"] != null)
            {
                if (Request["command"] == "shiftDetails")
                {
                    this.FillShiftDetails();
                }
            }

        }

        private void FillCurrentSellingShifts()
        {
            tableOut3.Text = "";

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", ui.Id));
            DataTable dt = db.GetDataSet("SELECT IID, CreateTime, Date, StartTime, EndTime, Type, IsTrade FROM Shift WHERE EIID = @EIID AND (Type = 0 OR Type = 1 OR Type = 2) AND Inactive = 0 ORDER BY Date", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                if (!this.CheckIfShiftBought(r["IID"].ToString()))
                {
                    string shiftType = (r["IsTrade"].ToString() == "1" ? "Byttevagt til " + this.convertShiftTypeToString(r["Type"].ToString().ToLower()) : this.convertShiftTypeToString(r["Type"].ToString().ToLower()));
                    string shiftDate = dateFormater(r["Date"].ToString());
                    string saleDate = dateFormater(r["CreateTime"].ToString());

                    tableOut3.Text += "<tr>" +
                                "   <td>" + shiftType + "</td>" +
                                "   <td>" + saleDate + "</td>" +
                                "   <td>" + shiftDate + " kl. " + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                                "   <td> <a href=\"MyShifts.aspx?shiftid=" + r["IID"].ToString() + "&command=shiftDetails\" class=\"btn green\"><i class=\"\"></i> Vis </a>" + "</td>" +

                                    "</tr>";
                }
            }
        }

        private void FillBoughtShiftsTable()
        {

            tableOut1.Text = "";

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", ui.Id));
            DataTable dt = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, s.IID, s.Date, s.StartTime, s.EndTime, bsc.CreateTime FROM Employee e, Shift s, BuyShiftComplete bsc WHERE s.IID = bsc.ShiftID AND bsc.BuyerEIID = @EIID AND s.EIID = e.IID ORDER BY Date", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                string shiftDate = dateFormater(r["Date"].ToString());
                string bougthDate = dateFormater(r["CreateTime"].ToString());


                tableOut1.Text += "<tr>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + shiftDate + " kl. " + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                            "   <td>" + bougthDate + "</td>" +
                            "   <td> <a href=\"MyShifts.aspx?shiftid=" + r["IID"].ToString() + "&command=shiftDetails\" class=\"btn green\"><i class=\"\"></i> Vis </a>" + "</td>" +
                                "</tr>";
            }
        }

        private void FillSoldShiftsTable()
        {
            tableOut2.Text = "";

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", ui.Id));
            DataTable dt = db.GetDataSet("SELECT  e.Firstname, e.Middlename, e.Lastname, s.IID, s.Date, s.StartTime, s.EndTime, s.IsTrade, bsc.CreateTime FROM Employee e, Shift s, BuyShiftComplete bsc WHERE s.EIID = @EIID AND s.IID = bsc.ShiftID AND bsc.BuyerEIID = e.IID ORDER BY Date;", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                // kode til at fjerne den ekstra string: 00:00:0000 der medfølger date fra database
                string shiftDate = dateFormater(r["Date"].ToString());
                string soldDate = dateFormater(r["CreateTime"].ToString());


                tableOut2.Text += "<tr>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + shiftDate + " kl. " + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                            "   <td>" + soldDate + "</td>" +
                            "   <td> <a href=\"MyShifts.aspx?shiftid=" + r["IID"].ToString() + "&command=shiftDetails\" class=\"btn green\"><i class=\"\"></i> Vis </a>" + "</td>" +
                                "</tr>";
            }
        }


        private void FillShiftDetails()
        {
            string shiftId = Request["shiftid"].ToString();

            // pick from database start
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("shiftId", shiftId));
            DataTable dt1 = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, s.CreateTime, s.Date, s.StartTime, s.EndTime, s.Type, s.IsTrade, s.TradeType FROM Shift s, Employee e WHERE s.IID = @shiftId AND s.EIID = e.IID", p).Table;


            DataTable dt2 = null;
            if (dt1.Rows[0]["IsTrade"].ToString() == "1")
            {
                p.Clear();
                p.Add(new SqlParameter("shiftId", shiftId));
                dt2 = db.GetDataSet("SELECT * FROM ResponseTrade WHERE RequestShiftId = @shiftId", p).Table;
            }

            p.Clear();
            p.Add(new SqlParameter("shiftId", shiftId));
            DataTable dt3 = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, bsc.BuyerEIID, bsc.CreateTime FROM BuyShiftComplete bsc, Employee e WHERE bsc.ShiftID = @shiftId AND bsc.BuyerEIID = e.IID", p).Table;

            Boolean shiftSold = false;
            if (dt3.Rows.Count > 0)
            {
                shiftSold = true;
            }
            // pick from database end

            if(dt1.Rows.Count > 0){
                DataRow r1 = dt1.Rows[0];

                string shiftType = (r1["IsTrade"].ToString() == "1" ? "Byttevagt til " + this.convertShiftTypeToString(r1["Type"].ToString().ToLower()) : this.convertShiftTypeToString(r1["Type"].ToString().ToLower()));
                tableOut4.Text = this.CreateShiftDetailTableElement(tableOut4.Text, "Vagttype", shiftType);

                tableOut4.Text = this.CreateShiftDetailTableElement(tableOut4.Text, "Oprettelsesdato", this.dateFormater(r1["CreateTime"].ToString()));

                string sellerName = r1["Firstname"].ToString() + " " + (r1["Middlename"].ToString() != "" ? (r1["Middlename"].ToString()) + " " : "") + r1["Lastname"].ToString();
                tableOut4.Text = this.CreateShiftDetailTableElement(tableOut4.Text, (shiftSold ? (r1["IsTrade"].ToString() == "1" ? "Byttet væk af" : "Solgt af") : (r1["IsTrade"].ToString() == "1" ? "Bytter" : "Sælger")), sellerName);

                if (shiftSold)
                {
                    DataRow r3 = dt3.Rows[0];
                    string buyerName = r3["Firstname"].ToString() + " " + (r3["Middlename"].ToString() != "" ? (r3["Middlename"].ToString()) + " " : "") + r3["Lastname"].ToString();
                    tableOut4.Text = this.CreateShiftDetailTableElement(tableOut4.Text,(r1["IsTrade"].ToString() == "1" ? "Byttet med" : "Solgt til"), buyerName);
                }


                string shiftDate = dateFormater(r1["Date"].ToString()) + " kl. " + r1["StartTime"].ToString() + " - " + r1["EndTime"].ToString();
                tableOut4.Text = this.CreateShiftDetailTableElement(tableOut4.Text, "Vagttid", shiftDate);


                if (r1["IsTrade"].ToString() == "1")
                {
                    if (dt2.Rows.Count > 0)
                    {
                        DataRow r2 = dt2.Rows[0];
                        tableOut4.Text = this.CreateShiftDetailTableElement(tableOut4.Text, "Bytte note", r2["ResponseNote"].ToString());
                    }
                }

                if (shiftSold)
                {
                    DataRow r3 = dt3.Rows[0];
                    tableOut4.Text = this.CreateShiftDetailTableElement(tableOut4.Text, "Salgsdato", this.dateFormater(r3["CreateTime"].ToString()));
                }
            }
        }

        private string CreateShiftDetailTableElement(string tableOut, string name, string value)
        {

            tableOut +=
            "<tr>" +
                " <td>" +
                     name +
             " </td>" +
              " <td>" +
                     value +
               " </td>" +
            " <tr>";

            return tableOut;
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyShifts.aspx");
        }

    }



}