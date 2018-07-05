using Rex.Tools.Test.DataCheck.Common;
using Rex.Tools.Test.DataCheck.Entity;
using Rex.Tools.Test.DataCheck.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rex.Tools.Test.DataCheck.Controls
{
    /// <summary>
    /// テストデータ初期化する
    /// </summary>
    public class TestDataInitializer : ProgressReporter
    {
        public TestDataInitializer(ReportHandler reportHandler)
            : base(reportHandler)
        {

        }

        /// <summary>
        /// データ初期化する
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="isTarget"></param>
        public void DoInitlize(string filePath, bool isTarget, string batchFile)
        {
            string outPutPath = System.IO.Path.ChangeExtension(filePath, "sql");
            Logging.OutputFileName = outPutPath;
            try
            {
                base.Report("テーブル一覧を取得しています");
                using (ExcelAccessor xlsAdo = new ExcelAccessor(filePath))
                {
                    DataTable tableList = GetSheetTableDatas(xlsAdo, "目次");
                    base.SetStep(tableList.Rows.Count, "データクリア用SQL文を作成しています。");
                    Logging.WriteLine("/*** データクリア ***/");
                    DataTableInfo tableInfo = null;
                    foreach (DataRow row in tableList.Rows)
                    {
                        tableInfo = new DataTableInfo(row);
                        string sql = string.Format("TRUNCATE TABLE [{0}]", tableInfo.TableName);
                        Logging.WriteLine(sql);
                        Logging.WriteLine("GO");
                        base.ReportStep("{0}\n{1}", tableInfo.DisplayName, tableInfo.TableName);
                    }

                    base.SetStep(tableList.Rows.Count, "インサートSQL文を作成しています。");

                    foreach (DataRow row in tableList.Rows)
                    {
                        tableInfo = new DataTableInfo(row);
                        DataTable dtt = xlsAdo.GetTableData(tableInfo.SheetName, tableInfo.TableName, null, 2, Config.MaxDataCount + 2);
                        string sql = CreateSheetDataSql(tableInfo, dtt, isTarget, true);
                        Logging.WriteLine(sql);
                        base.ReportStep("{0}\n{1}", tableInfo.DisplayName, tableInfo.TableName);
                    }
                }
                string connStr = isTarget ? Config.TargetDbConnection : Config.SourceDbConnection;
                //Batファイル作成する
                string batFilePath = System.IO.Path.ChangeExtension(filePath, "bat");
                string cmdSqlBat = GetSqlCmdLine(connStr,batchFile);
                System.IO.File.WriteAllText(batFilePath, cmdSqlBat, System.Text.Encoding.Default);
                base.Report("SQL文を作成しました。");
            }
            finally
            {
                Logging.OutputFileName = "";
            }
        }

        private string CreateSheetDataSql(DataTableInfo tInfo, DataTable dtt, bool isTarget, bool isIdInsert)
        {
            TableLayoutInfo tinfo = GetTableLayoutInfo(tInfo.TableName, isTarget);

            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("/****【{0}】（{1}） ****/", tInfo.DisplayName, tInfo.TableName);
            sbSql.AppendLine();
            bool hasIdColumn = tinfo.Columns.Any(col => col.IsIdentity);
            if (isIdInsert && hasIdColumn)
            {
                sbSql.AppendFormat("SET IDENTITY_INSERT [{0}] ON", tinfo.TableName);
                sbSql.AppendLine("GO");
            }
            foreach (DataRow row in dtt.Rows)
            {
                sbSql.AppendLine(tinfo.GetInsertScript(row, true));
                sbSql.AppendLine("GO");
            }
            if (isIdInsert && hasIdColumn)
            {
                sbSql.AppendFormat("SET IDENTITY_INSERT [{0}] OFF", tinfo.TableName);
                sbSql.AppendLine("GO");
            }
            return sbSql.ToString();
        }
        /// <summary>
        /// バッチファイルを作成する
        /// </summary>
        /// <param name="connectString"></param>
        /// <returns></returns>
        private string GetSqlCmdLine(string connectString,string batchFile)
        {
            //Driver={SQL Server}; Server=192.168.137.163; Uid=sa; Pwd=p; Database=Live06;
            //Data Source=192.168.137.163;Initial Catalog=SeedDB;Persist Security Info=True;User ID=sa;Password=p;
            string pattern = @"(?<name>[^;\=]+)=(?<value>[^;\=]+);{0,1}";
            Regex regex = new Regex(pattern);
            string strConn = regex.Replace(connectString, new MatchEvaluator(match =>
            {
                string name = match.Groups["name"].Value;
                string value = match.Groups["value"].Value;
                switch (name.Trim().ToLower())
                {
                    case "data source":
                        return " -S " + value;
                    case "initial catalog":
                        return " -d " + value;
                    case "user id":
                        return " -U " + value;
                    case "password":
                        return " -P " + value;
                    default:
                        return string.Empty;
                }
            }));
            StringBuilder cmdLine = new StringBuilder();
            cmdLine.AppendFormat("SQLCMD {0} -f 65001 -i \"%~dpn0.sql\"",strConn);
            cmdLine.AppendLine();
            if (!string.IsNullOrEmpty(batchFile))
            {
                cmdLine.AppendLine(batchFile);
            }
            cmdLine.AppendLine("Pause");
            return cmdLine.ToString();
        }

        private TableLayoutInfo GetTableLayoutInfo(string tableName, bool isTarget)
        {
            DatabaseAcsesser dba = new DatabaseAcsesser();
            DatabaseAcsesser.DbConnections connType = isTarget ? DatabaseAcsesser.DbConnections.TargetDbConnection
                                                               : DatabaseAcsesser.DbConnections.SourceDbConnection;
            TableLayoutInfo info = dba.GetTableLayout(connType, tableName);
            return info;
        }


        private DataTable GetSheetTableDatas(ExcelAccessor xlsAdo, string sheetName)
        {
            string sql = "Select * from [" + sheetName + "$]";
            return xlsAdo.GetTableData("tableList", null, sql);
        }

    }
}
