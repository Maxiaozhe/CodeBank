using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DenshowBusinessInterface;
using DenshowBusinessInterface.Entity;
using DenshowCommon;

namespace DenshowBusinessComponent.Control
{
    /// <summary>
    /// 論理演算式のチェッククラスを実装
    /// </summary>
    /// <remarks>
    /// <![CDATA[
    /// ◆．日付形式の検査
    ///   定義式： &
    /// ◆．日付計算の妥当性検査
    ///   定義式： &、-
    ///   結果式： &、+、-、*、/、()
    /// ◆．時間形式の検査
    ///   定義式： &
    /// ◆．時間計算の妥当性検査
    ///   定義式： &、-
    ///   結果式： &、+、-、*、/、()
    /// ◆．数値形式の検査
    ///   定義式： &、+、-、*、/、()
    /// ◆．計算結果の妥当性検査
    ///   定義式： &、+、-、*、/、()
    ///   結果式： &、+、-、*、/、()
    /// ]]>
    /// </remarks>
    internal class ExpressionChecker
    {
        #region Enum
        /// <summary>
        /// 計算式の種別
        /// </summary>
        public enum ExpressType
        {
            /// <summary>
            /// 日付形式の検査
            /// </summary>
            CheckDate,
            /// <summary>
            /// 時間形式の検査
            /// </summary>
            CheckTime,
            /// <summary>
            /// 数値形式の検査
            /// </summary>
            CheckNumeric,
            /// <summary>
            /// 日付計算式
            /// </summary>
            CalcDate,
            /// <summary>
            /// 時間計算式
            /// </summary>
            CalcTime,
            /// <summary>
            /// 数値計算式
            /// </summary>
            CalcNumeric
        }
        #endregion

        #region delegate
        /// <summary>
        /// 値取得用デリゲート
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private delegate string GetValuePrivateHandler(string match);
        /// <summary>
        /// 項目IDで値を取得するデリゲート
        /// </summary>
        /// <param name="groupId">グループID</param>
        /// <returns></returns>
        public delegate string GetValueHandler(string groupId);
        /// <summary>
        /// グループ項目を取得するデリゲート
        /// </summary>
        /// <param name="groupId">グループID</param>
        /// <returns></returns>
        public delegate ChecklistGroup GetChecklistDetailHandler(string groupId);
        /// <summary>
        /// グループ項目の合計桁数を取得するデリゲート
        /// </summary>
        /// <param name="groupId">グループID</param>
        /// <returns>桁数</returns>
        public delegate int GetTotalRcDegitHandler(string groupId);
        #endregion

        #region Fields

        /// <summary>
        /// 計算式
        /// </summary>
        private string expression;
        /// <summary>
        /// 計算式の種別
        /// </summary>
        private ExpressType expressType;
        /// <summary>
        /// 値取得用デリゲート
        /// </summary>
        private GetValuePrivateHandler getValuePrivateHander = null;
        /// <summary>
        /// 項目IDで値を取得するデリゲート
        /// </summary>
        private GetValueHandler getValueHandler;
        /// <summary>
        /// グループ項目を取得するデリゲート
        /// </summary>
        private GetChecklistDetailHandler getChecklistDetailHandler;
        /// <summary>
        /// グループ項目の合計桁数を取得するデリゲート
        /// </summary>
        private GetTotalRcDegitHandler getTotalRcDegitHandler;
        /// <summary>
        /// エラーが発生したチェックリストグループIDリスト
        /// </summary>
        private List<string> errorClGroupList = new List<string>();

        /// <summary>
        /// 文字列結合式を抽出する正規表現式
        /// </summary>
        /// <remarks>
        /// [<![CDATA[
        /// {CG00001}&{CG00002}&{CG00002}のような計算式を抽出する
        /// 固定の数値も含む
        /// ]]>
        /// </remarks>
        private const string stringJoinExpressRegex = @"((\{[^\{\}]+\}|\d+)\s*&\s*)+(\{[^\{\}]+\}|\d+)";

