using Rex.Tools.Test.DataCheck.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Tools.Test.DataCheck.Entity
{


    public class TableLayoutInfo
    {
        private string _tableName;
        private string _displayName;
        private List<ColumnInfo> _columns;

        internal TableLayoutInfo(string tableName, DataTable layoutTable)
        {
            this._tableName = tableName;
            this._columns = new List<ColumnInfo>();
            foreach (DataRow row in layoutTable.Rows)
            {
                this._columns.Add(new ColumnInfo(row));
            }
        }

        public TableLayoutInfo(string tableName)
        {
            this._tableName = tableName;
            this._columns = new List<ColumnInfo>();
        }


        public string TableName
        {
            get
            {
                return this._tableName;
            }
        }

        public List<ColumnInfo> Columns
        {
            get
            {
                return _columns;
            }
        }

        public string DisplayName
        {
            get
            {
                return _displayName;
            }

            set
            {
                _displayName = value;
            }
        }

        public string GetCreateScript()
        {
            StringBuilder sb = new StringBuilder();
            string template = Properties.Resources.CreateTable;
            string column = this.CreateColumns();
            string primkey = this.CreateIndexSql();
            sb.AppendFormat(template, this.TableName, this.DisplayName, column, primkey);
            sb.AppendLine();
            return sb.ToString();
        }
        /// <summary>
        /// INSERT文を作成する
        /// </summary>
        /// <param name="row"></param>
        /// <param name="isIdentityOn">ID列を明示的にINSERTかどうか</param>
        /// <returns></returns>
        public string GetInsertScript(DataRow row,bool isIdentityOn)
        {
            StringBuilder sb = new StringBuilder();
            string columns = this.CreateColumnsForInsert(isIdentityOn);
            string values = this.CreateValuesForInsert(row, isIdentityOn);
            sb.AppendFormat("INSERT INTO [{0}] ({1}) VALUES ( {2} )", this.TableName, columns, values);
            
            return sb.ToString();
        }



        public string GetDropScript()
        {
            StringBuilder sb = new StringBuilder();
            string template = Properties.Resources.DropTable;
            sb.AppendFormat(template, this.TableName, this.DisplayName);
            sb.AppendLine();
            return sb.ToString();
        }

        public string GetDropDescriptionScript()
        {
            StringBuilder sb = new StringBuilder();
            //テーブル説明Drop
            string template = Properties.Resources.DropTableDescription;
            sb.AppendFormat(template, this.TableName);
            //カラム説明Drop
            string colTemp = Properties.Resources.DropColumnDescription;
            string commentTemp = Properties.Resources.DropColumnComment;
            foreach (ColumnInfo col in this.Columns)
            {
                //列表示名削除
                sb.AppendFormat(colTemp, this.TableName, col.ColumnName);
                sb.AppendLine();
                //コメント削除
                sb.AppendFormat(commentTemp, this.TableName, col.ColumnName);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public string GetCreateDescriptionScript()
        {
            StringBuilder sb = new StringBuilder();
            //カラム説明
            string colTemp = Properties.Resources.AddColumnDescription;
            string commentTemp = Properties.Resources.AddColumnComment;
            foreach (ColumnInfo col in this.Columns)
            {
                sb.AppendFormat(colTemp, this.TableName, col.ColumnName, col.DisplayName);
                if (!string.IsNullOrWhiteSpace(col.Comment))
                {
                    sb.AppendLine();
                    sb.AppendFormat(commentTemp, this.TableName, col.ColumnName, col.Comment);
                }
            }
            //テーブル説明
            string template = Properties.Resources.AddTableDescription;
            sb.AppendFormat(template, this.TableName, this.DisplayName);
            return sb.ToString();
        }

        /// <summary>
        /// CreateTable Script用列作成のSQL文
        /// </summary>
        /// <returns></returns>
        private string CreateColumns()
        {
            StringBuilder sb = new StringBuilder();
            int index = 0;
            foreach (ColumnInfo column in this.Columns)
            {
                index++;
                sb.Append(column.GetSqlForCreate());
                if (index < this.Columns.Count)
                {
                    sb.Append(",");
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }

        private string CreateIndexSql()
        {
            StringBuilder sb = new StringBuilder();
            var indexCols = this.Columns.Where(col => col.IsPrimaryKey).OrderBy(col => col.IndexColumnId);
            var keyCount = indexCols.Count();
            if (keyCount > 0)
            {
                sb.Append(",");
                sb.AppendLine();
                sb.AppendFormat(" CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED ", this.TableName);
                sb.AppendLine();
                sb.AppendLine("(");
                int index = 0;
                foreach (ColumnInfo col in indexCols)
                {
                    index++;
                    sb.AppendFormat("	[{0}]", col.ColumnName);
                    if (index < keyCount)
                    {
                        sb.Append(",");
                    }
                    sb.AppendLine();
                }
                sb.Append(") WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Insert Script用列作成のSQL文
        /// </summary>
        /// <returns></returns>
        private string CreateColumnsForInsert(bool isIdentityOn)
        {
            StringBuilder sb = new StringBuilder();
            int index = 0;
            foreach (ColumnInfo column in this.Columns)
            {
                if (!column.IsIdentity || isIdentityOn)
                {
                    if (index > 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append("[" + column.ColumnName + "]");
                    index++;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Insert Script用列作成のSQL文
        /// </summary>
        /// <returns></returns>
        private string CreateValuesForInsert(DataRow row,bool isIdentityOn)
        {
            StringBuilder sb = new StringBuilder();
            int index = 0;
            foreach (ColumnInfo column in this.Columns)
            {
                if (!column.IsIdentity || isIdentityOn)
                {
                    if (index > 0)
                    {
                        sb.Append(",");
                    }

                    if (row.Table.Columns.Contains(column.ColumnName))
                    {
                        sb.Append(column.GetValueForInsert(row[column.ColumnName]));
                    }
                    else
                    {
                        sb.Append("NULL");
                    }
                    index++;
                }
            }
            return sb.ToString();
        }




    }

    public partial class ColumnInfo
    {
        private string _columnName;
        private int _columnId;
        private int? _indexColumnId = null;
        private bool _isPrimaryKey = false;
        private string _displayName;
        private string _dataType;
        private int _length;
        private bool _nullable;
        private int _numericPrecision;
        private int _numericScale;
        private string _comment;
        private bool _isIdentity = false;


        internal ColumnInfo(DataRow row)
        {
            this._columnName = Utility.DBToString(row["column_name"]);
            this._columnId = Utility.DBToInteger(row["column_id"]);
            this._dataType = Utility.DBToString(row["DataType"]);
            this._length = Utility.DBToInteger(row["Length"]);
            this._nullable = Utility.DBToBoolean(row["nullable"]);
            this._isPrimaryKey = Utility.DBToBoolean(row["InPrimaryKey"]);
            this._numericPrecision = Utility.DBToInteger(row["NumericPrecision"]);
            this._numericScale = Utility.DBToInteger(row["NumericScale"]);
            if (!row.IsNull("index_column_id"))
            {
                this._indexColumnId = Utility.DBToInteger(row["index_column_id"]);
            }
            if (row.Table.Columns.Contains("display_name"))
            {
                this._displayName = Utility.DBToString(row["display_name"]);
            }
            if (row.Table.Columns.Contains("comment"))
            {
                this._comment = Utility.DBToString(row["comment"]);
            }
            if (row.Table.Columns.Contains("is_identity"))
            {
                this._isIdentity = Utility.DBToBoolean(row["is_identity"]);
            }
        }

        public ColumnInfo()
        {

        }

        public string ColumnName
        {
            get
            {
                return this._columnName;
            }
            set
            {
                this._columnName = value;
            }
        }

        public int ColumnId
        {
            get
            {
                return this._columnId;
            }
            set
            {
                this._columnId = value;
            }
        }

        public bool IsPrimaryKey
        {
            get
            {
                return this._isPrimaryKey;
            }
            set
            {
                this._isPrimaryKey = value;
            }
        }

        public int? IndexColumnId
        {
            get
            {
                return this._indexColumnId;
            }
            set
            {
                _indexColumnId = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                _displayName = value.Trim();
            }
        }

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }

        }

        public bool Nullable
        {
            get
            {
                return this._nullable;
            }
            set
            {
                this._nullable = value;
            }

        }

        public bool IsIdentity
        {
            get { return this._isIdentity; }
            set { this._isIdentity = value; }
        }

        public int NumericPrecision
        {
            get
            {
                return _numericPrecision;
            }

            set
            {
                _numericPrecision = value;
            }
        }

        public int NumericScale
        {
            get
            {
                return _numericScale;
            }

            set
            {
                _numericScale = value;
            }
        }

        public string DataType
        {
            get
            {
                return _dataType;
            }

            set
            {
                _dataType = value;
            }
        }

        public string Comment
        {
            get
            {
                return _comment;
            }

            set
            {
                _comment = value;
            }
        }


        public string GetSqlForCreate()
        {
            string sql = string.Format("	[{0}] [{1}] ", this.ColumnName, this.DataType);
            string lengthStr = "";
            switch (this.DataType.ToLower())
            {
                case "varchar":
                case "nvarchar":
                case "varbinary":
                    if (this.Length > 0)
                    {
                        lengthStr = "(" + this.Length + ")";
                    }
                    else
                    {
                        lengthStr = "( max )";
                    }
                    break;
                case "char":
                case "nchar":
                case "binary":
                    if (this.Length > 0)
                    {
                        lengthStr = "(" + this.Length + ")";
                    }
                    break;
                case "decimal":
                case "numeric":
                    if (this.NumericScale > 0 && this.NumericPrecision > 0)
                    {
                        lengthStr = "(" + this.NumericPrecision + " , " + this.NumericScale + ")";
                    }
                    else
                    {
                        int precision = this.Length > 0 ? this.Length : this.NumericPrecision;
                        if (precision > 0)
                        {
                            lengthStr = "(" + this.Length + ")";
                        }
                    }
                    break;
                default:
                    break;
            }
            sql = sql + lengthStr + (this.Nullable ? " NULL " : " NOT NULL ");
            return sql;

        }

        public string GetSqlType()
        {
            if (string.IsNullOrEmpty(this.DataType))
            {
                return string.Empty;
            }
            string sql = this.DataType.ToUpper();
            string lengthStr = "";
            switch (this.DataType.ToLower())
            {
                case "varchar":
                case "nvarchar":
                case "varbinary":
                    if (this.Length > 0)
                    {
                        lengthStr = "(" + this.Length + ")";
                    }
                    else
                    {
                        lengthStr = "( max )";
                    }
                    break;
                case "char":
                case "nchar":
                case "binary":
                    if (this.Length > 0)
                    {
                        lengthStr = "(" + this.Length + ")";
                    }
                    break;
                case "decimal":
                case "numeric":
                    if (this.NumericScale > 0 && this.NumericPrecision > 0)
                    {
                        lengthStr = "(" + this.NumericPrecision + " , " + this.NumericScale + ")";
                    }
                    else
                    {
                        int precision = this.Length > 0 ? this.Length : this.NumericPrecision;
                        if (precision > 0)
                        {
                            lengthStr = "(" + this.Length + ")";
                        }
                    }
                    break;
                default:
                    break;
            }
            sql = sql + lengthStr + (this.Nullable ? " NULL " : " NOT NULL ");
            return sql;
        }
        /// <summary>
        /// Insert SQL文用値の文字列を取得する
        /// </summary>
        /// <param name="value"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public string GetValueForInsert(object value)
        {
            if (value == null || value is DBNull|| value.Equals("NULL"))
            {
                return this.Nullable ? "NULL" :
                    (IsNumericType ? "0" : "''");
            }
            switch (this.DataType.ToLower())
            {
                case "datetime":
                    DateTime dateVal;
                    if (DateTime.TryParse(value.ToString(), out dateVal))
                    {
                        return "'" + dateVal.ToString("yyyy/MM/dd HH:mm:ss") + "'";
                    }
                    else
                    {
                        return "NULL";
                    }
                case "decimal":
                case "numeric":
                case "tinyint":
                case "int":
                case "bigint":
                case "smallint":
                case "float":
                case "money":
                case "smallmoney":
                    decimal decVal;
                    if (decimal.TryParse(value.ToString(), out decVal))
                    {
                        return value.ToString();
                    }
                    else
                    {
                        return this.Nullable ? "NULL" : "0";
                    }
                case "bit":
                    bool blnVal;
                    string strVal = value.ToString();
                    if (bool.TryParse(strVal, out blnVal))
                    {
                        return blnVal ? "1" : "0";
                    }
                    else
                    {
                        if (strVal.Equals("0") || strVal.Equals("1"))
                        {
                            return strVal;
                        }
                        else
                        {
                            return this.Nullable ? "NULL" : "0";
                        }
                    }
                default:
                    return Utility.SqlQuot(value.ToString());
            }
        }

        private bool IsNumericType
        {
            get
            {
                switch (this.DataType.ToLower())
                {
                    case "decimal":
                    case "numeric":
                    case "bigint":
                    case "int":
                    case "tinyint":
                    case "smallint":
                    case "float":
                    case "money":
                    case "smallmoney":
                        return true;
                    default:
                        return false;
                }
            }
        }

    }
}
