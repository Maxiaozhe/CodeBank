using Rex.Tools.Test.DataCheck.Common;
using Rex.Tools.Test.DataCheck.Controls.SqlServer;
using Rex.Tools.Test.DataCheck.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Rex.Tools.Test.DataCheck.Controls
{
    public class DenshowDataAccesser
    {

        private PostgreDao GetDao()
        {
            int cmdTimeout = Common.Config.CommandTimeout;
            PostgreDao dao = new PostgreDao(Common.Config.DenshowDbConnection, cmdTimeout);
            dao.Connect();
            return dao;
        }

        public NpgTableLayoutInfo GetTableLayout( string tableName)
        {
            using (PostgreDao dao = GetDao())
            {
                using (NpgsqlCommand cmd = dao.CreateCommand())
                {
                    cmd.CommandText = Properties.Resources.GetNpgTableLayout;
                    cmd.Parameters.AddWithValue("@schema", Common.Config.DenshowDbSchema);
                    cmd.Parameters.AddWithValue("@tableName", tableName);
                    DataTable dtt = dao.ExecuteResultSet(cmd, tableName, false);
                    NpgTableLayoutInfo tableInfo = new NpgTableLayoutInfo(tableName, dtt);
                    return tableInfo;
                }
            }

        }

        public DataTable GetResultData(string tableName)
        {
            using (PostgreDao dao = GetDao())
            {
                using (NpgsqlCommand cmd = dao.CreateCommand())
                {
                    cmd.CommandText = "Select * from [" + tableName + "]";
                    DataTable dtt = dao.ExecuteResultSet(cmd, tableName, true);
                    return dtt;
                }
            }
        }
        public DataTable GetResultData(string tableName, string sql)
        {
            using (PostgreDao dao = GetDao())
            {
                using (NpgsqlCommand cmd = dao.CreateCommand())
                {
                    cmd.CommandText = sql;
                    DataTable dtt = dao.ExecuteResultSet(cmd, tableName, true);
                    return dtt;
                }
            }
        }

      
    }
}
