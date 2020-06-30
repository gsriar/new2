using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    public class InputHandle : ExcelBase, ILog, IDisposable
    {
        private Action<String> logDelegate;

        public InputHandle(string excelFilePath, Action<string> LogDelegate) : base(excelFilePath)
        {
            this.logDelegate = LogDelegate;
        }

        public override void Dispose()
        {
            base.Dispose();
        }
        
        public DataTable GetDataTable(DataObject dataObject)
        {
            throw new NotImplementedException();
        }

        public bool Validate(DataObject dataObj)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(string logtext)
        {
            if (logDelegate != null)
            {
                logDelegate(logtext);
            }
        }



    }
}
