using System;
using System.Collections.Generic;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.Model
{
	public class DataObject
	{
		public string Name { get; set; }

		public string Alias { get; set; }

		public List<FieldDef> FieldDef { get; set; }

		public bool IsCalculated { get; set; }

		public string Query { get; set; }
	}
}
