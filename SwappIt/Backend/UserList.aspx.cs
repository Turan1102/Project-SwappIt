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

            if (Request["closeresponsibleid"] != null)
            {
                ToggleCloseResponsible(Request["closeresponsibleid"].ToString());
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
                                                        "   <td>" + (ui.haveRights("slet") ? "<a href=\"UserList.aspx?closeresponsibleid=" + r["IID"] + "\" class=\"btn default btn-xs" + (r["CloseResponsible"].ToString() == "0" ? " green\"><i class=\"fa fa-unlock-alt\"></i> Ja" : " red\"><i class=\"fa fa-lock\"></i> Nej") + "</a>" : "") + "</td>" +
                            "   <td>" + (ui.haveRights("slet") ? "<a href=\"UserList.aspx?activateid=" + r["IID"] + "\" class=\"btn default btn-xs yellow\">" + (r["Inactive"].ToString() == "0" ? "<i class=\"fa fa-unlock-alt\"></i> Aktiv" : "<i class=\"fa fa-lock\"></i> Deaktiveret") + "</a>" : "") + "</td>" +
                            "</tr>";
            }
        }

    }
}