        /// <summary>
        /// グループID及び固定数値を抽出する正規表現式
        /// </summary>
        /// <remarks>
        /// <![CDATA[
        /// {CG0001}或いは1234のような数値文字を抽出する 
        /// ]]>
        /// </remarks>
        private const string groupIdOrNumberRegex = @"(\{[^\{\}]+\})|(\d+\.{0,1}\d*)";

        /// <summary>
        /// 演算式使用可能な演算子を抽出する正規表現式
        /// </summary>
        private const string operatorCheckRegex = @"[\+\-\*\/\&]";
        /// <summary>
        /// 演算式の演算項目部分を抽出する正規表現式
        /// (\{[^\{\}]+\})：グループコード
        /// (\(\s*\-[0-9\.]+\s*\))：括弧付けマイナス数値
        /// ([0-9\.]+)：正数値
        /// </summary>
        private const string expressItemCheckRegex = @"(\{[^\{\}]+\})|(\(\s*\-[0-9\.]+\s*\))|([0-9\.]+)";
        /// <summary>
        /// グループ項目のIDと値を保持するコレクション
        /// </summary>
        private Dictionary<string, string> groupItems = new Dictionary<string, string>();
        #endregion

        #region Property
        /// <summary>
        /// すべての項目データは未入力かどうかを取得する
        /// </summary>
        public bool HasInput
        {
            get
            {
                //項目データない場合、Trueで戻す（入力ありと見なす）
                if (this.groupItems.Count == 0)
                {
                    return true;
                }
                //一つ項目の値は空ではない場合Trueで戻す
                return this.groupItems.Any(x => !string.IsNullOrEmpty(x.Value));
            }
        }
        #endregion

