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
        InputParameter inputParameter;
        string prefix;

        public CalculationEngine(InputParameter inputParameter, Action<string> logDelegate)
        {
            this.inputParameter = inputParameter;
            prefix = DateTime.Now.ToString("yyyyMMdd HHmmssff");
            var fileFullName = Path.Combine(this.inputParameter.LogFolder, prefix + "log.txt");
            logWriter = new LogWriter(fileFullName);
            logWriter.Add(logDelegate);
        }
        
        public void Evaluate()
        {
            try
            {
                context = new SQLContext(logWriter.Write);

                configHandle = new ConfigHandle(inputParameter.ConfigExcelFilePath, logWriter.Write);

                configHandle.Initilize();

                inputHandle = new InputHandle(inputParameter.InputExcelFilePath, logWriter.Write);

                var rawdata = inputHandle.GetData(configHandle.GetClientSheetNameList());

                configHandle.SetDataContext(rawdata);

                configHandle.Validate();


                var meaureDef = configHandle.GetMeasureDefCollection;

            }
            catch (Exception ex)
            {
                logWriter.Write(ex.Message);
            }
        }

        private void MeasureEvaluator(List<MeasureDef> MeasureDefCollection, Action<string> textWriter, Action<string> logwriter)
        {
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

            if (context != null)
            {
                context.Dispose();
            }

            if (logWriter != null)
            {
                logWriter.Dispose();
                logWriter = null;
            }


        }
    }
}
