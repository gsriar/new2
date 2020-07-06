using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionUtility.TransactionTool
{
    class Log : ILog
    {
        private Action<string> writeDelegate;

        public Log(Action<string> writeDelegate)
        {
            this.writeDelegate = writeDelegate;
        }
        public void WriteLog(string logText)
        {
            if (this.writeDelegate!=null)
            {
                this.writeDelegate(logText);
            }
        }
    }
}
