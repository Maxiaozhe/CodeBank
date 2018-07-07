using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DenshowBusinessInterface;
using DenshowBusinessInterface.Entity;
using DenshowCommon;
using DenshowDataAccessInterface.Dto;
using System.Data;
using Microsoft.Win32;

namespace DenshowBusinessComponent.Control
{
    /// <summary>
    /// マスタ参照コントロール
    /// </summary>
    internal class MasterReferenceControl
    {
        #region Field
        /// <summary>
        /// 値取得用デリゲート
        /// </summary>
        private GetValuePrivateHandler getValuePrivateHander = null;
        /// <summary>
        /// グループ項目の値を取得するデリゲート
        /// </summary>
        private GetValueHandler getValueHandler;
        /// <summary>
        /// グループ項目のデータタイプを取得するデリゲート
        /// </summary>
        private GetTryValueHandler getTryValueHandler;
        /// <summary>
        /// SQL文のDDL禁則キーワード
        /// </summary>
        private string[] sqlForbidWords = { "UPDATE", "DELETE", "INSERT", "DROP", "CREATE", "TRUNCATE", "ALTER" };
        /// <summary>
        /// コマンドパラメーターリスト
        /// </summary>
        private List<OdbcParameter> cmdParamters = null;
        /// <summary>
        /// エラーが発生したチェックリストグループIDリスト
        /// </summary>
        private List<string> errorClGroupList = new List<string>();
        #endregion

        #region Delegate
        /// <summary>
        /// 値取得用デリゲート
        /// </summary>
        /// <param name="clId">チェックリストID</param>
        /// <param name="groupId">グループID</param>
        /// <returns></returns>
        private delegate string GetValuePrivateHandler(string clId, string groupId);
        /// <summary>
        /// グループ項目IDで値を取得するデリゲート宣言
        /// </summary>
        /// <param name="clId">チェックリストID</param>
        /// <param name="groupId">グループID</param>
        /// <returns></returns>
        public delegate string GetValueHandler(string clId, string groupId);
        /// <summary>
        /// 試しみ実行時、グループ項目の型を取得するデリゲート宣言
        /// </summary>
        /// <param name="clId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public delegate ChecklistGroup GetTryValueHandler(string clId, string groupId);

        #endregion

        #region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MasterReferenceControl()
        {
        }
        #endregion

        #region private Method
        /// <summary>
        /// SQL式を作成する
        /// </summary>
        /// <param name="tableName">参照テーブル名</param>
        /// <param name="referenceColumn">参照カラム名</param>
        /// <param name="conditions">マスタ参照条件</param>
        /// <returns></returns>
        private string createQuery(string tableName, string referenceColumn, List<MasterReference> conditions)
        {
            //SQLを作成
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" Select ");
            sql.AppendLine(safeDbName(referenceColumn));
            sql.AppendLine(" From ");
            sql.AppendLine(safeDbName(tableName));
            sql.AppendLine(" Where ");
            int index = 0;

            //SQL検索条件式を作成する
            foreach (MasterReference condition in conditions)
            {
                string value = getValuePrivateHander(condition.ClId, condition.ConditionGroupId);

                //名前重複しないように番号付き
                string paramName="@" + condition.ConditionGroupId + cmdParamters.Count;
                OdbcParameter param = new OdbcParameter(paramName, OdbcType.NVarChar);
                param.Value = value;
                this.cmdParamters.Add(param);
                sql.AppendFormat(" {0} {1} {2} ", safeDbName(condition.ConditionColumn), condition.ConditionOperator, "?");

                // 演算子の追加
                if (index != conditions.Count - 1)
                {
                    sql.Append(getSqlLogicOperator(condition.Operator));
                }
                index++;
            }
            return sql.ToString();
        }

