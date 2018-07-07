using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DenshowBusinessInterface;
using DenshowBusinessInterface.Entity;
using DenshowCommon;
using DenshowDataAccessInterface;
using DenshowDataAccessInterface.Dto;

namespace DenshowBusinessComponent.Control
{
    /// <summary>
    /// 認識結果修正の入力検査コントロール
    /// </summary>
    internal class ResultChecker
    {
        #region Field
        /// <summary>
        /// 認識結果データリスト
        /// </summary>
        private List<OcrEdit> ocrEditList = null;

        /// <summary>
        /// チェックリスト設計情報
        /// </summary>
        private List<ChecklistInfo> checklistInfoList = null;
        /// <summary>
        /// マスタ参照情報
        /// </summary>
        private List<MasterReference> masterReferenceList = null;
        /// <summary>
        /// 定義式結果メッセージ表示
        /// </summary>
        private const string ValidateResultMsg = @"(定義式：""{0}"" 結果式：""{1}"")";
        /// <summary>
        /// 結果式結果メッセージ表示
        /// </summary>
        private const string CheckExpResultMsg = @"(定義式：""{0}"")";

        #endregion

        #region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="ocrEditList">認識結果項目情報</param>
        public ResultChecker(List<OcrEdit> ocrEditList)
        {
            //検査対象リストをセットする
            this.ocrEditList = ocrEditList;

            //関連設計情報を取得する
            this.getDesignInfoList();
        }
        #endregion

        #region private Method

        #region 関連情報取得
        /// <summary>
        /// 関連設計情報(チェックリスト、マスタ参照)を取得する
        /// </summary>
        private void getDesignInfoList()
        {

            //認識結果データに参照するチェックリストIDを抽出する
            List<string> clIdList = this.ocrEditList.Select(x => x.ClId).Distinct().ToList();

            using (IDataAccessComponent access = DenshowDataAccessInterface.DataAccessFactory.GetDataAccess())
            {
                // チェックリストビューの取得
                var checklistDtoList = access.GetChecklistViewDao().GetList(clIdList);
                this.checklistInfoList = new List<ChecklistInfo>();
                foreach (ChecklistViewDto chkinfoDto in checklistDtoList)
                {
                    ChecklistInfo chkinfo = new ChecklistInfo();
                    Utility.CopyProperty(chkinfoDto, chkinfo);
                    this.checklistInfoList.Add(chkinfo);
                }

                //マスタ参照情報を取得する
                List<MasterReferenceDesignDto> masterRefDtoList = access.GetMasterReferenceDesignDao().GetList(clIdList);
                this.masterReferenceList = new List<MasterReference>();
                foreach (MasterReferenceDesignDto masterDto in masterRefDtoList)
                {
                    MasterReference entity = new MasterReference();
                    Utility.CopyProperty(masterDto, entity);
                    this.masterReferenceList.Add(entity);
                }

            }
        }

        /// <summary>
        /// 該当帳票認識結果項目のチェックリストグループ情報を取得する
        /// </summary>
        /// <param name="editItem"></param>
        /// <returns></returns>
        private ChecklistInfo getChecklistInfo(OcrEdit editItem)
        {
            ChecklistInfo clItem = (from x in this.checklistInfoList
                                    where x.ClId == editItem.ClId && x.ClGroupId == editItem.ClGroupId
                                    select x).First();
            return clItem;
        }

        /// <summary>
        /// グループ項目の桁数の合計値を取得する
        /// </summary>
        /// <returns></returns>
        private int getRcDigit(OcrEdit editItem)
        {
            int rcDigit = (from x in this.checklistInfoList
                           where x.ClId == editItem.ClId && x.ClGroupId == editItem.ClGroupId && x.ItemKind == Definition.ItemKind.PICTURE
                           select x.RcDigit).Sum(digit =>
                           {
                               int ret = 0;
                               return int.TryParse(digit, out ret) ? ret : 0;
                           });
            return rcDigit;
        }

