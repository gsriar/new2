using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    public class ExcelBase : IExcelConnection
    {
        protected XLWorkbook workBook;
        private List<string> allSheets;
        Dictionary<string, DataTable> tableCollection = new Dictionary<string, DataTable>();
        FileInfo excelFile = null;
        Action<string> logDelegate;

        public ExcelBase(string excelFilePath,Action<string> LogDelegate)
        {
            this.logDelegate = LogDelegate;
            WriteLog($"...");
            WriteLog($"Loading File : {excelFilePath}");
           
            FileInfo fi = new FileInfo(excelFilePath);

            if (!fi.Exists)
                throw new Exception($"File does not exists [{fi.Name}]");

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

            WriteLog($"Read Worksheet [{sheetName}]");
           

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

                        foreach (IXLCell cell in row.Cells(row.FirstCellUsed().Address.ColumnNumber, row.LastCellUsed().Address.ColumnNumber))
                        //foreach (IXLCell cell in row.Cells())
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

        public void WriteLog(string logtext)
        {
            if (logDelegate != null)
            {
                logDelegate(logtext);
            }
        }
    }
}

