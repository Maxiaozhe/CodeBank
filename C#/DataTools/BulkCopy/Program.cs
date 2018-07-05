using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkCopy
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection(SourceDbConnection))
            {
                using (SqlDataReader source = GetSource(conn))
                {
                    BulkCopy(source);
                }
            }
        }
        private static SqlDataReader GetSource(SqlConnection conn)
        {
               conn.Open();
               SqlCommand cmd= conn.CreateCommand();
               cmd.CommandText = "Select * From T_CheckResult";
               cmd.CommandTimeout = 3600;
               return cmd.ExecuteReader();
        }

        private static void BulkCopy(SqlDataReader reader)
        {
            using (SqlBulkCopy blk = new SqlBulkCopy(TargetDbConnection))
            {
                blk.BulkCopyTimeout = 86400;
                blk.DestinationTableName = "T_CheckResult";
                blk.WriteToServer(reader);
                blk.Close();
            }
        }



        /// <summary>
        /// データベース接続文字列
        /// </summary>
        private static string SourceDbConnection
        {
            get
            {
                var conn = System.Configuration.ConfigurationManager.ConnectionStrings["SourceDatabase"];
                return conn.ConnectionString;
            }
        }
        /// <summary>
        /// データベース接続文字列
        /// </summary>
        private static string TargetDbConnection
        {
            get
            {
                var conn = System.Configuration.ConfigurationManager.ConnectionStrings["TargetDatabase"];
                return conn.ConnectionString;
            }
        }
    }
}
