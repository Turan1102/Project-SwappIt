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
        Database db = new Database();

        public UserInfo(string id)
        {
            this.id = id;
        }

        public UserInfo()
        {
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