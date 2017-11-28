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

namespace Rex.Tools.Test.DataCheck.Controls
{
    public class DatabaseAcsesser
    {
        public enum DbConnections
        {
            /// <summary>
            /// 変換先データベースコネクション
            /// </summary>
            TargetDbConnection,
            /// <summary>
            /// 変換元データベースコネクション
            /// </summary>
            SourceDbConnection,
        }



        private DaoBase GetDao(DbConnections conn)
        {
            string connStr = "";
            switch (conn)
            {
                case DbConnections.TargetDbConnection:
                    connStr = Config.TargetDbConnection;
                    break;
                default:
                    connStr = Config.SourceDbConnection;
                    break;
            }
            int cmdTimeout = Common.Config.CommandTimeout;
            DaoBase dao = new DaoBase(connStr, cmdTimeout);
            dao.Connect();
            return dao;
        }

        public TableLayoutInfo GetTableLayout(DbConnections conn, string tableName)
        {
            using (DaoBase dao = GetDao(conn))
            {
                using (SqlCommand cmd = dao.CreateCommand())
                {
                    cmd.CommandText = Properties.Resources.GetTableLayout;
                    cmd.AddParameter("@tableName", tableName);
                    DataTable dtt = dao.ExecuteResultSet(cmd, tableName, false);
                    TableLayoutInfo tableInfo = new TableLayoutInfo(tableName, dtt);
                    return tableInfo;
                }
            }
  
        }

        public DataTable GetResultData(string tableName)
        {
            using (DaoBase dao = GetDao(DbConnections.TargetDbConnection))
            {
                using (SqlCommand cmd = dao.CreateCommand())
                {
                    cmd.CommandText = "Select * from [" + tableName + "]";
                    DataTable dtt = dao.ExecuteResultSet(cmd, tableName, true);
                    return dtt;
                }
            }
        }
        public DataTable GetResultData(string tableName,string sql)
        {
            using (DaoBase dao = GetDao(DbConnections.TargetDbConnection))
            {
                using (SqlCommand cmd = dao.CreateCommand())
                {
                    cmd.CommandText = sql;
                    DataTable dtt = dao.ExecuteResultSet(cmd, tableName, true);
                    return dtt;
                }
            }
        }

        /// <summary>
        /// 新しい採番された生産計画Noを取得する
        /// </summary>
        /// <param name="scheduledKeyNo">旧生産計画No</param>
        /// <returns></returns>
        public string GetProductionPlanNo(string scheduledKeyNo)
        {
            using (DaoBase dao = GetDao(DbConnections.SourceDbConnection))
            {
                using (SqlCommand cmd = dao.CreateCommand())
                {
                    cmd.CommandText = Properties.Resources.GetNewProductionNo;
                    cmd.Parameters.AddWithValue("@SCHEDULED_KEY_NO", scheduledKeyNo);
                    string planNo =Utility.DBToString( dao.ExecuteScalar(cmd));
                    return planNo;
                }
            }
        }

        /// <summary>
        /// 新しい採番された稼動計画Noを取得する
        /// </summary>
        /// <param name="facilityCode">旧設備コード</param>
        /// <param name="operationDate">稼動日（yyyy/MM/dd）</param>
        /// <returns></returns>
        public string GetOperationPlanNo(string facilityCode, string operationDate)
        {
            using (DaoBase dao = GetDao(DbConnections.SourceDbConnection))
            {
                using (SqlCommand cmd = dao.CreateCommand())
                {
                    cmd.CommandText = Properties.Resources.GetNewOperationNo;
                    cmd.Parameters.AddWithValue("@FACILITY_CODE", facilityCode);
                    cmd.Parameters.AddWithValue("@OPERATION_DATE", operationDate);
                    string planNo = Utility.DBToString(dao.ExecuteScalar(cmd));
                    return planNo;
                }
            }
        }
    }
}
