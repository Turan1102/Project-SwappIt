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
            if (Request["shopId"] != null)
            {
                if (Request["username"] != null && Request["password"] != null)
                {
                    string RecordId = Login(Request["username"].ToString(), Request["password"].ToString(), Request["shopId"].ToString());
                    // string RecordId = "1"; // til at teste
                    if (RecordId != null)
                    {
                        Session["UserInfo"] = new UserInfo(RecordId);
                        Response.Redirect("TestMaster.aspx");
                    }

                }
                else
                {
                    this.ShowErrorText(2); // manglende username og/eller password
                }
            }
            else
            {
                this.ShowErrorText(3); // manglende shopId
            }
        }

        private void ShowErrorText(byte error)
        {
            // ErrorPanel.Visible = true;
            switch (error)
            {
                case 0:
                    // errortekst for forkert username og/eller password
                    break;
                case 1:
                    // errortekst for forkert shopId
                    break;
                case 2:
                    // errortekst for manglende username og/eller password
                    break;
                case 3:
                    // errortekst for manglende shopId
                    break;
            }
        }

        private string Login(string username, string password, string shopId)
        {
            List<KeyValuePair<string, string>> users = new List<KeyValuePair<string, string>>();

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("Username", username));
            p.Add(new SqlParameter("Password", password));
            DataTable dt = db.GetDataSet("SELECT l.EIID, e.SIID FROM Login l, Employee e WHERE l.Username = @Username AND l.Password = @Password AND e.IID = l.EIID", p).Table;
            foreach (DataRow r in dt.Rows)
            {
                users.Add(new KeyValuePair<string, string>(r["EIID"].ToString(), r["SIID"].ToString()));
            }

            if (users.Count != 0)
            {
                foreach (KeyValuePair<string, string> details in users)
                {
                    if (details.Value.Equals(shopId))
                    {
                        return details.Key;
                    }
                }

                this.ShowErrorText(1);
            }
            else
            {
                this.ShowErrorText(0);
            }

            return null;

        }

    }
}
