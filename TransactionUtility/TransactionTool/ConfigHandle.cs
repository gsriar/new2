using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    public class ConfigHandle : ExcelBase, ILog, IDisposable
    {
        private Action<String> logDelegate;
        List<DataObject> dataObjectCollection;
        List<MeasureDef> measureDefCollection;
       
        public ConfigHandle(string excelFilePath, Action<string> LogDelegate) : base(excelFilePath)
        {
            FileInfo fi = new FileInfo(excelFilePath);

            if (!fi.Exists)
                throw new Exception($"File does nor exists [{fi.Name}]");

            if(fi.Extension.ToLower()!=".xlsx")
                throw new Exception($"File [{fi.Name}] extension is not [{fi.Extension}]");

            this.logDelegate = LogDelegate;
        }

        public void Init()
        {
            LoadDefinition();
        }

        private void LoadDefinition()
        {
            WriteLog($"Loading [{Constants.SheetConstants}]");
            var sheetConstants = this.GetDataTable(Constants.SheetConstants);

            WriteLog($"Loading [{Constants.SheetDataFiledDefinition}]");
            var sheetDataObject = this.GetDataTable(Constants.SheetDataObjectName);

            WriteLog($"Loading [{Constants.SheetDataFiledDefinition}]");
            var sheetDataFields = this.GetDataTable(Constants.SheetDataFiledDefinition);

            WriteLog($"Loading config [{Constants.SheetMeasureDefinition}]");
            var sheetMeasures = this.GetDataTable(Constants.SheetMeasureDefinition);

            var delQueryDataObject = $"{Constants.ColumnFields.DataObject}='' or {Constants.ColumnFields.DataObject} is null";
            var delQuerySourceMeasure = $"{Constants.ColumnFields.SourceMeasure}='' or {Constants.ColumnFields.SourceMeasure} is null";

            CommonFunctions.Delete(sheetDataObject, delQueryDataObject);
            WriteLog($"DataObject definition Count : {sheetDataObject.Rows.Count}");
            
            CommonFunctions.Delete(sheetDataFields, delQueryDataObject);
            WriteLog($"Data Field Definition Count : {sheetDataObject.Rows.Count}");

            CommonFunctions.Delete(sheetMeasures, delQuerySourceMeasure);
            WriteLog($"Source Measure Definition Count : {sheetDataObject.Rows.Count}");

            LoadDataObject(sheetDataObject);

            LoadDataFields(sheetDataFields, dataObjectCollection);

            LoadMeasureDefinition(sheetMeasures);

        }

        void LoadDataObject(DataTable sheetDataObject)
        {
            dataObjectCollection = new List<DataObject>();

            foreach (DataRow row in sheetDataObject.Rows)
            {
                WriteLog($"Loading Dataobject [{row["dataObject"] as string}.{row["alias"] as string}]");
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
                    fld.IsCalculated = row["IsCalculated"] as string;
                    fld.Formula = row["Formula"] as string;
                    fld.Remarks = row["Remarks"] as string;

                    WriteLog($"Fields  [{fld.DataObject}.{fld.DataFieldName}]");

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

                WriteLog($"Loading Measure Definition  [{m.SourceMeasure}]");

                measureDefCollection.Add(m);
            }

        }



        public string GetConstant(string Name)
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

        public DataObjectContext GetDataObjectContext(DataObject dataObj)
        {
            throw new NotImplementedException();
        }

        public DataObject GetDataObject(string Name)
        {
            throw new NotImplementedException();
        }

        public List<MeasureDef> GetMeasureDefCollection()
        {
            throw new NotImplementedException();
        }

        public List<DataObject> GetDataObjectCollection()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            base.Dispose();
        }

    }
}
