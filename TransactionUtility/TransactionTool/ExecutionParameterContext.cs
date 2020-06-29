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

		public ConfigHandle ConfigHandle { get; set; }

		public InputHandle InputHandle { get; set; }
	}
}
