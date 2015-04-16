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
    public partial class UserEdit : AdminPage
    {
        int currentId;
        int currentSId;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (ui.haveRights("opret") && Request["id"] != null && Request["sid"] != null)
            {
                currentId = int.Parse(Request["id"].ToString());
                currentSId = int.Parse(Request["sid"].ToString());
            }

            if (currentId == 0)
                currentId = int.Parse(ui.Id);
            if (currentSId == 0)
                currentSId = int.Parse(ui.Siid);

            if (!Page.IsPostBack)
            {
                this.Fill();
            }

        }

        private void Fill()
        {
            // Clear
            Gender.Items.Clear();
            Leader.Items.Clear();
            Department.Items.Clear();
            CloseResponsible.Items.Clear();
            EmployeeType.Items.Clear();
            Role.Items.Clear();

            // Fill gender
            Gender.Items.Add(new ListItem("Mand", "M"));
            Gender.Items.Add(new ListItem("Kvinde", "F"));
            Gender.Items.Add(new ListItem("Ukendt", "U"));


            // Fill departments - denne skal være multi
            List<SqlParameter> p1 = new List<SqlParameter>();
            p1.Add(new SqlParameter("SIID", currentSId));
            DataTable dt1 = db.GetDataSet("SELECT IID, Name FROM Department WHERE SIID = @SIID", p1).Table;
            foreach (DataRow r in dt1.Rows)
            {
                Department.Items.Add(new ListItem(r["Name"].ToString(), r["IID"].ToString()));
            }


            // Fill leaders
            List<SqlParameter> p2 = new List<SqlParameter>();
            p2.Add(new SqlParameter("SIID", currentSId));
            DataTable dt2 = db.GetDataSet("SELECT e.IID, e.Firstname, e.Lastname, e.Middlename FROM Employee e, Role r, relaUserRole rur WHERE e.SIID = @SIID AND e.IID = rur.EIID AND rur.RoleIID = r.IID AND r.Name = 'Leader'", p2).Table;
            foreach (DataRow r in dt2.Rows)
            {
                string fullName = r["Firstname"].ToString() + " " + (r["Middlename"].ToString() != "" ? (r["Middlename"].ToString()) + " " : "") + r["Lastname"].ToString();
                Leader.Items.Add(new ListItem(fullName, r["IID"].ToString()));
            }


            // Fill closeresponsible
            CloseResponsible.Items.Add(new ListItem("Nej", "0"));
            CloseResponsible.Items.Add(new ListItem("Ja", "1"));

            // Fill employeetype
            DataTable dt3 = db.GetDataSet("SELECT IID, Type FROM EmployeeType").Table;
            foreach (DataRow r in dt3.Rows)
            {
                EmployeeType.Items.Add(new ListItem(r["Type"].ToString(), r["IID"].ToString()));
            }

            // Fill roles
            List<SqlParameter> p4 = new List<SqlParameter>();
            p4.Add(new SqlParameter("SIID", currentSId));
            DataTable dt4 = db.GetDataSet("SELECT IID, Name FROM Role", p4).Table;
            foreach (DataRow r in dt4.Rows)
            {
                Role.Items.Add(new ListItem(r["Name"].ToString(), r["IID"].ToString()));
            }

            this.FillEmployeeInfo();

        }

        private void FillEmployeeInfo()
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", currentId));
            DataTable dt1 = db.GetDataSet("SELECT * FROM Employee WHERE IID=@EIID", p).Table;
            DataRow r1 = dt1.Rows[0];

            StaffNumber.Value = r1["StaffNumber"].ToString();
            CPR.Value = r1["CPR"].ToString();
            Name.Value = r1["Firstname"].ToString() + " " + (r1["Middlename"].ToString() != "" ? (r1["Middlename"].ToString()) + " " : "") + r1["Lastname"].ToString();
            Email.Value = r1["Email"].ToString();
            Gender.Value = r1["Gender"].ToString();
            Leader.Value = r1["LeaderIID"].ToString();
            CloseResponsible.Value = r1["CloseResponsible"].ToString();
            EmployeeType.Value = r1["EmployeeType"].ToString();

            p.Clear();
            p.Add(new SqlParameter("EIID", currentId));
            DataTable dt2 = db.GetDataSet("SELECT DIID FROM relaUserDepartment WHERE EIID=@EIID", p).Table;
            foreach (DataRow r in dt2.Rows)
            {
                foreach (ListItem i in Department.Items)
                {
                    if (i.Value.Equals(r["DIID"].ToString()))
                    {
                        i.Selected = true;
                    }
                }
            }

            p.Clear();
            p.Add(new SqlParameter("EIID", currentId));
            DataTable dt3 = db.GetDataSet("SELECT RoleIID FROM relaUserRole WHERE EIID=@EIID", p).Table;
            foreach (DataRow r in dt3.Rows)
            {
                foreach (ListItem i in Role.Items)
                {
                    if (i.Value.Equals(r["RoleIID"].ToString()))
                    {
                        i.Selected = true;
                    }
                }
            }

        }

        protected void SaveUserButton_Click(object sender, EventArgs e)
        {

            if (ui.haveRights("opret"))
            {
                string[] NameArray = SplitFullname(Name.Value);
                string Firstname = NameArray[0];
                string Lastname = NameArray[1];
                string Middlename = NameArray[2];

                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("EIID", currentId));
                p.Add(new SqlParameter("StaffNumber", StaffNumber.Value));
                p.Add(new SqlParameter("CPR", CPR.Value));

                p.Add(new SqlParameter("Firstname", Firstname));
                p.Add(new SqlParameter("Middlename", Middlename));
                p.Add(new SqlParameter("Lastname", Lastname));

                p.Add(new SqlParameter("Email", Email.Value));
                p.Add(new SqlParameter("Gender", Gender.Value));
                p.Add(new SqlParameter("LeaderIID", Leader.Value));
                p.Add(new SqlParameter("CloseResponsible", CloseResponsible.Value));
                p.Add(new SqlParameter("EmployeeType", EmployeeType.Value));

                String SQL = "UPDATE Employee SET "
                    + "StaffNumber=@StaffNumber, CPR=@CPR, "
                    + "Firstname=@Firstname, Lastname=@Lastname, Middlename=@Middlename, "
                    + "Email=@Email, Gender=@Gender, LeaderIID=@LeaderIID, CloseResponsible=@CloseResponsible, EmployeeType=@EmployeeType "
                    + "WHERE IID=@EIID";

                db.ExecuteUpdate(SQL, p);

                // Update department(s)
                p.Clear();
                p.Add(new SqlParameter("EIID", currentId));
                db.ExecuteDelete("DELETE FROM relaUserDepartment WHERE EIID=@EIID", p);

                foreach (ListItem i in Department.Items)
                {
                    if (i.Selected)
                    {
                        p.Clear();
                        p.Add(new SqlParameter("EIID", currentId));
                        p.Add(new SqlParameter("DIID", i.Value));
                        db.ExecuteInsert("INSERT INTO relaUserDepartment (EIID, DIID) VALUES (@EIID, @DIID)", p);
                    }
                }

                // Update role(s)
                p.Clear();
                p.Add(new SqlParameter("EIID", currentId));
                db.ExecuteDelete("DELETE FROM relaUserRole WHERE EIID=@EIID", p);

                foreach (ListItem i in Role.Items)
                {
                    if (i.Selected)
                    {
                        p.Clear();
                        p.Add(new SqlParameter("EIID", currentId));
                        p.Add(new SqlParameter("RoleIID", i.Value));
                        db.ExecuteInsert("INSERT INTO relaUserRole (EIID, RoleIID) VALUES (@EIID, @RoleIID)", p);
                    }
                }


                AddToastrSucces("Succes", "Gemt");
            }

        }

    }
}