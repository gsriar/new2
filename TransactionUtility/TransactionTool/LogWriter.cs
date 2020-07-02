using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    public class LogWriter:IDisposable
	{
        StreamWriter outputFile;
        public LogWriter(string fileFullName) {

            File.WriteAllText(fileFullName, "");

            StringWriter t = new StringWriter();

            outputFile = new StreamWriter(fileFullName);

        }

        Action<string> logger;

        public void Add(Action<string> logger)
        {
            this.logger = logger;

        }

        public void Dispose()
        {
            if(outputFile!=null )
            {
                outputFile.Close();
                outputFile.Dispose();
                outputFile = null;
            }
        }

        int count = 1;
        public void Write(string text)
        {
            string txt=$"[{count++.ToString("00")}] - {text}";
           
            outputFile.WriteLine(txt);

            if (this.logger != null)
                this.logger(txt);
        }
    }
}
