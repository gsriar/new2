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

        public object TypeDefault { get { return _typeDefault; } }

        public string IsNullable { get; set; }

        public string SetIsCalculated
        {
            set
            {
                _iscalcuated = (value ?? "") == "" ? "N" : value;
            }
        }

        public bool IsCalculated
        {
            get { return _iscalcuated.ToUpper() == "Y"; }
        }
        public string Formula { get; set; }
        public string Remarks { get; set; }

		public DataFieldType DataFieldType()
        {
            return Model.DataFieldType.Numeric;
        }
	}
}
