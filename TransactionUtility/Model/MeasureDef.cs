using System;
using System.Collections.Generic;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.Model
{
	public class MeasureDef
	{
		public string Name { get; set; }

		public string Level { get; set; }

		public string DataSourceIdentifier { get; set; }

		public string Periodidity { get; set; }

		public string DataObjectName { get; set; }

		public string SourceFiledName { get; set; }

		public int SourceDateFieldName { get; set; }

		public string SourceEmployeeFiled { get; set; }

		public string SourceOrgFieldName { get; set; }

		public string FilterClause { get; set; }
	}
}
