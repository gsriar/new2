using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    public class ConfigHelper : ExcelBase, ILog, IDisposable
    {
        List<DataObject> dataObjectCollection = new List<DataObject>();
        List<MeasureDef> measureDefCollection = new List<MeasureDef>();
        Dictionary<DataObject, DataObjectContext> dataContextDictionary = new Dictionary<DataObject, DataObjectContext>();
        private bool isBaseDataPersisted;

        public ConfigHelper(string excelFilePath, Action<string> LogDelegate) : base(excelFilePath, LogDelegate, "Config") { }

        public void Initilize()
        {
            LoadDefinition();
        }

        public List<string> GetBaseDataObjectNames()
        {
            List<string> result = new List<string>();
            dataObjectCollection.ForEach(dob => { if (!dob.IsComputed) result.Add(dob.DataObjectName); });
            return result;
        }

        public List<string> GetComputedDataObjectNames()
        {
            List<string> result = new List<string>();
            dataObjectCollection.ForEach(dob => { if (dob.IsComputed) result.Add(dob.DataObjectName); });
            return result;
        }

        public void ValidateBaseDataObjects()
        {
            WriteLog(Constants.BlankLine);
            WriteLog("Validating base data...");

            foreach (DataObject dob in dataObjectCollection.Where(d => !d.IsComputed))
            {
                var ctx = dataContextDictionary[dob];
                ctx.Validate();
            }
        }

        public void ValidateComputedDataObjects()
        {
            WriteLog(Constants.BlankLine);
            WriteLog("Validating computed data ...");

            foreach (DataObject dob in dataObjectCollection.Where(d => d.IsComputed))
            {
                var ctx = dataContextDictionary[dob];
                ctx.Validate();
            }
        }

        internal void EvaluateComputedDataObjects(SQLContext sqlContext)
        {
            //insert data in sql
            this.PersistBaseDataObjects(sqlContext);
            //set computed data tables
            this.SetComputedDataObjectContext(sqlContext);
        }

        private void PersistBaseDataObjects(SQLContext sqlContext)
        {
            if (dataObjectCollection.Any(d => d.IsComputed) && !isBaseDataPersisted)
            {
                foreach (DataObject dob in this.dataContextDictionary.Keys.Where(d => !d.IsComputed))
                {
                    WriteLog(Constants.BlankLine);
                    var ctx = dataContextDictionary[dob];
                    if (!ctx.IsSQLTableCreated)
                    {
                        var sql1 = ctx.GetCreateTableQuery();
                        WriteLog(Environment.NewLine + sql1);
                        sqlContext.ExecuteNonQuery(sql1);
                        WriteLog($"SQLLite Table[{dob.Alias}] Created");
                    }

                    if (!ctx.IsDataInserted)
                    {
                        var sql2 = ctx.GetInsertQuery();
                        var idx = sql2.NthIndexOf(Environment.NewLine, 3);
                        if (idx > -1)
                            WriteLog(Environment.NewLine + sql2.Substring(0, idx) + "...................");
                        else
                            WriteLog(sql2);

                        sqlContext.ExecuteNonQuery(sql2);
                        WriteLog("Data Persited");
                    }

                    isBaseDataPersisted = true;
                }
            }
        }

        internal void SetComputedDataObjectContext(SQLContext context)
        {
            foreach (DataObject dob in this.dataObjectCollection.Where(d => d.IsComputed))
            {
                var table = context.GetDataTable(dob.ComputeQuery);
                SetDataContext(dob, table);
            }
        }

        public void WriteMeasureOutput(IWriter writer)
        {
            WriteLog(Constants.BlankLine);
            WriteLog("Writing Measure Output");
            foreach (DataObject dob in dataContextDictionary.Keys)
            {
                var dataObjCtx = dataContextDictionary[dob];
                dataObjCtx.WriteMeasureOutput(writer);
            }
        }

        public void SetBaseDataObjectContext(Dictionary<string, DataTable> objDataDictionary)
        {
            WriteLog(Constants.BlankLine);

            foreach (var key in objDataDictionary.Keys)
            {
                WriteLog($"Set DataContext :[{key}]");
                var table = objDataDictionary[key];

                var dataObj = dataObjectCollection.FirstOrDefault(d => string.Equals(d.DataObjectName, key, StringComparison.OrdinalIgnoreCase));

                SetDataContext(dataObj, table);
            }
        }

        private void SetDataContext(DataObject dob, DataTable table)
        {
            WriteLog(Constants.BlankLine);

            var measureList = measureDefCollection.FindAll(m => m.SourceDataObject == dob.Alias).ToList();

            DataObjectContext ctx = new DataObjectContext(dob, table, WriteLog, measureList);

            dataContextDictionary[dob] = ctx;

        }


        private void LoadDefinition()
        {
            ReadWorkbookAndCleanup();
            
            LoadDataObject(this.GetDataTable(Constants.SheetDataObjectName));
           
            LoadDataFields(this.GetDataTable(Constants.SheetDataFiledDefinition), dataObjectCollection);
           
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
        }

        void LoadDataObject(DataTable sheetDataObject)
        {
            dataObjectCollection = new List<DataObject>();
            WriteLog(Constants.BlankLine);
            foreach (DataRow row in sheetDataObject.Rows)
            {
                WriteLog($"Loading DataObject Definition Configuration [{row[Constants.ColumnFields.DataObject] as string}] alias [{row[Constants.ColumnFields.Alias] as string}]");
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
                WriteLog(Constants.BlankLine);
                WriteLog($"Loading Data Fields Definition Configuration of [{dataObject.DataObjectName}] alias [{dataObject.Alias}]");

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
                    
                    var isNullable = row[Constants.ColumnFields.IsNullable] as string;
                    isNullable = string.IsNullOrEmpty(isNullable) ? "Y" : isNullable.Trim().ToUpper();
                    fld.IsNullable = (isNullable == "Y");

                    fld.DefaultValue = row[Constants.ColumnFields.DefaultValue] as string;
                    fld.Format = row[Constants.ColumnFields.Format] as string;

                    fld.SetIsComputed = row[Constants.ColumnFields.IsComputed] as string;
                    fld.Formula = row[Constants.ColumnFields.ComputeFormula] as string;
                    fld.Remarks = row[Constants.ColumnFields.Remarks] as string;

                    WriteLog($" Field #{rowCounter++}:  [{fld.DataFieldName}] alias [{fld.Alias}]");

                    FieldDefCollection.Add(fld);
                }

                dataObject.FieldDefCollection = FieldDefCollection;

            }

        }

        void LoadMeasureDefinition(DataTable sheetMeasures)
        {
            measureDefCollection = new List<MeasureDef>();
            WriteLog(Constants.BlankLine);
            WriteLog("Loading Measure Definition Configuration");
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

                WriteLog($" Measure Name: [{m.SourceMeasure}] - Source [{m.SourceDataObject}]");

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

        public DataObject GetDataObject(string alias)
        {
            return dataObjectCollection.FirstOrDefault(d => string.Equals(d.Alias, alias, StringComparison.OrdinalIgnoreCase));
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
