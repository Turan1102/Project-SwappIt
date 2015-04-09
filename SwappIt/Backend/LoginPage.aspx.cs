using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.code;

namespace Backend
{
    public partial class LoginPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["username"] != null && Request["password"] != null)
            {
                if (Login(Request["username"].ToString(), Request["password"].ToString()))
                {
                    Session["UserInfo"] = new UserInfo("1");
                    Response.Redirect("TestMaster.aspx");
                }
            }
        }

        private Boolean Login(string username, string password)
        {
            return true;
        }
    }
}
