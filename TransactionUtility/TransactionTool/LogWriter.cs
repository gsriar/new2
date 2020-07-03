using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.TransactionTool
{
    class LogWriter : TextFileWriter
    {
        public LogWriter(string fileFullName) : base(fileFullName) { }

        Action<string> additionalWriter;
        private int count=1;

        public void Add(Action<string> additionalWriter)
        {
            this.additionalWriter = additionalWriter;
        }
        public override void Write(string text)
        {
            string txt = $"[{count++.ToString("00")}] - {text}";

            base.Write(txt);
            if (additionalWriter != null)
                additionalWriter(txt);
        }
    }
}