        /// <summary>
        /// グループ項目の件数を取得する
        /// </summary>
        /// <returns></returns>
        private int getOmrGroupCount(OcrEdit editItem)
        {
            int count = (from x in this.ocrEditList
                         where (x.PageNo == editItem.PageNo) && (x.ClId == editItem.ClId) && (x.ClGroupId == editItem.ClGroupId)
                             && (x.ItemKind == Definition.ItemKind.PICTURE)
                         select x).Count();
            return count;
        }

        /// <summary>
        /// 指定グループIDの検査項目の値を取得する
        /// </summary>
        /// <param name="pageNo">ページ番号</param>
        /// <param name="clId">チェックリストID</param>
        /// <param name="groupId">グループID</param>
        /// <returns>指定グループIDの検査項目の値</returns>
        private string getGroupValue(int pageNo, string clId, string groupId)
        {
            try
            {
                string value = (from x in this.ocrEditList
                                where (x.PageNo == pageNo) && (x.ClId == clId) && (x.ClGroupId == groupId)
                                    && (x.IsCheckItem)
                                select x.CorrectedString).Single();
                return value;
            }
            catch
            {
                //定義式に存在しないグループコードがある場合
                throw new DenshowBusinessException(string.Format(Message.EP130, groupId));
            }
        }

        /// <summary>
        /// 指定グループIDの検査項目を取得する
        /// </summary>
        /// <param name="pageNo">ページ番号</param>
        /// <param name="clId">チェックリストID</param>
        /// <param name="groupId">グループID</param>
        /// <returns>指定グループIDの検査項目の値</returns>
        private OcrEdit getEditItem(int pageNo, string clId, string groupId)
        {
            try
            {
                OcrEdit value = (from x in this.ocrEditList
                                 where (x.PageNo == pageNo) && (x.ClId == clId) && (x.ClGroupId == groupId)
                                     && (x.IsCheckItem)
                                 select x).Single();
                return value;
            }
            catch
            {
                //定義式に存在しないグループコードがある場合
                throw new DenshowBusinessException(string.Format(Message.EP130, groupId));
            }
        }


        /// <summary>
        /// 該当帳票認識結果項目のマスタ参照情報を取得する
        /// </summary>
        /// <param name="editItem"></param>
        /// <returns></returns>
        private List<MasterReference> GetMasterReference(OcrEdit editItem)
        {
            List<MasterReference> masterInfos =
                                    (from x in this.masterReferenceList
                                     where x.ClId == editItem.ClId && x.ClGroupId == editItem.ClGroupId
                                     orderby x.RowNo
                                     select x).ToList();
            return masterInfos;
        }
        #endregion

        #region 検査
        /// <summary>
        /// OMR範囲検査
        /// </summary>
        /// <param name="chkInfo">検査情報</param>
        /// <param name="ocrEdit">検査対象</param>
        private bool checkOmrRange(ChecklistInfo chkInfo, OcrEdit ocrEdit)
        {
            bool result = true;
            if (ocrEdit.ItemKind == Definition.ItemKind.OMR)
            {
                int count = this.getOmrGroupCount(ocrEdit);

                //0,1以外の値の入力チェック
                bool isNotBitOnly = ocrEdit.CorrectedString.Any(x => x != '0' && x != '1');
                //0,1の値がある或いは桁数不正の場合
                if (isNotBitOnly || ocrEdit.CorrectedString.Length != count)
                {
                    setErrMessage(ocrEdit, DenshowCommon.Message.EC002);
                    result = false;
                }
                //マック数を取得する
                int markCount = ocrEdit.CorrectedString.Count(x => x == '1');
                if (chkInfo.MarkCheckMinValue > 0 || chkInfo.MarkCheckMaxValue > 0)
                {//最小・最大範囲値がどちらも0の場合は、チェック対象外。
                    if (markCount < chkInfo.MarkCheckMinValue || markCount > chkInfo.MarkCheckMaxValue)
                    {
                        setErrMessage(ocrEdit, DenshowCommon.Message.EP087);
                        result = false;
                    }
                }

            }
            return result;
        }

