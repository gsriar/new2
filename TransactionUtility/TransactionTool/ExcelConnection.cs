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

        public ExcelBase(string excelFilePath)
        {
            FileInfo fi = new FileInfo(excelFilePath);
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

        public DataTable GetDataTable(string SheetName)
        {
            throw new NotImplementedException();
        }
    }
}
