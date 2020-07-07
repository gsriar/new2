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
        private List<MeasureDef> measureDefCollection;
        private Action<String> logDelegate;
        private DataTable rawDataTable;
        private DataTable newDataTable;
        private DataObject dataObject;
        private bool IsCalculatedFiledEvaluated;

        public DataObjectContext(DataObject dataObject, DataTable rawDataTable, Action<string> LogDelegate, List<MeasureDef> measureDefCollection)
        {
            this.measureDefCollection = measureDefCollection;
            this.logDelegate = LogDelegate;
            this.rawDataTable = rawDataTable;
            this.dataObject = dataObject;
        }

        public bool Validate()
        {
            List<DataColumn> columnList = new List<DataColumn>();
            foreach (DataColumn col in this.rawDataTable.Columns)
            {
                columnList.Add(col);
            }

            WriteLog($"Data Object [{dataObject.DataObjectName}] alias [{dataObject.Alias}]");
            WriteLog($"Validating Column Names");

            int counter = 1;
            foreach (FieldDef fl in dataObject.FieldDefCollection)
            {
                if (!fl.IsComputed)
                {
                    var hasField = columnList.FirstOrDefault(c => string.Equals(fl.DataFieldName, c.ColumnName, StringComparison.OrdinalIgnoreCase));
                    if (hasField == null)
                        throw new Exception($"Data Sheet [{dataObject.DataObjectName}] does not contain column [{fl.DataFieldName}]");
                    else
                        WriteLog($" Column #{counter++} - [{fl.DataFieldName}]");
                }
            }

            WriteLog($"Validating Source Measure Configuration");
            foreach (MeasureDef mdef in this.measureDefCollection)
            {
                var flDdate = dataObject.GetFieldDef(mdef.SourceDateMappingField);
                var flEmp = dataObject.GetFieldDef(mdef.SourceEmployeeMappingField);
                var flSourceMeasure = dataObject.GetFieldDef(mdef.SourceMeasureMappingField);
                var flOrg = dataObject.GetFieldDef(mdef.SourceOrgMappingField);

                if (flDdate == null)
                {
                    throw new Exception($"Date Mapping Field (DataObject[{mdef.SourceDataObject}] alias:[{mdef.SourceDateMappingField}]) doesn't exist. Measure[{mdef.SourceMeasure}]");
                }
                else if (flDdate.Type != typeof(DateTime))
                {
                    //throw new Exception($"Date Mapping Field (DataObject[{mdef.SourceDataObject}] alias:[{mdef.SourceDateMappingField}]) is not of Date Type. Measure[{mdef.SourceMeasure}]");
                }

                if (flSourceMeasure == null)
                {
                    throw new Exception($"Measure Mapping Field (DataObject[{mdef.SourceDataObject}] alias:[{mdef.SourceMeasureMappingField}]) doesn't exist. Measure[{mdef.SourceMeasure}]");
                }

                if (!string.IsNullOrWhiteSpace(mdef.SourceEmployeeMappingField) && flEmp == null)
                {
                    throw new Exception($"Employee Mapping Field (DataObject[{mdef.SourceDataObject}] alias:[{mdef.SourceEmployeeMappingField}]) doesn't exist. Measure[{mdef.SourceMeasure}]");
                }

                if (!string.IsNullOrWhiteSpace(mdef.SourceOrgMappingField) && flOrg == null)
                {
                    throw new Exception($"Orgnisation Mapping Field (DataObject[{mdef.SourceDataObject}] alias:[{mdef.SourceOrgMappingField}]) doesn't exist. Measure[{mdef.SourceMeasure}]");
                }
            }

            WriteLog($"Load and Validate Row Level Data");

            RowWiseValidate();

            EvaluatedComputedColumn();

            WriteLog($"Validating Successfull");

            return true;
        }


        private void RowWiseValidate()
        {
            CreateNewDataTable();
            List<object> objArray = new List<object>();

            int rowNum = 1;
            foreach (DataRow row in rawDataTable.Rows)
            {
                rowNum++;
                objArray.Clear();
                foreach (FieldDef field in dataObject.FieldDefCollection)
                {
                    if (field.IsComputed)
                    {
                        // objArray.Add(fl.TypeDefault);
                    }
                    else
                    {
                        object obj = row[field.DataFieldName];
                        try
                        {
                            object convertedObj = null;

                            //field is not nullable, and input is null, then throw exception
                            if (!field.IsNullable && obj.IsDbNull())
                            {
                                throw new Exception($"Field [{field.DataFieldName}] value is null");
                            }

                            //if field is null and has default value, then set default value
                            if(obj.IsDbNull() && !field.DefaultValue.IsDbNull())
                            {
                                obj = field.DefaultValue;
                            }

                            if (obj.IsDbNull())
                            {
                                convertedObj = null;
                            }
                            else
                            {
                                convertedObj = CommonFunctions.ConvertType(obj, field.DataType, field.Type);
                            }

                            objArray.Add(convertedObj);
                        }
                        catch (Exception ex)
                        {
                            WriteLog(ex.Message);
                            throw new Exception($"Unbale to convert [{obj}] to [{field.DataType.ToUpper()}] at row #[{rowNum}] in [{dataObject.DataObjectName}]");
                        }
                    }
                }
                newDataTable.Rows.Add(objArray.ToArray());
            }
        }

        private void CreateNewDataTable()
        {
            newDataTable = new DataTable();

            foreach (FieldDef field in dataObject.FieldDefCollection)
            {
                if (!field.IsComputed)
                {
                    newDataTable.Columns.Add(field.Alias, field.Type);
                }
            }
        }


        private void EvaluatedComputedColumn()
        {
            if (!IsCalculatedFiledEvaluated)
            {
                foreach (FieldDef field in dataObject.FieldDefCollection)
                {
                    if (field.IsComputed)
                    {
                        newDataTable.Columns.Add(field.Alias, field.Type, field.Formula);
                    }
                }
                IsCalculatedFiledEvaluated = true;
            }
        }

        public bool IsDataObjectClaculationDone { get; private set; }
        public bool IsSQLTableCreated { get; internal set; }
        public bool IsDataInserted { get; internal set; }

        public string GetCreateTableQuery()
        {
            WriteLog($"CREATE TABLE QUERY [{this.dataObject.Alias}] ");
            return SQLTool.GetCreateFromDataTableSQL(this.dataObject.Alias, newDataTable);
        }

        public string GetInsertQuery()
        {
            WriteLog($"INSERT QUERY [{this.dataObject.Alias}] ");
            return SQLTool.GetInsertSQL(this.dataObject.Alias, newDataTable);
        }

        public bool ValidateCaluclatedDataObject(DataTable table)
        {
            throw new NotImplementedException();
        }

        public void WriteMeasureOutput(IWriter writer)
        {
            try
            {

                foreach (MeasureDef m in measureDefCollection)
                {
                    WriteLog(" Source Measure: [" + m.SourceMeasure + "], DataObject: [" + m.SourceDataObject + "], Filter: [" + m.FilterClause + "]");

                    DataRow[] rows;

                    if (string.IsNullOrWhiteSpace(m.FilterClause))
                    {
                        rows = newDataTable.Select(m.FilterClause);
                    }
                    else
                    {
                        rows = newDataTable.Select();
                    }

                    int counter = 0;

                    foreach (DataRow row in rows)
                    {
                        counter++;
                        OutputMeasure outMeasure = new OutputMeasure()
                        {
                            Date = row[m.SourceDateMappingField].ToString(),
                            DataSourceIdentifier = m.DataSourceIdentifier,
                            Periodicity = m.Periodicity,
                            ExternalEmpIdentifier = row[m.SourceEmployeeMappingField],

                            InternalOrgIdentifier = row[m.SourceOrgMappingField],
                            SourceMeasureValue = row[m.SourceMeasureMappingField],
                            SourceMeasureSystemCode = m.SourceMeasure
                        };
                        writer.Write(outMeasure.ToString());
                        outMeasure = null;
                    }
                    WriteLog($" Count: {counter}");
                }
            }
            catch (Exception ex)
            {
                WriteLog($"Error Has Occured [{ex.Message}]");
                writer.Write("Error Has Occured");
            }

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
