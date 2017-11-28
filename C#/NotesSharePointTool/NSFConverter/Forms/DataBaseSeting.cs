using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RJ.Tools.NotesTransfer.Components;
using RJ.Tools.NotesTransfer.Engines.Common;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.Notes.Controls;
using RJ.Tools.NotesTransfer.Engines.SqlServer;
using RJ.Tools.NotesTransfer.Engines.SqlServer.Entity;
using RJ.Tools.NotesTransfer.UI.Component.Desgin;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;
using System.Text.RegularExpressions;
namespace RJ.Tools.NotesTransfer.UI.Forms
{
    public partial class DataBaseSeting : FormBase
    {

        public DataBaseSeting()
        {
            InitializeComponent();
        }

        #region Field
        private const string HALF_ALFA_REGEX = @"^[a-zA-Z-_]+[0-9a-zA-Z-_]*$";
        private NotesAccessor _notesAccessor = null;
        private MigrateTask _taskInfo = null;
        #endregion

        #region Property
        /// <summary>
        /// 移行設定情報
        /// </summary>
        public MigrateTask TaskInfo
        {
            get
            {
                return this._taskInfo;
            }
            set
            {
                this._taskInfo = value;
            }
        }

        private NotesAccessor Notes
        {
            get
            {
                if (this._notesAccessor == null)
                {
                    this._notesAccessor = Accessor.AccessorFactory.GetNotesAccessor();
                    this._notesAccessor.TryConnect(Config.NotesPassword);
                }
                return this._notesAccessor;
            }
        }

        #endregion

        #region Method

        private void InitSpType()
        {
            using (SqlAccessor sqlAccessor = Accessor.AccessorFactory.GetSqlAccessor())
            {
                DataTable dtt = sqlAccessor.GetCodeList(CodeType.ListType);
                this.cmbSPType.Items.Clear();
                this.cmbSPType.DisplayMember = "DISPLAY_NAME";
                this.cmbSPType.ValueMember = "SP_TYPE";
                this.cmbSPType.DataSource = dtt;
            }
        }

        /// <summary>
        /// 画面初期化する
        /// </summary>
        private void InitDatabaseInfo()
        {

            this.txtTaskName.Text = this._taskInfo.TaskName;
            string server = string.IsNullOrEmpty(this._taskInfo.NotesServer) ? "Local" : this._taskInfo.NotesServer;
            this.txtServer.Text = server;
            this.txtFileName.Text = this._taskInfo.NotesFilePath;
            this.txtListName.Text = this._taskInfo.ListName;
            this.txtDisplayName.Text = this._taskInfo.DisplayName;
            this.txtDescription.Text = this._taskInfo.Description;
            this.txtWebSite.Text = this._taskInfo.SPSiteUrl;
            //状態
            switch (this._taskInfo.State)
            {
                case TaskState.NotExecute:
                    this.lblStatus.Text = RSM.GetMessage(RS.StringTable.TaskState_NotExecute);
                    break;
                case TaskState.Executed:
                    this.lblStatus.Text = RSM.GetMessage(RS.StringTable.TaskState_Executed);
                    break;
                case TaskState.ExecutFailed:
                    this.lblStatus.Text = RSM.GetMessage(RS.StringTable.TaskState_ExecutFailed);
                    break;
                default:
                    this.lblStatus.Text = string.Empty;
                    break;
            }
            //既定のアイコン
            this.rdoDefaultIcon.Checked = this._taskInfo.IsUseDefaultIcon;
            this.rdoNotDefIcon.Checked = !this._taskInfo.IsUseDefaultIcon;
            //実行日時
            if (this._taskInfo.LastExecuteTime.HasValue)
            {
                this.lblConvertDate.Text = this._taskInfo.LastExecuteTime.Value.ToString("yyyy/MM/dd HH:mm:ss");
            }
            //フォーム一覧
            InitForms();
            //ビュー一覧
            InitViews();
            int pos = this.cmbSPType.FindString(this._taskInfo.ListType.ToString());
            if (pos > -1)
            {
                this.cmbSPType.SelectedIndex = pos;
            }

        }
        /// <summary>
        /// フォーム一覧を初期化
        /// </summary>
        private void InitForms()
        {
            this.listForm.BeginUpdate();
            this.listFormTarget.BeginUpdate();
            try
            {
                this.listForm.Items.Clear();
                this.listFormTarget.Items.Clear();
                if (this._taskInfo.CurrentDb == null)
                {
                    return;
                }
                List<IForm> sourceForms = this._taskInfo.CurrentDb.Forms;
                List<IForm> targetForms = this._taskInfo.TargetForms;
                var leftForms = sourceForms.Except(targetForms);
                //備選フォームリスト
                foreach (IForm form in leftForms)
                {
                    ListViewItem item = this.listForm.Items.Add(form.Name);
                    item.ImageIndex = (form.IsDefault) ? 0 : 1;
                    item.SubItems.Add(form.GetAliasesString());
                    item.Tag = form;
                }
                //対象フォームリスト
                foreach (IForm form2 in targetForms)
                {
                    ListViewItem item = this.listFormTarget.Items.Add(form2.Name);
                    item.ImageIndex = (form2.IsDefault) ? 0 : 1;
                    item.SubItems.Add(form2.GetAliasesString());
                    item.Tag = form2;
                }
            }
            finally
            {
                this.listForm.EndUpdate();
                this.listFormTarget.EndUpdate();
            }
        }
        /// <summary>
        /// ビュー一覧を初期化
        /// </summary>
        private void InitViews()
        {
            this.listView.BeginUpdate();
            this.listViewTarget.BeginUpdate();
            try
            {
                this.listView.Items.Clear();
                this.listViewTarget.Items.Clear();
                if (this._taskInfo.CurrentDb== null)
                {
                    return;
                }

                List<IView> sourceViews = this._taskInfo.CurrentDb.Views;
                List<IView> targetViews = this._taskInfo.TargetViews;
                var leftviews = sourceViews.Except(targetViews);
                //備選ビューリスト
                foreach (IView view in leftviews)
                {
                    ListViewItem item = this.listView.Items.Add(view.Name);
                    item.ImageIndex = (view.IsDefault) ? 0 : 1;
                    string[] aliases = view.Aliases.ToArray();
                    string aliasesName = string.Join("|", aliases);
                    item.SubItems.Add(aliasesName);
                    item.Tag = view;
                }
                //対象ビューリスト
                foreach (IView view2 in targetViews)
                {
                    ListViewItem item = this.listViewTarget.Items.Add(view2.Name);
                    item.ImageIndex = (view2.IsDefault) ? 0 : 1;
                    string[] aliases = view2.Aliases.ToArray();
                    string aliasesName = string.Join("|", aliases);
                    item.SubItems.Add(aliasesName);
                    item.Tag = view2;
                }
            }
            finally
            {
                this.listView.EndUpdate();
                this.listViewTarget.EndUpdate();
            }

        }

