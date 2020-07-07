using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionUtility.TransactionTool;

namespace TransactionUtility
{
    public class DataHelper
    {

        public string getClientConfigData(string excelFilePath)
        {
            StringBuilder sb = new StringBuilder();
            char saparator = '\t';
            using (ExcelBase h = new ExcelBase(excelFilePath, null))
            {
                var allSheets = h.GetAllSheetNameList();

                sb.Append("DataObject").Append(saparator).Append("Alias").AppendLine();
                allSheets.ForEach(s => sb.Append(s).Append(saparator).Append(s).AppendLine());
                sb.AppendLine();
                sb.Append("DataObject").Append(saparator).Append("DataFieldName").Append(saparator).Append("Alias").AppendLine();
                foreach (var sheet in allSheets)
                {
                    var dt = h.GetHeaderRowDataTable(sheet);
                    foreach (DataColumn c in dt.Columns)
                    {
                        sb.Append(sheet).Append(saparator).Append(c.ColumnName).Append(saparator).Append(c.ColumnName).AppendLine();
                    }
                }
            }
            return sb.ToString();
        }
    }
}
