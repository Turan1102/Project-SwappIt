using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.code;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace Backend
{
    public partial class UserProfile : AdminPage
    {
        public string tab1;
        public string tab2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillPersonalInformations();
                tab1 = "active";
                tab2 = "";
            }
            if (Request["succes"] != null)
            {
                if (Request["succes"].ToString() == "true")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "showDialogue", "showDialogue()", true);
                    if (Request["tab"].ToString() == "2")
                    {
                        tab2 = "active";
                        tab1 = "";
                    }
            
                }
            }
        }

        private void FillPersonalInformations()
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", ui.Id));
            DataTable dt = db.GetDataSet("SELECT Email, PhoneNumber FROM Employee WHERE IID=@EIID", p).Table;
            if (dt.Rows.Count > 0)
            {
                email.Value = dt.Rows[0]["Email"].ToString();
                phoneNumber.Value = dt.Rows[0]["PhoneNumber"].ToString(); 
            }


        }

        protected void validateOldPsw_ServerValidate(object source, ServerValidateEventArgs args)
        {

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", ui.Id));
            DataTable dt = db.GetDataSet("SELECT Password FROM Login WHERE EIID=@EIID", p).Table;
            String CurrentOldPsw = dt.Rows[0]["Password"].ToString(); 

            if (args.Value == CurrentOldPsw)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }

        }

        protected void btnSavePassword_Click(object sender, EventArgs e)
        {
            if (validateNewPsw.IsValid && validateOldPsw.IsValid && validateRepNewPsw.IsValid)
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("EIID", ui.Id));
                p.Add(new SqlParameter("Password", newPsw.Value));
                string SQL = "UPDATE Login SET Password = @Password WHERE EIID = @EIID";
                db.ExecuteUpdate(SQL, p);

                Response.Redirect(Request.RawUrl + "?succes=true&tab=2");
            }

        }

        protected void btnSavePersonal_Click(object sender, EventArgs e)
        {
            if (validatePhoneNumber.IsValid && validateEmail.IsValid)
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("EIID", ui.Id));
                p.Add(new SqlParameter("Email", email.Value));
                p.Add(new SqlParameter("PhoneNumber", phoneNumber.Value));

                string SQL = "UPDATE Employee SET Email=@Email, PhoneNumber=@PhoneNumber WHERE IID=@EIID";
                db.ExecuteUpdate(SQL, p);

                Response.Redirect(Request.RawUrl + "?succes=true&tab=1");

            }

        }

        protected void validateNewPsw_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == repNewPsw.Value && args.Value != "")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void validateRepNewPsw_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == newPsw.Value && args.Value != "")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void validatePhoneNumber_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value != "")
            {
                args.IsValid = true;
                try
                {
                    Convert.ToInt32(args.Value);
                }
                catch (Exception ex)
                {
                    args.IsValid = false;
                }                
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void validateEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value != "")
            {
                args.IsValid = true;
                try
                {
                    var test = new MailAddress(args.Value);
                }
                catch (FormatException ex)
                {
                    args.IsValid = false;
                }
            }
            else
            {
                args.IsValid = false;
            }
        }

    }
}
