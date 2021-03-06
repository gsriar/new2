using System;
using System.Collections.Generic;
using System.Text;
using TransactionUtility.Model;
using TransactionUtility.TransactionTool;

namespace TransactionUtility
{
	public class InputParameter
	{
		public string ConfigExcelFilePath { get; set; }

		public string InputExcelFilePath { get; set; }

		public string CompletedFolder { get; set; }

		public string OutputFileName { get; set; }

		public string ErrorFolder { get; set; }

        public string LogFolder { get; set; }
    }
}
