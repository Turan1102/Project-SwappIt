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

        }

        private void Fill()
        {
            tableOut.Text = "";

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("SIID", ui.Siid)); // skal vi evt. tjekke om s.inactive = 0????
            p.Add(new SqlParameter("EIID", ui.Id));
            DataTable dt = db.GetDataSet("SELECT e.Firstname, e.Middlename, e.Lastname, s.IID, s.Date, s.StartTime, s.EndTime FROM Employee e, Shift s WHERE s.EIID = e.IID AND s.SIID=@SIID AND s.EIID != @EIID AND s.Type=0 AND s.Inactive=0 ORDER BY Date;", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                // kode til at fjerne den ekstra string: 00:00:0000 der medfølger date fra database
                string date = "";
                int dateindex = r["Date"].ToString().IndexOf(' ');
                if (dateindex > 0)
                {
                    date = r["Date"].ToString().Substring(0, dateindex);
                }

                tableOut.Text += "<tr>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + date + "</td>" +
                            "   <td>" + r["StartTime"].ToString() + " - " + r["EndTime"].ToString() + "</td>" +
                            "   <td>" + "<a class=\"btn green\" data-toggle=\"modal\" href=\"#ConfirmBuy\" OnClick=\"SetCurrentShiftId(" + r["IID"].ToString() + ");\"> Køb </a>" + "</td>" +
                                "</tr>";
            }
            
        }

        protected void Buy_Click(object sender, EventArgs e)
        {
            // CurrentShiftId er fra HiddenField i aspx, som indeholder shiftid for den klikkede vagt
            string id = CurrentShiftId.Value;

            if (!CheckIfAlreadyBought(id))
            {

                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("ShiftID", id));
                string SQL1 = "UPDATE Shift SET Inactive=1 WHERE IID=@ShiftID";
                db.ExecuteUpdate(SQL1, p);

                p.Clear();
                p.Add(new SqlParameter("ShiftID", id));
                p.Add(new SqlParameter("EIID", ui.Id));
                string SQL2 = "INSERT INTO BuyShiftComplete (ShiftId, BuyerEIID) VALUES (@ShiftID, @EIID)";
                db.ExecuteInsert(SQL2, p);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "showDialogue", "showDialogue()", true);
            }

        }

        // denne metode bruges bl.a. til at reloade side, når en vagt er købt, så den forsvinder fra tabellen. 
        protected void RefreshPage_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
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

        //private Boolean CheckIfBuyingOwnShift(string eiid, string shiftid)
        //{
        //    List<SqlParameter> p = new List<SqlParameter>();
        //    p.Add(new SqlParameter("IID", shiftid));
        //    DataTable dt = db.GetDataSet("SELECT EIID FROM Shift WHERE IID=@IID;", p).Table;

        //    if (dt.Rows[0]["EIID"].ToString().Equals(eiid))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

    }
}