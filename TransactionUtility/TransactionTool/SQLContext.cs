using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
	public class SQLContext : ILog
	{
		private Action<String> logDelegate;

		public SQLContext(Action<string> LogDelegate)
        {
            throw new NotImplementedException();
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
            logDelegate(logtext);
        }
	}
}
