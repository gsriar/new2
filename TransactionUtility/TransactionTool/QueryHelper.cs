using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
	public class QueryHelper : ILog
	{
		private Action<String> logDelegate;

		public QueryHelper(Action<string> LogDelegate)
        {
            throw new NotImplementedException();
        }

        public string CreateTableQuery(DataObject dataObject)
        {
            throw new NotImplementedException();
        }

        public string InsertQuery(DataObject dataObject, DataTable table)
        {
            throw new NotImplementedException();
        }

        public string SelectQuery(DataObject dataObj)
        {
            throw new NotImplementedException();
        }

        public void UpdateQuery(string tableName, FieldDef fieldDef, string value)
        {
            throw new NotImplementedException();
        }

        public string CalcFiledEvalUpdateQuery(DataObject dataObj)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(string logtext)
        {
            throw new NotImplementedException();
        }
    }
}
