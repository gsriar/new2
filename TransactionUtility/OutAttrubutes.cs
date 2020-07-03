using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionUtility
{
    public class OutAttrubute
    {
        private Dictionary<string, string> attribs = new Dictionary<string, string>();

        internal void add(string key, string value)
        {
            attribs[key] = value;
        }

        public string GetAttrib(string key)
        {
            if (attribs.ContainsKey(key))
                return attribs[key];

            return null;
        }
    }
}
