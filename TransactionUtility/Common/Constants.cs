using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionUtility
{
    static class Constants
    {
        public static string SheetDataObject = "DataObject";
        public static string SheetDataFiledDefinition = "DataFiledDefinition";
        public static string SheetMearsureDefinition = "MearsureDefinition";

        public static string[] configSheets = {
            SheetDataObject,
            SheetDataFiledDefinition,
            SheetMearsureDefinition
        };

        public static class ColumnFields
        {
            public static string DataObject = "DataObject";
            public static string Alias = "Alias";
            public static string EvaluationQuery = "Evaluation Query";
            public static string IsCalculated = "IsCalculated";

            public static string Remarks = "Remarks";

            public static string[] DataObjectFieldList = {
            DataObject,
            Alias,
            IsCalculated,
            EvaluationQuery,
            Remarks };
            //DataObject	Alias	IsCalculated	Evaluation Query	Remarks


            public static string DataFieldName = "Data Field Name";
            public static string DataType = "Data Type";
            public static string IsNullable = "IsNullable";
            public static string Formula = "Formula";

            public static string[] DataFieldList = {
            DataObject,
            DataFieldName,
            Alias,
            DataType,
            IsNullable,
            IsCalculated,
            Formula,
            Remarks};


            public static string SourceMeasure = "SourceMeasure";
            public static string PersonOrOrg = "PersonOrOrg";
            public static string DataSourceIdentifier = "DataSourceIdentifier";
            public static string Periodicity = "Periodicity";
            public static string SourceDataObject = "SourceDataObject";
            public static string SourceMeasureMappingField = "SourceMeasureMappingField";
            public static string SourceDateMappingField = "SourceDateMappingField";
            public static string SourceEmployeeMappingField = "SourceEmployeeMappingField";
            public static string SourceOrgMappingField = "SourceOrgMappingField";
            public static string FilterClause = "FilterClause";
            public static string Comments = "Comments";

            public static string[] MeasureFieldList = {
            SourceMeasure,
            PersonOrOrg,
            DataSourceIdentifier,
            Periodicity,
            SourceDataObject,
            SourceMeasureMappingField,
            SourceDateMappingField,
            SourceEmployeeMappingField,
            SourceOrgMappingField,
            FilterClause,
            Comments};

        }
    }
}

