using System.Collections.Generic;
using System.Data;

namespace TransactionUtility.TransactionTool
{
    public interface IExcelConnection
    {
        void Dispose();
        List<string> GetAllSheet();
        DataTable GetDataTable(string SheetName);
    }
}