using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDesignInfo.Entity;
using Excel = Microsoft.Office.Interop.Excel;

namespace TableDesignInfo.Controls
{
    public class DbDocumentCreator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public void CreateDocument(DbDocumentInfo docInfo)
        {
            using (ExcelHelp xls = new ExcelHelp(GetTemplateFile(docInfo)))
            {
                TemplateInfo.DocumentTemplateRow info = docInfo.TemplateInfo;

                xls.BeginUpdate();
                //表題
                if (!string.IsNullOrEmpty(info.CoverSheet))
                {
                    Excel.Worksheet coverSheet = xls.WorkBook.Sheets[info.CoverSheet];
                    xls.WriteValue(coverSheet, info.SystemNameCell, docInfo.SystemName);
                    xls.WriteValue(coverSheet, info.SubSystemNameCell, docInfo.SubSystemName);
                    xls.WriteValue(coverSheet, info.UpdateDate, DateTime.Today.ToString("yyyy/MM/dd"));
                }
                //目次を取得
                Excel.Worksheet indexSheet = xls.WorkBook.Sheets[info.IndexSheet];
                int rowNo = info.IndexSheet_StartRow;
                foreach (string tableName in docInfo.TableNames)
                {
                    TableList table = LinqSqlHelp.GetTable(tableName);
                    if (table != null)
                    {
                        string sheetName = string.IsNullOrEmpty(table.TableDisplayName) ? table.TableName : table.TableDisplayName;
                        Excel.Worksheet templateSheet=xls.WorkBook.Sheets[info.TemplateSheet];
                        Excel.Worksheet tableSheet = xls.CreateSheet(sheetName, templateSheet);
                        //テーブル情報を書く
                        xls.WriteValue(tableSheet, info.TableId, table.TableName);
                        xls.WriteValue(tableSheet, info.TableName, table.TableName);
                        xls.WriteValue(tableSheet, info.TableDisplayName, table.TableDisplayName);
                        xls.WriteValue(tableSheet, info.TableComment, "");
                        xls.WriteValue(tableSheet, info.TableSummary, table.Comment);
                        //目次に書く
                        if (rowNo > info.IndexSheet_StartRow)
                        {
                            xls.CopyRow(indexSheet, info.IndexSheet_StartRow, rowNo);
                        }
                        //xls.WriteValue(indexSheet, info.IndexSheet_TableId , rowNo, table.TableName);
                        xls.WriteValue(indexSheet, info.IndexSheet_TableName , rowNo, table.TableName);
                        xls.WriteValue(indexSheet, info.IndexSheet_DisplayName, rowNo, table.TableDisplayName);
                        xls.WriteValue(indexSheet, info.IndexSheet_Summary , rowNo, table.Comment);
                        //リンク追加
                        if (!string.IsNullOrEmpty(info.IndexSheet_Link))
                        {
                            Excel.Range anchor = indexSheet.Range[info.IndexSheet_Link + rowNo];
                            indexSheet.Hyperlinks.Add(Anchor: anchor, Address: "", SubAddress: "'" + tableSheet.Name + "'!A1", TextToDisplay: sheetName);
                        }
                        //テーブルレイアウトを書く
                        var columns = LinqSqlHelp.GetTableLayout(tableName);
                        int colIndex = info.ColumnStartRow;
                        //カラム情報を書く
                        foreach (TableLayoutInfo column in columns)
                        {
                            if (colIndex > info.ColumnMaxRow)
                            {
                                xls.CopyRow(tableSheet, info.ColumnStartRow, colIndex);
                            }
                            xls.WriteValue(tableSheet, info.ColumnNo , colIndex, (colIndex - info.ColumnStartRow+1).ToString());
                            xls.WriteValue(tableSheet, info.ColumnName , colIndex, column.ColumnName);
                            xls.WriteValue(tableSheet, info.ColumnDisplayName , colIndex, column.ColumnDisplayName);
                            xls.WriteValue(tableSheet, info.ColumnDataType , colIndex, column.DataType);
                            xls.WriteValue(tableSheet, info.ColumnDataLength , colIndex, column.DataLengthDisplay);
                            xls.WriteValue(tableSheet, info.ColumnNullable , colIndex, column.Nullable ? "○" : "");
                            xls.WriteValue(tableSheet, info.ColumnIsPrimaryKey , colIndex, column.IsPrimaryKey ? "○" : "");
                            xls.WriteValue(tableSheet, info.ColumnIndex , colIndex, 
                                            column.IndexId.HasValue?Convert.ToString(column.IndexId.Value):"");
                            xls.WriteValue(tableSheet, info.ColumnComment , colIndex, column.Comment);
                            colIndex++;
                        }
                        tableSheet.Columns.AutoFit();
                        rowNo++;
                    }
                }
                indexSheet.Columns.AutoFit();
                xls.EndUpdate();
                xls.Save(docInfo.FileName);
            }
        }

        private string GetTemplateFile(DbDocumentInfo docInfo)
        {
            string basePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string fileName =System.IO.Path.Combine(basePath,"Template",docInfo.TemplateInfo.TemplateFileName);
            return fileName;
        }
    }
}
