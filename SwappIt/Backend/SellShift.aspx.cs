using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.code;
using System.Data;
using System.Data.SqlClient;

namespace Backend
{
    public partial class SellShift : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.fillIndividualDD();
            }
        }

        protected void SellShiftToAllButton_Click(object sender, EventArgs e)
        {
            string date = shiftDate0.Value;
            string timeStart = startTime0.Value;
            string timeEnd = endTime0.Value;

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("Date", date));
            p.Add(new SqlParameter("StartTime", timeStart));
            p.Add(new SqlParameter("EndTime", timeEnd));
            p.Add(new SqlParameter("SIID", ui.Siid));
            p.Add(new SqlParameter("EIID", ui.Id));
            p.Add(new SqlParameter("Type", "0"));

            string SQL = "INSERT INTO Shift (SIID, EIID, Date, StartTime, EndTime, Type) VALUES (@SIID, @EIID, @Date, @StartTime, @EndTime, @Type)";

            db.ExecuteInsert(SQL, p);         

        }

        protected void SellShiftToIndividualButton_Click(object sender, EventArgs e)
        {
            string date = shiftDate1.Value;
            string timeStart = startTime1.Value;
            string timeEnd = endTime1.Value;

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("Date", date));
            p.Add(new SqlParameter("StartTime", timeStart));
            p.Add(new SqlParameter("EndTime", timeEnd));
            p.Add(new SqlParameter("SIID", ui.Siid));
            p.Add(new SqlParameter("EIID", ui.Id));
            p.Add(new SqlParameter("Type", "0"));

            string SQL = "INSERT INTO Shift (SIID, EIID, Date, StartTime, EndTime, Type) VALUES (@SIID, @EIID, @Date, @StartTime, @EndTime, @Type)";
            int primaryKey = db.ExecuteInsert(SQL, p);

            p.Clear();
            foreach (ListItem i in individualDD.Items)
            {
                if (i.Selected)
                {
                    p.Add(new SqlParameter("SIID", ui.Siid));
                    p.Add(new SqlParameter("ShiftId", primaryKey));
                    p.Add(new SqlParameter("EIID", i.Value));

                    string SQL1 = "INSERT INTO ShiftToIndividual (SIID, ShiftId, EIID) VALUES (@SIID, @ShiftId, @EIID)";

                    db.ExecuteInsert(SQL1, p);
                    p.Clear();
                }
            }

        }

        private void fillIndividualDD()
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("SIID", ui.Siid));
            DataTable dt = db.GetDataSet("SELECT * FROM Employee WHERE SIID=@SIID ORDER BY Firstname", p).Table;

            foreach (DataRow r in dt.Rows)
            {
                individualDD.Items.Add(new ListItem(r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString(), r["IID"].ToString()));
            }

        }

        protected void SellShiftToCloseResponsibleButton_Click(object sender, EventArgs e)
        {
            string date = shiftDate1.Value;
            string timeStart = startTime1.Value;
            string timeEnd = endTime1.Value;

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("Date", date));
            p.Add(new SqlParameter("StartTime", timeStart));
            p.Add(new SqlParameter("EndTime", timeEnd));
            p.Add(new SqlParameter("SIID", ui.Siid));
            p.Add(new SqlParameter("EIID", ui.Id));
            p.Add(new SqlParameter("Type", "0"));

            string SQL = "INSERT INTO Shift (SIID, EIID, Date, StartTime, EndTime, Type) VALUES (@SIID, @EIID, @Date, @StartTime, @EndTime, @Type)";

            int primaryKey = db.ExecuteInsert(SQL, p);
            p.Clear();

            string SQL1 = "SELECT IID FROM Employee WHERE CloseResponsible= 1 AND SIID=" + ui.Siid + " AND IID !=" + ui.Id;
            DataTable dt = db.GetDataSet(SQL1).Table;
            foreach (DataRow r in dt.Rows)
            {
                p.Add(new SqlParameter("SIID", ui.Siid));
                p.Add(new SqlParameter("ShiftId", primaryKey));
                p.Add(new SqlParameter("EIID", r["IID"].ToString()));

                string SQL2 = "INSERT INTO ShiftToIndividual (SIID, ShiftId, EIID) VALUES (@SIID, @ShiftId, @EIID)";

                db.ExecuteInsert(SQL2, p);
                p.Clear();
            }

             

        }

    }
}