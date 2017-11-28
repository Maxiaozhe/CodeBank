using RJ.Tools.NotesTransfer.Engines.Common;
using RJ.Tools.NotesTransfer.Engines.Design;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.SqlServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;


namespace RJ.Tools.NotesTransfer.UI.Forms
{
    public partial class LogAdmin : FormBase
    {
        private const int MAX_DISPLAY_NUM = 1000;

        public LogAdmin()
        {
            InitializeComponent();
        }

        #region Method
        /// <summary>
        /// 画面を初期化する
        /// </summary>
        private void InitControls()
        {
            this.dtgEventLog.AutoGenerateColumns = false;
            this.dtgSystemLog.AutoGenerateColumns = false;
            InitLogTypes();
        }
        /// <summary>
        /// ログ種別コンボボックスを初期化
        /// </summary>
        private void InitLogTypes()
        {
            this.cmbLogType.Items.Clear();
            this.cmbLogType.DisplayMember = "DisplayName";
            this.cmbLogType.ValueMember = "EnumValue";
            var mems = typeof(LogType).GetMembers(BindingFlags.Public | BindingFlags.Static);
            foreach (MemberInfo info in mems)
            {
                object[] customAttributes = info.GetCustomAttributes(typeof(EnumNameAttribute), true);
                if (customAttributes.Count() > 0)
                {
                    EnumNameAttribute item = (EnumNameAttribute)customAttributes[0];
                    this.cmbLogType.Items.Add(item);
                }
            }
            if (this.cmbLogType.Items.Count > 0)
            {
                this.cmbLogType.SelectedIndex = 0;
            }

        }


