using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    public class DataObjectContext : ILog
    {
        private Action<String> logDelegate;
        private DataTable rawDataTable;
        private DataTable newDataTable;
        private DataObject dataObject;

        public DataObjectContext(DataObject dataObject, DataTable rawDataTable, Action<string> LogDelegate)
        {
            this.logDelegate = LogDelegate;
            this.rawDataTable = rawDataTable;
            this.dataObject = dataObject;
        }

        public bool Validate()
        {
            WriteLog($"...");
            WriteLog($"Validating [{dataObject.DataObjectName}]");
            List<DataColumn> columnList = new List<DataColumn>();
            foreach (DataColumn col in this.rawDataTable.Columns)
            {
                columnList.Add(col);
            }

            WriteLog($"Validating Column Names");

            foreach (FieldDef fl in dataObject.FieldDef)
            {
                if (!fl.IsCalculated)
                {
                    var hasField = columnList.FirstOrDefault(c => string.Equals(fl.DataFieldName, c.ColumnName, StringComparison.OrdinalIgnoreCase));
                    if (hasField == null)
                        throw new Exception($"Data Sheet [{dataObject.DataObjectName}] does not contain column [{fl.DataFieldName}]");
                    else
                        WriteLog($" contains column [{fl.DataFieldName}]");
                }
            }

            CreateDataTable();
            WriteLog($"Validating Row Data");
            LoadNewDataTable();

            var x = newDataTable.ToCSV();

            WriteLog(Environment.NewLine + x);


            WriteLog($"Validating Successfull");

            return true;
        }

        void LoadNewDataTable()
        {
            List<object> objArray = new List<object>();

            int rowNum = 1;
            foreach (DataRow row in rawDataTable.Rows)
            {
                rowNum++;
                objArray.Clear();
                foreach (FieldDef fl in dataObject.FieldDef)
                {
                    if (fl.IsCalculated)
                    {
                        objArray.Add(fl.TypeDefault);
                    }
                    else
                    {
                        object o = row[fl.DataFieldName];
                        try
                        {
                            objArray.Add(ConvertObjType(o, fl.DataType, fl.Type));
                        }
                        catch (Exception ex)
                        {
                            WriteLog(ex.Message);
                            throw new Exception($"Unbale to convert [{fl.DataFieldName}] value [{o}] to [{fl.DataType.ToUpper()}] at row #[{rowNum}] in [{dataObject.DataObjectName}]");
                        }
                    }
                }
                newDataTable.Rows.Add(objArray.ToArray());
            }
        }

        object ConvertObjType(object o, string typeText, Type _type)
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

        void CreateDataTable()
        {
            newDataTable = new DataTable();

            foreach (FieldDef f in dataObject.FieldDef)
            {
                newDataTable.Columns.Add(f.Alias, f.Type);
            }
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
            if (logDelegate != null)
            {
                logDelegate(logtext);
            }
        }
    }
}
