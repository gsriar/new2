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

        public ConfigHandle(string excelFilePath, Action<string> LogDelegate) : base(excelFilePath, LogDelegate,"Config") { }

        public void Initilize()
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
            var sheetConstants = this.GetDataTable(Constants.SheetConstants);

            var deleteQuery1 = $"{Constants.ColumnFields.DataObject}='' or {Constants.ColumnFields.DataObject} is null";

            var deleteQuery2 = $"{Constants.ColumnFields.SourceMeasure}='' or {Constants.ColumnFields.SourceMeasure} is null";

            CommonFunctions.DeleteTableRows(this.GetDataTable(Constants.SheetDataObjectName), deleteQuery1);

            CommonFunctions.DeleteTableRows(this.GetDataTable(Constants.SheetDataFiledDefinition), deleteQuery1);

            CommonFunctions.DeleteTableRows(this.GetDataTable(Constants.SheetMeasureDefinition), deleteQuery2);

            DataTable dt = this.GetDataTable(Constants.SheetDataFiledDefinition);
            
           //riteLog(Environment.NewLine + dt.ToCSV());
        }

        void LoadDataObject(DataTable sheetDataObject)
        {
            dataObjectCollection = new List<DataObject>();

            foreach (DataRow row in sheetDataObject.Rows)
            {
                WriteLog($" Loading DataObject Configuration [{row[Constants.ColumnFields.DataObject] as string}] alias [{row[Constants.ColumnFields.Alias] as string}]");
                dataObjectCollection.Add(new DataObject(
                    row[Constants.ColumnFields.DataObject] as string,
                    row[Constants.ColumnFields.Alias] as string,
                    row[Constants.ColumnFields.IsComputed] as string,
                    row[Constants.ColumnFields.ComputeQuery] as string));
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
                WriteLog($"Loading Data Fields of DataObject [{dataObject.DataObjectName}] alias [{dataObject.Alias}]");

                if (rows.Length == 0)
                    throw new Exception($"No Field defined for Data Object [{dataObject.Alias}]");
                int rowCounter = 1;
                foreach (DataRow row in rows)
                {
                    FieldDef fld = new FieldDef();
                    fld.DataObject = row[Constants.ColumnFields.DataObject] as string;
                    fld.DataFieldName = row[Constants.ColumnFields.DataFieldName] as string;
                    fld.Alias = row[Constants.ColumnFields.Alias] as string;
                    fld.DataType = row[Constants.ColumnFields.DataType] as string;
                    fld.IsNullable = row[Constants.ColumnFields.IsNullable] as string;
                    fld.SetIsCalculated = row[Constants.ColumnFields.IsComputed] as string;
                    fld.Formula = row[Constants.ColumnFields.ComputeFormula] as string;
                    fld.Remarks = row[Constants.ColumnFields.Remarks] as string;

                    WriteLog($" Field #{rowCounter++}:  [{fld.DataFieldName}] alias [{fld.Alias}]");

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

                m.SourceMeasure = row[Constants.ColumnFields.SourceMeasure] as string;
                m.PersonOrOrg = row[Constants.ColumnFields.PersonOrOrg] as string;
                m.DataSourceIdentifier = row[Constants.ColumnFields.DataSourceIdentifier] as string;
                m.Periodicity = row[Constants.ColumnFields.Periodicity] as string;
                m.SourceDataObject = row[Constants.ColumnFields.SourceDataObject] as string;
                m.SourceMeasureMappingField = row[Constants.ColumnFields.SourceMeasureMappingField] as string;
                m.SourceDateMappingField = row[Constants.ColumnFields.SourceDateMappingField] as string;
                m.SourceEmployeeMappingField = row[Constants.ColumnFields.SourceEmployeeMappingField] as string;
                m.SourceOrgMappingField = row[Constants.ColumnFields.SourceOrgMappingField] as string;
                m.FilterClause = row[Constants.ColumnFields.FilterClause] as string;
                m.Comments = row[Constants.ColumnFields.Comments] as string;

                WriteLog($"Config Measure Definition  [{m.SourceDataObject}] | [{m.SourceMeasure}]");

                measureDefCollection.Add(m);
            }

        }

        public string GetConstant(string Name)
        {
            return null;
        }

        public DataObjectContext GetDataObjectContext(DataObject dataObj)
        {
            return dataContextDictionary[dataObj];
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

        public override void Dispose()
        {
            base.Dispose();
        }

    }
}