        #region Contructot
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="expression">計算式</param>
        /// <param name="expressType">計算式の種別</param>
        /// <param name="getValueHandler">計算式の項目IDで値を取得するデリゲート</param>
        public ExpressionChecker(string expression, ExpressType expressType, GetValueHandler getValueHandler)
        {
            this.expression = expression;
            this.expressType = expressType;
            this.getValueHandler = getValueHandler;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="expression">計算式</param>
        /// <param name="expressType">計算式の種別</param>
        /// <param name="getTryValueHandler"></param>
        /// <param name="getTryValueHandler2"></param>
        public ExpressionChecker(string expression, ExpressType expressType, GetChecklistDetailHandler getTryValueHandler, GetTotalRcDegitHandler getTryValueHandler2)
        {
            this.expression = expression;
            this.expressType = expressType;
            this.getChecklistDetailHandler = getTryValueHandler;
            this.getTotalRcDegitHandler = getTryValueHandler2;
        }

        #endregion

        #region private methods
        /// <summary>
        /// 文字連結式分析
        /// </summary>
        private string analysisStringContact(string express)
        {
            Regex regex = new Regex(stringJoinExpressRegex);

            string result = regex.Replace(express, new MatchEvaluator(match =>
            {
                return getStringContact(match.Value);
            }));

            Regex calcRegxt = new Regex(groupIdOrNumberRegex);
            result = calcRegxt.Replace(result, new MatchEvaluator(match =>
            {
                return getValuePrivateHander(match.Value);
            }));
            return result;
        }

        /// <summary>
        /// 日付計算式を行う
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        private int analysisDateCalcExpression(string express)
        {
            string[] subExpresses = express.Split('-');
            if (subExpresses.Length > 2)
            {
                throw new DenshowBusinessException(DenshowCommon.Message.EP132);
            }
            string leftExp = subExpresses[0];
            string rightExp = subExpresses[1];
            string leftValue = analysisStringContact(leftExp);
            string rightValue = analysisStringContact(rightExp);
            DateTime leftDate = ConvertToDate(leftValue);
            DateTime rightDate = ConvertToDate(rightValue);
            return (int)Math.Truncate(leftDate.Subtract(rightDate).TotalDays);
        }

        /// <summary>
        /// 時間計算式を行う
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        private int analysisTimeCalcExpression(string express)
        {
            string[] subExpresses = express.Split('-');
            if (subExpresses.Length > 2)
            {
                throw new DenshowBusinessException(DenshowCommon.Message.EP132);
            }
            string leftExp = subExpresses[0];
            string rightExp = subExpresses[1];
            string leftValue = analysisStringContact(leftExp);
            string rightValue = analysisStringContact(rightExp);
            DateTime leftDate = ConvertToTime(leftValue);
            DateTime rightDate = ConvertToTime(rightValue);
            return (int)Math.Truncate(leftDate.Subtract(rightDate).TotalMinutes);
        }

        /// <summary>
        /// 数値計算式を行う
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        private string analysisNumericCalcExpression(string express)
        {
            Regex regex = new Regex(stringJoinExpressRegex);

            express = regex.Replace(express, new MatchEvaluator(match =>
            {
                return ConvertToNumeric(getStringContact(match.Value));
            }));

            Regex calcRegxt = new Regex(groupIdOrNumberRegex);
            express = calcRegxt.Replace(express, new MatchEvaluator(match =>
            {
                return ConvertToNumeric(getValuePrivateHander(match.Value));
            }));

            DataTable dttComputer = new DataTable();
            decimal result = Convert.ToDecimal(dttComputer.Compute(express, ""));
            return  Math.Floor( result).ToString("#");
        }

        /// <summary>
        /// 日付へ変換
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private DateTime ConvertToDate(string date)
        {
            string[] formats = { "yyyyMMdd" };//サポート形式拡張は可能
            DateTime dt;
            if (!DateTime.TryParseExact(date, formats, null, DateTimeStyles.AllowWhiteSpaces, out dt))
            {
                throw new Exception();
            }
            return dt;
        }

        /// <summary>
        /// 時間へ変換
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private DateTime ConvertToTime(string date)
        {
            string[] formats = { "HHmm", "HHmmss" };//サポート形式拡張は可能
            DateTime dt;
            if (!DateTime.TryParseExact(date, formats, null, DateTimeStyles.AllowWhiteSpaces, out dt))
            {
                throw new Exception();
            }
            return dt;
        }

        /// <summary>
        /// 数値へ変換する
        /// </summary>
        /// <param name="value">文字列</param>
        /// <returns>変換結果の数値</returns>
        private string ConvertToNumeric(string value)
        {
            decimal reuslt;
            if (!decimal.TryParse(value, out reuslt))
            {
                throw new Exception();
            }
            return reuslt.ToString();
        }

        /// <summary>
        /// 文字列連結式の値へ変換する
        /// </summary>
        /// <param name="express">文字列連結式</param>
        /// <returns>文字列連結式の値</returns>
        private string getStringContact(string express)
        {
            Regex regex = new Regex(groupIdOrNumberRegex);
            express = express.Replace("&", "");
            express = express.Replace(" ", "");
            string result = regex.Replace(express, new MatchEvaluator(match =>
            {
                return getValuePrivateHander(match.Value);
            }));
            return result;
        }

        /// <summary>
        /// グループID及び固定数値の計算式から値を取得
        /// </summary>
        /// <param name="match">グループID及び固定数値の計算式</param>
        /// <returns>グループID及び固定数値の計算式の値</returns>
        private string getValue(string match)
        {

            // 中括弧で囲まれていない場合はそのまま返す
            if (!match.StartsWith("{") || !match.EndsWith("}"))
            {
                return match;
            }
            if (this.getValueHandler != null)
            {
                string propName = Regex.Replace(match, @"[\{\}]", "");
                string value = this.getValueHandler(propName);
                //項目コレクションに含めない場合追加する
                if (!this.groupItems.ContainsKey(propName))
                {
                    this.groupItems.Add(propName, value);
                }
                //未入力時0で代入
                if (string.IsNullOrEmpty(value))
                {
                    value = "0";
                }
                return value;
            }
            else
            {
                return match;
            }
        }

        /// <summary>
        /// グループID及び固定数値の計算式から値を取得（チェック用）
        /// </summary>
        /// <param name="match">グループID及び固定数値の計算式</param>
        /// <returns>グループID及び固定数値の計算式の値</returns>
        private string getValueForTry(string match)
        {
            // 中括弧で囲まれていない場合はそのまま返す
            if (!match.StartsWith("{") || !match.EndsWith("}"))
            {
                return match;
            }

            // チェックリストグループデータを取得する
            string propName = Regex.Replace(match, @"[\{\}]", "");
            if (this.getChecklistDetailHandler(propName) == null)
            {
                // チェックリストグループデータが存在しなかった場合はリストに追加
                this.errorClGroupList.Add(propName);
            }

            // 桁数を取得する
            int count = this.getTotalRcDegitHandler(propName);

            // 桁数分仮データとして「1」を連結する
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append("1");
            }

            // 仮データを返す
            return sb.ToString();
        }
        #endregion

