using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.code;

namespace Backend
{
    public partial class TestMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo ui = (UserInfo)Session["UserInfo"];
            TestText.Text = ui.Id;
        }
    }
}