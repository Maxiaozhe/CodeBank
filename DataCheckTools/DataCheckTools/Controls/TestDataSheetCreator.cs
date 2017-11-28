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
using Excel = Microsoft.Office.Interop.Excel;

namespace Rex.Tools.Test.DataCheck.Controls
{
    /// <summary>
    /// テストデータ作成用EXCELファイルを作成
    /// </summary>
    public class TestDataSheetCreator : ProgressReporter
    {
        private const int STRAT_ROW = 2;

        public TestDataSheetCreator(ReportHandler reportHandler)
            : base(reportHandler)
        {

        }

  
        public void CreateDBInitData(string[] sheetNames, bool isTarget)
        {
            DataKind kind = isTarget ? DataKind.LiveInitData : DataKind.SeedInitData;
            using (ExcelAccessor xlsAdo = new ExcelAccessor(Config.GetTransferSettingFile(isTarget)))
            {
                //テーブル一覧取得
                foreach (string sheetName in sheetNames)
                {
                    using (ExcelHelp xls = new ExcelHelp(Config.TemplateFile))
                    {
                        xls.BeginUpdate();
                        //接続文字列設定
                        string connStr = isTarget ? Config.TargetDbConnection : Config.SourceDbConnection;
                        string adoConnstr = ChangeConnectStringForADO(connStr);
                        Excel.Worksheet settingSheet =  xls.WorkBook.Sheets["設定"];
                        xls.WriteValue(settingSheet, 1, 2, adoConnstr);

                        //目次を取得
                        Excel.Worksheet indexSheet = xls.WorkBook.Sheets["目次"];
                        int rowNo = 2;
                        base.Report("テーブル一覧を取得しています");
                        DataTable tableList = GetSettingTableList(xlsAdo, sheetName);
                        //移行元データシート作成
                        base.SetStep(tableList.Rows.Count, "データシートを作成しています");
                        foreach (DataRow row in tableList.Rows)
                        {
                            DataTableInfo tabInfo = new DataTableInfo(row);
                            CreateDataSheet(xls, tabInfo, isTarget);
                            //目次作成
                            xls.WriteValue(indexSheet, rowNo, 1, tabInfo.DisplayName);
                            xls.WriteValue(indexSheet, rowNo, 2, tabInfo.TableName);
                            xls.WriteValue(indexSheet, rowNo, 4, tabInfo.SheetName);
                            //リンク追加
                            Excel.Range anchor = xls.GetRange(indexSheet, 1, 1, rowNo, rowNo);
                            indexSheet.Hyperlinks.Add(Anchor: anchor, Address: "", SubAddress: tabInfo.TableName, TextToDisplay: tabInfo.DisplayName);
                            rowNo++;
                            base.ReportStep("{0}\n{1}", tabInfo.DisplayName, tabInfo.TableName);
                        }

                        xls.AddListObject(indexSheet, 1, rowNo, 4, "Index");
                        indexSheet.Columns.AutoFit();
                        indexSheet.Columns["D:D"].EntireColumn.Hidden = true;
                        indexSheet.Select();
                        base.Report("「{0}」のデータシートを保存しています", sheetName);
                        xls.EndUpdate();
                        xls.Save(Config.GetDataSheetSavePath(sheetName), Excel.XlFileFormat.xlOpenXMLWorkbookMacroEnabled);
                    }
                }
            }
        }

        private string ChangeConnectStringForADO(string connectString)
        {
            //Driver={SQL Server}; Server=192.168.137.163; Uid=sa; Pwd=p; Database=Live06;
            //Data Source=192.168.137.163;Initial Catalog=SeedDB;Persist Security Info=True;User ID=sa;Password=p;
            string pattern = @"(?<name>[^;\=]+)=(?<value>[^;\=]+);{0,1}";
            Regex regex = new Regex(pattern);
            string adoConn= regex.Replace(connectString,new MatchEvaluator(match=>{
               string name = match.Groups["name"].Value;
               string value = match.Groups["value"].Value;
               switch (name.Trim().ToLower())
               {
                   case "data source":
                       return "Server=" + value +";" ;
                   case "initial catalog":
                       return "Database=" + value + ";";
                   case "user id":
                       return "Uid=" + value + ";";
                   case "password":
                       return "Pwd=" + value + ";";
                   default:
                       return string.Empty;
               }
            }));
            return "Driver={SQL Server};" + adoConn;
        }

        private void CreateDataSheet(ExcelHelp xls, DataTableInfo tableInfo, bool isTarget)
        {
            DatabaseAcsesser dba = new DatabaseAcsesser();

            DatabaseAcsesser.DbConnections connType = isTarget ? DatabaseAcsesser.DbConnections.TargetDbConnection
                                                               : DatabaseAcsesser.DbConnections.SourceDbConnection;
            TableLayoutInfo info = dba.GetTableLayout(connType, tableInfo.TableName);
            Excel.Worksheet templateSheet = xls.WorkBook.Sheets["Template"];
            Excel.Worksheet sheet = xls.CreateSheet(tableInfo.SheetName, templateSheet);
            int colIndex = 0;
            xls.WriteValue(sheet, 1, 2, info.TableName);
            foreach (ColumnInfo column in info.Columns)
            {
                colIndex++;
                xls.WriteValue(sheet, STRAT_ROW, colIndex, column.ColumnName);
                if (!string.IsNullOrEmpty(column.DisplayName))
                {
                    string comment = column.DisplayName + "\n" + column.GetSqlType();
                    sheet.Range[xls.GetColumnName(colIndex, STRAT_ROW)].AddComment(comment);
                }
                if (column.IsPrimaryKey)
                {
                    Excel.Range cell = sheet.Range[xls.GetColumnName(colIndex, STRAT_ROW)];
                    cell.Font.Color = Excel.XlRgbColor.rgbRed;
                }
            }
            xls.AddListObject(sheet, STRAT_ROW, STRAT_ROW + 1, colIndex, tableInfo.TableName);
            SetColumnFormat(info, sheet);
            sheet.Columns.AutoFit();
            sheet.Tab.Color = isTarget ? Excel.XlRgbColor.rgbBlue : Excel.XlRgbColor.rgbRed;
        }

        /// <summary>
        /// テーブル列の書式を設定する
        /// </summary>
        /// <param name="info"></param>
        /// <param name="sheet"></param>
        private void SetColumnFormat(TableLayoutInfo info, Excel.Worksheet sheet)
        {
            string rangeName;
            foreach (ColumnInfo column in info.Columns)
            {
                switch (column.DataType)
                {
                    case "datetime":
                        rangeName=string.Format("{0}[{1}]",info.TableName,column.ColumnName);
                        sheet.Range[rangeName].NumberFormat = "yyyy/MM/dd HH:mm:ss";
                        break;
                    case "nvarchar":
                    case "varchar":
                    case "char":
                         rangeName=string.Format("{0}[{1}]",info.TableName,column.ColumnName);
                        sheet.Range[rangeName].NumberFormat = "@";
                        break;
                    default:
                        break;
                }
            }
        }



        private DataTable GetSettingTableList(ExcelAccessor xlsAdo, string sheetName)
        {
            string sql = "Select * from [" + sheetName + "$] where [No] IS NOT NULL";
            return xlsAdo.GetTableData("tableList", null, sql);
        }
    }
}
