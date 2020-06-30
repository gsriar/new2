using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TransactionUtility.Model;
using TransactionUtility.TransactionTool;

namespace TransactionUtility
{
    public class CalculationEngine : IDisposable
    {
        ConfigHandle configHandle;
        InputHandle inputHandle;
        LogWriter logWriter;
        SQLContext context;

        public CalculationEngine(InputParameter inputParam, Action<string> logDelegate)
        {
            logWriter = new LogWriter(inputParam.LogFolder, "log.txt");

            logWriter.Add(logDelegate);

            context = new SQLContext(logWriter.Write);

            configHandle = new ConfigHandle(inputParam.ConfigExcelFilePath, logWriter.Write);

            inputHandle = new InputHandle(inputParam.InputExcelFilePath, logWriter.Write);

        }

        public void Dispose()
        {
            if (configHandle != null)
            {
                configHandle.Dispose();
                configHandle = null;
            }

            if (inputHandle != null)
            {
                inputHandle.Dispose();
                inputHandle = null;
            }

            if (context!=null)
            {
                context.Dispose();
            }

                if (logWriter != null)
            {
                logWriter.Dispose();
                logWriter = null;
            }

           
        }

        public void Evaluate()
        {
            logWriter.Write("Evaluating...");
        }
    }
}