        private bool ValidateInputs()
        {
            if (this.cmbLogType.SelectedIndex == -1)
            {
                RSM.ShowMessage(this, RS.Exclamations.NotSelectLogType);
                this.cmbLogType.Focus();
                return false;
            }
            DateTime? sdate = null;
            DateTime? edate = null;
            //開始日
            if (dtpStartDate.Checked)
            {
                sdate = dtpStartDate.Value.Date;
                if (sdate.Value > SqlDateTime.MaxValue || sdate.Value < SqlDateTime.MinValue)
                {
                    RSM.ShowMessage(this, RS.Exclamations.InvalidateDateRang);
                    this.dtpStartDate.Focus();
                    return false;
                }
            }
            //終了日
            if (dtpEndDate.Checked)
            {
                edate = dtpEndDate.Value.Date;
                if (edate.Value > SqlDateTime.MaxValue || edate.Value < SqlDateTime.MinValue)
                {
                    RSM.ShowMessage(this, RS.Exclamations.InvalidateDateRang);
                    this.dtpEndDate.Focus();
                    return false;
                }
            }
            //日付範囲
            if (sdate.HasValue && edate.HasValue && sdate.Value > edate.Value)
            {
                RSM.ShowMessage(this, RS.Exclamations.InvalidateDateRang);
                this.dtpStartDate.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 検索条件を取得する
        /// </summary>
        /// <returns></returns>
        private SearchArgs GetSearchArgs()
        {
            SearchArgs args = new SearchArgs();
            //Type
            EnumNameAttribute selectedItem = (EnumNameAttribute)this.cmbLogType.SelectedItem;
            args.Type = (LogType)selectedItem.EnumValue;
            //開始日
            if (dtpStartDate.Checked)
            {
                args.StartDate = dtpStartDate.Value.Date;
            }
            //終了日
            if (dtpEndDate.Checked)
            {
                args.EndDate = DateTime.Parse(dtpEndDate.Value.ToString("yyyy/MM/dd") + " 23:59:59");
            }
            return args;
        }
        /// <summary>
        /// 検索結果を表示する
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        private void BindLogList(LogType logType, DateTime? sdate, DateTime? edate)
        {
            DataSet result = null;
            using (SqlAccessor accessor = Accessor.AccessorFactory.GetSqlAccessor())
            {
                result = accessor.GetLogList(logType, sdate, edate);
            }
            if (result != null || result.Tables.Count > 1)
            {
                //件数
                int count = Utility.DBToInteger(result.Tables[0].Rows[0]["LOGCOUNT"]);
                if (count > MAX_DISPLAY_NUM)
                {
                    RSM.ShowMessage(this, RS.Exclamations.MaxDisplayNumOvered);
                }
                DataTable datasource = result.Tables[1];
                if (logType == LogType.System)
                {
                    this.dtgSystemLog.DataSource = datasource;
                    this.dtgEventLog.DataSource = null;
                    this.dtgEventLog.Visible = false;
                    this.dtgSystemLog.Visible = true;
                }
                else
                {
                    this.dtgEventLog.DataSource = datasource;
                    this.dtgSystemLog.DataSource = null;
                    this.dtgSystemLog.Visible = false;
                    this.dtgEventLog.Visible = true;
                }
            }
        }


        /// <summary>
        /// CSVファイルを出力
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        private void SaveCsvFile(LogType type, DateTime? sdate, DateTime? edate)
        {
            this.saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
            if (this.saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataTable logData = null;
                using (SqlAccessor accessor = Accessor.AccessorFactory.GetSqlAccessor())
                {
                    logData = accessor.GetLogCsv(type, sdate, edate);
                }
                string filePath=this.saveFileDialog.FileName;
                string csvData = GetCsvFile(logData);
                 System.Text.Encoding Encoder  = System.Text.Encoding.Default;
                 System.IO.File.WriteAllText(filePath, csvData, Encoder);
            }
        }

        /// <summary>
        /// ログを削除する
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        private void DeleteLog(LogType type, DateTime? sdate, DateTime? edate)
        {
            using (SqlAccessor accessor = Accessor.AccessorFactory.GetSqlAccessor())
            {
                accessor.DeleteLog(type, sdate, edate);
            }
            RSM.ShowMessage(this, RS.Informations.LogDataDeleted);
            this.BindLogList(type, sdate, edate);
        }

        private string GetCsvFile(DataTable logData)
        {
            StringBuilder sbCsv = new StringBuilder();
            string colSpliter = ",";
            string rowSpliter = "\n";

            sbCsv.Append(this.GetCsvHeader(logData) + rowSpliter);
            string value = string.Empty;
            foreach (DataRow row in logData.Rows)
            {
                int index = 0;
                int colIndex = 0;
                foreach (DataColumn column in logData.Columns)
                {
                    colIndex++;
                    if (index > 0)
                    {
                        sbCsv.Append(colSpliter);
                    }
                    value = this.GetRowValue(column, row);
                    sbCsv.Append(AddQuotaion(value));
                    index++;
                }
                sbCsv.Append(rowSpliter);
            }

            return sbCsv.ToString();

        }

        private string GetCsvHeader(DataTable logData)
        {
            StringBuilder header = new StringBuilder();
            int index = 0;
            int ColIndex = 0;
            foreach (DataColumn column in logData.Columns)
            {
                ColIndex++;
                if (index > 0)
                {
                    header.Append(",");
                }

                header.Append(AddQuotaion(column.ColumnName));
                index++;
            }
            return header.ToString();
        }

        private string GetRowValue(DataColumn column, DataRow row)
        {
            switch (column.DataType.ToString())
            {
                case "System.String":
                    return Utility.DBToString(row[column.ColumnName]);

                case "System.DateTime":
                    DateTime? value = Utility.DBToDateTime(row[column.ColumnName]);
                    if (value.HasValue)
                    {
                        return value.Value.ToString("yyyy/MM/dd HH:mm:ss");
                    }
                    else
                    {
                        return "";
                    }
                case "System.Decimal":
                    return Utility.DBToDecimal(row[column.ColumnName]).ToString();
                case "System.Integer":
                case "System.Int32":
                case "System.Int64":
                    return Utility.DBToLong(row[column.ColumnName]).ToString();
                default:
                    return Utility.DBToString(row[column.ColumnName]);
            }
        }


        private string AddQuotaion(string value)
        {
            return ("\"" + value.Replace("\"", "\"\"") + "\"");
        }


        #endregion

        #region Enevt Handler

        private void LogAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                this.InitControls();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }

        private void styleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                {
                    return;
                }
                SearchArgs args = GetSearchArgs();
                this.BindLogList(args.Type, args.StartDate, args.EndDate);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// CSVを出力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCsvSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                {
                    return;
                }
                SearchArgs args = GetSearchArgs();
                this.SaveCsvFile(args.Type, args.StartDate, args.EndDate);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }



        /// <summary>
        /// ログを削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                {
                    return;
                }
                SearchArgs args = GetSearchArgs();
                this.DeleteLog(args.Type, args.StartDate, args.EndDate);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        #endregion

        #region Inner Class
        internal class SearchArgs
        {
            /// <summary>
            /// 開始日付
            /// </summary>
            public DateTime? StartDate { get; set; }
            /// <summary>
            /// 完了日付
            /// </summary>
            public DateTime? EndDate { get; set; }
            /// <summary>
            /// 種別
            /// </summary>
            public LogType Type { get; set; }

        }
        #endregion

        private void CloseButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }


    }
}
