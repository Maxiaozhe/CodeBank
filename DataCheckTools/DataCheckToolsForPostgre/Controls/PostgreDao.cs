using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Rex.Tools.Test.DataCheck.Controls
{
    public class PostgreDao : IDisposable
    {
        
        #region Field
        private bool _IsConnected;
        private Exception _InnerException;
        private int _CommandTimeout;
        private NpgsqlConnection _sqlConnect;
        private NpgsqlTransaction _sqlTran;
        private string _ConnString;
        #endregion

        #region Property
        /// <summary>
        /// SQL Server データベースへの開いた接続を表します
        /// </summary>
        internal NpgsqlConnection Connection
        {
            get
            {
                if (!this._IsConnected)
                {
                    this._sqlConnect = new NpgsqlConnection(this._ConnString);
                    this._sqlConnect.Open();
                    this._IsConnected = true;
                }
                return this._sqlConnect;
            }
        }

        public virtual int CommandTimeout
        {
            get
            {
                return this._CommandTimeout;
            }
            set
            {
                this._CommandTimeout = value;
            }
        }

        public virtual bool IsConnected
        {
            get
            {
                return this._IsConnected;
            }
        }

        public virtual string ConnectionString
        {
            get
            {
                return this._ConnString;
            }
        }

      
        public virtual Exception LastException
        {
            get
            {
                return this._InnerException;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// インスタンスを作成する
        /// </summary>
        private PostgreDao()
        {

        }
        /// <summary>
        /// Databaseのインスタンスを取得する
        /// （Windows認証モード）
        /// </summary>
        /// <param name="server">サーバー</param>
        /// <param name="database">データベース</param>
        /// <param name="connectTimeout"></param>
        /// <param name="commandTimeOut"></param>
        /// <returns></returns>
        internal PostgreDao(string connectString, int commandTimeOut)
        {
            this._IsConnected = false;
            this._CommandTimeout = (commandTimeOut == 0 ? 100 : commandTimeOut);
            this._ConnString = connectString;
            this.disposedValue = false;
        }
  
        #endregion

        #region Method

        #region Transaction
        /// <summary>
        /// データベース
        /// </summary>
        /// <returns></returns>
        public virtual bool BeginTransaction()
        {
            bool flag;

            try
            {
                this._sqlTran = this.Connection.BeginTransaction();
                flag = true;
                return flag;
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
        }
        /// <summary>
        /// ロールバック
        /// </summary>
        /// <returns></returns>
        public virtual bool RollbackTransaction()
        {
            bool flag;
            if (!this._IsConnected)
            {
                this.Connect();
            }
            try
            {
                if (this._sqlTran != null)
                {
                    this._sqlTran.Rollback();
                    this._sqlTran = null;
                }
                flag = true;
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                flag = false;
            }
            return flag;
        }
        #endregion


        #region CommitTransaction
        /// <summary>
        /// コミット(BeginTransactoinを使用している場合のみ)
        /// </summary>
        /// <returns></returns>
        public virtual bool CommitTransaction()
        {
            if (!this._IsConnected)
            {
                this.Connect();
            }
            try
            {
                this._sqlTran.Commit();
                this._sqlTran = null;
                return true;
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
        }
        #endregion

        #region Connect
        public virtual bool Connect()
        {
            try
            {
                this._sqlConnect = new NpgsqlConnection(this._ConnString);
                this._sqlConnect.Open();
                this._IsConnected = true;
                return true;
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }

        }
        #endregion

        #region CreateCommand
        public virtual NpgsqlCommand CreateCommand()
        {
            NpgsqlCommand cmd;
            try
            {
                cmd = this.Connection.CreateCommand();
                if (this._sqlTran != null)
                {
                    cmd.Transaction = this._sqlTran;
                }
                cmd.CommandTimeout = this._CommandTimeout;
                return cmd;
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
        }
        #endregion

        #region SelectSql

        /// <summary>
        /// SQL実行(sqlDataReaderを使用する場合)
        /// </summary>
        /// <param name="rstrSQL"></param>
        /// <param name="sqlReader"></param>
        /// <returns></returns>
        public NpgsqlDataReader SelectSql(string rstrSQL)
        {
            try
            {
                if (!this._IsConnected)
                {
                    this.Connect();
                }
                using (NpgsqlCommand cmd = this.CreateCommand())
                {
                    cmd.CommandText = rstrSQL;
                    NpgsqlDataReader sqlReader = cmd.ExecuteReader();
                    return sqlReader;
                }
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
        }

        /// <summary>
        /// Select文を発行する
        /// </summary>
        /// <param name="sql">SQL文</param>
        /// <param name="tableName">検索結果のテーブル名</param>
        /// <returns>検索結果データテーブル</returns>
        public DataTable SelectSql(string sql, string tableName)
        {
            NpgsqlDataAdapter adapter = null;
            try
            {
                using (NpgsqlCommand cmd = this.CreateCommand())
                {
                    cmd.CommandText = sql;
                    adapter = new NpgsqlDataAdapter(sql, this._ConnString);
                    DataSet dts = new DataSet();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dts, tableName);
                    if (!dts.Tables.Contains(tableName))
                    {
                        return null;
                    }
                    adapter.Dispose();
                    return dts.Tables[tableName];
                }
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
            finally
            {
                if (adapter != null)
                {
                    adapter.Dispose();
                }
            }
        }
        /// <summary>
        /// SELECT文を発行する
        /// </summary>
        /// <param name="rstrSQL">SQL文</param>
        /// <param name="rstrTableName"> テーブル マップに使用するソース テーブルの名前。</param>
        /// <param name="dataset">結果をセットするデータセット</param>
        /// <param name="IsFillSchema">スキーマ情報をセットするかどうか</param>
        /// <returns>Datasetを基づきの検索結果</returns>
        public bool SelectSql(string rstrSQL, string rstrTableName, DataSet dataset, bool IsFillSchema)
        {
            NpgsqlDataAdapter adapter = null;
            try
            {
                if (dataset == null)
                {
                    throw new ArgumentException("dataset is null.");
                }
                using (NpgsqlCommand cmd = this.CreateCommand())
                {
                    cmd.CommandText = rstrSQL;
                    cmd.CommandTimeout = this._CommandTimeout;
                    adapter = new NpgsqlDataAdapter(rstrSQL, this._ConnString);
                    adapter.SelectCommand = cmd;
                    if (IsFillSchema)
                    {
                        adapter.FillSchema(dataset, SchemaType.Mapped, rstrTableName);
                    }
                    adapter.Fill(dataset, rstrTableName);
                }
                return true;
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
            finally
            {
                if (adapter != null)
                {
                    adapter.Dispose();
                }
            }
        }


        #endregion

        #region Execute

        /// <summary>
        /// SqlCommandを実行する
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(NpgsqlCommand cmd)
        {
            try
            {
                if (cmd.Connection == null)
                {
                    cmd.Connection = this.Connection;
                }
                if (this._sqlTran != null)
                {
                    cmd.Transaction = this._sqlTran;
                }
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }

        }

        /// <summary>
        /// クエリを実行し、そのクエリが返す結果セットの最初の行にある最初の列を返します。 
        /// 残りの列または行は無視されます。
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public virtual object ExecuteScalar(NpgsqlCommand cmd)
        {
            try
            {
                if (cmd.Connection == null)
                {
                    cmd.Connection = this.Connection;
                }
                if (this._sqlTran != null)
                {
                    cmd.Transaction = this._sqlTran;
                }
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
        }

        public virtual NpgsqlDataReader ExecuteReader(NpgsqlCommand cmd)
        {
            NpgsqlDataReader reader;
            try
            {
                if (cmd.Connection == null)
                {
                    cmd.Connection = this.Connection;
                }
                if (this._sqlTran != null)
                {
                    cmd.Transaction = this._sqlTran;
                }
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
            return reader;
        }

        public virtual DataSet ExecuteResultSet(NpgsqlCommand cmd)
        {
            DataSet dts;
            NpgsqlDataAdapter adapter = null;
            try
            {
                if (cmd.Connection == null)
                {
                    cmd.Connection = this.Connection;
                }
                if (this._sqlTran != null)
                {
                    cmd.Transaction = this._sqlTran;
                }
                dts = new DataSet();
                adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(dts);
                return dts;
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
            finally
            {
                if (adapter != null)
                {
                    adapter.Dispose();
                }
            }
        }

        public virtual DataSet ExecuteResultSet(NpgsqlCommand cmd, bool IsFillSchema)
        {
            DataSet dts = null;
            NpgsqlDataAdapter adapter = null;
            try
            {
                if (cmd.Connection == null)
                {
                    cmd.Connection = this.Connection;
                }
                if (this._sqlTran != null)
                {
                    cmd.Transaction = this._sqlTran;
                }
                dts = new DataSet();
                adapter = new NpgsqlDataAdapter(cmd);
                if (IsFillSchema)
                {
                    adapter.FillSchema(dts, SchemaType.Mapped);
                }
                adapter.Fill(dts);
                return dts;
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
            finally
            {
                if (adapter != null) adapter.Dispose();
                adapter = null;
            }
        }

        public virtual DataTable ExecuteResultSet(NpgsqlCommand cmd, string TableName, bool IsFillSchema)
        {
            return ExecuteResultSet(cmd, new DataSet(), TableName, IsFillSchema);
        }

        public virtual DataTable ExecuteResultSet(NpgsqlCommand cmd, DataSet rDataSet, string TableName, bool IsFillSchema)
        {
            NpgsqlDataAdapter adapter = null;
            try
            {
                if (cmd.Connection == null)
                {
                    cmd.Connection = this.Connection;
                }
                if (this._sqlTran != null)
                {
                    cmd.Transaction = this._sqlTran;
                }
                if (rDataSet == null)
                {
                    rDataSet = new DataSet();
                }
                adapter = new NpgsqlDataAdapter(cmd);
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
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
            finally
            {
                if (adapter != null) adapter.Dispose();
                adapter = null;

            }
        }


        #endregion

        #region UpdateTable
        public virtual int UpdateTable(DataTable rdatTable, NpgsqlCommand SelectCommand)
        {
            NpgsqlDataAdapter adapter = null;
            NpgsqlCommandBuilder builder = null;
            try
            {
                if ((rdatTable == null) || (SelectCommand == null))
                {
                    return 0;
                }
                if (this._sqlTran != null)
                {
                    SelectCommand.Transaction = this._sqlTran;
                }
                adapter = new NpgsqlDataAdapter(SelectCommand);
                builder = new NpgsqlCommandBuilder(adapter);
                return adapter.Update(rdatTable);
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
            finally
            {
                if (builder != null) { builder.Dispose(); }
                if (adapter != null) { adapter.Dispose(); }
                builder = null;
                adapter = null;
            }
        }

        public virtual int UpdateTable(DataTable rdatTable, NpgsqlCommand SelectCommand, NpgsqlCommand UpdateCommand, NpgsqlCommand InsertCommand, NpgsqlCommand DeleteCommand)
        {
            NpgsqlDataAdapter adapter = null;
            try
            {
                if ((rdatTable == null) || (SelectCommand == null))
                {
                    return 0;
                }
                if (SelectCommand.Connection == null)
                {
                    SelectCommand.Connection = this.Connection;
                }
                if (this._sqlTran != null)
                {
                    if (SelectCommand != null)
                    {
                        SelectCommand.Transaction = this._sqlTran;
                    }
                    if (UpdateCommand != null)
                    {
                        UpdateCommand.Transaction = this._sqlTran;
                    }
                    if (DeleteCommand != null)
                    {
                        DeleteCommand.Transaction = this._sqlTran;
                    }
                    if (InsertCommand != null)
                    {
                        InsertCommand.Transaction = this._sqlTran;
                    }
                }
                adapter = new NpgsqlDataAdapter(SelectCommand)
                {
                    UpdateCommand = UpdateCommand,
                    DeleteCommand = DeleteCommand,
                    InsertCommand = InsertCommand
                };
                return adapter.Update(rdatTable);
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
            finally
            {
                if (adapter != null)
                {
                    adapter.Dispose();
                }
                adapter = null;
            }
        }

        #endregion

        #region GetSchema
        public virtual bool GetSchema(string rstrSQL, string rstrTableName, DataSet rdatSet)
        {
            NpgsqlDataAdapter adapter = null;
            try
            {
                if (rdatSet == null)
                {
                    rdatSet = new DataSet();
                }
                using (NpgsqlCommand cmd = this.CreateCommand())
                {
                    cmd.CommandText = rstrSQL;
                    cmd.CommandTimeout = this._CommandTimeout;
                    adapter = new NpgsqlDataAdapter(rstrSQL, this._ConnString);
                    adapter.SelectCommand = cmd;
                    adapter.FillSchema(rdatSet, SchemaType.Mapped, rstrTableName);
                }
                return true;
            }
            catch (Exception ex)
            {
                this._InnerException = ex;
                throw ex;
            }
            finally
            {
                if (adapter != null)
                {
                    adapter.Dispose();
                }
            }
        }
        #endregion
        #endregion

        #region IDisposable Support
        /// <summary>
        /// 重複する呼び出しを検出するには
        /// </summary>
        private bool disposedValue = false;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///  IDisposable
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue && disposing)
            {
                this.Release();
            }
            this.disposedValue = true;
        }

        private void Release()
        {
            try
            {
                if (this._IsConnected && this._sqlConnect != null)
                {
                    this._sqlConnect.Close();
                }
                if (this._sqlTran != null)
                {
                    this._sqlTran.Dispose();
                }
                if (this._sqlConnect != null)
                {
                    this._sqlConnect.Dispose();
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion
    }
}
