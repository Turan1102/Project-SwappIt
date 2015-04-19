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

        public string[] SplitFullname(string fullname)
        {
            string[] fullnameArray = fullname.TrimEnd().Split(' ');
            string Firstname = "";
            string Middlename = "";
            string Lastname = "";

            if (fullnameArray.Length == 1)
            {
                Firstname = fullnameArray[0];
            }
            if (fullnameArray.Length == 2)
            {
                Firstname = fullnameArray[0];
                Middlename = fullnameArray[1];
            }
            if (fullnameArray.Length == 3)
            {
                Firstname = fullnameArray[0];
                Middlename = fullnameArray[1];
                Lastname = fullnameArray[2];
            }
            if (fullnameArray.Length > 3)
            {
                Firstname = fullnameArray[0];

                for (int i = 1; i < fullnameArray.Length; i++)
                {
                    if (i != fullnameArray.Length - 1)
                    {
                        Middlename += fullnameArray[i] + " ";
                    }
                }

                Middlename = Middlename.TrimEnd();
                Lastname = fullnameArray[fullnameArray.Length - 1];
            }

            return new string[] { Firstname, Lastname, Middlename };
        }

    }
}