        private IDatabase GetDatabase(string server,string filePath)
        {
            IDatabase db = this.Notes.GetDataBase(filePath, server);
            return db;
        }

        private bool ValidateInputs()
        {
            
            //変換タスク名
            if (string.IsNullOrEmpty(this.txtTaskName.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotTaskName);
                FocusControl(this.txtTaskName);
                return false;
            }
            //対象DB
            if (string.IsNullOrEmpty(this.txtFileName.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotTagetDatabase);
                FocusControl(this.btnSelectDb);
                return false;
            }
            //対象DBへアクセスチェック
            IDatabase db= this.Notes.GetDataBase(this._taskInfo.NotesFilePath, this._taskInfo.NotesServer);
            if (db == null)
            {
                RSM.ShowMessage(this, RS.Exclamations.CantOpenDatabase);
                FocusControl(this.btnSelectDb);
                return false;
            }
            //List名
            if (string.IsNullOrEmpty(this.txtListName.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotListName);
                FocusControl(this.txtListName);
                return false;
            }
            string listName=this.txtListName.Text;
            if (!Regex.Match(listName, HALF_ALFA_REGEX).Success)
            {
                RSM.ShowMessage(this, RS.Exclamations.InvalidateListName);
                FocusControl(this.txtListName);
                return false;
            }
            //タイトル
            if (string.IsNullOrEmpty(this.txtDisplayName.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotTitleName);
                FocusControl(this.txtDisplayName);
                return false;
            }
            //サイト名
            if (string.IsNullOrEmpty(this.txtWebSite.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotWebSiteName);
                FocusControl(this.txtWebSite);
                return false;
            }
            //対象フォーム
            if (this._taskInfo.TargetForms.Count == 0)
            {
                RSM.ShowMessage(this, RS.Exclamations.NotTargetForm);
                FocusControl(this.listFormTarget);
                return false;

            }
            //対象フォーム
            if (this._taskInfo.TargetViews.Count == 0)
            {
                RSM.ShowMessage(this, RS.Exclamations.NotTargetView);
                FocusControl(this.listViewTarget);
                return false;
            }
            //参照フォーム存在するかどうかをチェックする
            foreach (IView view in this._taskInfo.TargetViews)
            {
                foreach (string formName in view.ReferForms)
                {
                  IForm form = this._taskInfo.TargetForms.Find(t => t.Name.Equals(formName));
                  if (form == null)
                  {
                      RSM.ShowMessage(this, RS.Exclamations.NotReferForm,formName);
                      FocusControl(this.listFormTarget);
                      return false;
                  }
                }
            }


            return true;
        }

