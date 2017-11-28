using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace Rex.Tools.Test.DataCheck.Controls
{
    public class ExcelHelp : IDisposable
    {
        private Excel.Application _thisApp;
        private Excel.Workbook _wk;
        private bool _isUpdating = false;


        public ExcelHelp()
        {
            this._thisApp = new Excel.Application();
            this._wk = this._thisApp.Workbooks.Add();
        }

        public ExcelHelp(string fileName)
        {
            this._thisApp = new Excel.Application();
            this._wk = this._thisApp.Workbooks.Add(fileName);
        }

        public Excel.Workbook WorkBook
        {
            get
            {
                return this._wk;
            }
        }

        public void BeginUpdate()
        {
            this._isUpdating = true;
            this._thisApp.ScreenUpdating = false;
        }


        public void EndUpdate()
        {
            this._isUpdating = false;
            this._thisApp.ScreenUpdating = true;
        }



        /// <summary>
        /// シートを作成する
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public Excel.Worksheet CreateSheet(string sheetName)
        {
            int count = this._wk.Sheets.Count;
            Excel.Worksheet sheet = this._wk.Sheets.Add(After: this._wk.Sheets[count]);
            sheet.Name = sheetName;
            return sheet;
        }

        /// <summary>
        /// テンプレートから新しいシートを作成する
        /// </summary>
        /// <param name="sheetName"></param>
        /// <param name="templateSheet"></param>
        /// <returns></returns>
        public Excel.Worksheet CreateSheet(string sheetName,Excel.Worksheet templateSheet)
        {
            templateSheet.Copy(Before: templateSheet);
            Excel.Worksheet sheet = this._wk.Sheets[templateSheet.Name + " (2)"];
            sheet.Name = sheetName;
            if (sheet.Visible != Excel.XlSheetVisibility.xlSheetVisible)
            {
                sheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
            }
            return sheet;
        }



        public void WriteValue(Excel.Worksheet sheet, int row, int col, string value)
        {
            sheet.Cells[row, col].Value = value;
        }

        /// <summary>
        /// 一行のデータを一括書き込み
        /// </summary>
        /// <param name="range"></param>
        /// <param name="row"></param>
        public void WriteValues(Excel.Worksheet sheet, DataRow data, int startRow, int startCol)
        {
            int colCount = data.Table.Columns.Count;
            Excel.Range range = this.GetRange(sheet, startCol, startCol + colCount - 1, startRow, startRow);
            object[,] values = new object[1, colCount];
            object[] ItemArray = data.ItemArray;
            for (int i = 0; i < colCount; i++)
            {
                if (ItemArray[i] == null || ItemArray[i] is DBNull)
                {
                    values[0, i] = "<null>";
                }
                else
                {
                    values[0, i] = ItemArray[i];
                }

            }
            range.Value2 = values;
        }

        /// <summary>
        /// 一行のデータを一括書き込み
        /// </summary>
        /// <param name="range"></param>
        /// <param name="row"></param>
        public void WriteValues(Excel.Worksheet sheet, object[] data, int startRow, int startCol)
        {
            int colCount = data.Length;
            Excel.Range range = this.GetRange(sheet, startCol, startCol + colCount - 1, startRow, startRow);
            object[,] values = new object[0, colCount - 1];
            for (int i = 0; i < colCount; i++)
            {
                values[1, i + 1] = data[i];
            }
            range.Value = values;
        }

        public void Save(string fileName)
        {
            this._wk.SaveAs(fileName);
        }


        public void Save(string fileName, Excel.XlFileFormat format)
        {
            this._wk.SaveAs(fileName,FileFormat:format);
        }

        public void Close()
        {
            try
            {
                if (this._isUpdating)
                {
                    this._thisApp.ScreenUpdating = true;
                    this._isUpdating = false;
                }
                if (this._wk != null)
                {
                    this._wk.Close(false);
                    this._wk = null;
                }
                this._thisApp.Workbooks.Close();
                this._thisApp.Quit();
                WinAPI.KillExcel(this._thisApp);
            }
            catch
            {
                //skip
            }finally
            {
            }
        }

        public void Dispose()
        {

            this.Close();
        }

        public System.Data.DataTable GetSheetData(string sheetName)
        {
            Excel.Worksheet sheet = this._wk.Sheets[sheetName];
            object[,] valueArray = (object[,])sheet.UsedRange.Value;

            return null;
        }

        public System.Data.DataTable GetTableData(string sheetName, string tableName)
        {
            Excel.Worksheet sheet = this._wk.Sheets[sheetName];
            var list = sheet.ListObjects[tableName];
            System.Data.DataTable dttSource = new System.Data.DataTable();
            foreach (Excel.ListColumn column in list.ListColumns)
            {
                AddTableColumn(dttSource, column);
            }

            foreach (Excel.ListRow listRow in list.ListRows)
            {
                object[,] valueArray = (object[,])listRow.Range.Value;
                int length = valueArray.GetLength(1);
                if (length > 0
                    && (valueArray[1, 1] == null || string.IsNullOrEmpty(valueArray[1, 1].ToString())))
                {
                    break;
                }
                object[] rowValue = new object[length];
                for (int i = 0; i < length; i++)
                {
                    rowValue[i] = valueArray[1, i + 1];
                }
                dttSource.Rows.Add(rowValue);
            }

            return dttSource;

        }

        public System.Data.DataTable GetTableData(string sheetName, string[] columns, string[] columnNames, int startRow)
        {
            Excel.Worksheet sheet = this._wk.Sheets[sheetName];
            
            System.Data.DataTable dttSource = new System.Data.DataTable();
            foreach (string column in columnNames)
            {
                dttSource.Columns.Add(column,typeof(string));
            }
            int maxRow = sheet.UsedRange.Rows.Count;
       
            for (int r = startRow; r <= maxRow;r++ )
            {
                DataRow row =  dttSource.NewRow();
                for (int c = 0; c < columns.Length; c++)
                {
                    row[c] = sheet.Range[columns[c] + r].Value;
                }
                dttSource.Rows.Add(row);
            }
            return dttSource;

        }

        private void AddTableColumn(System.Data.DataTable dtt, Excel.ListColumn listColumn)
        {
            Type columnType = typeof(string);
            switch (listColumn.ListDataFormat.Type)
            {
                case Excel.XlListDataType.xlListDataTypeNumber:
                    columnType = typeof(decimal);
                    break;
                case Excel.XlListDataType.xlListDataTypeCurrency:
                    columnType = typeof(decimal);
                    break;
                case Excel.XlListDataType.xlListDataTypeCheckbox:
                    columnType = typeof(bool);
                    break;
                case Excel.XlListDataType.xlListDataTypeDateTime:
                    columnType = typeof(DateTime);
                    break;
                default:
                    break;
            }
            dtt.Columns.Add(listColumn.Name, columnType);
        }

        public Excel.Range GetRange(Excel.Worksheet sheet, int startCol, int endCol, int startRow, int endRow)
        {
            string rangeName = GetColumnName(startCol, endCol, startRow, endRow);
            try
            {
                return sheet.Range[rangeName];
            }
            catch (Exception ex)
            {
                Logging.WriteLine("-- Range:{0}が不正", rangeName);
                throw ex;
            }
        }

        public void AddListObject(Excel.Worksheet sheet, int startRow, int endRow, int endCol, string tableName)
        {
            Excel.Range range = GetRange(sheet, 1, endCol, startRow, endRow);
            sheet.ListObjects.AddEx(SourceType: Excel.XlListObjectSourceType.xlSrcRange,
                                    Source: range,
                                    XlListObjectHasHeaders: Excel.XlYesNoGuess.xlYes)
                                    .Name = tableName;
        }

        public string GetColumnName(int colIndex, int rowIndex)
        {
            return ToAlphabet(colIndex) + rowIndex;
        }

        public string GetColumnName(int startCol, int endCol, int startRow, int endRow)
        {
            return ToAlphabet(startCol) + startRow + ":" + ToAlphabet(endCol) + endRow;
        }




        /// <summary>
        /// 数値を26進の文字へ変換する
        /// </summary>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        private string ToAlphabet(int colIndex)
        {
            if (colIndex <= 0) return "";
            int num = colIndex % 26;
            num = (num == 0) ? 26 : num;
            string alphabet = ((char)(num + 64)).ToString();
            if (colIndex == num) return alphabet;
            return ToAlphabet((colIndex - num) / 26) + alphabet;
        }

    }

    internal class WinAPI
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);



        public static void KillExcel(Excel.Application app)
        {
            try
            {
                if (app != null)
                {
                    int lpdwProcessId;
                    GetWindowThreadProcessId(new IntPtr(app.Hwnd), out lpdwProcessId);
                    System.Diagnostics.Process.GetProcessById(lpdwProcessId).Kill();
                }
            }
            catch (Exception ex)
            {
                Logging.Exception("", ex);
            }
        }

    }
}
