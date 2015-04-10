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
    public partial class LoginPage : System.Web.UI.Page
    {
        Database db = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["username"] != null && Request["password"] != null)
            {
                // string RecordId = Login(Request["username"].ToString(), Request["password"].ToString());
                string RecordId = "1"; // til at teste
                if (RecordId != null)
                {
                    Session["UserInfo"] = new UserInfo(RecordId);
                    Response.Redirect("TestMaster.aspx");
                }
                else
                {
                    // kast fejlbesked til bruger
                }
            }
        }

        private string Login(string username, string password)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("Username", username));
            p.Add(new SqlParameter("Password", password));
            DataTable dt = db.GetDataSet("SELECT EIID FROM Login WHERE Username = @Username AND Password = @Password", p).Table;
            if (dt.Rows.Count != 0)
            {
                if (!dt.Rows[0]["EIID"].ToString().Equals("") || dt.Rows[0]["EIID"].ToString() != null)
                {
                    return dt.Rows[0]["EIID"].ToString();
                }
            }

            return null;
        }

    }
}
