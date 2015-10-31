using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend.code
{
    public class UserInfo
    {
        string id;
        string siid;

        Database db = new Database();

        public UserInfo(string id, string siid)
        {
            this.id = id;
            this.siid = siid;
        }

        public UserInfo()
        {
        }

        public string Id
        {
            get { return id; }
            // set { id = value; }
        }

        public string Siid
        {
            get { return siid; }
            set { siid = value; }
        }

        public Boolean haveRights(string right)
        {
            DataTable dt = db.GetDataSet("SELECT sr.Name FROM SecureRight sr, relaUserSecureRight rusr WHERE sr.IID = rusr.SecureRightIID AND rusr.EIID = " + id).Table;
            foreach (DataRow r in dt.Rows)
            {
                if (r["Name"].ToString().Equals(right))
                {
                    return true;
                }
            }

            return false;
        }

        public Boolean IsAdmin()
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", id));
            DataTable dt3 = db.GetDataSet("SELECT r.Name FROM relaUserRole rur, Role r WHERE rur.EIID=@EIID AND rur.RoleIID=r.IID", p).Table;
            foreach (DataRow r in dt3.Rows)
            {
                if (r["Name"].ToString().ToUpper().Equals("ADMIN"))
                {
                    return true;
                }
            }

            return false;
        }


        public Boolean IsLeader()
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", id));
            DataTable dt3 = db.GetDataSet("SELECT r.Name FROM relaUserRole rur, Role r WHERE rur.EIID=@EIID AND rur.RoleIID=r.IID", p).Table;
            foreach (DataRow r in dt3.Rows)
            {
                if (r["Name"].ToString().ToUpper().Equals("LEADER"))
                {
                    return true;
                }
            }

            return false;
        }


        public Boolean IsCloseResponsible()
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("EIID", id));
            DataTable dt3 = db.GetDataSet("SELECT CloseResponsible FROM Employee WHERE IID=@EIID", p).Table;
            foreach (DataRow r in dt3.Rows)
            {
                if (r["CloseResponsible"].ToString() == "1")
                {
                    return true;
                }
            }

            return false;
        }

    }
}