using System;
using System.Collections.Generic;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.Model
{
	public class OutputMeasure
	{
		public object DataSourceIdentifier { get; set; }

		public object SourceMeasureSystemCode { get; set; }

		public object InternalOrgIdentifier { get; set; }

		public object ExternalEmpIdentifier { get; set; }

		public string Date { get; set; }

		public object Periodicity { get; set; }

		public object SourceMeasureValue { get; set; }

        public static string CsvHeader = "DataSourceIdentifier,SourceMeasureSystemCode,InternalOrgIdentifier,ExternalEmpIdentifier,Date,Periodicity,SourceMeasureValue";

        public override string ToString()
        {
            return $"{DataSourceIdentifier },{SourceMeasureSystemCode},{InternalOrgIdentifier},{ExternalEmpIdentifier},{Date},{Periodicity},{SourceMeasureValue}";
        }
    }
}
