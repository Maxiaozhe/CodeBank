using Rex.Tools.Test.DataCheck.Common;
using Rex.Tools.Test.DataCheck.Entity;
using Rex.Tools.Test.DataCheck.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace Rex.Tools.Test.DataCheck.Controls
{
    public class TableCreator : ProgressReporter
    {

        internal static class LiveLayoutInfo
        {
            internal const string TABLE_DISPLAY_NAME = "H5";
            internal const string TABLE_NAME = "R5";
            internal const int START_ROW = 10;
            internal const string COLUMN_NO = "A";
            internal const string COLUMN_NAME = "I";
            internal const string COLUMN_DISPLAY = "C";
            internal const string COLUMN_TYPE = "O";
            internal const string COLUMN_LENGTH = "Q";
            internal const string COLUMN_NULLABLE = "S";
            internal const string COLUMN_ISPRIMARY = "U";
            internal const string COLUMN_INDEX = "W";
            internal const string COLUMN_COMMENT = "Y";
        }
        internal static class SeedLayoutInfo
        {
            internal const string TABLE_DISPLAY_NAME = "J5";
            internal const string TABLE_NAME = "A5";
            internal const int START_ROW = 7;
            internal const string COLUMN_NO = "A";
            internal const string COLUMN_NAME = "B";
            internal const string COLUMN_DISPLAY = "G";
            internal const string COLUMN_DISPLAY2 = "I";
            internal const string COLUMN_TYPE = "M";
            internal const string COLUMN_LENGTH = "Q";
            internal const string COLUMN_SCALE = "S";
            internal const string COLUMN_NULLABLE = "U";
            internal const string COLUMN_PRIMARYINDEX = "AA";
            internal const string COLUMN_COMMENT = "AC";
        }


        public TableCreator(ReportHandler reportHandler)
            : base(reportHandler)
        {

        }


        public void CreateDBScript(TableCreateInfo info)
        {
            string outPutPath = System.IO.Path.ChangeExtension(info.LayoutFileName, "sql");
            Logging.OutputFileName = outPutPath;
            try
            {

                base.Report(Resource.StringTable.Messages.OpenDesignFile);
                using (ExcelHelp xls = new ExcelHelp(info.LayoutFileName))
                {
                    //int sheectCount = xls.WorkBook.Sheets.Count;
                    base.Report(Resource.StringTable.Messages.ReadingTableList);
                    System.Data.DataTable dttList = GetTableList( info.TableListSheetName);
                    base.SetStep(dttList.Rows.Count, Resource.StringTable.Messages.CreatingSqlScript);
                    foreach (System.Data.DataRow row in dttList.Rows)
                    {
                        DataTableInfo tbInfo = new DataTableInfo(row);
                        try
                        {
                            TableLayoutInfo tableInfo = ReadTableLayout(xls, tbInfo.SheetName, info.LayoutKind);
                            //Script出力
                            CreateSqlScript(info.Options, tableInfo);
                            ReportStep(Resource.StringTable.Messages.CreatedTableSqlScript, tableInfo.DisplayName, tableInfo.TableName);
                        }
                        catch (Exception ex)
                        {
                            Logging.WriteLine("/*");
                            Logging.WriteLine(Resource.StringTable.Messages.ScriptCreateFailed, tbInfo.SheetName, tbInfo.TableName);
                            Logging.Exception("", ex);
                            Logging.WriteLine("*/");
                        }

                    }
                    Report(Resource.StringTable.Messages.ProcessFinished);
                    xls.Close();
                }
            }
            finally
            {
                Logging.OutputFileName = "";
            }
        }

        public void CreateDBScript(LayoutType layout, string tableLayoutFile, ScriptOptions opt)
        {
            base.Report(Resource.StringTable.Messages.OpenDesignFile);
            using (ExcelHelp xls = new ExcelHelp(tableLayoutFile))
            {
                //int sheectCount = xls.WorkBook.Sheets.Count;
                base.Report(Resource.StringTable.Messages.ReadingTableList);
                System.Data.DataTable dttList = GetTableList(layout);
                //System.Data.DataTable dttList = GetTableList(xls,layout );
                base.SetStep(dttList.Rows.Count, Resource.StringTable.Messages.CreatingSqlScript);
                foreach (System.Data.DataRow row in dttList.Rows)
                {
                    string sheetName = Utility.DBToString(row["DisplayName"]);
                    string tabName = Utility.DBToString(row["TableName"]);
                    try
                    {
                        TableLayoutInfo tableInfo = ReadTableLayout(xls, sheetName, layout);
                        //Script出力
                        CreateSqlScript(opt, tableInfo);
                        ReportStep(Resource.StringTable.Messages.CreatedTableSqlScript, tableInfo.DisplayName, tableInfo.TableName);
                    }
                    catch (Exception ex)
                    {
                        Logging.WriteLine("/*");
                        Logging.WriteLine(Resource.StringTable.Messages.ScriptCreateFailed, sheetName, tabName);
                        Logging.Exception("", ex);
                        Logging.WriteLine("*/");
                    }

                }
                Report(Resource.StringTable.Messages.ProcessFinished);
                xls.Close();
            }
        }

        private TableLayoutInfo ReadTableLayout(ExcelHelp xls, string sheetName, LayoutType layout)
        {
            if (layout == LayoutType.Live)
            {
                return ReadLiveTableLayout(xls, sheetName);
            }
            else
            {
                return ReadSeedTableLayout(xls, sheetName);
            }

        }

        private TableLayoutInfo ReadLiveTableLayout(ExcelHelp xls, string sheetName)
        {

            Excel.Worksheet sheet = xls.WorkBook.Sheets[sheetName];
            string tableName = Utility.DBToString(sheet.Range[LiveLayoutInfo.TABLE_NAME].Value);
            TableLayoutInfo tableInfo = new TableLayoutInfo(tableName)
            {
                DisplayName = sheet.Range[LiveLayoutInfo.TABLE_DISPLAY_NAME].Value
            };
            //列作成
            int rowIndex = LiveLayoutInfo.START_ROW;
            string No = Utility.DBToString(sheet.Range[LiveLayoutInfo.COLUMN_NO + rowIndex].Value);
            int columnId = 0;
            while (!string.IsNullOrEmpty(No) && int.TryParse(No, out columnId))
            {
                //ColumnName
                ColumnInfo column = new ColumnInfo();
                column.ColumnId = columnId;
                column.ColumnName = Utility.DBToString(sheet.Range[LiveLayoutInfo.COLUMN_NAME + rowIndex].Value).Trim();
                column.DisplayName = Utility.DBToString(sheet.Range[LiveLayoutInfo.COLUMN_DISPLAY + rowIndex].Value).Trim();
                column.DataType = Utility.DBToString(sheet.Range[LiveLayoutInfo.COLUMN_TYPE + rowIndex].Value).Trim();
                //Length
                string lenVal = Utility.DBToString(sheet.Range[LiveLayoutInfo.COLUMN_LENGTH + rowIndex].Value).Trim();
                if (!string.IsNullOrWhiteSpace(lenVal))
                {
                    int length = 0;
                    if (int.TryParse(lenVal, out length))
                    {
                        column.Length = length;
                    }
                    else if (lenVal.Contains(","))
                    {
                        int num = 0;
                        string[] sect = lenVal.Split(',');
                        if (int.TryParse(sect[0], out num))
                        {
                            column.NumericPrecision = num;
                        }
                        if (int.TryParse(sect[1], out num))
                        {
                            column.NumericScale = num;
                        }
                    }
                    else
                    {
                        if (lenVal.ToLower().Equals("max"))
                        {
                            column.Length = -1;
                        }
                    }
                }
                //Nullable
                string nullable = Utility.DBToString(sheet.Range[LiveLayoutInfo.COLUMN_NULLABLE + rowIndex].Value);
                column.Nullable = (!string.IsNullOrWhiteSpace(nullable));
                //InPrimary
                string InPrimary = Utility.DBToString(sheet.Range[LiveLayoutInfo.COLUMN_ISPRIMARY + rowIndex].Value);
                column.IsPrimaryKey = (!string.IsNullOrWhiteSpace(InPrimary));
                //Index Key
                string indexNo = Utility.DBToString(sheet.Range[LiveLayoutInfo.COLUMN_INDEX + rowIndex].Value);
                int indexId = 0;
                if (!string.IsNullOrWhiteSpace(indexNo) && int.TryParse(indexNo, out indexId))
                {
                    column.IndexColumnId = indexId;
                }
                if (!string.IsNullOrWhiteSpace(column.ColumnName) && !string.IsNullOrWhiteSpace(column.DataType))
                {
                    tableInfo.Columns.Add(column);
                }
                else
                {
                    Logging.WriteLine("-- ERROR:: {0}-{1} 行:{2} {3}",
                        sheetName, tableInfo.TableName, No,
                        string.IsNullOrWhiteSpace(column.ColumnName) ? "列名なし" : "型なし");

                }
                //Comment
                column.Comment = Utility.DBToString(sheet.Range[LiveLayoutInfo.COLUMN_COMMENT + rowIndex].Value).Trim();
                rowIndex++;
                No = Utility.DBToString(sheet.Range[LiveLayoutInfo.COLUMN_NO + rowIndex].Value);
            }

            return tableInfo;
        }

        private TableLayoutInfo ReadSeedTableLayout(ExcelHelp xls, string sheetName)
        {

            Excel.Worksheet sheet = xls.WorkBook.Sheets[sheetName];
            string tableName = Utility.DBToString(sheet.Range[SeedLayoutInfo.TABLE_NAME].Value);
            TableLayoutInfo tableInfo = new TableLayoutInfo(tableName)
            {
                DisplayName = sheetName
            };

            //列作成
            int rowIndex = SeedLayoutInfo.START_ROW;
            int columnId = 0;
            string no = Utility.DBToString(sheet.Range[SeedLayoutInfo.COLUMN_NO + rowIndex].Value);
            string columnName = Utility.DBToString(sheet.Range[SeedLayoutInfo.COLUMN_NAME + rowIndex].Value).Trim();
            while (!string.IsNullOrEmpty(columnName) || !string.IsNullOrEmpty(no))
            {
                //ColumnName
                ColumnInfo column = new ColumnInfo();

                if (int.TryParse(no, out columnId))
                {
                    column.ColumnId = columnId;
                }
                column.ColumnName = columnName;
                string displayName = Utility.DBToString(sheet.Range[SeedLayoutInfo.COLUMN_DISPLAY + rowIndex].Value).Trim();
                if (sheet.Range[SeedLayoutInfo.COLUMN_DISPLAY + rowIndex].MergeCells == true)
                {
                    displayName = Utility.DBToString(sheet.Range[SeedLayoutInfo.COLUMN_DISPLAY + rowIndex].MergeArea[1, 1].Value);
                    string displayName2 = Utility.DBToString(sheet.Range[SeedLayoutInfo.COLUMN_DISPLAY2 + rowIndex].Value).Trim();
                    displayName = displayName + " " + displayName2;
                    displayName = displayName.Replace("\n", "");
                }
                column.DisplayName = displayName;
                column.DataType = Utility.DBToString(sheet.Range[SeedLayoutInfo.COLUMN_TYPE + rowIndex].Value).Trim();
                //Length
                string lenVal = Utility.DBToString(sheet.Range[SeedLayoutInfo.COLUMN_LENGTH + rowIndex].Value).Trim();
                if (!string.IsNullOrWhiteSpace(lenVal))
                {
                    int length = 0;
                    if (int.TryParse(lenVal, out length))
                    {
                        column.Length = length;
                    }
                    else
                    {
                        if (lenVal.ToLower().Equals("max"))
                        {
                            column.Length = -1;
                        }
                    }
                }
                //Scale
                string scaleVal = Utility.DBToString(sheet.Range[SeedLayoutInfo.COLUMN_SCALE + rowIndex].Value).Trim();
                if (!string.IsNullOrWhiteSpace(scaleVal))
                {
                    int scale = 0;
                    if (int.TryParse(lenVal, out scale))
                    {
                        column.NumericPrecision = column.Length;
                        column.NumericScale = scale;
                    }
                }
                //Nullable
                string nullable = Utility.DBToString(sheet.Range[SeedLayoutInfo.COLUMN_NULLABLE + rowIndex].Value);
                if (!string.IsNullOrWhiteSpace(nullable) && nullable.Equals("N"))
                {
                    column.Nullable = false;
                }
                else
                {
                    column.Nullable = true;
                }

                //Primary Key
                string indexNo = Utility.DBToString(sheet.Range[SeedLayoutInfo.COLUMN_PRIMARYINDEX + rowIndex].Value);
                int indexId = 0;
                if (!string.IsNullOrWhiteSpace(indexNo) && int.TryParse(indexNo, out indexId))
                {
                    column.IndexColumnId = indexId;
                }
                //InPrimary
                if (column.IndexColumnId > 0)
                {
                    column.IsPrimaryKey = true;
                }

                if (!string.IsNullOrWhiteSpace(column.ColumnName) && !string.IsNullOrWhiteSpace(column.DataType))
                {
                    tableInfo.Columns.Add(column);
                }
                //Comment
                column.Comment = Utility.DBToString(sheet.Range[SeedLayoutInfo.COLUMN_COMMENT + rowIndex].Value).Trim();
                rowIndex++;
                no = Utility.DBToString(sheet.Range[SeedLayoutInfo.COLUMN_NO + rowIndex].Value);
                columnName = Utility.DBToString(sheet.Range[SeedLayoutInfo.COLUMN_NAME + rowIndex].Value).Trim();

            }

            return tableInfo;
        }

        /// <summary>
        /// SQL Scriptを出力する
        /// </summary>
        /// <param name="opt"></param>
        /// <param name="tableInfo"></param>
        private void CreateSqlScript(ScriptOptions opt, TableLayoutInfo tableInfo)
        {
            //OutPut Start
            Logging.WriteLine(Resource.StringTable.Messages.SqlScriptStart, tableInfo.TableName, tableInfo.DisplayName);
            //Drop Description
            if ((opt & ScriptOptions.DropDropDescriptions) == ScriptOptions.DropDropDescriptions)
            {
                Logging.Write(tableInfo.GetDropDescriptionScript());
            }
            //Drop
            if ((opt & ScriptOptions.DropTables) == ScriptOptions.DropTables)
            {
                Logging.Write(tableInfo.GetDropScript());
            }
            //Create
            if ((opt & ScriptOptions.CreateTables) == ScriptOptions.CreateTables)
            {
                Logging.Write(tableInfo.GetCreateScript());
            }
            //Create Description
            if ((opt & ScriptOptions.CreateDropDescriptions) == ScriptOptions.CreateDropDescriptions)
            {
                Logging.Write(tableInfo.GetCreateDescriptionScript());
            }
        }

        private System.Data.DataTable GetTableList(LayoutType layoutType)
        {
            using (ExcelAccessor xlsAdo = new ExcelAccessor(Config.TemplateFile))
            {

                string sheetName = "";
                string tableName = "";
                switch (layoutType)
                {
                    case LayoutType.Live:
                        //sheetName = "テーブル一覧";
                        sheetName = "テーブル一覧２";
                        tableName = "TableIndex";
                        break;
                    default:
                        sheetName = "旧テーブル一覧";
                        tableName = "OldTableIndex";
                        break;
                }
                return xlsAdo.GetTableData(sheetName, tableName, null);
            }

        }

        private System.Data.DataTable GetTableList(string sheetName)
        {
            using (ExcelAccessor xlsAdo = new ExcelAccessor(Config.DbTableListSettingFile))
            {
                return xlsAdo.GetTableData(sheetName, "TableList", null);
            }

        }

        private System.Data.DataTable GetTableList(ExcelHelp xls, LayoutType layoutType)
        {

            string sheetName = "";
            string tableNameCol = "";
            string tableDisplayCol = "";
            string commentCol = "";
            int startRow = 0;
            switch (layoutType)
            {
                case LayoutType.Live:
                    sheetName = "テーブル一覧";
                    tableNameCol = "AJ";
                    tableDisplayCol = "J";
                    commentCol = "T";
                    startRow = 5;
                    break;
                default:
                    sheetName = "テーブル一覧（Live）";
                    tableNameCol = "F";
                    tableDisplayCol = "J";
                    commentCol = "S";
                    startRow = 5;
                    break;
            }
            return xls.GetTableData(sheetName,
                new string[] { tableNameCol, tableDisplayCol, commentCol },
                new string[] { "TableName", "DisplayName", "Comment" },
                startRow);

        }

    }

    public class TableCreateInfo
    {
        /// <summary>
        /// レイアウト種別
        /// </summary>
        public LayoutType LayoutKind
        {
            get;
            set;
        }
        /// <summary>
        /// DB設計書のファイル名
        /// </summary>
        public string LayoutFileName
        {
            get;
            set;
        }
        /// <summary>
        /// テーブル一覧のシート名
        /// </summary>
        public string TableListSheetName
        {
            get;
            set;
        }
        /// <summary>
        /// 作成オプション
        /// </summary>
        public ScriptOptions Options
        {
            get;
            set;
        }

    }
}
