using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
	public class SQLContext : ILog, IDisposable
    {
        private SQLiteConnection conn=null;

        private Action<string> logDelegate=null;


        public SQLContext(Action<string> LogDelegate)
        {
            this.logDelegate = LogDelegate;
            string cs = "Data Source=:memory:";

            conn = new SQLiteConnection(cs);
            conn.Open();
        }

        public void Dispose()
        {
            if(conn!=null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        public int ExecuteNonQuery(string query)
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteQuery()
        {
            throw new NotImplementedException();
        }

        public void WriteLog(string logtext)
        {
            if (this.logDelegate != null)
                logDelegate(logtext);
        }
	}
}
