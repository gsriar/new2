using System;
using System.Collections.Generic;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
	public interface ILog
	{
		void WriteLog(string logText);
	}
}
