using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
	public class ExcelConnection : ILog
	{
		private Action<String> logDelegate;

		public ExcelConnection(string excelFileName, Action<string> LogDelegate)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllSheet()
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(string SheetName)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(string logtext)
        {
            throw new NotImplementedException();
        }
    }
}
