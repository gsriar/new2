using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    public class ExcelBase : IExcelConnection, IDisposable
    {
        protected XLWorkbook workBook;
        private List<string> allSheets;
        Dictionary<string, DataTable> tableCollection = new Dictionary<string, DataTable>();
        FileInfo excelFile = null;
        Action<string> logDelegate;

        public ExcelBase(string excelFilePath,Action<string> LogDelegate,string title="")
        {
            this.logDelegate = LogDelegate;
            WriteLog(Constants.BlankLine);
            FileInfo fi = new FileInfo(excelFilePath);

            WriteLog($"[{title}] Excel: {fi.FullName}");

            if (!fi.Exists)
                throw new Exception($"File does not exists [{fi.FullName}]");

            if (fi.Extension.ToLower() != ".xlsx")
                throw new Exception($"File is not (.xlsx) extension");

            excelFile = new FileInfo(excelFilePath);
            workBook = new XLWorkbook(excelFile.FullName);
        }
        public virtual void Dispose()
        {
            workBook.Dispose();
        }

        public List<string> GetAllSheetNameList()
        {
            if (allSheets == null)
            {
                List<string> listSheet = new List<string>();
                foreach (IXLWorksheet workSheet in workBook.Worksheets)
                {
                    listSheet.Add(workSheet.Name);
                }

                allSheets = listSheet;
            }

            return allSheets;
        }

        public DataTable GetDataTable(string sheetName, int headerRow = 1)
        {
            if (tableCollection.ContainsKey(sheetName))
                return tableCollection[sheetName];

            var sheets = GetAllSheetNameList();

            WriteLog($"Read Config Worksheet Name:[{sheetName}] from:[{excelFile.Name}]");
           

            if (!sheets.Contains(sheetName))
            {
                throw new Exception($"Workbook [{excelFile.Name}] does not contain sheet [{sheetName}]");
            }


            if (headerRow <= 0)
                headerRow = 1;

            //Read the first Sheet from Excel file.
            IXLWorksheet workSheet = workBook.Worksheet(sheetName);

            //Create a new DataTable.
            DataTable dt = new DataTable();

            int count = 0;
            //Loop through the Worksheet rows.
            bool firstRow = true;

            foreach (IXLRow row in workSheet.Rows())
            {
                count++;
                if (count < headerRow)
                {
                    continue;
                }

                //Use the first row to add columns to DataTable.
                if (firstRow)
                {
                    foreach (IXLCell cell in row.Cells())
                    {
                        dt.Columns.Add(cell.Value.ToString());
                    }
                    firstRow = false;
                }
                else
                {
                    if (!row.IsEmpty())
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;

                        foreach (IXLCell cell in row.Cells(row.FirstCell().Address.ColumnNumber, row.LastCellUsed().Address.ColumnNumber))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value ?? "".ToString();
                            i++;
                        }
                    }
                }
            }
           
            tableCollection[sheetName] = dt;
            return dt;
        }

        public DataTable GetHeaderRowDataTable(string sheetName, int headerRow = 1)
        {
            if (tableCollection.ContainsKey(sheetName))
                return tableCollection[sheetName];

            var sheets = GetAllSheetNameList();

            if (!sheets.Contains(sheetName))
            {
                throw new Exception($"Workbook [{excelFile.Name}] does not contain sheet [{sheetName}]");
            }


            if (headerRow <= 0)
                headerRow = 1;

            //Read the first Sheet from Excel file.
            IXLWorksheet workSheet = workBook.Worksheet(sheetName);

            //Create a new DataTable.
            DataTable dt = new DataTable();

            int count = 0;
            //Loop through the Worksheet rows.
            bool firstRow = true;

            foreach (IXLRow row in workSheet.Rows())
            {
                count++;
                if (count < headerRow)
                {
                    continue;
                }

                //Use the first row to add columns to DataTable.
                if (firstRow)
                {
                    foreach (IXLCell cell in row.Cells())
                    {
                        dt.Columns.Add(cell.Value.ToString());
                    }
                    firstRow = false;
                }
                break;
            }

            return dt;
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

