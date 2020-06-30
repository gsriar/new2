using System;
using System.Collections.Generic;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.Model
{
	public class MeasureDef
	{
        public string SourceMeasure { get; set; }
        public string PersonOrOrg { get; set; }
        public string DataSourceIdentifier { get; set; }
        public string Periodicity { get; set; }
        public string SourceDataObject { get; set; }
        public string SourceMeasureMappingField { get; set; }
        public string SourceDateMappingField { get; set; }
        public string SourceEmployeeMappingField { get; set; }
        public string SourceOrgMappingField { get; set; }
        public string FilterClause { get; set; }
        public string Comments { get; set; }
    }
}
