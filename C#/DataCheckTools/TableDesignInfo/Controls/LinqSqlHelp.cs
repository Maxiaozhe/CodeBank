using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableDesignInfo.Controls
{
    public enum SearchModes
    {
        //含む
        Contain,
        //前方一致
        ForwardMatch,
        //後方一致
        BackwardMatch,
        //完全一致
        Equale,
    }
    [Flags]
    public enum SearchOptions
    {
        None = 0,
        TableName = 2,
        ColumnName = 4,
        CommentName = 8,
    }
    /// <summary>
    /// Linq to Sqlの検証のため、実装する
    /// </summary>
    public static class LinqSqlHelp
    {
        private static string _currentConnection;

        public static string CurrentConnection
        {
            get
            {
                if (string.IsNullOrEmpty(_currentConnection))
                {
                    _currentConnection = Properties.Settings.Default.LiveDatabase;
                }
                return _currentConnection;
            }
            set
            {
                _currentConnection = value;
            }
        }

   
        /// <summary>
        /// テーブルJoin（検索条件複雑な場合、SQL自動生成できない！）シンプルな検索条件が必要
        /// メリット：
        /// １．SQL不要（場合によるデメリットになる）
        /// ２．データモデル自動作成する（カスタムズメソッド追加も可能）
        /// ３．単純なDMLは使いやすい（効率で実行するのため、個別実装が必要）
        /// ４．必要な場合のみ、データアクセス発生するので、無駄なデータアクセスは避けることができる
        ///     （開発者はLINQの仕様をよく理解するが必要）
        /// デメリット、制約条件：
        /// １．シンプルな検索条件が必要
        /// ２．Sql Linq式にカスタム関数が使えない
        /// ３．データエンティティのデータ保護が足りない（個別対応が必要）
        /// ４．複雑な検索（例えばjoin,groupなど使う場合）、LINQ式の方がわかりにくい、チューニングが難しい
        /// ５. 抽出結果の型は匿名クラスになると、関数の戻り値として返せない（型変換が必要）
        /// ６．LINQ式が動的な生成できない（この場合、直接にSQLでアクセスは補助手段としてが必要）
        /// ７．プログラムの柔軟性は比較的に乏しい
        /// ８．データモデルは自動生成するため、チューニングははぼできない
        /// ９．大規模、複雑な処理、高い効率が必要の場合、リスクが高い
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="mode"></param>
        /// <param name="opts"></param>
        /// <returns>戻り値はEntitySetを使用することよりソードなどDataSet並みの機能が持っている</returns>
        public static EntitySet<TableList> Search(string keyword, SearchModes mode, SearchOptions opts)
        {
            EntitySet<TableList> result = new EntitySet<TableList>();
            using (LiveDataContext live = new LiveDataContext(CurrentConnection))
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    result.SetSource(live.TableList.ToList());
                    return result;
                }
                keyword = keyword.Replace("　", " ");
                //全件のデータをまず抽出する（検索条件にカスタム関数が存在するため）
                //検索条件に個別関数IsMatchを使用する
                //IQueryableからIEnumerableに変換する必要がある（この処理は実際C#の方でやる）
                var source = from t in live.TableList.AsEnumerable()
                             join c in live.TableLayoutInfo.AsEnumerable() on
                             t.TableName equals c.TableName
                             where IsMatch(keyword, t, c, mode, opts)
                             group t by t.TableName into g
                             orderby g.Key
                             select g.First();

                //toListを呼び出し場合、実際のデータアクセスが発生する
                result.SetSource(source.ToList());

                return result;
            }
        }

        public static TableList GetTable(string tableName)
        {
            using (LiveDataContext live = new LiveDataContext(CurrentConnection))
            {
                var table = from t in live.TableList
                             where t.TableName.Equals(tableName)
                             select t;
                if (table.Count<TableList>()==0)
                {
                    return null;
                }
                return table.First<TableList>();
            }
        }

        public static EntitySet<TableLayoutInfo> GetTableLayout(string tableName)
        {
            EntitySet<TableLayoutInfo> result = new EntitySet<TableLayoutInfo>();
            using (LiveDataContext live = new LiveDataContext(CurrentConnection))
            {
                var layout = from t in live.TableLayoutInfo
                             where t.TableName.Equals(tableName)
                             orderby t.ColumnId
                             select t;
                result.SetSource(layout.ToList());
                return result;
            }
        }

        /// <summary>
        /// データ更新はDelete、Insertになるが、動的生成されたSQLは
        /// UPDATE文で発行する（但し、主キーでの更新条件になっていない）
        /// </summary>
        /// <param name="entity"></param>
        public static void Update(TableList entity)
        {
            using (LiveDataContext live = new LiveDataContext(CurrentConnection))
            {
                var orgs = live.TableList.Where(t => t.TableName.Equals(entity.TableName));
                live.TableList.DeleteAllOnSubmit(orgs);
                live.TableList.InsertOnSubmit(entity);
                live.SubmitChanges();
            }

        }

        public static void Update(List<TableLayoutInfo> entitys)
        {
            using (LiveDataContext live = new LiveDataContext(CurrentConnection))
            {
                //複数レコードを抽出する場合、Localのコレクションと結合はできないため、
                //AsEnumerableに変換が必要。データは全件抽出
                var orgEntities = from org in live.TableLayoutInfo.AsEnumerable()
                                  join curr in entitys on new
                                  {
                                      TableName = org.TableName,
                                      ColumnName = org.ColumnName
                                  } equals
                                  new
                                  {
                                      TableName = curr.TableName,
                                      ColumnName = curr.ColumnName
                                  }
                                  select org;
                live.TableLayoutInfo.DeleteAllOnSubmit(orgEntities);
                live.TableLayoutInfo.InsertAllOnSubmit(entitys);
                live.SubmitChanges();
            }
        }

        private static bool IsMatch(string keyword, TableList t, TableLayoutInfo c, SearchModes mode, SearchOptions opts)
        {
            bool result = false;

            if ((opts & SearchOptions.TableName) == SearchOptions.TableName)
            {
                result = Match(t.TableName, keyword, mode) || Match(t.TableDisplayName, keyword, mode);
            }

            if ((opts & SearchOptions.ColumnName) == SearchOptions.ColumnName)
            {
                result = result || Match(c.ColumnName, keyword, mode) || Match(c.ColumnDisplayName, keyword, mode);
            }
            if ((opts & SearchOptions.CommentName) == SearchOptions.CommentName)
            {
                result = result || Match(t.Comment, keyword, SearchModes.Contain) || Match(c.Comment, keyword, SearchModes.Contain);
            }
            return result;
        }

        private static bool Match(string src, string target, SearchModes mode)
        {
            if (string.IsNullOrEmpty(src)) return false;
            string[] keywords;

            if (target.Contains(" "))
            {
                keywords = target.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                keywords = new string[] { target };
            }
            string x = src.ToLower();
            //string y = target.ToLower();
            switch (mode)
            {
                case SearchModes.Contain:
                    return keywords.All(y => x.Contains(y.ToLower()));
                case SearchModes.ForwardMatch:
                    return keywords.All(y => x.StartsWith(y.ToLower()));
                case SearchModes.BackwardMatch:
                    return keywords.All(y => x.EndsWith(y.ToLower()));
                case SearchModes.Equale:
                    return x.Equals(target.ToLower());
                default:
                    break;
            }

            return false;
        }

        public static DataTable GetTableData(string tableName,int maxCount)
        {
            using (LiveDataContext live = new LiveDataContext(CurrentConnection))
            {
                DbCommand cmd = live.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("SELECT Top {0} * FROM [{1}]", maxCount, tableName);
                return live.ExecuteResultSetForSql(cmd, tableName, true);
            }
        }

        public static long GetTableDataCount(string tableName)
        {
            using (LiveDataContext live = new LiveDataContext(CurrentConnection))
            {

                StringBuilder sql = new StringBuilder();
                    
                sql.Append("SELECT sum(row_count) AS num FROM sys.dm_db_partition_stats Where ");
                sql.AppendFormat(" object_id=OBJECT_ID('{0}')  AND (index_id=0 or index_id=1)",tableName);
                DbCommand cmd = live.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                return live.ExecuteScalar<long>(cmd);
            }
        }
        /// <summary>
        /// 最新のデータベース設計情報を取得する
        /// </summary>
        public static void UpdateTableInfo()
        {
            using (LiveDataContext live = new LiveDataContext(CurrentConnection))
            {

                DbCommand cmd = live.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Properties.Resources.UpdateTableinfo;
                int result= live.ExecuteNonQuery(cmd);
            }
        }
    }
}