        #region public methods
        /// <summary>
        /// 初期化時指定した計算式を計算する
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            //項目データをクリアする
            groupItems.Clear();
            // 値取得メソッドの登録
            getValuePrivateHander = this.getValue;

            switch (this.expressType)
            {
                case ExpressType.CheckDate:
                case ExpressType.CheckTime:
                    return this.analysisStringContact(this.expression);
                case ExpressType.CheckNumeric:
                    return this.analysisNumericCalcExpression(this.expression);
                case ExpressType.CalcDate:
                    return this.analysisDateCalcExpression(this.expression).ToString();
                case ExpressType.CalcTime:
                    return this.analysisTimeCalcExpression(this.expression).ToString();
                default:
                    return this.analysisNumericCalcExpression(this.expression);
            }
        }

        /// <summary>
        /// 初期化時指定した計算式を計算する（チェック版）
        /// </summary>
        /// <returns></returns>
        public bool TryCompute()
        {
            // 値取得メソッドの登録
            getValuePrivateHander = this.getValueForTry;

            string ret = null;
            try
            {
                // グループ存在チェック
                Regex calcRegxt = new Regex(groupIdOrNumberRegex);
                string result = calcRegxt.Replace(this.expression, new MatchEvaluator(match =>
                {
                    return getValuePrivateHander(match.Value);
                }));

                // グループIDが存在しない項があった場合は例外をスローする
                this.checkGroupList();

                // 禁則文字チェック
                this.checkForbidChar();

                // 演算子必須チェック
                this.checkOperationNum();

                switch (this.expressType)
                {
                    case ExpressType.CheckDate:
                        // 定義式のみの場合：日付形式検査
                        ret = tryAnalysisDateCheckExpression(this.expression);
                        break;

                    case ExpressType.CheckTime:
                        // 定義式のみの場合：時間形式検査
                        ret = tryAnalysisTimeCheckExpression(this.expression);
                        break;

                    case ExpressType.CheckNumeric:
                        // 定義式：数値形式検査
                        ret = tryAnalysisNumericCheckExpression(this.expression);
                        break;
                    case ExpressType.CalcDate:
                        // 定義式：日付形式検査
                        ret = tryAnalysisDateCalcExpression(this.expression).ToString();
                        break;
                    case ExpressType.CalcTime:
                        // 定義式：時間形式検査
                        ret = tryAnalysisTimeCalcExpression(this.expression).ToString();
                        break;
                    default:
                        // 結果式：妥当性チェック
                        ret = tryAnalysisNumericCalcExpression(this.expression);
                        break;
                }
            }
            catch (DenshowBusinessException)
            {
                throw;
            }

            return true;
        }

        /// <summary>
        /// 禁則文字チェック
        /// </summary>
        /// <returns></returns>
        private void checkForbidChar()
        {
            // 空白を除く
            string express = Regex.Replace(this.expression, @"\s", string.Empty);

            //グループコード及び固定文字列を除く
            express = Regex.Replace(express, groupIdOrNumberRegex, string.Empty);

            string forbidRegex = string.Empty;
            switch (this.expressType)
            {
                case ExpressType.CheckDate:
                case ExpressType.CheckTime:
                    //[&,0-9]のみ許可する
                    forbidRegex = @"[^0-9&]";
                    break;
                case ExpressType.CalcDate:
                case ExpressType.CalcTime:
                    //[&,0-9,-]のみ許可する
                    forbidRegex = @"[^0-9&\-]";
                    break;
                default:
                    //[&,0-9,+-*/(),小数点]のみ許可する
                    forbidRegex = @"[^0-9\+\-\*\/\.&\(\)]";
                    break;
            }
            if (Regex.Match(express, forbidRegex).Success)
            {
                throw new DenshowBusinessException(Message.EP131);
            }
        }

