using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.Model
{
    public class DataObject
    {

        public DataObject(string dataObject, string alias, string isCalculated, string evaluationQuery)
        {
            this.DataObjectName = dataObject;
            this.Alias = alias;
            this.IsCalculated = IsCalculated;
            this.EvaluationQuery = evaluationQuery;
        }

        public string DataObjectName { get; private set; }

		public string Alias { get; private set; } 

        public string IsCalculated { get; private set; }

		public string EvaluationQuery { get; private set; }

        public List<FieldDef> FieldDefCollection { get; set; }

        public FieldDef GetFieldDef(string alias)
        {
          return this.FieldDefCollection.FirstOrDefault(f => f.Alias == alias);
        }
    }
}
