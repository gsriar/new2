using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionUtility.TransactionTool
{
    class TextFileWriter : IWriter
    {
        StreamWriter outputFile;
        public TextFileWriter(string fileFullName)
        {
            File.WriteAllText(fileFullName, "");

            StringWriter t = new StringWriter();

            outputFile = new StreamWriter(fileFullName);
        }

        public void Dispose()
        {
            if (outputFile != null)
            {
                outputFile.Close();
                outputFile.Dispose();
                outputFile = null;
            }
        }

        public virtual void Write(string text)
        {
            outputFile.WriteLine(text);
        }
    }
}
