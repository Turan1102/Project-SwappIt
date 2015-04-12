using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.code
{
    public class AdminPage : System.Web.UI.Page
    {
        protected Database db = new Database();
        protected UserInfo ui;
        public string script = "";

        public AdminPage()
        {
            base.Load += new EventHandler(AdminPage_Load);
            base.PreInit += new EventHandler(AdminPage_PreInit);
        }

        protected void AdminPage_Load(object sender, EventArgs e)
        {
            ui = (UserInfo)Session["UserInfo"];
            Session["StartPage"] = (string)Request.Url.AbsoluteUri;

            if (ui == null || ui.Id == "")
                Server.Transfer("LoginPage.aspx");
        }

        private void AdminPage_PreInit(object sender, EventArgs e)
        {
        }

        protected void AddToastrSucces(string title, string text)
        {
            script += "toastr['success']('" + text + "', '" + title + "');" + Environment.NewLine;
        }

        protected void AddToastrInfo(string title, string text)
        {
            script += "toastr['info']('" + text + "', '" + title + "');" + Environment.NewLine;
        }

        protected void AddToastrWarning(string title, string text)
        {
            script += "toastr['warning']('" + text + "', '" + title + "');" + Environment.NewLine;
        }
        protected void AddToastrError(string title, string text)
        {
            script += "toastr['error']('" + text + "', '" + title + "');" + Environment.NewLine;
        }

    }
}