using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Backend.code;

namespace Backend
{
    public partial class CreateNewsPage : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.FillNews();
        }

        private void FillNews()
        {
            tableOut.Text = "";

            string newsCreateDate = "";
            string newsTitle = "";
            string newsText = "";

            DataTable dt = db.GetDataSet("SELECT * FROM News WHERE SIID= " + ui.Siid).Table; // hent fra nyhed tabellen
            foreach (DataRow r in dt.Rows)
            {
                newsCreateDate = r["CreateTime"].ToString();
                newsTitle = r["Title"].ToString();
                newsText = r["Text"].ToString();

                string newsCreatorName = "";
                DataTable dt1 = db.GetDataSet("SELECT Firstname, Middlename, Lastname FROM Employee WHERE IID=" + ui.Id).Table;
                newsCreatorName = dt1.Rows[0]["Firstname"].ToString() + " " + (dt1.Rows[0]["Middlename"].ToString() != "" ? (dt1.Rows[0]["Middlename"].ToString()) + " " : "") + dt1.Rows[0]["Lastname"].ToString();

                tableOut.Text += "<li class=\"in\" style=\"margin-top: -25px;\">" +
                      "   <i class=\"fa fa-envelope-o\" style=\"font-size: 45px; position: relative; top: 45px;\"></i>" +
                      "   <div class=\"message\">" +
                      "   <span class=\"arrow\"></span>" +
                      "Af: " + newsCreatorName +
                      "<span class=\"datetime\">" + newsCreateDate + "</span></br>" +
                      "<b>" + newsTitle + "</b>" + "</a>" +
                      "<span class=\"body\">" +
                      "" + newsText + "</span>" +
                      "</div></li>";
            }
        }

        private void CreateNews()
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", ui.Id));
            p.Add(new SqlParameter("SIID", ui.Siid));
            p.Add(new SqlParameter("Title", Titel.Value));
            p.Add(new SqlParameter("Text", Text.Value));
            db.ExecuteInsert("INSERT INTO News (EIID, SIID, Title, Text) VALUES (@EIID, @SIID, @Title, @Text)", p);

            Titel.Value = "";
            Text.Value = "";
        }

        protected void CreateNewsButton_Click(object sender, EventArgs e)
        {
            this.CreateNews();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}