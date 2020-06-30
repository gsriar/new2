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
        Dictionary<string, DataTable> tableColl = new Dictionary<string, DataTable>();
        FileInfo fi = null;


        public ExcelBase(string excelFilePath)
        {
            fi = new FileInfo(excelFilePath);
            workBook = new XLWorkbook(fi.FullName);
        }
        public virtual void Dispose()
        {
            workBook.Dispose();
        }

        public List<string> GetAllSheet()
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

        public DataTable GetDataTable(string sheetName, int headerRow=1)
        {
            var sheets = GetAllSheet();

            if(!sheets.Contains(sheetName))
            {
                throw new Exception($"Workbook [{fi.Name}] does not contain sheet [{sheetName}]");
            }

            if (tableColl.ContainsKey(sheetName))
                return tableColl[sheetName];

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
                    //Add rows to DataTable.
                    dt.Rows.Add();
                    int i = 0;

                    //foreach (IXLCell cell in row.Cells(row.FirstCellUsed().Address.ColumnNumber, row.LastCellUsed().Address.ColumnNumber))
                    foreach (IXLCell cell in row.Cells())
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell.Value??"".ToString();
                        i++;
                    }
                }
            }
            tableColl[sheetName] = dt;
            return dt;
        }
    }
}

