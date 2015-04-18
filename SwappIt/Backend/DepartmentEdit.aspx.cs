using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.code;
using System.Data.SqlClient;
using System.Data;

namespace Backend
{
    public partial class DepartmentEdit : AdminPage
    {
        int currentId;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (ui.haveRights("opret") && Request["id"] != null
                || Request["NewDepartment"] != null && ui.haveRights("opret"))
            {
                if (Request["NewDepartment"] != "true")
                {
                    currentId = int.Parse(Request["id"].ToString());
                    if (!Page.IsPostBack)
                    {
                        this.Fill();
                    }
                }
            }
            else
            {
                Server.Transfer("DepartmentList.aspx");
            }

        }

        private void Fill()
        {

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("IID", currentId));
            DataTable dt = db.GetDataSet("SELECT Code, Name FROM Department WHERE IID=@IID", p).Table;
            DataRow r = dt.Rows[0];

            Code.Value = r["Code"].ToString();
            Name.Value = r["Name"].ToString();

        }

        protected void SaveDepartmentButton_Click(object sender, EventArgs e)
        {
            if (ui.haveRights("opret"))
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("IID", currentId));
                p.Add(new SqlParameter("Code", Code.Value));
                p.Add(new SqlParameter("Name", Name.Value));

                String SQL = "UPDATE Department SET "
                    + "Code=@Code, Name=@Name "
                    + "WHERE IID=@IID";

                db.ExecuteUpdate(SQL, p);
            }
        }


        protected void CreateDepartmentButton_Click(object sender, EventArgs e)
        {
            if (ui.haveRights("opret"))
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("SIID", ui.Siid));
                p.Add(new SqlParameter("Code", Code.Value));
                p.Add(new SqlParameter("Name", Name.Value));

                String SQL = "INSERT INTO Department (Code, Name, SIID) "
                    + "VALUES (@Code, @Name, @SIID)";

                db.ExecuteInsert(SQL, p);
            }
        }

    }
}