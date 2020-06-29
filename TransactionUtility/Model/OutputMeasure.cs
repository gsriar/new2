using System;
using System.Collections.Generic;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.Model
{
	public class OutputMeasure
	{
		public string DataSourceIdentifier { get; set; }

		public string SourceMeasureSystemCode { get; set; }

		public string InternalOrgIdentifier { get; set; }

		public string ExternalEmpIdentifier { get; set; }

		public string Date { get; set; }

		public string Periodicity { get; set; }

		public string SourceMeasureValue { get; set; }

		public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
