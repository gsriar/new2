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
        SQLContext sqlContext;
        InputParameter inputParameter;
        TextFileWriter outputTextWriter;
        string prefix;
        string logFileName;

        public CalculationEngine(InputParameter inputParameter, Action<string> logDelegate)
        {
            this.inputParameter = inputParameter;
            prefix = DateTime.Now.ToString("yyyyMMdd-HH.mm.ss.fff-");
            logFileName = Path.Combine(this.inputParameter.LogFolder, prefix + "log.txt");
            logWriter = new LogWriter(logFileName);
            logWriter.Add(logDelegate);
            logWriter.Write($"Log File : {logFileName}");
        }
        
        public void Evaluate(out OutAttrubute outputAttribute)
        {
            outputAttribute = new OutAttrubute();
            try
            {
                outputAttribute.add("log", logFileName);
                sqlContext = new SQLContext(logWriter.Write);

                configHandle = new ConfigHandle(inputParameter.ConfigExcelFilePath, logWriter.Write);

                configHandle.Initilize();

                inputHandle = new InputHandle(inputParameter.InputExcelFilePath, logWriter.Write);

                var rawDataTables = inputHandle.GetRawDataTables(configHandle.GetBaseDataObjectNames());

                configHandle.SetDataContext(rawDataTables);

                configHandle.Validate();

                //insert data in sql
                configHandle.RunComputedDataObjects(sqlContext);

                //validate computed data types
                //configHandle.ValidateComputedDataObjects();

                var outputfile = Path.Combine(inputParameter.LogFolder, prefix + inputParameter.OutputFileName);

                outputAttribute.add("csv", outputfile);

                outputTextWriter = new TextFileWriter(outputfile);

                logWriter.Write(outputfile);

                outputTextWriter.Write(OutputMeasure.CsvHeader);


                configHandle.WriteMeasureOutput(outputTextWriter);
            }
            catch (Exception ex)
            {
                logWriter.Write(ex.Message);
            }
        }

        private void MeasureEvaluator(List<MeasureDef> MeasureDefCollection)
        {
            foreach(MeasureDef mdef in MeasureDefCollection)
            {

            }
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

            if (sqlContext != null)
            {
                sqlContext.Dispose();
            }

            if (logWriter != null)
            {
                logWriter.Dispose();
                logWriter = null;
            }

            if (outputTextWriter != null)
            {
                outputTextWriter.Dispose();
                outputTextWriter = null;
            }
        }
    }
}