        /// <summary>
        /// 存在しないグループIDがあるかチェックして例外をスローする処理
        /// </summary>
        private void checkGroupList()
        {
            if (this.errorClGroupList.Count() != 0)
            {
                int i = 0;
                StringBuilder sb = new StringBuilder();
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

                // 結果式か定義式かでメッセージIDを変更する
                if (this.expressType == ExpressType.CalcNumeric)
                {
                    throw new DenshowBusinessException(string.Format(Message.EP135, sb.ToString()));
                }
                throw new DenshowBusinessException(string.Format(Message.EP130, sb.ToString()));
            }
        }

        /// <summary>
        /// 演算子の数が合っているかのチェック（＆必須チェックも兼ねる）
        /// </summary>
        private void checkOperationNum()
        {
            Regex regex = new Regex(expressItemCheckRegex);
            int itemNum = 0;
            //演算項目を除くして、演算項目数を計算する
            string exp = regex.Replace(this.expression, new MatchEvaluator(match =>
            {
                itemNum++;
                return string.Empty;
            }));
            //演算子の個数を抽出する
            regex = new Regex(operatorCheckRegex);
            int operatorNum = regex.Matches(exp).Count;

            if (itemNum != operatorNum + 1)
            {
                // 結果式か定義式かでメッセージIDを変更する
                switch (this.expressType)
                {
                    case ExpressType.CheckDate:
                    case ExpressType.CheckTime:
                    case ExpressType.CheckNumeric:
                        throw new DenshowBusinessException(Message.EP134);
                 default:
                        throw new DenshowBusinessException(Message.EP136);
                }
            }
        }

        /// <summary>
        /// 定義式：日付形式検査
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        private string tryAnalysisDateCheckExpression(string express)
        {
            // 空白を除く
            string result = Regex.Replace(express, @"\s", string.Empty);

            // グループ結合マッチングによる置き換え
            Regex joinRegex = new Regex(stringJoinExpressRegex);
            result = joinRegex.Replace(result, new MatchEvaluator(match =>
            {
                return getStringContact(match.Value);
            }));

            // グループ単体および数値マッチングによる置き換え
            Regex calcRegxt = new Regex(groupIdOrNumberRegex);
            result = calcRegxt.Replace(result, new MatchEvaluator(match =>
            {
                return getValuePrivateHander(match.Value);
            }));

            // 桁数検査
            if (result.Length != 8)
            {
                throw new DenshowBusinessException(string.Format(Message.EP133, express));
            }

            // 形式検査
            try
            {
                DateTime dt = ConvertToDate(result);
            }
            catch
            {
                throw new DenshowBusinessException(Message.EP134);
            }

            return result;
        }

        /// <summary>
        /// 定義式：時間形式検査
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        private string tryAnalysisTimeCheckExpression(string express)
        {
            // 空白を除く
            string result = Regex.Replace(express, @"\s", string.Empty);

            // グループ結合マッチングによる置き換え
            Regex joinRegex = new Regex(stringJoinExpressRegex);
            result = joinRegex.Replace(result, new MatchEvaluator(match =>
            {
                return getStringContact(match.Value);
            }));

            // グループ単体および数値マッチングによる置き換え
            Regex calcRegxt = new Regex(groupIdOrNumberRegex);
            result = calcRegxt.Replace(result, new MatchEvaluator(match =>
            {
                return getValuePrivateHander(match.Value);
            }));

            // 桁数検査
            if (result.Length != 4)
            {
                throw new DenshowBusinessException(string.Format(Message.EP133, express));
            }

            // 形式検査
            try
            {
                DateTime dt = ConvertToTime(result);
            }
            catch
            {
                throw new DenshowBusinessException(Message.EP134);
            }

            return result;
        }