        /// <summary>
        /// フォーカスを設定する
        /// </summary>
        /// <param name="ctrl"></param>
        private void FocusControl(Control ctrl)
        {
            ctrl.Focus();
            TabPage tab = FindTabPage(ctrl);
            if (tab != null)
            {
                this.tabMain.SelectedTab = tab;
            }

        }
        /// <summary>
        /// タブページを探す
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private TabPage FindTabPage(Control ctrl)
        {
            if (ctrl.Parent == null)
            {
                return null;
            }
            if (ctrl.Parent is TabPage)
            {
                return (TabPage)ctrl.Parent;
            }
            else
            {
                return FindTabPage(ctrl.Parent);
            }

        }

        #endregion

        #region Event Handler
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataBaseSeting_Load(object sender, EventArgs e)
        {
            try
            {
                //LIST種別リスト初期化
                this.InitSpType();
                //IDatabase初期化
                if (this._taskInfo == null) return;
                if (this._taskInfo.CurrentDb == null && !string.IsNullOrEmpty(this._taskInfo.NotesFilePath))
                {
                    IDatabase db = this.GetDatabase(this._taskInfo.NotesServer, this._taskInfo.NotesFilePath);
                    this._taskInfo.CurrentDb = db;
                }
                this.InitDatabaseInfo();
 
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }

        /// <summary>
        /// データベース選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDb_Click(object sender, EventArgs e)
        {
            try
            {
                NsfPicker nsfPicker = new NsfPicker();
                nsfPicker.NotesPassword = Config.NotesPassword;
                if (nsfPicker.ShowNsfPicker(this, false) == System.Windows.Forms.DialogResult.OK)
                {
                    NsfInfo dbInfo = nsfPicker.SelectNsfDb;
                    IDatabase db = GetDatabase(dbInfo.Server,dbInfo.FilePath);
                    this._taskInfo.ResetNotesDatabase(db);
                    InitDatabaseInfo();
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }

        }

        /// <summary>
        /// 対象フォームを追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listForm.SelectedItems == null || this.listForm.SelectedItems.Count == 0)
                {
                    return;
                }
                IForm formItem = this.listForm.SelectedItems[0].Tag as IForm;
                if (formItem != null)
                {
                    formItem.IsTarget = true;
                    this._taskInfo.TargetForms.Add(formItem);
                }
                this.InitForms();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }

        }
        /// <summary>
        /// 対象フォームを削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listFormTarget.SelectedItems == null || this.listFormTarget.SelectedItems.Count == 0)
                {
                    return;
                }
                IForm formItem = this.listFormTarget.SelectedItems[0].Tag as IForm;
                if (formItem != null)
                {
                    formItem.IsTarget = false;
                    this._taskInfo.TargetForms.Remove(formItem);
                }
                this.InitForms();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// 対象ビューを追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddView_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView.SelectedItems == null || this.listView.SelectedItems.Count == 0)
                {
                    return;
                }
                IView viewItem = this.listView.SelectedItems[0].Tag as IView;
                if (viewItem != null)
                {
                    viewItem.IsTarget = true;
                    this._taskInfo.TargetViews.Add(viewItem);
                }
                this.InitViews();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }

        }
        /// <summary>
        /// 対象ビューを削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveView_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listViewTarget.SelectedItems == null || this.listViewTarget.SelectedItems.Count == 0)
                {
                    return;
                }
                IView viewItem = this.listViewTarget.SelectedItems[0].Tag as IView;
                if (viewItem != null)
                {
                    viewItem.IsTarget = false;
                    this._taskInfo.TargetViews.Remove(viewItem);
                }
                this.InitViews();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// データ保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateInputs())
                {
                    return;
                }
                //入力値を設定する
                this._taskInfo.TaskName = this.txtTaskName.Text;
                this._taskInfo.DisplayName = this.txtDisplayName.Text;
                this._taskInfo.ListName = this.txtListName.Text;
                this._taskInfo.Description = this.txtDescription.Text;
                this._taskInfo.IsUseDefaultIcon = this.rdoDefaultIcon.Checked;
                string strType = Convert.ToString(this.cmbSPType.SelectedValue);
                SPListType sptype = SPListType.GenericList;
                if (Enum.TryParse(strType, true, out sptype))
                {
                    this._taskInfo.ListType = sptype;
                }
                using (SqlAccessor sqlAccessor = Accessor.AccessorFactory.GetSqlAccessor())
                {
                    sqlAccessor.InsertMigrate(this._taskInfo);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Log.Write(this._taskInfo.TaskId, 
                        RSM.GetMessage(RS.Informations.DataBaseSetted, this._taskInfo.TaskName, this._taskInfo.TaskId));
                this.Close();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }










    }
}
