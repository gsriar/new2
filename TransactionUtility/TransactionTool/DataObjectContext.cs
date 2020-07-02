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
        private bool IsCalculatedFiledEvaluated;

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
                        WriteLog($" >[{fl.DataFieldName}]");
                }
            }

            CreateDataTable();
            WriteLog($"Load and Validate Row Level Data");
            LoadNewDataTable();
            EvaluatedComputedColumn();


           // WriteLog(Environment.NewLine + newDataTable.ToCSV());


            WriteLog($"Validating Successfull");

            return true;
        }

        void CreateDataTable()
        {
            newDataTable = new DataTable();

            foreach (FieldDef fl in dataObject.FieldDef)
            {
                if (!fl.IsCalculated)
                {
                    newDataTable.Columns.Add(fl.Alias, fl.Type);
                }
            }
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
                        // objArray.Add(fl.TypeDefault);
                    }
                    else
                    {
                        object o = row[fl.DataFieldName];
                        try
                        {
                            objArray.Add(CommonFunctions.ConvertObjType(o, fl.DataType, fl.Type));
                        }
                        catch (Exception ex)
                        {
                            WriteLog(ex.Message);
                            throw new Exception($"Unbale to convert [{o}] to [{fl.DataType.ToUpper()}] at row #[{rowNum}] in [{dataObject.DataObjectName}]");
                        }
                    }
                }
                newDataTable.Rows.Add(objArray.ToArray());
            }
        }

        void EvaluatedComputedColumn()
        {
            if (!IsCalculatedFiledEvaluated)
            {
                foreach (FieldDef fl in dataObject.FieldDef)
                {
                    if (fl.IsCalculated)
                    {
                        newDataTable.Columns.Add(fl.Alias, fl.Type, fl.Formula);
                    }
                }
                IsCalculatedFiledEvaluated = true;
            }
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
