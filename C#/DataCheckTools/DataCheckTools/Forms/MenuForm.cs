using Rex.Tools.Test.DataCheck.Common;
using Rex.Tools.Test.DataCheck.Controls;
using Rex.Tools.Test.DataCheck.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Rex.Tools.Test.DataCheck.Forms
{
    /// <summary>
    /// メニューフォーム
    /// </summary>
    public partial class MenuForm : BaseForm
    {
        #region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MenuForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Inner Class
        /// <summary>
        /// BackgroundWorkに渡すパラメタ情報を定義する
        /// </summary>
        internal class CommandArg
        {
            /// <summary>
            /// コマンド種別
            /// </summary>
            internal CommandKind Kind { get; set; }
            /// <summary>
            /// コマンドパラメタ
            /// </summary>
            internal object[] Params { get; set; }

            /// <summary>
            /// インスタンスを生成する
            /// </summary>
            /// <param name="kind"></param>
            /// <param name="args"></param>
            internal CommandArg(CommandKind kind, params object[] args)
            {
                this.Kind = kind;
                this.Params = args;
            }

        }
        #endregion

        #region Inner Enum
        /// <summary>
        /// 処理種別
        /// </summary>
        internal enum CommandKind
        {
            /// <summary>
            /// テーブルレイアウト作成SQLスクリプト作成
            /// </summary>
            TableScriptCreate,
            /// <summary>
            /// データシート作成（新LIVE）
            /// </summary>
            LiveDataSheetCreate,
            /// <summary>
            /// データシート作成（SEED）
            /// </summary>
            SeedDataSheetCreate,
            /// <summary>
            /// データインサート用SQLスクリプト作成（新LIVE）
            /// </summary>
            LiveInsertSqlCreate,
            /// <summary>
            /// データインサート用SQLスクリプト作成（SEED）
            /// </summary>
            SeedInsertSqlCreate,
            /// <summary>
            /// 生産計画・実績データ移行結果をチェックする
            /// </summary>
            ProductionDataCheck,
            /// <summary>
            /// 稼動実績データ移行結果をチェックする
            /// </summary>
            OperationDataCheck,
        }

        #endregion

        #region Methods
        ///// <summary>
        ///// テストデータシート（枠のみ）作成
        ///// </summary>
        ///// <param name="kind"></param>
        //private void DoCreateDataSheet(DataKind kind)
        //{
        //    TestDataSheetCreator creator = new TestDataSheetCreator(reportHandler);
        //    creator.CreateTestData(kind);
        //}
        /// <summary>
        /// データ入力シート（枠のみ）を作成する
        /// </summary>
        /// <param name="sheets"></param>
        /// <param name="isTarget"></param>
        private void DoCreateDataSheet(string[] sheets, bool isTarget)
        {

            TestDataSheetCreator creator = new TestDataSheetCreator(reportHandler);
            creator.CreateDBInitData(sheets, isTarget);
        }
        /// <summary>
        /// 移行結果データをチェックする
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="filePath"></param>
        private void DoCheckDatas(DataKind kind, string filePath)
        {

            TestDataChecker checker = new TestDataChecker(reportHandler);
            checker.CheckDatas(filePath,"");
        }
        /// <summary>
        /// データベース作成用SQL文を生成する
        /// </summary>
        /// <param name="designFileName"></param>
        /// <param name="layoutType"></param>
        private void DoCreateSqlScript(string designFileName, LayoutType layoutType)
        {
            try
            {
                ScriptOptions opts;
                if (layoutType == LayoutType.Live)
                {
                    Logging.OutputFileName = "LiveDBCreater.sql";
                    opts = ScriptOptions.DropTables | ScriptOptions.CreateTables |
                        ScriptOptions.CreateDropDescriptions | ScriptOptions.DropDropDescriptions;
                }
                else
                {
                    Logging.OutputFileName = "SeedDBCreater.sql";
                    opts = ScriptOptions.CreateTables | ScriptOptions.DropTables |
                           ScriptOptions.CreateDropDescriptions | ScriptOptions.DropDropDescriptions;
                }
                TableCreator creator = new TableCreator(reportHandler);
                creator.CreateDBScript(layoutType, designFileName, opts);
            }
            finally
            {
                Logging.OutputFileName = "";
            }
        }

        /// <summary>
        /// データベース作成用SQL文を生成する
        /// </summary>
        /// <param name="designFileName"></param>
        /// <param name="layoutType"></param>
        private void DoCreateSqlScript(TableCreateInfo createInfo)
        {

            TableCreator creator = new TableCreator(reportHandler);
            creator.CreateDBScript(createInfo);
        }

        /// <summary>
        /// データインサート用SQL文を生成する
        /// </summary>
        /// <param name="designFileName"></param>
        /// <param name="layoutType"></param>
        private void DoInsertSqlScript(string dataSheetName, bool isTarget)
        {
            TestDataInitializer initializer = new TestDataInitializer(reportHandler);
            initializer.DoInitlize(dataSheetName, isTarget,"");
        }

        /// <summary>
        /// BackgroundWorker開始する
        /// </summary>
        /// <param name="arg"></param>
        private void Run(CommandArg arg)
        {
            this.mnuPanel.Enabled = false;
            this.lblParcentage.Text = "";
            this.lblMessage.Text = "";
            this.progressBar1.Value = 0;
            this.ProgressPanel.Visible = true;
            this.ProgressPanel.BringToFront();
            this.backgroundWorker1.RunWorkerAsync(arg);
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// データベース（SEED）　データ入力シート作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeedInitDataCreateButton_Click(object sender, EventArgs e)
        {

            try
            {
                string[] selectedSheets = null;
                using (SheetSelectForm form = new SheetSelectForm())
                {
                    form.Title = "データベース（SEED）テーブル一覧を選択する";
                    form.ExcelFileName = Config.GetTransferSettingFile(false);
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return;
                    }
                    selectedSheets = form.SelectedSheets;
                }
                Run(new CommandArg(CommandKind.SeedDataSheetCreate, selectedSheets));
            }
            catch (Exception ex)
            {
                Logging.Exception("", ex);
                base.ShowException(ex);
            }
        }
        /// <summary>
        /// データベース（LIVE）　データ入力シート作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LiveInitDataCreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] selectedSheets = null;
                using (SheetSelectForm form = new SheetSelectForm())
                {
                    form.Title = "データベース（LIVE）テーブル一覧を選択する";
                    form.ExcelFileName = Config.GetTransferSettingFile(true);
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return;
                    }
                    selectedSheets = form.SelectedSheets;
                }
                Run(new CommandArg(CommandKind.LiveDataSheetCreate, selectedSheets));
            }
            catch (Exception ex)
            {
                Logging.Exception("", ex);
                base.ShowException(ex);

            }
        }
        /// <summary>
        /// データベース（SEED）　初期データ作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeedInserSqlCreate_Click(object sender, EventArgs e)
        {
            try
            {
                this.openExcelDialog.Title = "データ入力シート(SEED)を選択してください";
                if (this.openExcelDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                if (System.IO.File.Exists(this.openExcelDialog.FileName))
                {
                    Run(new CommandArg(CommandKind.SeedInsertSqlCreate, this.openExcelDialog.FileName));
                }
            }
            catch (Exception ex)
            {
                Logging.Exception("", ex);
                base.ShowException(ex);
            }
        }
        /// <summary>
        /// データベース（LIVE）　初期データ作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LiveInserSqlCreate_Click(object sender, EventArgs e)
        {
            try
            {
                this.openExcelDialog.Title = "データ入力シート(LIVE)を選択してください";
                if (this.openExcelDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                if (System.IO.File.Exists(this.openExcelDialog.FileName))
                {
                    Run(new CommandArg(CommandKind.LiveInsertSqlCreate, this.openExcelDialog.FileName));
                }
            }
            catch (Exception ex)
            {
                Logging.Exception("", ex);
                base.ShowException(ex);

            }
        }
        /// <summary>
        /// 生産計画・稼働期待データをチェックする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductionDataCheck_Click(object sender, EventArgs e)
        {
            try
            {
                this.openExcelDialog.Title = "生産計画・稼働期待データを選択してください";
                if (this.openExcelDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                if (System.IO.File.Exists(this.openExcelDialog.FileName))
                {
                    Run(new CommandArg(CommandKind.ProductionDataCheck, this.openExcelDialog.FileName));
                }
            }
            catch (Exception ex)
            {
                Logging.Exception("", ex);
                base.ShowException(ex);

            }
        }

        /// <summary>
        /// 設備計画・稼働データをチェックする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperationDataCheck_Click(object sender, EventArgs e)
        {
            try
            {
                this.openExcelDialog.Title = "設備計画・稼働期待データを選択してください";
                if (this.openExcelDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                if (System.IO.File.Exists(this.openExcelDialog.FileName))
                {
                    Run(new CommandArg(CommandKind.OperationDataCheck, this.openExcelDialog.FileName));
                }
            }
            catch (Exception ex)
            {
                Logging.Exception("", ex);
                MessageBox.Show(this, ex.Message, "例外", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        /// <summary>
        /// データベースCreate用SQLスクリプトを作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseCreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                TableCreateInfo info = null;
                using (SelectDbLayoutForm selectForm = new SelectDbLayoutForm())
                {
                    if (selectForm.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }
                    info = selectForm.SettingInfo;
                }

                if (info != null)
                {
                    Run(new CommandArg(CommandKind.TableScriptCreate, info));
                }

            }
            catch (Exception ex)
            {
                Logging.Exception("", ex);
                MessageBox.Show(this, ex.Message, "例外", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        /// <summary>
        /// BackgroundWorker開始イベントを処理する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CommandArg commandArg = (CommandArg)e.Argument;

                switch (commandArg.Kind)
                {
                    case CommandKind.TableScriptCreate:
                        DoCreateSqlScript((TableCreateInfo)commandArg.Params[0]);
                        break;
                    case CommandKind.SeedDataSheetCreate:
                        this.DoCreateDataSheet((string[])commandArg.Params, false);
                        break;
                    case CommandKind.LiveDataSheetCreate:
                        this.DoCreateDataSheet((string[])commandArg.Params, true);
                        break;
                    case CommandKind.LiveInsertSqlCreate:
                        this.DoInsertSqlScript((string)commandArg.Params[0], true);
                        break;
                    case CommandKind.SeedInsertSqlCreate:
                        this.DoInsertSqlScript((string)commandArg.Params[0], false);
                        break;
                    case CommandKind.ProductionDataCheck:
                        DoCheckDatas(DataKind.ProductionData, (string)commandArg.Params[0]);
                        break;
                    case CommandKind.OperationDataCheck:
                        DoCheckDatas(DataKind.OperationData, (string)commandArg.Params[0]);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Logging.Exception("", ex);
                throw ex;
            }
        }

        /// <summary>
        /// リポートハンドローラー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void reportHandler(object sender, ReportEventArgs args)
        {
            this.backgroundWorker1.ReportProgress(args.ProgressPercentage, args);
        }
        /// <summary>
        /// プロセス進歩報告イベントを処理する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            ReportEventArgs reportArgs = e.UserState as ReportEventArgs;
            if (reportArgs != null)
            {
                this.lblMessage.Text = reportArgs.Message;
                if (reportArgs.TotalCount > 0)
                {
                    this.lblParcentage.Text = reportArgs.ProcessedCount + " / " + reportArgs.TotalCount;
                }
                else
                {
                    this.lblParcentage.Text = "";
                }
            }

        }
        /// <summary>
        /// 処理完了するイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                base.ShowInfomation("処理完了しました。");
            }
            else
            {
                Logging.Exception("", e.Error);
                base.ShowException(e.Error);
            }
            this.progressBar1.Value = 100;

            this.mnuPanel.Enabled = true;
            this.ProgressPanel.Visible = false;
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
