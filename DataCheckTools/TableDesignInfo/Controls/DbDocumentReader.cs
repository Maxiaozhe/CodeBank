using Rex.Tools.Test.DataCheck.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDesignInfo.Common;
using TableDesignInfo.Entity;
using Excel = Microsoft.Office.Interop.Excel;

namespace TableDesignInfo.Controls
{
    /// <summary>
    /// SQLスクリプト作成オプション
    /// </summary>
    [Flags]
    public enum ScriptOptions
    {
        /// <summary>
        /// Drop Table作成
        /// </summary>
        DropTables = 2,
        /// <summary>
        /// テーブル説明文をドロップする
        /// </summary>
        DropDropDescriptions = 4,
        /// <summary>
        /// Create Table作成
        /// </summary>
        CreateTables = 8,
        /// <summary>
        /// テーブル説明文を作成
        /// </summary>
        CreateDropDescriptions = 16
    }

   public class DbDocumentReader
   {
        public void CreateDBScript(TableCreateInfo info)
        {
            string outPutPath = System.IO.Path.ChangeExtension(info.LayoutFileName, "sql");
            Logging.OutputFileName = outPutPath;
            try
            {

                using (ExcelHelp xls = new ExcelHelp(info.LayoutFileName))
                {
                    //int sheectCount = xls.WorkBook.Sheets.Count;
                    System.Data.DataTable dttList = GetTableList(xls, info.TemplateInfo);
                    foreach (System.Data.DataRow row in dttList.Rows)
                    {
                        DataTableInfo tbInfo = new DataTableInfo(row);
                        try
                        {
                            TableLayout tableInfo = ReadTableLayout(xls, tbInfo, info.TemplateInfo);
                            //Script出力
                            CreateSqlScript(info.Options, tableInfo);
                        }
                        catch (Exception ex)
                        {
                            Logging.WriteLine("/*");
                            Logging.WriteLine(Resources.StringTable.ScriptCreateFailed, tbInfo.SheetName, tbInfo.TableName);
                            Logging.Exception("", ex);
                            Logging.WriteLine("*/");
                        }

                    }
                    xls.Close();
                }
            }
            finally
            {
                Logging.OutputFileName = "";
            }
        }

   

        private TableLayout ReadTableLayout(ExcelHelp xls, DataTableInfo tabInfo, TemplateInfo.DocumentTemplateRow LiveLayoutInfo)
        {

            Excel.Worksheet sheet = xls.WorkBook.Sheets[tabInfo.SheetName];
            string tableName = Utility.DBToString(sheet.Range[LiveLayoutInfo.TableName].Value);
            TableLayout tableInfo = new TableLayout(tableName)
            {
                DisplayName = sheet.Range[LiveLayoutInfo.TableDisplayName].Value,
                Comment = tabInfo.Comment
            };
            //列作成
            int rowIndex = LiveLayoutInfo.ColumnStartRow;
            string No = Utility.DBToString(sheet.Range[LiveLayoutInfo.ColumnNo + rowIndex].Value);
            int columnId = 0;
            while (!string.IsNullOrEmpty(No) && int.TryParse(No, out columnId))
            {
                //ColumnName
                ColumnInfo column = new ColumnInfo();
                column.ColumnId = columnId;
                column.ColumnName = Utility.DBToString(sheet.Range[LiveLayoutInfo.ColumnName + rowIndex].Value).Trim();
                column.DisplayName = Utility.DBToString(sheet.Range[LiveLayoutInfo.ColumnDisplayName + rowIndex].Value).Trim();
                column.DataType = Utility.DBToString(sheet.Range[LiveLayoutInfo.ColumnDataType + rowIndex].Value).Trim();
                //Length
                string lenVal = Utility.DBToString(sheet.Range[LiveLayoutInfo.ColumnDataLength + rowIndex].Value).Trim();
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
                string nullable = Utility.DBToString(sheet.Range[LiveLayoutInfo.ColumnNullable + rowIndex].Value);
                column.Nullable = (!string.IsNullOrWhiteSpace(nullable));
                //InPrimary
                string InPrimary = Utility.DBToString(sheet.Range[LiveLayoutInfo.ColumnIsPrimaryKey + rowIndex].Value);
                column.IsPrimaryKey = (!string.IsNullOrWhiteSpace(InPrimary));
                //Index Key
                string indexNo = Utility.DBToString(sheet.Range[LiveLayoutInfo.ColumnIndex + rowIndex].Value);
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
                        tabInfo.SheetName, tableInfo.TableName, No,
                        string.IsNullOrWhiteSpace(column.ColumnName) ? "列名なし" : "型なし");

                }
                //Comment
                column.Comment = Utility.DBToString(sheet.Range[LiveLayoutInfo.ColumnComment + rowIndex].Value).Trim();
                rowIndex++;
                No = Utility.DBToString(sheet.Range[LiveLayoutInfo.ColumnNo + rowIndex].Value);
            }

            return tableInfo;
        }

    
        /// <summary>
        /// SQL Scriptを出力する
        /// </summary>
        /// <param name="opt"></param>
        /// <param name="tableInfo"></param>
        private void CreateSqlScript(ScriptOptions opt, TableLayout tableInfo)
        {
            //OutPut Start
            Logging.WriteLine(Resources.StringTable.SqlScriptStart, tableInfo.TableName, tableInfo.DisplayName);
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

  

        private System.Data.DataTable GetTableList(ExcelHelp xls, TemplateInfo.DocumentTemplateRow layoutInfo)
        {

            string sheetName = layoutInfo.IndexSheet;
            Excel.Worksheet sheet = xls.WorkBook.Sheets[sheetName];
            string[] columnNames = { "TableName", "DisplayName", "Comment","SheetName" };
            string[] columns = { layoutInfo.IndexSheet_TableName, layoutInfo.IndexSheet_DisplayName, layoutInfo.IndexSheet_Summary,layoutInfo.IndexSheet_Link };

            System.Data.DataTable dttSource = new System.Data.DataTable();
            foreach (string column in columnNames)
            {
                dttSource.Columns.Add(column, typeof(string));
            }
            int maxRow = sheet.UsedRange.Rows.Count;

            for (int r = layoutInfo.IndexSheet_StartRow; r <= maxRow; r++)
            {
                DataRow row = dttSource.NewRow();
                for (int c = 0; c < columns.Length; c++)
                {
                    if (columnNames[c].Equals("SheetName"))
                    {
                       if( sheet.Range[columns[c] + r].Hyperlinks.Count > 0)
                        {
                            string link = sheet.Range[columns[c] + r].Hyperlinks[1].SubAddress;
                            if(!string.IsNullOrEmpty(link) && link.Contains("!"))
                            {
                                link = link.Substring(0, link.IndexOf("!"));
                                link = link.Replace("'", "");
                            }
                            row[c] = string.IsNullOrEmpty(link) ? sheet.Range[columns[c] + r].Value : link;
                        }
                    }
                    else
                    {
                        row[c] = sheet.Range[columns[c] + r].Value;
                    }
                }
                dttSource.Rows.Add(row);
            }
            return dttSource;
        }
   }

   public class TableCreateInfo
   {
       /// <summary>
       /// レイアウト種別
       /// </summary>
       public TemplateInfo.DocumentTemplateRow TemplateInfo
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
       /// 作成オプション
       /// </summary>
       public ScriptOptions Options
       {
           get;
           set;
       }

   }

  
}
