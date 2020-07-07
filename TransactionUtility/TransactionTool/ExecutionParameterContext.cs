using System;
using System.Collections.Generic;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
	public class ExecutionParameterContext
	{
		public InputParameter InputParameter { get; set; }
		
		public SQLContext SQLContext { get; set; }

		public ConfigHelper ConfigHandle { get; set; }

		public InputDataHelper InputHandle { get; set; }
	}
}
