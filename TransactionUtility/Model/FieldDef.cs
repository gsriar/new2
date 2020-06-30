using System;
using System.Collections.Generic;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.Model
{
	public class FieldDef
	{
        public string DataObject { get; set; }
        public string DataFieldName { get; set; }
        public string Alias { get; set; }
        public string DataType { get; set; }
        public string IsNullable { get; set; }
        public string IsCalculated { get; set; }
        public string Formula { get; set; }
        public string Remarks { get; set; }

		public DataFieldType DataFieldType()
        {
            return Model.DataFieldType.Numeric;
        }
	}
}
