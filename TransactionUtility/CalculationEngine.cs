using System;
using System.Collections.Generic;
using System.Text;
using TransactionUtility.Model;
using TransactionUtility.TransactionTool;

namespace TransactionUtility
{
	public class CalculationEngine
	{
        ConfigHandle ConfigHandle;
		InputHandle InputHandle;
		LogWriter LogWriter;
        Action<string> log;


        public CalculationEngine(InputParameter parameters, Action<string> log)
        {
            this.log = log;
            LogWriter = new LogWriter();
        }

        public void Evaluate()
        {
            WriteLog("Working");
        }


        private void WriteLog(string logtext)
        {
            if (!(log is null))
                log(logtext);

            LogWriter.Write(logtext);
        }
    }
}
