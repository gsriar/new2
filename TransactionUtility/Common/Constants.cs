using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionUtility
{
    static class Constants
    {
        internal static readonly string SheetConstants ="Constants";
        public static string SheetDataObjectName = "DataObject";
        public static string SheetDataFiledDefinition = "DataFieldDefinition";
        public static string SheetMeasureDefinition = "MeasureDefinition";
        internal static string BlankLine = "";

        public static string[] configSheets = {
            SheetDataObjectName,
            SheetDataFiledDefinition,
            SheetMeasureDefinition
        };
       

        public static class DataTypes
        {
            public const string Text = "TEXT";
            public const string Numeric = "NUMERIC";
            public const string Date = "DATE";
            public const string Integer = "INT";
            public const string Int = "INTEGER";
        }

        public static class ColumnFields
        {
            public static string DataObject = "DataObject";
            public static string Alias = "Alias";
            public static string ComputeQuery = "ComputeQuery";
            public static string IsComputed = "IsComputed";

            public static string DataFieldName = "DataFieldName";
            public static string DataType = "DataType";
            public static string IsNullable = "IsNullable";
            public static string DefaultValue = "DefaultValue";
            public static string Format = "Format";

            public static string ComputeFormula = "ComputeFormula";
            public static string Remarks = "Remarks";

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

            public static string[] DataObjectFieldList = {
                                                        DataObject,
                                                        Alias,
                                                        IsComputed,
                                                        ComputeQuery,
                                                        Remarks };


            

            public static string[] DataFieldList = {
                                                    DataObject,
                                                    DataFieldName,
                                                    Alias,
                                                    DataType,
                                                    IsNullable,
                                                    DefaultValue,
                                                    Format,
                                                    IsComputed,
                                                    ComputeFormula,
                                                    Remarks};


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

