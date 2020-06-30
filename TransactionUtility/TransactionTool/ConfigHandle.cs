using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    public class ConfigHandle : ILog, IDisposable, IExcelConnection
    {
        private Action<String> logDelegate;
        List<DataObject> DataObjectCollection;
        List<MeasureDef> MeasureDefCollection;
        private XLWorkbook workBook;
        private List<string> allSheets;

        public ConfigHandle(string excelFilePath, Action<string> LogDelegate)
        {
            this.logDelegate = LogDelegate;
            FileInfo fi = new FileInfo(excelFilePath);
            workBook = new XLWorkbook(fi.FullName);

        }

        private void Init()
        {
            throw new NotImplementedException();
        }


        private void LoadDataObjectDefinition()
        {
            throw new NotImplementedException();
        }

        private void LoadFieldObjectSchema(DataObject dataObj)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllSheets()
        {
            if (allSheets == null)
            {
                List<string> listSheet = new List<string>();
                foreach (IXLWorksheet workSheet in workBook.Worksheets)
                {
                    listSheet.Add(workSheet.Name);
                }

                WriteLog("All Sheets :" + string.Join(" | ", listSheet));

                allSheets = listSheet;
            }

            return allSheets;
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

        public void Dispose()
        {
            if (workBook != null)
            {
                workBook.Dispose();
                workBook = null;
            }
        }

        public List<string> GetAllSheet()
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(string SheetName)
        {
            throw new NotImplementedException();
        }
    }
}
