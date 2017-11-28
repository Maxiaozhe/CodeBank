
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace TableDesignInfo
{
    public partial class LiveDataContext
    {
        #region Transaction

        partial void OnCreated()
        {
            this.CommandTimeout = Properties.Settings.Default.CommandTimeOut;
        }

        /// <summary>
        /// データベース
        /// </summary>
        /// <returns></returns>
        public void BeginTransaction()
        {
            this.Transaction = this.Connection.BeginTransaction();
        }
        /// <summary>
        /// ロールバック
        /// </summary>
        /// <returns></returns>
        public void RollbackTransaction()
        {
            if (this.Transaction != null)
            {
                this.Transaction.Rollback();
                this.Transaction = null;
            }
        }

        /// <summary>
        /// コミット(BeginTransactoinを使用している場合のみ)
        /// </summary>
        /// <returns></returns>
        public void CommitTransaction()
        {
            if (this.Transaction == null) return;
            this.Transaction.Commit();
            this.Transaction = null;
        }

        #endregion

        public DbConnection GetConnection()
        {
            if (this.Connection.State == ConnectionState.Closed)
            {
                this.Connection.Open();
            }
            return this.Connection;
        }

        public DbCommand GetCommand()
        {
            DbCommand cmd = this.GetConnection().CreateCommand();
            if (this.Transaction != null)
            {
                cmd.Transaction = this.Transaction;
            }
            cmd.CommandTimeout = this.CommandTimeout;
            return cmd;
        }


        #region Execute

        /// <summary>
        /// SqlCommandを実行する
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(DbCommand cmd)
        {
            if (cmd.Connection == null)
            {
                cmd.Connection = this.GetConnection();
            }
            if (this.Transaction != null)
            {
                cmd.Transaction = this.Transaction;
            }
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// クエリを実行し、そのクエリが返す結果セットの最初の行にある最初の列を返します。 
        /// 残りの列または行は無視されます。
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public T ExecuteScalar<T>(DbCommand cmd)
        {
            if (cmd.Connection == null)
            {
                cmd.Connection = this.GetConnection();
            }
            if (this.Transaction != null)
            {
                cmd.Transaction = this.Transaction;
            }
            return (T)cmd.ExecuteScalar();
        }

        public DbDataReader ExecuteReader(DbCommand cmd)
        {
            DbDataReader reader;

            if (cmd.Connection == null)
            {
                cmd.Connection = this.GetConnection();
            }
            if (this.Transaction != null)
            {
                cmd.Transaction = this.Transaction;
            }
            reader = cmd.ExecuteReader();
            return reader;
        }

        public DataSet ExecuteResultSetForSql(DbCommand cmd)
        {
            DataSet dts;

            if (cmd.Connection == null)
            {
                cmd.Connection = this.GetConnection();
            }
            if (this.Transaction != null)
            {
                cmd.Transaction = this.Transaction;
            }
            dts = new DataSet();
            using (DbDataAdapter adapter = new SqlDataAdapter((SqlCommand)cmd))
            {
                adapter.Fill(dts);
            }
            return dts;
        }

        public DataSet ExecuteResultSetForSql(DbCommand cmd, bool IsFillSchema)
        {
            DataSet dts;

            if (cmd.Connection == null)
            {
                cmd.Connection = this.GetConnection();
            }
            if (this.Transaction != null)
            {
                cmd.Transaction = this.Transaction;
            }
            dts = new DataSet();
            using (DbDataAdapter adapter = new SqlDataAdapter((SqlCommand)cmd))
            {
                if (IsFillSchema)
                {
                    adapter.FillSchema(dts, SchemaType.Mapped);
                }
                adapter.Fill(dts);
            }
            return dts;
        }

        public DataTable ExecuteResultSetForSql(DbCommand cmd, string TableName, bool IsFillSchema)
        {
            return ExecuteResultSetForSql(cmd, new DataSet(), TableName, IsFillSchema);
        }

        public DataTable ExecuteResultSetForSql(DbCommand cmd, DataSet rDataSet, string TableName, bool IsFillSchema)
        {
            DataSet dts;

            if (cmd.Connection == null)
            {
                cmd.Connection = this.GetConnection();
            }
            if (this.Transaction != null)
            {
                cmd.Transaction = this.Transaction;
            }
            dts = new DataSet();
            using (DbDataAdapter adapter = new SqlDataAdapter((SqlCommand)cmd))
            {
                if (IsFillSchema)
                {
                    adapter.FillSchema(rDataSet, SchemaType.Mapped, TableName);
                }
                adapter.Fill(rDataSet, TableName);
                if (rDataSet.Tables.Contains(TableName))
                {
                    return rDataSet.Tables[TableName];
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion



    }
    public partial class TableLayoutInfo
    {
        private bool _isChanged = false;
        /// <summary>
        /// プロパティ追加
        /// </summary>
        public string SqlDataType
        {
            get
            {
                if (string.IsNullOrEmpty(this.DataType))
                {
                    return string.Empty;
                }
                string sql = this.DataType;
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
                        if (this.Scale.HasValue && this.Precision.HasValue && this.Scale > 0 && this.Precision > 0)
                        {
                            lengthStr = "(" + this.Precision.Value + " , " + this.Scale.Value + ")";
                        }
                        else
                        {
                            int precision = this.Precision.HasValue ? this.Precision.Value : this.Length.HasValue ? this.Length.Value : 0;
                            if (precision > 0)
                            {
                                lengthStr = "(" + this.Length + ")";
                            }
                        }
                        break;
                    default:
                        break;
                }
                sql = sql + lengthStr;
                return sql;
            }
        }
        /// <summary>
        /// プロパティ追加
        /// </summary>
        public string DataLengthDisplay
        {
            get
            {
                if (string.IsNullOrEmpty(this.DataType))
                {
                    return string.Empty;
                }
                string lengthStr = "";
                switch (this.DataType.ToLower())
                {
                    case "varchar":
                    case "nvarchar":
                    case "varbinary":
                        if (this.Length > 0)
                        {
                            lengthStr = Convert.ToString(this.Length);
                        }
                        else
                        {
                            lengthStr = "max";
                        }
                        break;
                    case "char":
                    case "nchar":
                    case "binary":
                        if (this.Length > 0)
                        {
                            lengthStr = Convert.ToString(this.Length);
                        }
                        break;
                    case "decimal":
                    case "numeric":
                        if (this.Scale.HasValue && this.Precision.HasValue && this.Scale > 0 && this.Precision > 0)
                        {
                            lengthStr = this.Precision.Value + " , " + this.Scale.Value;
                        }
                        else
                        {
                            int precision = this.Precision.HasValue ? this.Precision.Value : this.Length.HasValue ? this.Length.Value : 0;
                            if (precision > 0)
                            {
                                lengthStr = Convert.ToString(this.Length); ;
                            }
                        }
                        break;
                    default:
                        break;
                }
                return lengthStr;
            }
        }
        /// <summary>
        /// データ変更があるかどうかを表す
        /// </summary>
        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }
        }
        /// <summary>
        /// partialメソッドを実装する
        /// </summary>
        partial void OnCreated()
        {
            this.PropertyChanged += OnPropertyChanged;
        }


        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this._isChanged = true;
        }
    }
    public partial class TableList
    {
        private bool _isChanged = false;
        private long? _dataCount = null;

        /// <summary>
        /// データ変更があるかどうかを表す
        /// </summary>
        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }
        }

        public long DataCount
        {
            get
            {
                if (!this._dataCount.HasValue)
                {
                    this._dataCount = Controls.LinqSqlHelp.GetTableDataCount(this.TableName);
                }
                return this._dataCount.Value;
            }
        }

        /// <summary>
        /// partialメソッドを実装する
        /// </summary>
        partial void OnCreated()
        {
            this.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this._isChanged = true;
        }
    }
}