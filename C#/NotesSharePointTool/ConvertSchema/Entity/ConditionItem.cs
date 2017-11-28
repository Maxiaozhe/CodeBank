using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Interfaces;

namespace RJ.Tools.NotesTransfer.Engines.Entity
{
    [Serializable]
    public class ConditionItem : IConditionItem
    {

        private OperatorType _type;
        [NonSerialized]
        private IFieldRef _fieldRef;
        private string _itemName;

        public ConditionItem(OperatorType operatorType)
        {
            this._type = operatorType;
        }

        public string TagName
        {
            get
            {
                return this.Operator.ToString();
            }
        }

        public OperatorType Operator
        {
            get
            {
                return this._type;
            }
        }

        public IFieldRef FieldRef
        {
            get
            {
                return this._fieldRef;
            }
            set
            {
                this._fieldRef = value;
                this._itemName = this._fieldRef.Name;
            }
        }

        public string ItemName
        {
            get
            {
                return this._itemName;
            }
        }

        public string Value
        {
            get;
            set;
        }

        public void ToXml(XmlWriter writer)
        {
            if (this.IsNumericField())
            {
                if (string.IsNullOrEmpty(this.Value) || IsNumeric(this.Value))
                {
                    writer.WriteStartElement(this.TagName);
                    WriteFieldRef(writer, this.FieldRef);
                    WriteValue(writer, "Number");
                    writer.WriteEndElement();
                }
            }
            else if (IsDatetimeField())
            {
                if (string.IsNullOrEmpty(this.Value) || IsNumeric(this.Value))
                {
                    writer.WriteStartElement(this.TagName);
                    WriteFieldRef(writer, this.FieldRef);
                    WriteValue(writer, "DateTime");
                    writer.WriteEndElement();
                }
            }
            else
            {
                writer.WriteStartElement(this.TagName);
                WriteFieldRef(writer, this.FieldRef);
                WriteValue(writer, "Text");
                writer.WriteEndElement();
            }
        }

        private void WriteFieldRef(XmlWriter writer, IFieldRef fld)
        {
            writer.WriteStartElement("FieldRef");
            writer.WriteAttributeString("Name", fld.RealName);
            writer.WriteEndElement();
        }

        private void WriteValue(XmlWriter writer, string type)
        {
            if (this.Value == null) return;
            writer.WriteStartElement("Value");
            writer.WriteAttributeString("Type", type);
            if (type.Equals("DateTime"))
            {
                DateTime? dateValue = this.GetDateTiem(this.Value);
                if (dateValue.HasValue)
                {
                    writer.WriteString(dateValue.Value.ToString("yyyy-MM-ddTHH:mm:ddZ"));
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.Value))
                {
                    writer.WriteString(this.Value.ToString());
                }
            }
            writer.WriteEndElement();
        }

        private bool IsNumericField()
        {
            if (this.FieldRef.TargetType != SPFieldType.Number &&
               this.FieldRef.TargetType != SPFieldType.Currency &&
               this.FieldRef.TargetType != SPFieldType.Integer)
            {
                return false;
            }
            return true;
        }

        private bool IsDatetimeField()
        {
            if (this.FieldRef.TargetType != SPFieldType.DateTime)
            {
                return false;
            }
            return true;
        }

        private bool IsNumeric(object value)
        {
            decimal decVal;
            if (decimal.TryParse(value.ToString(), out decVal))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 日付かどうかをチェックする
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsDataTime(object value)
        {
            DateTime dateVal;
            if (DateTime.TryParse(value.ToString(), out dateVal))
            {
                return true;
            }
            return false;
        }

        private DateTime? GetDateTiem(object value)
        {
            DateTime dateVal;
            if (DateTime.TryParse(value.ToString(), out dateVal))
            {
                return dateVal;
            }
            return null;
        }


        public override string ToString()
        {
            string format = @"[{0}] {1} ""{2}""";
            string format2 = @"[{0}] が ""{2}"" {1}";
            string name = string.IsNullOrEmpty(this.FieldRef.Title) ? this.ItemName : this.FieldRef.Title;
            string op = "";
            string value = this.Value.ToString();
            switch (this.Operator)
            {
                case OperatorType.Eq:
                    op = " = ";
                    break;
                case OperatorType.Neq:
                    op = " <> ";
                    break;
                case OperatorType.Gt:
                    op = " > ";
                    break;
                case OperatorType.Lt:
                    op = " < ";
                    break;
                case OperatorType.Geq:
                    op = " >= ";
                    break;
                case OperatorType.Leq:
                    op = " <= ";
                    break;
                case OperatorType.Contains:
                    op = " を含む ";
                    break;
                case OperatorType.BeginsWith:
                    op = " で始まる ";
                    break;
                default:
                    return string.Empty;
            }
            if (this.Operator == OperatorType.Contains || this.Operator == OperatorType.BeginsWith)
            {
                return string.Format(format2, name, op, value);
            }
            else
            {
                return string.Format(format, name, op, value);
            }
        }
    }
}
