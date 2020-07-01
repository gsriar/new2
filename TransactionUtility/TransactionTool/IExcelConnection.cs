using System.Collections.Generic;
using System.Data;

namespace TransactionUtility.TransactionTool
{
    public interface IExcelConnection
    {
        void Dispose();
        List<string> GetAllSheetNameList();
        DataTable GetDataTable(string SheetName, int headerRow);
    }
}