        /// <summary>
        /// SQL文の引数を入れ替え
        /// </summary>
        /// <param name="clId"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        private string createQuery(string clId, string sql)
        {
            //禁則キーワードをチェックする
            if (!checkForbidWords(sql))
            {
                throw new DenshowBusinessException(Message.EP008);
            }

            //先頭がSELECTかどうかをチェックする
            Regex regchk = new Regex(@"^\s*SELECT\s+", RegexOptions.IgnoreCase);
            if (!regchk.Match(sql).Success)
            {
                throw new DenshowBusinessException(Message.EP029);
            }

            Regex regex = new Regex(@"{(?<groupId>[^\{\}]+)}");
            //{CG00001}のようなグループIDを検出し、実際の値をパラメータコレクションに追加して、?で変換する
            sql = regex.Replace(sql, new MatchEvaluator(match =>
                {
                    //グループIDを取得
                    string groupId = match.Groups["groupId"].Value;
                    //SQLパラメータをコレクションに追加する
                    //名前重複しないように番号付き
                    string paramName = "@" + groupId + cmdParamters.Count;
                    OdbcParameter param = new OdbcParameter(paramName, OdbcType.NVarChar);
                    param.Value = getValuePrivateHander(clId, groupId); ;
                    this.cmdParamters.Add(param);
                    return "?";
                }));
            return sql;
        }

        /// <summary>
        /// グループ項目データを取得する
        /// </summary>
        /// <param name="clId">チェックリストID</param>
        /// <param name="groupId">チェックリストグループID</param>
        /// <returns></returns>
        private string getValue(string clId, string groupId)
        {
            //実際のデータを取得して実行する場合
            if (this.getValueHandler != null)
            {
                return this.getValueHandler(clId, groupId);
            }

            return string.Empty;
        }

        /// <summary>
        /// グループ項目データを取得する（チェック用１）
        /// </summary>
        /// <param name="clId">チェックリストID</param>
        /// <param name="groupId">チェックリストグループID</param>
        /// <returns>仮データ文字列</returns>
        private string getValueForTrySelect(string clId, string groupId)
        {
            string ret = string.Empty;

            // OCR項目であるグループ項目であるかチェックする
            ChecklistGroup group = this.getTryValueHandler(clId, groupId);

            //データタイプ別仮データ作成
            switch (group.DataType)
            {
                case Definition.DataType.Numeric:
                    ret = "0";
                    break;
                case Definition.DataType.Date:
                    ret = "2000/12/01";
                    break;
                case Definition.DataType.Time:
                    ret = "00:00";
                    break;
                default:
                    ret = "a";
                    break;
            }

            return ret;
        }

        /// <summary>
        /// グループ項目データを取得する（チェック用２）
        /// </summary>
        /// <param name="clId">チェックリストID</param>
        /// <param name="groupId">チェックリストグループID</param>
        /// <returns>仮データ文字列</returns>
        private string getValueForTryDirect(string clId, string groupId)
        {
            string ret = string.Empty;

            // OCR項目であるグループ項目であるかチェックする
            ChecklistGroup group = this.getTryValueHandler(clId, groupId);
            if (group == null)
            {
                // チェックリストグループデータが存在しなかった場合はリストに追加
                this.errorClGroupList.Add(groupId);
                return ret;
            }

            //データタイプ別仮データ作成
            switch (group.DataType)
            {
                case Definition.DataType.Numeric:
                    ret = "0";
                    break;
                case Definition.DataType.Date:
                    ret = "2000/12/01";
                    break;
                case Definition.DataType.Time:
                    ret = "00:00";
                    break;
                default:
                    ret = "a";
                    break;
            }

            return ret;
        }

        /// <summary>
        /// ダブルクオーテーションでDB識別子をカッコする
        /// </summary>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        private string safeDbName(string schemaName)
        {
            return "\"" + schemaName + "\"";
        }

        /// <summary>
        /// SQL条件式のロジック演算子を取得する
        /// </summary>
        /// <param name="Operator">
        /// <![CDATA[
        /// 設定する演算子(&、|)
        /// ]]></param>
        /// <returns></returns>
        private string getSqlLogicOperator(string Operator)
        {
            switch (Operator)
            {
                case "|":
                    return " OR ";
                default:
                    return " AND ";
            }
        }

        /// <summary>
        /// マスタ参照結果を文字列に変換する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string convertResultValue(object value)
        {
            if (value == null || value is DBNull)
            {
                return string.Empty;
            }
            return value.ToString();
        }


