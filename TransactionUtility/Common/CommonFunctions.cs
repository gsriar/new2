using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionUtility
{
    static class CommonFunctions
    {
        public static DataTable Delete(this DataTable table, string filter)
        {
            table.Select(filter).Delete();
            table.AcceptChanges();
            return table;
        }
        public static void Delete(this IEnumerable<DataRow> rows)
        {
            foreach (var row in rows)
                row.Delete();
        }
    }
}
