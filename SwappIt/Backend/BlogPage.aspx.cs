using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Backend.code;
using System.Data;

namespace Backend
{
    public partial class BlogPage : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.FillBlog();
        }

        private void FillBlog()
        {
            tableOut.Text = "";

            string blogCreateDate = "";
            string blogTitle = "";
            string blogText = "";

            DataTable dt = db.GetDataSet("SELECT * FROM Blog WHERE SIID= " + ui.Siid).Table; // hent fra blog tabellen
            foreach (DataRow r in dt.Rows)
            {
                blogCreateDate = r["CreateTime"].ToString();
                blogTitle = r["Title"].ToString();
                blogText = r["Text"].ToString();

                string blogCreatorName = "";
                DataTable dt1 = db.GetDataSet("SELECT Firstname, Middlename, Lastname FROM Employee WHERE IID=" + ui.Id).Table;
                blogCreatorName = dt1.Rows[0]["Firstname"].ToString() + " " + (dt1.Rows[0]["Middlename"].ToString() != "" ? (dt1.Rows[0]["Middlename"].ToString()) + " " : "") + dt1.Rows[0]["Lastname"].ToString();

                tableOut.Text += "<div class=\"media\">" +
                                 "<a class=\"pull-left\">" +
                                 "<img class=\"media-object\" src=\"data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI2NCIgaGVpZ2h0PSI2NCI+PHJlY3Qgd2lkdGg9IjY0IiBoZWlnaHQ9IjY0IiBmaWxsPSIjZWVlIi8+PHRleHQgdGV4dC1hbmNob3I9Im1pZGRsZSIgeD0iMzIiIHk9IjMyIiBzdHlsZT0iZmlsbDojYWFhO2ZvbnQtd2VpZ2h0OmJvbGQ7Zm9udC1zaXplOjEycHg7Zm9udC1mYW1pbHk6QXJpYWwsSGVsdmV0aWNhLHNhbnMtc2VyaWY7ZG9taW5hbnQtYmFzZWxpbmU6Y2VudHJhbCI+NjR4NjQ8L3RleHQ+PC9zdmc+\" alt=\"64x64\" data-src=\"holder.js/64x64\" style=\"width: 64px; height: 64px;\">" +
                                 "</a>" +
                                 "<div class=\"media-body\">" +
                                 "<h4 class=\"media-heading\">" + blogTitle + "</h4>" +
                                 "" + blogText + "" +
                                 "</div>" +
                                 "</div>";
    }
        }

        private void CreateBlog()
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", ui.Id));
            p.Add(new SqlParameter("SIID", ui.Siid));
            p.Add(new SqlParameter("Title", Titel.Value));
            p.Add(new SqlParameter("Text", Text.Value));
            db.ExecuteInsert("INSERT INTO Blog (EIID, SIID, Title, Text) VALUES (@EIID, @SIID, @Title, @Text)", p);

            Titel.Value = "";
            Text.Value = "";
        }

        protected void CreateBlogButton_Click(object sender, EventArgs e)
        {
            this.CreateBlog();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}
