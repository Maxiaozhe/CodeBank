using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Maxz.PoemSystem.Engine.Modules
{
    public partial class PoemDBDataContext
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
    
}
