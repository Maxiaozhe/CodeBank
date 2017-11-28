using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Tools.Test.DataCheck.Controls
{
    public class ExcelAccessor:IDisposable
    {
        private string _dataSource;
        private DbConnection _conn;
        private DbProviderFactory _factory;

        public ExcelAccessor(string fileName)
        {
            this._dataSource = fileName;

        }

        private void Connect()
        {
            if(this._conn!=null && this._conn.State == ConnectionState.Open)
            {
                return;
            }
            if (this._conn != null)
            {
                this.Release();
            }
            _factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            this._conn = _factory.CreateConnection();
            DbConnectionStringBuilder builder = _factory.CreateConnectionStringBuilder();
            builder["Provider"] = "Microsoft.ACE.OLEDB.12.0";
            //builder["Provider"] = "Microsoft.Jet.OLEDB.4.0;";
            builder["Data Source"] = this._dataSource;
            builder["Extended Properties"] = "Excel 12.0;HDR=YES;";

            this._conn.ConnectionString = builder.ToString();
            this._conn.Open();
 
        }

        private void Release()
        {
            if (this._conn != null)
            {
                this._conn.Close();
                this._conn.Dispose();
            }
        }

        public DataTable GetSchema(string type)
        {
            this.Connect();
            if (string.IsNullOrEmpty(type))
            {
                return this._conn.GetSchema();
            }
            else
            {
                return this._conn.GetSchema(type);
            }
        }

        public DataTable GetTableData(string tableName, DataTable tableSchema, string sql)
        {
            this.Connect();
            using (DbCommand cmd = this._conn.CreateCommand())
            {
                cmd.CommandText = sql;
                DbDataAdapter adapter = _factory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                if (tableSchema == null)
                {
                    tableSchema = new DataTable(tableName);
                }
                adapter.Fill(tableSchema);
                return tableSchema;
            }
        }



        public DataTable GetTableData(string sheetName,string tableName,DataTable tableSchema )
        {
            this.Connect();
            using(DbCommand cmd = this._conn.CreateCommand())
            {
                cmd.CommandText = "Select * from [" + sheetName + "$]" ;
                DbDataAdapter adapter = _factory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                if (tableSchema == null)
                {
                    tableSchema = new DataTable(tableName);
                }
                adapter.Fill(tableSchema);
                return tableSchema;
            }
        }
        /// <summary>
        /// 指定行数範囲で検索する
        /// </summary>
        /// <param name="sheetName"></param>
        /// <param name="tableName"></param>
        /// <param name="tableSchema"></param>
        /// <param name="startRow">開始行</param>
        /// <param name="endRow">完了行</param>
        /// <returns></returns>
        public DataTable GetTableData(string sheetName, string tableName, DataTable tableSchema,int startRow,int endRow)
        {
            this.Connect();
            using (DbCommand cmd = this._conn.CreateCommand())
            {
                cmd.CommandText = string.Format("Select * from [{0}${1}:{2}]",sheetName,startRow,endRow);
                DbDataAdapter adapter = _factory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable  tableSheet = new DataTable(tableName);
                adapter.Fill(tableSheet);
                ClearEmptyRows(tableSheet);
                if (tableSchema != null)
                {
                    foreach (DataRow row in tableSheet.Rows)
                    {
                        tableSchema.ImportRow(row);
                    }
                    return tableSchema;
                }
                else
                {
                    return tableSheet;
                }

                
            }
        }
        /// <summary>
        /// 空行をクリアする
        /// </summary>
        /// <param name="dtt"></param>
        private void ClearEmptyRows(DataTable dtt)
        {
            foreach (DataRow row in dtt.Rows)
            {
                if (row.ItemArray.All(value => (value is DBNull || value == null)))
                {
                    row.Delete();
                }
            }
            dtt.AcceptChanges();
        }

        public void Dispose()
        {
            this.Release();
        }
    }
}
