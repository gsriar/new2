using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using TransactionUtility.Model;
using TransactionUtility.TransactionTool;

namespace TransactionUtility
{
    public class CalculationEngine : IDisposable
    {
        ConfigHelper config;
        InputDataHelper inputData;
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

                config = new ConfigHelper(inputParameter.ConfigExcelFilePath, logWriter.Write);

                config.Initilize();

                inputData = new InputDataHelper(inputParameter.InputExcelFilePath, logWriter.Write);

                Dictionary<string, DataTable> baseData = inputData.GetBaseData(config.GetBaseDataObjectNames());

                config.SetBaseDataObjectContext(baseData);

                config.ValidateBaseDataObjects();

                //insert data in sql
                config.EvaluateComputedDataObjects(sqlContext);

                //validate computed data types
                config.ValidateComputedDataObjects();

                var outputfile = Path.Combine(inputParameter.LogFolder, prefix + inputParameter.OutputFileName);

                outputAttribute.add("csv", outputfile);

                outputTextWriter = new TextFileWriter(outputfile);

                logWriter.Write(outputfile);

                outputTextWriter.Write(OutputMeasure.CsvHeader);


                config.WriteMeasureOutput(outputTextWriter);
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
            if (config != null)
            {
                config.Dispose();
                config = null;
            }

            if (inputData != null)
            {
                inputData.Dispose();
                inputData = null;
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