        /// <summary>
        /// 定義式：数値形式検査
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        private string tryAnalysisNumericCheckExpression(string express)
        {
            try
            {
                // 空白を除く
                express = Regex.Replace(express, @"\s", string.Empty);

                // グループ結合マッチングによる置き換え
                Regex regex = new Regex(stringJoinExpressRegex);
                express = regex.Replace(express, new MatchEvaluator(match =>
                {
                    return ConvertToNumeric(getStringContact(match.Value));
                }));

                // グループ単体および数値マッチングによる置き換え
                Regex calcRegxt = new Regex(groupIdOrNumberRegex);
                express = calcRegxt.Replace(express, new MatchEvaluator(match =>
                {
                    string value = getValuePrivateHander(match.Value);
                    return ConvertToNumeric(value);
                }));

                // 実際に計算する
                DataTable dttComputer = new DataTable();
                object result = dttComputer.Compute(express, "");
                return result.ToString();
            }
            catch
            {
                throw new DenshowBusinessException(Message.EP134);
            }
        }

        /// <summary>
        /// 定義式：日付計算の妥当性検査
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        private int tryAnalysisDateCalcExpression(string express)
        {
            // マイナス演算子が１つかどうかのチェック
            string[] subExpresses = express.Split('-');
            if (subExpresses.Length > 2)
            {
                throw new DenshowBusinessException(DenshowCommon.Message.EP132);
            }

            // マイナス演算子が存在しない場合（単体項目）
            if (subExpresses.Length == 1)
            {
                string leftExp = subExpresses[0];
                string leftValue = tryAnalysisDateCheckExpression(leftExp);
                DateTime leftDate = ConvertToDate(leftValue);
                return 0;
            }
            // マイナス演算子が存在する場合（日付の演算）
            else
            {
                string leftExp = subExpresses[0];
                string rightExp = subExpresses[1];
                string leftValue = tryAnalysisDateCheckExpression(leftExp);
                string rightValue = tryAnalysisDateCheckExpression(rightExp);
                DateTime leftDate = ConvertToDate(leftValue);
                DateTime rightDate = ConvertToDate(rightValue);
                return (int)Math.Truncate(leftDate.Subtract(rightDate).TotalDays);
            }
        }

        /// <summary>
        /// 定義式：時間計算の妥当性検査
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        private int tryAnalysisTimeCalcExpression(string express)
        {
            // マイナス演算子が２つ以上ないかどうかのチェック
            string[] subExpresses = express.Split('-');
            if (subExpresses.Length > 2)
            {
                throw new DenshowBusinessException(DenshowCommon.Message.EP132);
            }

            // マイナス演算子が存在しない場合（単体項目）
            if (subExpresses.Length == 1)
            {
                string leftExp = subExpresses[0];
                string leftValue = tryAnalysisTimeCheckExpression(leftExp);
                DateTime leftDate = ConvertToTime(leftValue);
                return 0;
            }

            // マイナス演算子が存在する場合（時間の演算）
            else
            {
                string leftExp = subExpresses[0];
                string rightExp = subExpresses[1];
                string leftValue = tryAnalysisTimeCheckExpression(leftExp);
                string rightValue = tryAnalysisTimeCheckExpression(rightExp);
                DateTime leftDate = ConvertToTime(leftValue);
                DateTime rightDate = ConvertToTime(rightValue);
                return (int)Math.Truncate(leftDate.Subtract(rightDate).TotalMinutes);
            }
        }

        /// <summary>
        /// 結果式：日付、時間、数値計算の妥当性検査
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        private string tryAnalysisNumericCalcExpression(string express)
        {
            try
            {
                // 空白を除く
                express = Regex.Replace(express, @"\s", string.Empty);

                // グループ結合マッチングによる置き換え
                Regex regex = new Regex(stringJoinExpressRegex);
                express = regex.Replace(express, new MatchEvaluator(match =>
                {
                    return ConvertToNumeric(getStringContact(match.Value));
                }));

                // グループ単体および数値マッチングによる置き換え
                Regex calcRegxt = new Regex(groupIdOrNumberRegex);
                express = calcRegxt.Replace(express, new MatchEvaluator(match =>
                {
                    string value = getValuePrivateHander(match.Value);
                    return ConvertToNumeric(value);
                }));

                // 実際に計算する
                DataTable dttComputer = new DataTable();
                object result = dttComputer.Compute(express, "");
                return result.ToString();
            }
            catch
            {
                throw new DenshowBusinessException(Message.EP136);
            }
        }
        #endregion
    }
}
