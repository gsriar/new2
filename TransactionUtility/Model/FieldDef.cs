using System;
using System.Collections.Generic;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.Model
{
	public class FieldDef
	{
		public string Name { get; set; }

		public string Alias { get; set; }

		public string TypeName { get; set; }

		public bool Nullable { get; set; }

		public bool IsCalculated { get; set; }

		public string Expression { get; set; }

		public DataFieldType DataFieldType { get; set; }
	}
}
