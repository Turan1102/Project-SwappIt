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
    public partial class UserList : AdminPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["deleteid"] != null)
            {
                Delete(Request["deleteid"].ToString());
            }
            if (Request["activateid"] != null)
            {
                ToggleEmployeeInactive(Request["activateid"].ToString());
            }

            if (ui.haveRights("list"))
            {
                if (Page.IsPostBack)
                {
                    string searchTextValue = searchText.Value;
                    string searchSql = "AND (Firstname LIKE '%" + searchTextValue + "%' OR Lastname LIKE '%" + searchTextValue + "%' OR Middlename LIKE '%" + searchTextValue + "%' OR StaffNumber LIKE '%" + searchTextValue + "%' OR CPR LIKE '%" + searchTextValue + "%')";
                    Fill(searchSql);
                }
                else
                {
                    Fill("");
                }
            }

        }

        private void Fill(string searchtext)
        {
            tableOut.Text = "";

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("SIID", ui.Siid));
            DataTable dt = db.GetDataSet("SELECT * FROM Employee WHERE SIID=@SIID " + searchtext + " ORDER BY Inactive, Firstname", p).Table;

            if (Page.IsPostBack)
            {
                searchTotal.Text = "(Antal: " + dt.Rows.Count + ")";
            }
            
            foreach (DataRow r in dt.Rows)
            {
                tableOut.Text += "<tr>" +
                            "   <td>" + r["StaffNumber"].ToString() + "</td>" +
                            "   <td>" + r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString() + "</td>" +
                            "   <td>" + r["CPR"].ToString() + "</td>" +

                            "   <td>" + (ui.haveRights("slet") ? "<a href=\"UserEdit.aspx?id=" + r["IID"] + "\" class=\"btn default btn-xs yellow\"><i class=\"fa fa-edit\"></i> Ret</a>" : "") + "</td>" +
                            "   <td>" + (ui.haveRights("slet") ? "<a href=\"UserList.aspx?activateid=" + r["IID"] + "\" class=\"btn default btn-xs yellow\">" + (r["Inactive"].ToString() == "0" ? "<i class=\"fa fa-unlock-alt\"></i> Aktiv" : "<i class=\"fa fa-lock\"></i> Deaktiveret") + "</a>" : "") + "</td>" +
                            "   <td>" + (ui.haveRights("slet") ? "<a href=\"UserList.aspx?deleteid=" + r["IID"]  + "\" class=\"btn default btn-xs red btn-confirm\"><i class=\"fa fa-trash-o\"></i> Slet</a>" : "") + "</td>" +
                            "</tr>";
            }
        }

        public void Delete(string id)
        {
            if (ui.haveRights("slet"))
            {
                List<SqlParameter> p1 = new List<SqlParameter>();
                p1.Add(new SqlParameter("IID", id));
                DataTable dt1 = db.GetDataSet("SELECT * FROM Employee WHERE IID=@IID", p1).Table;
                if (dt1.Rows.Count > 0)
                {
                    List<SqlParameter> p2 = new List<SqlParameter>();
                    p2.Add(new SqlParameter("IID", id));
                    db.ExecuteDelete("DELETE FROM Employee WHERE IID=@IID", p2);
                    // AddToastrSucces("Slettet", "Bruger " + r["Name"] + " er blevet slettet");
                }
            }
        }


    }
}