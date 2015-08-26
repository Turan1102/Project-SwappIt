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
            if (Request["BuyShiftId"] != null)
            {
                Buy(Request["BuyShiftId"].ToString());
            }

            Fill();            

        }

        private void Fill()
        {
            tableOut.Text = "";

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("SIID", ui.Siid)); // skal vi evt. tjekke om s.inactive = 0????
            DataTable dt = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, s.IID, s.Date, s.StartTime, s.EndTime FROM Employee e, Shift s WHERE s.EIID = e.IID AND s.SIID=@SIID AND s.Type=0 AND s.Inactive=0 ORDER BY Date;", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                tableOut.Text += "<tr>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + r["Date"].ToString() + "</td>" +
                            "   <td>" + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                            "   <td>" + "<a href=\"BuyShift.aspx?BuyShiftId=" + r["IID"] + "\" class=\"btn default btn-xs green btn-confirm\"><i class=\"fa fa-shopping-cart\"></i> Køb</a>" + "</td>" +
                                "</tr>";
            }
        }

        private void Buy(string id)
        {
            if (CheckIfBuyingOwnShift(id))
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("ShiftID", id));
                p.Add(new SqlParameter("EIID", ui.Id));
                string SQL1 = "UPDATE Shift SET Inactive=1 WHERE IID=@ShiftID";
                db.ExecuteUpdate(SQL1, p);

                string SQL2 = "INSERT INTO BuyShiftComplete (ShiftId, BuyerEIID) VALUES (@ShiftID, @EIID)";
                db.ExecuteInsert(SQL2, p);  
            }

            // fyr en fejlbesked popup af med at man køber egen vagt
        }

        private Boolean CheckIfBuyingOwnShift(string IID)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("IID", IID));
            DataTable dt = db.GetDataSet("SELECT EIID FROM Shift WHERE IID=@IID;", p).Table;

            if (dt.Rows.Count > 0)
            {
                return false;
            }

            return true; 
        }
    }
}