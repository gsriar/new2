using System;
using System.Collections.Generic;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    public class ConfigHandle : ILog
	{
		private Action<String> logDelegate;
		ExcelConnection ExcelConnection;
		List<DataObject> DataObjectCollection;
		List<MeasureDef> MeasureDefCollection;

		public ConfigHandle(string excelFilePath, Action<string> LogDelegate)
        {
            throw new NotImplementedException();
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

        public string GetConstant(string Name)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(string logtext)
        {
            throw new NotImplementedException();
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
    }
}
