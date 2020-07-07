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
        public static DataTable DeleteTableRows(this DataTable table, string filter)
        {
            table.Select(filter).Delete();
            table.AcceptChanges();
            return table;
        }

        public static bool IsDbNull(this object obj)
        {
            return (obj == DBNull.Value || obj == null);
        }

        public static void Delete(this IEnumerable<DataRow> rows)
        {
            foreach (var row in rows)
                row.Delete();
        }

        public static int NthIndexOf(this string str,string text, int n)
        {
            int i = str.IndexOf(text);
            int last = i;
            while (--n > 0)
            {
                if (i > -1 && i + 1 < str.Length)
                {
                    i = str.IndexOf(text, last + 1);
                    if (i == -1)
                        break;
                }
                last = i;
            }
            return last;
        }

        public static string ToCSV(this DataTable table)
        {
           
            StringBuilder sb = new StringBuilder();
            foreach (DataColumn c in table.Columns)
            {
                sb.Append(c.ColumnName);
                sb.Append('\t');
            }

            sb.AppendLine();

            foreach (DataRow r in table.Rows)
            {
                sb.AppendLine(string.Join('\t'.ToString(), r.ItemArray));
            }

            return sb.ToString();
        }

        public static object TypeDefaultValue(string typ)
        {
            object result;
            switch (typ.ToUpper().Trim())
            {
                case Constants.DataTypes.Date:
                    result = DateTime.MinValue;
                    break;

                case Constants.DataTypes.Numeric:
                case Constants.DataTypes.Int:
                case Constants.DataTypes.Integer:
                    result = 0;
                    break;
                default:
                    result = string.Empty;
                    break;
            }

            return result;
        }

        public static Type GetType(string typ)
        {
            Type result = typeof(string);

            switch (typ.ToUpper().Trim())
            {
                case Constants.DataTypes.Date:
                    result = typeof(DateTime);
                    break;

                case Constants.DataTypes.Numeric:
                    result = typeof(decimal);
                    break;

                case Constants.DataTypes.Int:
                case Constants.DataTypes.Integer:
                    result = typeof(Int32);
                    break;

            }

            return result;
        }

        public static object ConvertType(object o, string typeText, Type _type)
        {
            object result = o;

            if (result.GetType() == _type)
            {
                return result;
            }
            else
            {
                switch (typeText)
                {
                    case Constants.DataTypes.Date:
                        result = Convert.ToDateTime(o);
                        break;

                    case Constants.DataTypes.Numeric:
                        result = Convert.ToDecimal(o);
                        break;

                    case Constants.DataTypes.Int:
                    case Constants.DataTypes.Integer:
                        result = Convert.ToInt32(o);
                        break;
                }
            }
            return result;
        }
    }
}
