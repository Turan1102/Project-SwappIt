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

        }

        private void FillCurrentSellingShifts()
        {
            tableOut3.Text = "";

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", ui.Id));
            DataTable dt = db.GetDataSet("SELECT CreateTime, Date, StartTime, EndTime, Type, IsTrade, Inactive FROM Shift WHERE EIID = @EIID AND (Type = 0 OR Type = 1 OR Type = 2) ORDER BY Date", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                // kode til at fjerne den ekstra string: 00:00:0000 der medfølger date fra database
                string shiftType = convertShiftTypeToString(r["Type"].ToString());
                string shiftDate = dateFormater(r["Date"].ToString());
                string saleDate = dateFormater(r["CreateTime"].ToString());


                tableOut3.Text += "<tr>" +
                            "   <td>" + shiftType + "</td>" +
                            "   <td>" + (r["IsTrade"].ToString() == "0" ? "Nej" : "Ja") + "</td>" +
                            "   <td>" + saleDate + "</td>" +
                            "   <td>" + shiftDate + "</td>" +
                            "   <td>" + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                            "   <td>" + (r["Inactive"].ToString() == "0" ? "Til salg" : "Solgt") + "</td>" +
                                "</tr>";
            }
        }

        private void FillBoughtShiftsTable()
        {

            tableOut1.Text = "";

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", ui.Id));
            DataTable dt = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, s.Date, s.StartTime, s.EndTime, bsc.CreateTime FROM Employee e, Shift s, BuyShiftComplete bsc WHERE s.IID = bsc.ShiftID AND bsc.BuyerEIID = @EIID AND s.EIID = e.IID ORDER BY Date", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                 // kode til at fjerne den ekstra string: 00:00:0000 der medfølger date fra database
                string shiftDate = dateFormater(r["Date"].ToString());
                string bougthDate = dateFormater(r["CreateTime"].ToString());


                tableOut1.Text += "<tr>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + shiftDate + "</td>" +
                            "   <td>" + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                            "   <td>" + bougthDate + "</td>" +
                                "</tr>";
            }
        }

        private void FillSoldShiftsTable()
        {
            tableOut2.Text = "";

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", ui.Id));
            DataTable dt = db.GetDataSet("SELECT  e.Firstname, e.Middlename, e.Lastname, s.Date, s.StartTime, s.EndTime, bsc.CreateTime FROM Employee e, Shift s, BuyShiftComplete bsc WHERE s.EIID = @EIID AND s.IID = bsc.ShiftID AND bsc.BuyerEIID = e.IID ORDER BY Date;", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                // kode til at fjerne den ekstra string: 00:00:0000 der medfølger date fra database
                string shiftDate = dateFormater(r["Date"].ToString());
                string soldDate = dateFormater(r["CreateTime"].ToString());


                tableOut2.Text += "<tr>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + shiftDate + "</td>" +
                            "   <td>" + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                            "   <td>" + soldDate + "</td>" +
                                "</tr>";
            }
        }

    }
}