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
        ConfigHandle configHandle = null;
        public InputHandle(string excelFilePath, Action<string> LogDelegate) : base(excelFilePath, LogDelegate,"Data")
        {
        }

        internal Dictionary<string, DataTable> GetRawDataTables(List<string> sheets)
        {
            Dictionary<string, DataTable> pairs = new Dictionary<string, DataTable>();
            WriteLog($"...");
            foreach (var obj in sheets)
            {
                pairs.Add(obj, this.GetDataTable(obj));
            }
            return pairs;
        }

        public override void Dispose()
        {
            base.Dispose();
        }

    }
}
