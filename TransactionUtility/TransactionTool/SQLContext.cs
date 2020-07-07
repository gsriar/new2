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
        private SQLiteConnection conn = null;

        private Action<string> logDelegate = null;

        public SQLContext(Action<string> LogDelegate)
        {
            this.logDelegate = LogDelegate;
            string cs = "Data Source=:memory:";

            conn = new SQLiteConnection(cs);
            conn.Open();
            WriteLog("Open in memory SQLite Connection");
        }

        public void Dispose()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        public int ExecuteNonQuery(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, conn);
            return command.ExecuteNonQuery();
        }
        
        public DataTable GetDataTable(string sql)
        {
            try
            {
                DataTable dt = new DataTable();

                SQLiteCommand mycommand = new SQLiteCommand(conn);
                mycommand.CommandText = sql;
                SQLiteDataReader reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();

                return dt;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error executing select query :[{sql}].{Environment.NewLine}Error Message :[{ex.Message}]");
            }
        }

        public void WriteLog(string logtext)
        {
            if (this.logDelegate != null)
                logDelegate(logtext);
        }
    }
}
