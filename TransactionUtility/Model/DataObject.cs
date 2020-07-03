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

        public DataObject(string dataObject, string alias, string isCalculated, string evaluationQuery)
        {
            this.DataObjectName = dataObject;
            this.Alias = alias;
            this.IsCalculated = IsCalculated;
            this.EvaluationQuery = evaluationQuery;
        }

        public string DataObjectName { get; private set; }

		public string Alias { get; private set; } 

        private string IsCalculated { get { return _isCalculated; }  set { _isCalculated = (value ?? "").ToUpper().Trim(); } }

		public string EvaluationQuery { get; private set; }

        public List<FieldDef> FieldDefCollection { get; set; }
        public bool IsComputed { get { return IsCalculated == "Y"; } }

        public FieldDef GetFieldDef(string alias)
        {
          return this.FieldDefCollection.FirstOrDefault(f => f.Alias == alias);
        }
    }
}
