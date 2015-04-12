using System;
using System.Collections.Generic;
using System.Data;
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
            DataTable dt = db.GetDataSet("SELECT sr.Name FROM SecureRight sr, relaUserSecureRight rusr WHERE sr.RecordId = rusr.SIID AND rusr.EIID = " + id).Table;
            foreach (DataRow r in dt.Rows)
            {
                if (r["Name"].ToString().Equals(right))
                {
                    return true;
                }
            }

            return false;
        }

    }
}