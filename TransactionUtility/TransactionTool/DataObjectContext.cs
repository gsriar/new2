using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
	public class DataObjectContext : ILog
	{
		private Action<String> logDelegate;

		public DataObjectContext(DataObject dataObject, SQLContext  Conn, Action<string> LogDelegate)
        {
            throw new NotImplementedException();
        }

        public void CreateTable()
        {
            throw new NotImplementedException();
        }

        public void InsertDataInSQL(DataTable inDataTable)
        {
            throw new NotImplementedException();
        }

        public void EvaluateMeasure()
        {
            throw new NotImplementedException();
        }

        public bool IsCalculatedFiledEvaluated { get; private set; }

		public void EvaluateCalculatedFileds()
        {
            throw new NotImplementedException();
        }

        public bool IsDataObjectClaculationDone { get; private set; }

		public DataTable RunCalculatedDataObjectQuery()
        {
            throw new NotImplementedException();
        }

        public bool ValidateCaluclatedDataObject(DataTable table)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(string logtext)
		{
			
		}

		public DataTable RawDataTable { get; set; }
	}
}