        /// <summary>
        /// 禁則キーワードを検査する
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private bool checkForbidWords(string sql)
        {
            foreach (string keywork in sqlForbidWords)
            {
                //禁則キーワード検索用正規表現式を作成
                string pattern = string.Format(@"(^|\s){0}\s", keywork);
                //禁則キーワードが存在するかどうかをチェックする
                if (Regex.IsMatch(sql, pattern, RegexOptions.IgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// マスタ参照値を取得する
        /// </summary>
        /// <param name="chkInfo">対象チェックリストグループ項目</param>
        /// <param name="conditions">マスタ参照条件項目リスト</param>
        /// <param name="getValueHandler">グループ項目の値を取得するデリゲート</param>
        /// <exception cref="DenshowBusinessException">EP092：接続失敗</exception>
        /// <exception cref="DenshowBusinessException">EP090：SQL文不正</exception>
        /// <returns></returns>
        public string GetReference(ChecklistInfo chkInfo, List<MasterReference> conditions, GetValueHandler getValueHandler)
        {
            // 値取得メソッドを登録する
            getValuePrivateHander = getValue;

            try
            {
                this.getValueHandler = getValueHandler;
                this.cmdParamters = new List<OdbcParameter>();
                string sql = string.Empty;

                // 選択入力の場合
                if (string.IsNullOrEmpty(chkInfo.Query))
                {
                    sql = this.createQuery(chkInfo.TableName, chkInfo.ReferenceColumn, conditions);
                }

                // 直接入力の場合
                else
                {
                    sql = this.createQuery(chkInfo.ClId, chkInfo.Query);
                }

                // クエリーの実行
                string connString = Utility.CreateConnectionString(chkInfo.DataSourceName);
                using (OdbcConnection conn = new OdbcConnection(connString))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (OdbcException ex)
                    {
                        //接続失敗時、EP092例外をThrowする
                        throw new DenshowBusinessException(Message.EP092,ex);
                    }
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandType = System.Data.CommandType.Text;
                        foreach (OdbcParameter param in this.cmdParamters)
                        {
                            cmd.Parameters.Add(param);
                        }
                        using (OdbcDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //参照データが存在する場合、一件目を取得する
                                return convertResultValue(reader.GetValue(0));
                            }
                            else
                            {
                                //参照データが存在しない場合
                                throw new DenshowBusinessException(Message.EP090);
                            }
                        }
                    }
                }
            }
            catch (DenshowBusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DenshowBusinessException(Message.EP090, ex);
            }

        }

        /// <summary>
        /// (設定画面用)マスタ参照を試して取得する
        /// </summary>
        /// <param name="chkInfo">対象チェックリストグループ項目</param>
        /// <param name="conditions">マスタ参照条件項目リスト</param>
        /// <param name="getTryValueHandler">試しみ実行時、グループ項目の型を取得するデリゲート</param>
        /// <returns></returns>
        public bool TryGetReference(ChecklistGroup chkInfo, List<MasterReference> conditions, GetTryValueHandler getTryValueHandler)
        {
            try
            {
                this.getTryValueHandler = getTryValueHandler;
                this.cmdParamters = new List<OdbcParameter>();
                string sql = string.Empty;

                // 選択入力の場合
                if (string.IsNullOrEmpty(chkInfo.Query))
                {
                    // 値取得メソッドを登録する
                    getValuePrivateHander = getValueForTrySelect;
                    sql = this.createQuery(chkInfo.TableName, chkInfo.ReferenceColumn, conditions);
                }

                // 直接入力の場合
                else
                {
                    // 値取得メソッドを登録する
                    getValuePrivateHander = getValueForTryDirect;
                    sql = this.createQuery(chkInfo.ClId, chkInfo.Query);
                }

                // グループIDが存在しない、もしくはOCR項目,ユーザ置換項目でない項があった場合は例外をスローする
                this.checkGroupList();

                // クエリーの実行
                string connString = Utility.CreateConnectionString(chkInfo.DataSourceName);
                using (OdbcConnection conn = new OdbcConnection(connString))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (OdbcException ex)
                    {
                        //接続失敗時、EP092例外をThrowする
                        throw new DenshowBusinessException(Message.EP092,ex);
                    }
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandType = System.Data.CommandType.Text;
                        foreach (OdbcParameter param in this.cmdParamters)
                        {
                            cmd.Parameters.Add(param);
                        }
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (DenshowBusinessException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new DenshowBusinessException(Message.EP008, e);
            }
        }

        /// <summary>
        /// 存在しないもしくはOCR項目,ユーザ置換項目でないグループIDがあるかチェックして例外をスローする処理
        /// </summary>
        private void checkGroupList()
        {
            if (this.errorClGroupList.Count() != 0)
            {
                int i = 0;
                StringBuilder sb = new StringBuilder();

                // グループIDを改行で連結し、10個を超えた場合は「他」を連結する
                foreach (string groupId in this.errorClGroupList)
                {
                    if (i > 9)
                    {
                        sb.AppendLine("他");
                        break;
                    }
                    sb.AppendLine(groupId);
                    i++;
                }

                throw new DenshowBusinessException(string.Format(Message.EP124, sb.ToString()));
            }
        }

        /// <summary>
        /// データソース名リストの取得
        /// </summary>
        /// <returns>データソース名リスト</returns>
        public List<string> GetDsnList()
        {
            List<string> dsnList = new List<string>();
            RegistryKey key_ini = null;
            try
            {
                // ODBCリスト用の例外処理
                // HKLM\Software\ODBC\ODBC.INIまでのレジストキーを開く
                key_ini = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\ODBC\\ODBC.INI");

                // サブキー名(=DSN)を全て取得する
                foreach (string dsn in key_ini.GetSubKeyNames().ToList())
                {
                    // 「ODBC Data Sources」は取得対象外なのでスキップ
                    if (dsn.Equals("ODBC Data Sources"))
                    {
                        continue;
                    }

                    try
                    {
                        string connString = Utility.CreateConnectionString(dsn);
                        using (OdbcConnection conn = new OdbcConnection(connString))
                        {
                            // ODBC接続を試みる
                            conn.Open();

                            // データソースリストに追加
                            dsnList.Add(dsn);
                        }
                    }
                    catch(Exception ex)
                    {
                        // データソースリストに追加しない
                        DenshowCommon.ReportDefinitionLogger.WriteError(ex);
                    }
                }
            }
            finally
            {
                key_ini.Close();
            }

            return dsnList;
        }

        /// <summary>
        /// テーブル名リストを取得
        /// </summary>
        /// <param name="dsn">データソース名</param>
        /// <returns>テーブル名リスト</returns>
        public List<string> GetTableList(string dsn)
        {
            List<string> tableList = new List<string>();
            string connString = Utility.CreateConnectionString(dsn);
            using (OdbcConnection con = new OdbcConnection(connString))
            {
                try
                {
                    con.Open();

                    //table名取得
                    DataTable table = con.GetSchema("Tables");
                    foreach (DataRow row in table.Rows)
                    {
                        tableList.Add(row["TABLE_NAME"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    //ODBC接続に失敗しました。
                    throw new DenshowBusinessException(DenshowCommon.Message.EP092,ex);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }

            return tableList;
        }

        /// <summary>
        /// テーブルのカラム名リストを取得
        /// </summary>
        /// <param name="dsn">データソース名</param>
        /// <param name="tableName">テーブル名</param>
        /// <returns>カラム名リスト</returns>
        public List<string> GetColumnList(string dsn, string tableName)
        {
            List<string> columnList = new List<string>();
            string connString = Utility.CreateConnectionString(dsn);
            using (OdbcConnection con = new OdbcConnection(connString))
            {
                try
                {
                    con.Open();

                    //カラム名取得
                    DataTable column = con.GetSchema("Columns", new String[] { null, null, tableName });
                    foreach (DataRow row in column.Rows)
                    {
                        columnList.Add(row["COLUMN_NAME"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    //ODBC接続に失敗しました。
                    throw new DenshowBusinessException(DenshowCommon.Message.EP092,ex);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }

            return columnList;
        }

        #endregion

    }
}
