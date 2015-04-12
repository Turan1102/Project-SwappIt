using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Backend
{
    public partial class TestMaster : System.Web.UI.Page
    {
        Database db = new Database();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.FillNews();
        }

        public void FillNews()
        {
            string newsCreatorName = "";
            string newsCreateDate = "";
            string newsTitle = "";
            string newsText = "";

            DataTable dt = db.GetDataSet("SELECT * FROM Company").Table; // hent fra nyhed tabellen
            foreach (DataRow r in dt.Rows)
            {
                newsCreatorName = r["Name"].ToString();

                tableOut.Text += "<li class=\"in\" style=\"margin-top: -25px;\">" +
                      "   <i class=\"fa fa-envelope-o\" style=\"font-size: 45px; position: relative; top: 45px;\"></i>" +
                      "   <div class=\"message\">" +
                      "   <span class=\"arrow\"></span>" +
                      "<a href=\"https://twitter.com/OlePaske/status/586834740491223040\" class=\"name\">" + newsCreatorName + "</a>" +
                      "<span class=\"datetime\">11-04-2015 10:14</span>" + // her skal den hente dato fra db hvor nyheden er oprettet
                      "<span class=\"body\">" +
                      "<a href=\"https://twitter.com/OlePaske/status/586834740491223040\">Danske Yildiz Akdogan: Fo</a></span>" +
                      "</div></li>";
            }
        }
    }
}