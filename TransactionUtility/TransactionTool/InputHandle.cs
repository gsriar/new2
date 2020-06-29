using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    public class InputHandle : ILog
    {
        private Action<String> logDelegate;
        private ExcelConnection ExcelConnection;
        public InputHandle(string excelFileName, Action<string> LogDelegate)
        {
            throw new NotImplementedException();
        }

        public DataSet InputDataSet { get; private set; }

        public DataTable GetDataTable(DataObject dataObj)
        {
            throw new NotImplementedException();
        }

        public bool Validate(DataObject dataObj)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(string logtext)
        {
            throw new NotImplementedException();
        }


    }
}
