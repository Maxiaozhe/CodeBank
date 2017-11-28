using Rex.Tools.Test.DataCheck.Common;
using Rex.Tools.Test.DataCheck.Entity;
using Rex.Tools.Test.DataCheck.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Rex.Tools.Test.DataCheck.Controls
{
    public class TestDataChecker : ProgressReporter
    {
        #region Const
        private const string REPORT_SHEET_NAME = "移行データ確認結果報告";
        private const int STRAT_ROW = 3;
        #endregion
        #region Fields
        private ExcelHelp xlsReport;
        private int currentRow;
        /// <summary>
        /// 計画Noコレクション
        /// </summary>
        private Dictionary<string, string> _productionPlanNos;
        /// <summary>
        /// 稼動Noコレクション
        /// </summary>
        private Dictionary<string, string> _operationPlanNos;
        #endregion

        public TestDataChecker(ReportHandler reportHandler)
            : base(reportHandler)
        {
            this._productionPlanNos = new Dictionary<string, string>();
            this._operationPlanNos = new Dictionary<string, string>();
        }

        public void CheckDatas(string filePath, string exportFolder)
        {
            base.Report("チェックテーブル一覧を取得しています");
            if (string.IsNullOrEmpty(exportFolder)|| !System.IO.Directory.Exists(exportFolder))
            {
                exportFolder = Config.ReportExportFolder;
            }
            using (this.xlsReport = new ExcelHelp(Config.ReportTemplateFile))
            {
                this.currentRow = STRAT_ROW;
                using (ExcelAccessor xlsAdo = new ExcelAccessor(filePath))
                {
                    DataTable dtt = GetCheckTableList(xlsAdo);
                    base.SetStep(dtt.Rows.Count, "対象テーブルをチェックしています");
                    foreach (DataRow row in dtt.Rows)
                    {
                        DataTableInfo tabInfo = new DataTableInfo(row);
                        CheckExpectData(xlsAdo, tabInfo);
                        base.ReportStep("{0}\n{1}", tabInfo.DisplayName, tabInfo.TableName);
                    }
                }
                base.Report("チェック結果報告を出力しています。");
                //枠設定
                Excel.Worksheet sheet = this.xlsReport.WorkBook.Sheets[REPORT_SHEET_NAME];
                this.xlsReport.AddListObject(sheet, 2, currentRow, 5, "ERRORLIST");
                //報告ファイルを保存する
                string reportFile = "DataCheckReport_" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".xlsx";
                reportFile = System.IO.Path.Combine(exportFolder, reportFile);
                this.xlsReport.Save(reportFile);
            }
        }

        private DataTable GetCheckTableList(ExcelAccessor xlsAdo)
        {
            string sheetName = "目次";
            string sql = "Select * from [" + sheetName + "$]";
            return xlsAdo.GetTableData("TableIndex", null, sql);
        }

        private void CheckExpectData(ExcelAccessor xlsAdo, DataTableInfo info)
        {
            try
            {
                DatabaseAcsesser dbAdo = new DatabaseAcsesser();
                DataTable dttResult = dbAdo.GetResultData(info.TableName);
                DataTable dttSchema = dttResult.Clone();

                DataTable dttExpect = xlsAdo.GetTableData(info.SheetName, info.TableName, dttSchema, 2, Config.MaxDataCount + 2);
                //データ比較する
                DiffDataSouce(info, dttExpect, dttResult);
            }
            catch (Exception ex)
            {
                Logging.Exception("", ex);
                throw ex;
            }
        }

        private void DiffDataSouce(DataTableInfo info, DataTable dttExpect, DataTable dttResult)
        {
            int diffCount = 0;
            int addedCount = 0;
            int losedCount = 0;

            //変換処理定義より、データを変換する
            ChangeDataByCheckPattern(info.TableName, dttExpect, true);
            ChangeDataByCheckPattern(info.TableName, dttResult, false);

            //期待より多い行および差異あり行を抽出
            DataTable dttCompare = dttExpect.Copy();
            DataTable dttTarget = dttResult.Copy();
            foreach (DataRow row in dttTarget.Rows)
            {
                row.SetAdded();
            }
            //差異あり行を抽出
            dttCompare.Merge(dttTarget, false);
            var changesRows = dttCompare.AsEnumerable().Where(row =>
            {
                return (row.RowState == DataRowState.Modified && IsModified(row));
            });
            diffCount = changesRows.Count();
            //期待よりたり多い行を抽出
            var addedRows = dttCompare.AsEnumerable().Where(row => row.RowState == DataRowState.Added);
            addedCount = addedRows.Count();
            //期待よりたりない行を抽出
            dttCompare = dttResult.Copy();
            dttTarget = dttExpect.Copy();
            foreach (DataRow row in dttTarget.Rows)
            {
                row.SetAdded();
            }
            dttCompare.Merge(dttTarget, false);
            var losedRows = dttCompare.AsEnumerable().Where(row => row.RowState == DataRowState.Added);
            losedCount = losedRows.Count();
            //報告
            Excel.Worksheet sheet = this.xlsReport.WorkBook.Sheets[REPORT_SHEET_NAME];
            //テーブル名
            this.xlsReport.WriteValue(sheet, this.currentRow, 1, info.DisplayName);
            //物理名
            this.xlsReport.WriteValue(sheet, this.currentRow, 2, info.TableName);
            //期待より多い件数
            this.xlsReport.WriteValue(sheet, this.currentRow, 3, addedCount.ToString());
            //期待より少ない件数
            this.xlsReport.WriteValue(sheet, this.currentRow, 4, losedCount.ToString());
            //差異あり
            this.xlsReport.WriteValue(sheet, this.currentRow, 5, diffCount.ToString());
            this.currentRow++;
            //報告詳細
            if (addedCount == 0 && losedCount == 0 && diffCount == 0)
            {
                return;
            }
            Excel.Worksheet detailSheet = this.xlsReport.CreateSheet(info.DisplayName);
            int colIndex = 1;
            int rowIndex = 1;
            int dataCount = 0;
            //テーブルヘッダ
            this.xlsReport.WriteValue(detailSheet, rowIndex, colIndex, "差異");
            foreach (DataColumn column in dttExpect.Columns)
            {
                colIndex++;
                this.xlsReport.WriteValue(detailSheet, rowIndex, colIndex, column.ColumnName);
            }
            //差異あり行
            dataCount = 0;
            foreach (DataRow row in changesRows)
            {
                rowIndex++;
                dataCount++;
                if (dataCount > 100)
                {
                    this.xlsReport.WriteValue(detailSheet, rowIndex, 1, "件数多過ぎ...");
                    break;
                }
                this.xlsReport.WriteValue(detailSheet, rowIndex, 1, "差異あり");
                //差異行出力
                WriteDiffRow(detailSheet, row, 2, rowIndex);
            }
            //期待より多い行
            dataCount = 0;
            foreach (DataRow row in addedRows)
            {
                rowIndex++;
                dataCount++;
                if (dataCount > 100)
                {
                    this.xlsReport.WriteValue(detailSheet, rowIndex, 1, "件数多過ぎ...");
                    break;
                }
                this.xlsReport.WriteValue(detailSheet, rowIndex, 1, "期待より多い");
                //差異行出力
                xlsReport.WriteValues(detailSheet, row, rowIndex, 2);
            }
            //期待よりたりない行
            dataCount = 0;
            foreach (DataRow row in losedRows)
            {
                rowIndex++;
                dataCount++;
                if (dataCount > 100)
                {
                    this.xlsReport.WriteValue(detailSheet, rowIndex, 1, "件数多過ぎ...");
                    break;
                }
                this.xlsReport.WriteValue(detailSheet, rowIndex, 1, "期待より足りない");
                //差異行出力
                this.xlsReport.WriteValues(detailSheet, row, rowIndex, 2);
            }
            //リンク追加
            Excel.Range anchor = this.xlsReport.GetRange(sheet, 1, 1, this.currentRow - 1, this.currentRow - 1);
            sheet.Hyperlinks.Add(Anchor: anchor, Address: "", SubAddress: info.TableName, TextToDisplay: info.DisplayName);
            this.xlsReport.AddListObject(detailSheet, 1, rowIndex, colIndex, info.TableName);
            //フォーマット設定
            SetColumnFormat(dttResult, detailSheet);
        }
        /// <summary>
        /// 差異行を出力する
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="data"></param>
        /// <param name="startCol"></param>
        /// <param name="startRow"></param>
        private void WriteDiffRow(Excel.Worksheet sheet, DataRow data, int startCol, int startRow)
        {
            this.xlsReport.WriteValues(sheet, data, startRow, startCol);
            for (int i = 0; i < data.Table.Columns.Count; i++)
            {
                var original = data[i, DataRowVersion.Original];
                var current = data[i, DataRowVersion.Current];
                if (!original.Equals(current))
                {
                    //赤表示
                    Excel.Range cell = sheet.Cells[startRow, startCol + i];
                    cell.Font.Color = Excel.XlRgbColor.rgbRed;
                    string orgVal = original is DBNull ? "<null>" : original.ToString();
                    cell.AddComment("期待結果:" + orgVal);
                }
            }

        }

        /// <summary>
        /// テーブル列の書式を設定する
        /// </summary>
        /// <param name="info"></param>
        /// <param name="sheet"></param>
        private void SetColumnFormat(DataTable dtt, Excel.Worksheet sheet)
        {
            string rangeName;
            foreach (DataColumn column in dtt.Columns)
            {
                string TypeName = column.DataType.Name.ToLower();
                switch (TypeName)
                {
                    case "datetime":
                        rangeName = string.Format("{0}[{1}]", dtt.TableName, column.ColumnName);
                        sheet.Range[rangeName].NumberFormat = "yyyy/MM/dd HH:mm:ss";
                        break;
                    case "string":
                        rangeName = string.Format("{0}[{1}]", dtt.TableName, column.ColumnName);
                        sheet.Range[rangeName].NumberFormat = "@";
                        break;
                    default:
                        break;
                }
            }
        }


        private bool CheckRowState(DataRow row)
        {
            var state = row.RowState;
            Logging.Error(row.RowState.ToString());
            switch (row.RowState)
            {
                case DataRowState.Added:
                    return true;
                case DataRowState.Modified:
                    return IsModified(row);
                default:
                    return false;
            }
        }

        private bool IsModified(DataRow row)
        {
            for (int i = 0; i < row.Table.Columns.Count; i++)
            {
                var original = row[i, DataRowVersion.Original];
                if (original.Equals("<EMPTY>"))
                {
                    original = string.Empty;
                }
                else if (original.Equals("NULL"))
                {
                    original = DBNull.Value;
                }
                var current = row[i, DataRowVersion.Current];
                if (!original.Equals(current))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// データ変換処理の定義通り、データソースを変換する
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dttSource"></param>
        /// <param name="isExpectData"></param>
        private void ChangeDataByCheckPattern(string tableName, DataTable dttSource, bool isExpectData)
        {
            string srcTableName = tableName.ToUpper();
            foreach (CheckInfoSet.CheckParttenRow partten in Config.CheckPartten)
            {
                DataProcessType changeType = (DataProcessType)Enum.Parse(typeof(DataProcessType), partten.ProcessType, true);
                ProcessTarget target = (ProcessTarget)Enum.Parse(typeof(ProcessTarget), partten.ProcessTarget, true);
                if (target != ProcessTarget.Both &&
                    ((target == ProcessTarget.ExpectData && isExpectData == false) || (target == ProcessTarget.ResultData && isExpectData)))
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(partten.TableName) && partten.TableName.ToUpper().Equals(srcTableName))
                {
                    //対象テーブルの場合、データ変換処理
                    ChangeDatas(dttSource, partten.ColumnName, changeType);
                }
                else if (!string.IsNullOrWhiteSpace(partten.ColumnName) && dttSource.Columns.Contains(partten.ColumnName))
                {
                    //対象列が存在する場合、データ変換処理
                    ChangeDatas(dttSource, partten.ColumnName, changeType);
                }
            }
        }

        /// <summary>
        /// 対象データテーブルのデータを変換する
        /// </summary>
        /// <param name="dttSource"></param>
        /// <param name="columnName"></param>
        /// <param name="changeType"></param>
        private void ChangeDatas(DataTable dttSource, string columnName, DataProcessType changeType)
        {
            switch (changeType)
            {
                case DataProcessType.PRODUCTION_PLAN_NO:
                    //新生産計画NOへ変換
                    ChangeProductionPlanNo(dttSource, columnName);
                    break;
                case DataProcessType.OPERATION_PLAN_NO:
                    //新稼動計画NOへ変換
                    ChangeOperationPlanNo(dttSource, columnName);
                    break;
                case DataProcessType.RESET:
                    //自動採番列の値をリセットする
                    ResetAutoNumber(dttSource, columnName);
                    break;
                case DataProcessType.SKIP:
                    //比較しない列を無視する
                    RemoveSkipColumns(dttSource, columnName);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 生産計画No変換
        /// </summary>
        /// <param name="dttSource"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private void ChangeProductionPlanNo(DataTable dttSource, string columnName)
        {
            string oldNo = "";
            string newNo = "";
            foreach (DataRow row in dttSource.Rows)
            {
                oldNo = Utility.DBToString(row[columnName]);
                if (string.IsNullOrEmpty(oldNo))
                {
                    continue;
                }
                newNo = GetNewProductionNo(oldNo);
                if (!string.IsNullOrEmpty(newNo))
                {
                    row[columnName] = newNo;
                }
            }
            dttSource.AcceptChanges();
        }
        /// <summary>
        /// 稼動計画NO変換
        /// </summary>
        /// <param name="dttSource"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private void ChangeOperationPlanNo(DataTable dttSource, string columnName)
        {
            string oldNo = "";
            string newNo = "";
            foreach (DataRow row in dttSource.Rows)
            {
                oldNo = Utility.DBToString(row[columnName]);

                if (string.IsNullOrEmpty(oldNo) || !oldNo.Contains("|"))
                {
                    //旧の計画NOは空および"|"記号が含まれていない場合、無視する
                    continue;
                }
                newNo = GetNewOperationNo(oldNo);
                if (!string.IsNullOrEmpty(newNo))
                {
                    row[columnName] = newNo;
                }
            }
            dttSource.AcceptChanges();
        }
        /// <summary>
        /// 採番された新生産計画NOを取得する
        /// </summary>
        /// <param name="oldNo"></param>
        /// <returns></returns>
        private string GetNewProductionNo(string oldNo)
        {
            if (this._productionPlanNos.ContainsKey(oldNo))
            {
                return this._productionPlanNos[oldNo];
            }
            else
            {
                return GetNewProductionNoFromDb(oldNo);
            }
        }

        /// <summary>
        /// 採番された新稼動計画NOを取得する
        /// </summary>
        /// <param name="oldNo"></param>
        /// <returns></returns>
        private string GetNewOperationNo(string oldNo)
        {
            if (this._operationPlanNos.ContainsKey(oldNo))
            {
                return this._operationPlanNos[oldNo];
            }
            else
            {
                return GetNewOperationNoFromDb(oldNo);
            }
        }
        /// <summary>
        /// データベースから、採番された新生産計画NOを取得する
        /// </summary>
        /// <param name="oldNo"></param>
        /// <returns></returns>
        private string GetNewProductionNoFromDb(string oldNo)
        {
            DatabaseAcsesser dba = new DatabaseAcsesser();
            string planNo = dba.GetProductionPlanNo(oldNo);
            //コレクションに追加
            this._productionPlanNos.Add(oldNo, planNo);
            return planNo;
        }

        /// <summary>
        /// データベースから、採番された新稼動計画NOを取得する
        /// </summary>
        /// <param name="oldNo">旧稼動計画キー（設備コード + '|' + 稼動日）</param>
        /// <returns></returns>
        private string GetNewOperationNoFromDb(string oldNo)
        {
            string facilityCode = oldNo.Split('|')[0];
            string operationDate = oldNo.Split('|')[1];
            DatabaseAcsesser dba = new DatabaseAcsesser();
            string planNo = dba.GetOperationPlanNo(facilityCode, operationDate);
            //コレクションに追加
            this._operationPlanNos.Add(oldNo, planNo);
            return planNo;
        }

        /// <summary>
        /// 比較しない行を削除する
        /// </summary>
        /// <param name="dttSource"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private void RemoveSkipColumns(DataTable dttSource, string columnName)
        {
            if (dttSource.Columns.Contains(columnName))
            {
                dttSource.Columns.Remove(columnName);
            }
        }

        /// <summary>
        /// 自動採番列の番号を再作成する
        /// </summary>
        /// <param name="dttSource"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private void ResetAutoNumber(DataTable dttSource, string columnName)
        {
            StringBuilder sortColumns = new StringBuilder();
            int index = 0;
            foreach (DataColumn col in dttSource.Columns)
            {
                if (index > 0)
                {
                    sortColumns.Append(",");
                }
                sortColumns.Append(col.ColumnName);
                index++;
            }
            DataRow[] rows = dttSource.Select("", sortColumns.ToString());
            dttSource.BeginLoadData();
            if (dttSource.Columns[columnName].ReadOnly)
            {
                dttSource.Columns[columnName].ReadOnly = false;
            }
            for (int i = 0; i < rows.Length; i++)
            {
                rows[i][columnName] = i;
            }
            if (dttSource.Columns[columnName].ReadOnly)
            {
                dttSource.Columns[columnName].ReadOnly = true;
            }
            dttSource.EndLoadData();
            dttSource.AcceptChanges();

        }


    }
}
