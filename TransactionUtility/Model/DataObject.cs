using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.Model
{
    public class DataObject
    {
        private string _isCalculated;

        public DataObject(string dataObject, string alias, string isCalculated, string computeQuery)
        {
            this.DataObjectName = dataObject;
            this.Alias = alias;
            this._isCalculated = isCalculated;
            this.ComputeQuery = computeQuery;
        }

        public string DataObjectName { get; private set; }

		public string Alias { get; private set; } 

        private string IsCalculated { get { return _isCalculated; }  set { _isCalculated = (value ?? "").ToUpper().Trim(); } }

		public string ComputeQuery { get; private set; }

        public List<FieldDef> FieldDefCollection { get; set; }
        public bool IsComputed { get { return IsCalculated == "Y"; } }

        public FieldDef GetFieldDef(string alias)
        {
          return this.FieldDefCollection.FirstOrDefault(f => f.Alias == alias);
        }
    }
}
