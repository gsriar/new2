using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    public class InputDataHelper : ExcelBase, ILog, IDisposable
    {
        ConfigHelper configHandle = null;
        public InputDataHelper(string excelFilePath, Action<string> LogDelegate) : base(excelFilePath, LogDelegate,"Data")
        {
        }

        internal Dictionary<string, DataTable> GetBaseData(List<string> sheets)
        {
            Dictionary<string, DataTable> pairs = new Dictionary<string, DataTable>();
            WriteLog(Constants.BlankLine);
            foreach (var sheet in sheets)
            {
                pairs.Add(sheet, this.GetDataTable(sheet));
            }
            return pairs;
        }

        public override void Dispose()
        {
            base.Dispose();
        }

    }
}
