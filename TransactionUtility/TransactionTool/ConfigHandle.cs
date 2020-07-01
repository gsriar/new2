using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    public class ConfigHandle : ExcelBase, ILog, IDisposable
    {
        List<DataObject> dataObjectCollection = new List<DataObject>();
        List<MeasureDef> measureDefCollection = new List<MeasureDef>();
        Dictionary<DataObject, DataObjectContext> dataContextDictionary = new Dictionary<DataObject, DataObjectContext>();

        public ConfigHandle(string excelFilePath, Action<string> LogDelegate) : base(excelFilePath, LogDelegate) { }

        public void Init()
        {
            LoadDefinition();
        }

        public List<string> GetClientSheetNameList()
        {
            List<string> result = new List<string>();
            dataObjectCollection.ForEach(d => result.Add(d.DataObjectName));
            return result;
        }

        public void Validate()
        {
            WriteLog("...");
            foreach (DataObject key in dataContextDictionary.Keys)
            {
                var ctx = dataContextDictionary[key];
                ctx.Validate();
            }
        }

        public void SetDataContext(Dictionary<string, DataTable> objDataDictionary)
        {
            WriteLog("...");
            foreach (var key in objDataDictionary.Keys)
            {
                WriteLog($"Set DataContext :[{key}]");
                var table = objDataDictionary[key];

                var obj = dataObjectCollection.FirstOrDefault(d => string.Equals(d.DataObjectName, key, StringComparison.OrdinalIgnoreCase));

                DataObjectContext ctx = new DataObjectContext(obj, table, WriteLog);

                dataContextDictionary[obj] = ctx;
            }
        }


        private void LoadDefinition()
        {
            WriteLog($"...");
            ReadWorkbookAndCleanup();
            WriteLog($"...");
            LoadDataObject(this.GetDataTable(Constants.SheetDataObjectName));
            WriteLog($"...");
            LoadDataFields(this.GetDataTable(Constants.SheetDataFiledDefinition), dataObjectCollection);
            WriteLog($"...");
            LoadMeasureDefinition(this.GetDataTable(Constants.SheetMeasureDefinition));
        }

        void ReadWorkbookAndCleanup()
        {
            var deleteQuery1 = $"{Constants.ColumnFields.DataObject}='' or {Constants.ColumnFields.DataObject} is null";

            var deleteQuery2 = $"{Constants.ColumnFields.SourceMeasure}='' or {Constants.ColumnFields.SourceMeasure} is null";

            CommonFunctions.DeleteTableRows(this.GetDataTable(Constants.SheetDataObjectName), deleteQuery1);

            CommonFunctions.DeleteTableRows(this.GetDataTable(Constants.SheetDataFiledDefinition), deleteQuery1);

            CommonFunctions.DeleteTableRows(this.GetDataTable(Constants.SheetMeasureDefinition), deleteQuery2);
            DataTable dt = this.GetDataTable(Constants.SheetDataFiledDefinition);
            string txt =dt.ToCSV();
            WriteLog(Environment.NewLine + txt);
        }

        void LoadDataObject(DataTable sheetDataObject)
        {
            dataObjectCollection = new List<DataObject>();

            foreach (DataRow row in sheetDataObject.Rows)
            {
                WriteLog($"Config Dataobject [{row["dataObject"] as string} | {row["alias"] as string}]");
                dataObjectCollection.Add(new DataObject(
                    row["dataObject"] as string,
                    row["alias"] as string,
                    row["isCalculated"] as string,
                    row["evaluationQuery"] as string));
            }

        }

        void LoadDataFields(DataTable sheetDataFields, List<DataObject> dataObjects)
        {
            foreach (var dataObject in dataObjects)
            {
                var filter = $"{Constants.SheetDataObjectName}='{dataObject.Alias}'";

                List<FieldDef> FieldDefCollection = new List<FieldDef>();

                DataRow[] rows = sheetDataFields.Select(filter);

                WriteLog($"...");
                WriteLog($"Loading Data Fields for  [{dataObject.Alias}]");

                if (rows.Length == 0)
                    throw new Exception($"No Field defined for Data Object [{dataObject.Alias}]");

                foreach (DataRow row in rows)
                {
                    FieldDef fld = new FieldDef();
                    fld.DataObject = row["DataObject"] as string;
                    fld.DataFieldName = row["DataFieldName"] as string;
                    fld.Alias = row["Alias"] as string;
                    fld.DataType = row["DataType"] as string;
                    fld.IsNullable = row["IsNullable"] as string;
                    fld.SetIsCalculated = row["IsCalculated"] as string;
                    fld.Formula = row["Formula"] as string;
                    fld.Remarks = row["Remarks"] as string;

                    WriteLog($"Config Field:  [{fld.DataObject} | {fld.DataFieldName}]");

                    FieldDefCollection.Add(fld);
                }

                dataObject.FieldDef = FieldDefCollection;

            }

        }

        void LoadMeasureDefinition(DataTable sheetMeasures)
        {
            measureDefCollection = new List<MeasureDef>();

            foreach (DataRow row in sheetMeasures.Rows)
            {
                MeasureDef m = new MeasureDef();

                m.SourceMeasure = row["SourceMeasure"] as string;
                m.PersonOrOrg = row["PersonOrOrg"] as string;
                m.DataSourceIdentifier = row["DataSourceIdentifier"] as string;
                m.Periodicity = row["Periodicity"] as string;
                m.SourceDataObject = row["SourceDataObject"] as string;
                m.SourceMeasureMappingField = row["SourceMeasureMappingField"] as string;
                m.SourceDateMappingField = row["SourceDateMappingField"] as string;
                m.SourceEmployeeMappingField = row["SourceEmployeeMappingField"] as string;
                m.SourceOrgMappingField = row["SourceOrgMappingField"] as string;
                m.FilterClause = row["FilterClause"] as string;
                m.Comments = row["Comments"] as string;

                WriteLog($"Config Measure Definition  [{m.SourceDataObject}] | [{m.SourceMeasure}]");

                measureDefCollection.Add(m);
            }

        }

        public string GetConstant(string Name)
        {
            var sheetConstants = this.GetDataTable(Constants.SheetConstants);
            return null;
        }

        public DataObjectContext GetDataObjectContext(DataObject dataObj)
        {
            throw new NotImplementedException();
        }

        public DataObject GetDataObject(string Name)
        {
            return dataObjectCollection.FirstOrDefault(d => d.DataObjectName == Name);
        }

        public List<MeasureDef> GetMeasureDefCollection
        {
            get
            {
                return measureDefCollection;
            }
        }

        public List<DataObject> GetDataObjectCollection
        {
            get
            {
                return dataObjectCollection;
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }

    }
}
