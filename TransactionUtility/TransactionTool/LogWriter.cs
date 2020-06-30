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
        public LogWriter(string folder,string fileNameSuffix) {

            var fileName = Path.Combine(folder, DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss.ff-") + fileNameSuffix);

            File.WriteAllText(fileName, "");

            StringWriter t = new StringWriter();

            outputFile = new StreamWriter(fileName);

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
