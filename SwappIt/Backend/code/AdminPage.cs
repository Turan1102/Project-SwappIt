using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

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

        public void ToggleEmployeeInactive(string EmployeeId)
        {
            if (ui.haveRights("slet"))
            {
                List<SqlParameter> p1 = new List<SqlParameter>();
                p1.Add(new SqlParameter("IID", EmployeeId));
                DataTable dt1 = db.GetDataSet("SELECT * FROM Employee WHERE IID=@IID", p1).Table;
                if (dt1.Rows.Count > 0)
                {
                    DataRow r = dt1.Rows[0];

                    List<SqlParameter> p2 = new List<SqlParameter>();
                    p2.Add(new SqlParameter("IID", EmployeeId));
                    p2.Add(new SqlParameter("Inactive", (r["Inactive"].ToString() == "1" ? "0" : "1")));
                    db.ExecuteUpdate("UPDATE Employee SET Inactive=@Inactive WHERE IID=@IID", p2);
                    // AddToastrSucces("Status", "Bruger " + r["Name"] + " er blevet " + (r["Inactive"].ToString() == "1" ? "aktiverede" : "deaktiverede"));

                }

            }
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

        public string convertShiftTypeToString(string typeCode)
        {
            switch (typeCode)
            {
                case "0":
                    return "Alle";
                case "1":
                    return "Enkelte";
                case "2":
                    return "Lukkevagter";
                case "4":
                    return "Byttevagt retur";
            }

            return "Ikke Defineret";
        }

        public string convertResponseTradeStatusToString(string statusCode)
        {
            switch (statusCode)
            {
                case "0":
                    return "Byttevagt modtaget (køber)";
                case "1":
                    return "Afvist (sælger)";
                case "2":
                    return "Godkendt (sælger)";

            }

            return "Ikke Defineret";
        }

        public String dateFormater(String date)
        {
            int dateindex = date.IndexOf(' ');
            if (dateindex > 0)
            {
                date = date.Substring(0, dateindex);
            }

            return date;

        } 

    }
}