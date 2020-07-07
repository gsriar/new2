using System;
using System.Collections.Generic;
using System.Text;
using TransactionUtility.Model;

namespace TransactionUtility.Model
{
    public class FieldDef
    {
        private string _iscalcuated;
        private string _dataType;
        private object _typeDefault;
        private Type _type;
        private string _isNullable;

        public string DataObject { get; set; }
        public string DataFieldName { get; set; }
        public string Alias { get; set; }
        public string DataType
        {
            get { return _dataType; }
            set
            {
                _dataType = (value ?? "").ToUpper();


                _type = CommonFunctions.GetType(_dataType);

                _typeDefault = CommonFunctions.TypeDefaultValue(_dataType);

            }
        }

        public Type Type { get { return _type; } }

        public object TypeDefaultValue { get { return _typeDefault; } }

        public bool IsNullable { get; set; }

        public string SetIsComputed
        {
            set
            {
                _iscalcuated = (value ?? "").ToUpper().Trim();
            }
        }

        public bool IsComputed
        {
            get { return _iscalcuated.ToUpper() == "Y"; }
        }
        public string Formula { get; set; }
        public string Remarks { get; set; }
        public object DefaultValue { get; internal set; }
        public string Format { get; internal set; }
    }
}
