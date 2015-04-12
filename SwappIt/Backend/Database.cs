using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Backend
{
    public class Database
    {
        SqlConnection myConnection;

        public Database()
        {
            // for en hardcoded connection name
            myConnection = new SqlConnection("Data Source=kenlpa57dr.database.windows.net;Initial Catalog=SwappIt;User ID=SwappIt;Password=Swa45DKIt");
        }

        public Database(string ConnectionName)
        {
            myConnection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings[ConnectionName]);
        }

        private bool ContainsForbiddenSql(string SQL)
        {
            if (SQL.StartsWith("update ", StringComparison.CurrentCultureIgnoreCase)
                || SQL.IndexOf("insert ", StringComparison.CurrentCultureIgnoreCase) > -1
                || SQL.IndexOf("drop ", StringComparison.CurrentCultureIgnoreCase) > -1
                || SQL.IndexOf("create ", StringComparison.CurrentCultureIgnoreCase) > -1)
            {
                /* Fyr en alarm af her */
                return true;
            }
            return false;
        }

        public DataView GetDataSet(string SQL)
        {
            if (this.ContainsForbiddenSql(SQL))
                return null;

            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();

            SqlDataAdapter tmpCommand = new SqlDataAdapter(SQL, myConnection);

            DataSet tmpSet = new DataSet();
            tmpCommand.Fill(tmpSet, "tmp");
            myConnection.Close();

            return tmpSet.Tables["tmp"].DefaultView;
        }

        public DataView GetDataSet(String SQL, List<SqlParameter> ListParms)
        {
            if (this.ContainsForbiddenSql(SQL))
                return null;

            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();

            SqlParameter[] Parms = ListParms.ToArray();
            SqlDataAdapter tmpCommand = new SqlDataAdapter(SQL, myConnection);
            tmpCommand.SelectCommand.Parameters.AddRange(Parms);

            DataSet tmpSet = new DataSet();
            tmpCommand.Fill(tmpSet, "tmp");
            myConnection.Close();

            return tmpSet.Tables["tmp"].DefaultView;
        }

        public void ExecuteUpdate(string SQL, List<SqlParameter> ListParms)
        {
            SqlParameter[] Parms = ListParms.ToArray();
            SqlCommand tmpCommand = new SqlCommand(SQL, myConnection);
            tmpCommand.Parameters.AddRange(Parms);

            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();

            tmpCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        public void ExecuteUpdate(string SQL)
        {
            SqlCommand tmpCommand = new SqlCommand(SQL, myConnection);

            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();

            tmpCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        public int ExecuteInsert(string SQL, List<SqlParameter> ListParms)
        {
            int RecordId = 0;

            SqlParameter[] Parms = ListParms.ToArray();
            SqlCommand tmpCommand = new SqlCommand(SQL, myConnection);
            tmpCommand.Parameters.AddRange(Parms);

            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();

            tmpCommand.ExecuteNonQuery();

            tmpCommand = new SqlCommand("SELECT @@IDENTITY", myConnection);
            RecordId = int.Parse(tmpCommand.ExecuteScalar().ToString());

            myConnection.Close();

            return RecordId;
        }

        public int ExecuteInsert(string SQL)
        {
            int RecordId = 0;

            SqlCommand tmpCommand = new SqlCommand(SQL, myConnection);

            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();

            tmpCommand.ExecuteNonQuery();

            tmpCommand = new SqlCommand("SELECT @@IDENTITY", myConnection);
            RecordId = int.Parse(tmpCommand.ExecuteScalar().ToString());

            myConnection.Close();
            return RecordId;
        }

        public void ExecuteDelete(string SQL, List<SqlParameter> ListParms)
        {
            SqlParameter[] Parms = ListParms.ToArray();
            SqlCommand tmpCommand = new SqlCommand(SQL, myConnection);
            tmpCommand.Parameters.AddRange(Parms);
            try
            {
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();

                tmpCommand.ExecuteNonQuery();
            }
            catch
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
        }

        public void ExecuteDelete(string SQL)
        {
            SqlCommand tmpCommand = new SqlCommand(SQL, myConnection);
            try
            {
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();

                tmpCommand.ExecuteNonQuery();
            }
            catch
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }

        }
    }
}