        /// <summary>
        /// 範囲チェック
        /// </summary>
        /// <param name="chkInfo">検査情報</param>
        /// <param name="item">検査対象</param>
        /// <returns></returns>
        private bool checkRange(ChecklistInfo chkInfo, OcrEdit item)
        {
            //両方とも設定されていない場合、チェック対象外
            if (!chkInfo.RangeCheckMinValue.HasValue && !chkInfo.RangeCheckMaxValue.HasValue)
            {
                return true;
            }
            //両方とも0の場合、チェック対象外
            if (chkInfo.RangeCheckMinValue == 0 && chkInfo.RangeCheckMaxValue == 0)
            {
                return true;
            }
            //型変換失敗する場合、他のチェックで行うので、範囲チェックを通る
            int value = 0;
            if (int.TryParse(item.CorrectedString, out value))
            {
                if (value < chkInfo.RangeCheckMinValue || value > chkInfo.RangeCheckMaxValue)
                {
                    setErrMessage(item, DenshowCommon.Message.EP147);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 桁数検査
        /// </summary>
        /// <param name="chkInfo">検査情報</param>
        /// <param name="ocrEdit">検査対象</param>
        private bool checkDigit(ChecklistInfo chkInfo, OcrEdit ocrEdit)
        {
            if (chkInfo.DigitInspectionFlag.HasValue && chkInfo.DigitInspectionFlag.Value)
            {
                int rcDigit = this.getRcDigit(ocrEdit);
                if (ocrEdit.CorrectedString.Length != rcDigit)
                {
                    setErrMessage(ocrEdit, DenshowCommon.Message.EP088);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 未記入検査
        /// </summary>
        /// <param name="chkInfo">検査情報</param>
        /// <param name="ocrEdit">検査対象</param>
        /// <returns>
        /// 戻り値：True:OK / False:NG
        /// </returns>
        private bool checkBlank(ChecklistInfo chkInfo, OcrEdit ocrEdit)
        {
            if (chkInfo.BlankInspectionFlag.HasValue && chkInfo.BlankInspectionFlag.Value)
            {
                if (string.IsNullOrEmpty(ocrEdit.CorrectedString))
                {
                    setErrMessage(ocrEdit, DenshowCommon.Message.EC001);
                    return false;
                }
            }
            return true;

        }


        /// <summary>
        /// チェックサム
        /// </summary>
        /// <param name="chkInfo">検査情報</param>
        /// <param name="item">検査対象</param>
        private bool checkSum(ChecklistInfo chkInfo, OcrEdit item)
        {
            if (chkInfo.DataType != Definition.DataType.Numeric)
            {
                return true;
            }

            int result;
            if (!int.TryParse(item.CorrectedString, out result))
            {
                return true;
            }

            if (chkInfo.ChecksumInspectionFlag == true)
            {
                int sum = 0;
                int itemLength = item.CorrectedString.Length;
                int checkSum = int.Parse(item.CorrectedString.Substring(itemLength - 1));


                // 末尾桁以外の数字の合計値を求める
                for (int i = 0; i < itemLength - 1; i++)
                {
                    int x = int.Parse(item.CorrectedString.Substring(i, 1));
                    sum += x;
                }
                if (sum % 10 != checkSum)
                {
                    setErrMessage(item, DenshowCommon.Message.EP089);
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// 論理演算検査
        /// </summary>
        /// <param name="chkInfo">検査情報</param>
        /// <param name="ocrEdit">検査対象</param>
        private bool checkLogicalOperation(ChecklistInfo chkInfo, OcrEdit ocrEdit)
        {
            FormulaResult expressResult = null;
            if (string.IsNullOrEmpty(chkInfo.DefinitionExpression))
            {
                return true;
            }
            

            // 日付妥当性検査
            if (chkInfo.DateValidationFlag.HasValue && chkInfo.DateValidationFlag.Value)
            {
                //定義式（日付計算）
                expressResult = this.createFormula(ExpressionChecker.ExpressType.CalcDate, chkInfo.DefinitionExpression, ocrEdit);

                // 結果式を解析
                FormulaResult resultExpression = createFormula(ExpressionChecker.ExpressType.CalcNumeric, chkInfo.ResultExpression, ocrEdit);
                if (!expressResult.HasInput && !resultExpression.HasInput)
                {
                    //未入力場合通る
                    return true;
                }
                //演算結果null及び一致しない場合エラーになる
                if ((expressResult.Value == null) || (resultExpression==null) 
                    || (expressResult.Value != resultExpression.Value))
                {
                    string result = string.Format(ValidateResultMsg, expressResult.Value, resultExpression.Value);
                    string errMsg = string.Format(DenshowCommon.Message.EP091, result);
                    setErrMessage(ocrEdit, errMsg);
                    return false;
                }
                return true;
            }

            // 時間妥当性検査
            if (chkInfo.TimeValidationFlag.HasValue && chkInfo.TimeValidationFlag.Value)
            {
                //定義式（時間計算）
                expressResult = this.createFormula(ExpressionChecker.ExpressType.CalcTime, chkInfo.DefinitionExpression, ocrEdit);

                // 結果式を解析
                FormulaResult resultExpression = createFormula(ExpressionChecker.ExpressType.CalcNumeric, chkInfo.ResultExpression, ocrEdit);

                if (!expressResult.HasInput && !resultExpression.HasInput)
                {
                    //未入力場合通る
                    return true;
                }
                //演算結果null及び一致しない場合エラーになる
                if ((expressResult.Value == null) || (resultExpression == null) 
                    || (expressResult.Value != resultExpression.Value))
                {
                    string result = string.Format(ValidateResultMsg, expressResult.Value, resultExpression.Value);
                    string errMsg = string.Format(DenshowCommon.Message.EP091, result);
                    setErrMessage(ocrEdit, errMsg);
                    return false;
                }
                return true;
            }

            // 数値妥当性検査
            if (chkInfo.NumberValidationFlag.HasValue && chkInfo.NumberValidationFlag.Value)
            {
                //定義式（時間計算）
                expressResult = this.createFormula(ExpressionChecker.ExpressType.CalcNumeric, chkInfo.DefinitionExpression, ocrEdit);

                // 結果式を解析
                FormulaResult resultExpression = createFormula(ExpressionChecker.ExpressType.CalcNumeric, chkInfo.ResultExpression, ocrEdit);

                if (!expressResult.HasInput && !resultExpression.HasInput)
                {
                    //未入力場合通る
                    return true;
                }
                //演算結果null及び一致しない場合エラーになる
                if ((expressResult.Value == null) || (resultExpression == null) 
                    || (expressResult.Value != resultExpression.Value))
                {
                    string result = string.Format(ValidateResultMsg, expressResult.Value, resultExpression.Value);
                    string errMsg = string.Format(DenshowCommon.Message.EP091, result);
                    setErrMessage(ocrEdit, errMsg);
                    return false;
                }
                return true;
            }

            // 日付形式検査
            if (chkInfo.DateFormatCheckFlag.HasValue && chkInfo.DateFormatCheckFlag.Value)
            {
                expressResult = this.createFormula(ExpressionChecker.ExpressType.CheckDate, chkInfo.DefinitionExpression, ocrEdit);
                if (expressResult.HasInput && !checkDate(expressResult.Value))
                {
                    string result = string.Format(CheckExpResultMsg, expressResult.Value);
                    string errMsg = string.Format(DenshowCommon.Message.EP091, result);
                    setErrMessage(ocrEdit, errMsg);
                    return false;
                }
                return true;
            }

            // 時刻形式検査
            if (chkInfo.TimeFormatCheckFlag.HasValue && chkInfo.TimeFormatCheckFlag.Value)
            {
                expressResult = this.createFormula(ExpressionChecker.ExpressType.CheckTime, chkInfo.DefinitionExpression, ocrEdit);

                if (expressResult.HasInput && !checkTime(expressResult.Value))
                {
                    string result = string.Format(CheckExpResultMsg, expressResult.Value);
                    string errMsg = string.Format(DenshowCommon.Message.EP091, result);
                    setErrMessage(ocrEdit, errMsg);
                    return false;
                }
                return true;
            }

            // 数値形式検査
            if (chkInfo.NumberFormatCheckFlag.HasValue && chkInfo.NumberFormatCheckFlag.Value)
            {
                expressResult = this.createFormula(ExpressionChecker.ExpressType.CheckNumeric, chkInfo.DefinitionExpression, ocrEdit);
                if (expressResult.HasInput && !checkNum(expressResult.Value))
                {
                    string result = string.Format(CheckExpResultMsg, expressResult.Value);
                    string errMsg = string.Format(DenshowCommon.Message.EP091, result);
                    setErrMessage(ocrEdit, errMsg);
                    return false;
                }
                return true;
            }

            return true;

        }

        /// <summary>
        /// 論理式を解析する
        /// </summary>
        /// <param name="expressType">論理演算式の種別</param>
        /// <param name="expression">論理演算式</param>
        /// <param name="ocrEdit">検査対象</param>
        /// <returns>解析した結果</returns>
        private FormulaResult createFormula(ExpressionChecker.ExpressType expressType, string expression, OcrEdit ocrEdit)
        {
            FormulaResult result = new FormulaResult();
            ExpressionChecker expressChecker = new ExpressionChecker(expression, expressType,
                    new ExpressionChecker.GetValueHandler(groupId =>
                    {
                        return this.getGroupValue(ocrEdit.PageNo, ocrEdit.ClId, groupId);
                    }));
            try
            {
                result.Value = expressChecker.Compute();
                result.HasInput = expressChecker.HasInput;
                return result;
            }
            catch (Exception)
            {
                //エラーの場合NULLで設定する
                result.Value = null;
                result.HasInput = expressChecker.HasInput;
                return result;
            }
        }

        /// <summary>
        /// 日付形式検査
        /// </summary>
        /// <param name="date">対象文字列</param>
        /// <returns>エラー有無</returns>
        /// <remarks>
        /// 空値は許可されない、呼び出す前にチェックしてください
        /// </remarks>
        private bool checkDate(string date)
        {
            DateTime dt;
            if (DateTime.TryParse(date, out dt))
            {
                return true;
            }
            //yyyyMMdd形式対応
            string[] formats = { "yyyyMMdd" };//サポート形式拡張は可能
            return DateTime.TryParseExact(date, formats, null, DateTimeStyles.AllowWhiteSpaces, out dt);

        }
        /// <summary>
        /// 日付データへ変換する
        /// </summary>
        /// <param name="date">対象文字列</param>
        /// <returns>日付データ</returns>
        private DateTime? getDateValue(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return null;
            }
            DateTime dt;
            if (DateTime.TryParse(date, out dt))
            {
                return dt;
            }
            //yyyyMMdd形式対応
            string[] formats = { "yyyyMMdd" };//サポート形式拡張は可能
            if (DateTime.TryParseExact(date, formats, null, DateTimeStyles.AllowWhiteSpaces, out dt))
            {
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 時刻形式検査
        /// </summary>
        /// <param name="time">対象文字列</param>
        /// <returns>エラー有無</returns>
        /// <remarks>
        /// 空値は許可されない、呼び出す前にチェックしてください
        /// </remarks>
        private bool checkTime(string time)
        {
            DateTime dt;
            if (DateTime.TryParse(time, out dt))
            {
                return true;
            }
            string[] formats = { "HHmm", "HHmmss" };//サポート形式拡張は可能
            return DateTime.TryParseExact(time, formats, null, DateTimeStyles.AllowWhiteSpaces, out dt);
        }

        /// <summary>
        /// 時刻データへ変換する
        /// </summary>
        /// <param name="time">対象文字列</param>
        /// <returns>日付データ</returns>
        private DateTime? getTimeValue(string time)
        {
            if (string.IsNullOrEmpty(time))
            {
                return null;
            }
            DateTime dt;
            if (DateTime.TryParse(time, out dt))
            {
                return dt;
            }
            string[] formats = { "HHmm", "HHmmss" };//サポート形式拡張は可能
            if (DateTime.TryParseExact(time, formats, null, DateTimeStyles.AllowWhiteSpaces, out dt))
            {
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 数値形式検査
        /// </summary>
        /// <param name="num">対象文字列</param>
        /// <returns>エラー有無</returns>
        private bool checkNum(string num)
        {
            decimal no = 0;
            return decimal.TryParse(num, out no);
        }


        /// <summary>
        /// 数値形式へ変換
        /// </summary>
        /// <param name="num">対象文字列</param>
        /// <returns>数値データ</returns>
        private int? getNumValue(string num)
        {
            int retVal = 0;
            if (int.TryParse(num, out retVal))
            {
                return retVal;
            }
            return null;
        }
        /// <summary>
        /// 型検査
        /// </summary>
        /// <param name="chkInfo">検査情報</param>
        /// <param name="ocrEdit">検査対象</param>
        private bool checkDataType(ChecklistInfo chkInfo, OcrEdit ocrEdit)
        {
            if (string.IsNullOrEmpty(ocrEdit.CorrectedString))
            {
                return true;
            }

            if (chkInfo.DataType == Definition.DataType.Numeric)
            {
                // 数値形式検査
                if (!checkNum(ocrEdit.CorrectedString))
                {
                    setErrMessage(ocrEdit, DenshowCommon.Message.EP084);
                    return false;
                }
            }

            if (chkInfo.DataType == Definition.DataType.Date)
            {
                // 日付形式検査
                if (!checkDate(ocrEdit.CorrectedString))
                {
                    setErrMessage(ocrEdit, DenshowCommon.Message.EP085);
                    return false;
                }
            }

            if (chkInfo.DataType == Definition.DataType.Time)
            {
                // 時刻形式検査
                if (!checkTime(ocrEdit.CorrectedString))
                {
                    setErrMessage(ocrEdit, DenshowCommon.Message.EP086);
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// マスタ参照検査
        /// </summary>
        /// <param name="chkInfo">検査情報</param>
        /// <param name="ocrEdit">検査対象</param>
        private bool checkMasterReference(ChecklistInfo chkInfo, OcrEdit ocrEdit)
        {
            if (!ocrEdit.MasterReferenceFlag)
            {
                return true;
            }
            //条件項目のコレクション
            List<OcrEdit> conditionItemList = new List<OcrEdit>();
            try
            {
                //関連するマスタ参照設定を取得する
                List<MasterReference> conditions = this.GetMasterReference(ocrEdit);
                //マスタ参照コントロールのインスタンスを生成する
                MasterReferenceControl masterCtrl = new MasterReferenceControl();
                //参照値を取得する
                string referValue = masterCtrl.GetReference(chkInfo, conditions,
                    //グループ項目の値を取得するデリゲートを渡す
                         new MasterReferenceControl.GetValueHandler((clId, groupId) =>
                         {
                             OcrEdit targetItem = this.getEditItem(ocrEdit.PageNo, clId, groupId);
                             if (!conditionItemList.Contains(targetItem))
                             {
                                 conditionItemList.Add(targetItem);
                             }
                             return getValueForSql(targetItem);
                         })
                     );
                //マスタ参照値を設定する
                ocrEdit.CorrectedString = referValue;
                ocrEdit.changeFlag = true;
                return true;
            }
            catch (DenshowBusinessException ex)
            {
                if (conditionItemList.Count > 0)
                {
                    //条件項目がある場合、条件項目にエラーメッセージを設定する
                    foreach (OcrEdit editItem in conditionItemList)
                    {
                        setErrMessage(editItem, ex.Message);
                    }
                }
                else
                {
                   //条件項目がない場合、対象項目にエラーメッセージを設定する
                   setErrMessage(ocrEdit, ex.Message);
                }
                return false;
            }
        }
        /// <summary>
        /// SQL検索用項目の値を取得する
        /// </summary>
        /// <returns></returns>
        private string getValueForSql(OcrEdit item)
        {
            switch (item.DataType)
            {
                case Definition.DataType.Numeric:
                    //数値型
                    int? intVal = this.getNumValue(item.CorrectedString);
                    if (intVal.HasValue)
                    {
                        return intVal.Value.ToString();
                    }
                    return item.CorrectedString;
                case Definition.DataType.Date:
                    //日付型
                    DateTime? dateVal = getDateValue(item.CorrectedString);
                    if (dateVal.HasValue)
                    {
                        return dateVal.Value.ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        return item.CorrectedString;
                    }
                case Definition.DataType.Time:
                    //時間型
                    DateTime? timeVal = getTimeValue(item.CorrectedString);
                    if (timeVal.HasValue)
                    {
                        return timeVal.Value.ToString("HH:mm");
                    }
                    else
                    {
                        return item.CorrectedString;
                    }
                default:
                    //文字型
                    return item.CorrectedString;
            }
        }

        #endregion

        #region エラーメッセージ
        /// <summary>
        /// エラーメッセージを設定する
        /// </summary>
        /// <param name="ocrEdit">検査対象</param>
        /// <param name="errMessage">エラーメッセージ</param>
        private void setErrMessage(OcrEdit ocrEdit, string errMessage)
        {
            if (string.IsNullOrEmpty(ocrEdit.ErrMessage))
            {
                ocrEdit.ErrMessage = errMessage;

            }
            else
            {
                ocrEdit.ErrMessage += Environment.NewLine;
                ocrEdit.ErrMessage += errMessage;
            }
        }
        #endregion

        #endregion

        #region public method

        /// <summary>
        /// 画面から渡された情報をもとに内容のチェックを行う
        /// </summary>
        /// <returns>描画する情報</returns>
        public List<OcrEdit> ReCheck()
        {

            // 検査対象のなる項目を取得する
            List<OcrEdit> checkOcrEditList = this.ocrEditList.Where(x => x.IsCheckItem).ToList();
            //すべてエラーメッセージをクリアする
            foreach (OcrEdit item in checkOcrEditList)
            {
                item.ErrMessage = string.Empty;
            }
            //検査を行う
            foreach (OcrEdit item in checkOcrEditList)
            {
                //項目に該当するチェックリスト設計情報を取得する
                ChecklistInfo checklistInfo = this.getChecklistInfo(item);
                // マスタ参照検査
                if (!this.checkMasterReference(checklistInfo, item))
                {
                    continue;
                }

                // 未記入検査
                if (!this.checkBlank(checklistInfo, item))
                {
                    continue;
                }

                // 型検査
                if (!this.checkDataType(checklistInfo, item))
                {
                    continue;
                }

                // 桁数検査
                if (!this.checkDigit(checklistInfo, item))
                {
                    continue;
                }

                // チェックサム
                if (!checkSum(checklistInfo, item))
                {
                    continue;
                }

                //範囲チェック
                if (!this.checkRange(checklistInfo, item))
                {
                    continue;
                }

                // 論理演算検査
                if (!this.checkLogicalOperation(checklistInfo, item))
                {
                    continue;
                }

                // OMR範囲検査
                if (!this.checkOmrRange(checklistInfo, item))
                {
                    continue;
                }
            }

            return this.ocrEditList;
        }



        #endregion


    }
}
