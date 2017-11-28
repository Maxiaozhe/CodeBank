using RJ.Tools.NotesTransfer.Engines.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RJ.Tools.NotesTransfer.Engines.Notes.Controls;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.SqlServer;
using RJ.Tools.NotesTransfer.Engines.Sharepoint.Controls;
namespace RJ.Tools.NotesTransfer.UI.Forms
{
    /// <summary>
    /// システム設定画面
    /// </summary>
    public partial class EnvSettingForm : FormBase
    {
        #region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EnvSettingForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Method
        /// <summary>
        /// 画面初期化
        /// </summary>
        private void InitControls()
        {
            //Notes設定
            this.txtNotesPassword.Text = Config.NotesPassword;
            NotesAccessor nsAccessor = Accessor.AccessorFactory.GetNotesAccessor();
            if (!string.IsNullOrEmpty(Config.NotesPassword) && nsAccessor.TryConnect(Config.NotesPassword))
            {
                this.lblUserId.Text = nsAccessor.GetCurrentUser();
            }
            //出力フォルダを
            this.txtOutputFolder.Text = Config.ExportFolder;
            //Sharepoint設定
            this.txtSPWebSite.Text = Config.SPDefaultWebSite;
            this.txtSPUser.Text = Config.SPUserId;
            this.txtSPPassword.Text = Config.SPPassword;
            //SqlServer
            this.txtSqlServer.Text = Config.SqlServer;
            this.txtSqlServer.Tag = Config.SqlServer;
            AuthenticateMode mode = (AuthenticateMode)Config.DBAuthenticateMode;
            if (mode == AuthenticateMode.SqlServer)
            {
                this.txtDbUserId.Enabled = true;
                this.txtDBPassword.Enabled = true;
                this.txtDbUserId.Text = Config.DBUserId;
                this.txtDbUserId.Tag = Config.DBUserId;
                this.txtDBPassword.Text = Config.DBPassWord;
                this.txtDBPassword.Tag = Config.DBPassWord;
            }
            else
            {
                this.txtDbUserId.Enabled = false;
                this.txtDbUserId.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                this.txtDBPassword.Clear();
                this.txtDBPassword.Enabled = false;
            }
            InitAuthModeComb();
            //Detabase List
            if (!string.IsNullOrEmpty(Config.DataBaseName) && !string.IsNullOrEmpty(Config.SqlServer))
            {
                using (SqlAccessor sqlAccessor = Accessor.AccessorFactory.GetSqlAccessor())
                {
                    if (this.InitDatabaseList(sqlAccessor))
                    {
                        this.cmbDataBase.SelectedItem = Config.DataBaseName;
                    }
                }
            }
        }

        private void InitAuthModeComb()
        {
            this.cmbAuthMode.Items.Clear();
            this.cmbAuthMode.DisplayMember = "DisplayName";
            this.cmbAuthMode.ValueMember = "Value";
            List<ListItem<AuthenticateMode>> items = ListItem<AuthenticateMode>.GetEnumItem();
            foreach (ListItem<AuthenticateMode> item in items)
            {
                this.cmbAuthMode.Items.Add(item);
                if ((int)item.Value == Config.DBAuthenticateMode)
                {
                    this.cmbAuthMode.SelectedItem = item;
                }
            }
        }



        /// <summary>
        /// すべての入力情報をチェックする
        /// </summary>
        /// <returns></returns>
        private bool ValidAllSettings()
        {
            if (!ValidNotes())
            {
                return false;
            }
            if (!ValidSP())
            {
                return false;
            }
            if (!ValidDatabase())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 入力情報をチェックする
        /// </summary>
        private bool ValidNotes()
        {
            //NotesPasswordが未入力の場合
            if (string.IsNullOrEmpty(this.txtNotesPassword.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotNotesPassword);
                FocusControl(this.txtNotesPassword);
                return false;
            }
            //NotesPasswordが違います
            NotesAccessor nsAccessor = Accessor.AccessorFactory.GetNotesAccessor();
            if (nsAccessor.TryConnect(this.txtNotesPassword.Text))
            {
                this.lblUserId.Text = nsAccessor.GetCurrentUser();
            }
            else
            {
                RSM.ShowMessage(this, RS.Exclamations.InvalidNotesPassword);
                FocusControl(this.txtNotesPassword);
                return false;
            }
            //出力フォルダ
            if (string.IsNullOrEmpty(this.txtOutputFolder.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotExportFolder);
                FocusControl(this.txtOutputFolder);
                return false;
            }
            //出力フォルダの存在チェック
            if (!System.IO.Directory.Exists(this.txtOutputFolder.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.ExportFolderNotExists);
                FocusControl(this.txtOutputFolder);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 入力情報をチェックする
        /// </summary>
        private bool ValidSP()
        {
            //SPWebSiteが未入力の場合
            if (string.IsNullOrEmpty(this.txtSPWebSite.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotSPWebSite);
                FocusControl(this.txtSPWebSite);
                return false;
            }

            //SPUserIDが未入力の場合
            if (string.IsNullOrEmpty(this.txtSPUser.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotSPUserID);
                FocusControl(this.txtSPUser);
                return false;
            }

            //SPPasswordが未入力の場合
            if (string.IsNullOrEmpty(this.txtSPPassword.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotSPPassword);
                FocusControl(this.txtSPPassword);
                return false;
            }
            string website = this.txtSPWebSite.Text;
            string userId = this.txtSPUser.Text;
            string psw = this.txtSPPassword.Text;

            //SP接続できない
            SpAccessor spAccessor = Accessor.AccessorFactory.GetSpAccessor(website, userId, psw);
            if (!spAccessor.TryConnect())
            {
                RSM.ShowMessage(this, RS.Exclamations.SPConnectFailed);
                FocusControl(this.txtSPPassword);
                return false;
            }

            return true;
        }

        /// <summary>
        /// DB接続入力情報をチェックする
        /// </summary>
        private bool ValidDatabase()
        {
            //Serverが未入力の場合
            if (string.IsNullOrEmpty(this.txtSqlServer.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotServer);
                FocusControl(this.txtSqlServer);
                return false;
            }
            if (this.cmbAuthMode.SelectedItem == null)
            {
                RSM.ShowMessage(this, RS.Exclamations.NotAuthMode);
                FocusControl(this.cmbAuthMode);
                return false;
            }
            AuthenticateMode mode = ((ListItem<AuthenticateMode>)this.cmbAuthMode.SelectedItem).Value;
            if (mode == AuthenticateMode.SqlServer)
            {
                //DB UserIDが未入力の場合
                if (string.IsNullOrEmpty(this.txtDbUserId.Text))
                {
                    RSM.ShowMessage(this, RS.Exclamations.NotDBUserID);
                    FocusControl(this.txtDbUserId);
                    return false;
                }
                //DB Passwordが未入力の場合
                if (string.IsNullOrEmpty(this.txtDBPassword.Text))
                {
                    RSM.ShowMessage(this, RS.Exclamations.NotDBPassword);
                    FocusControl(this.txtDBPassword);
                    return false;
                }
            }
            string database = "";
            if (cmbDataBase.SelectedItem != null)
            {
                database = (string)cmbDataBase.SelectedItem;
            }
            if (string.IsNullOrEmpty(database))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotDataBase);
                return false;
            }
            string server = this.txtSqlServer.Text;
            string userId = this.txtDbUserId.Text;
            string psw = this.txtDBPassword.Text;

            //SQL Serve接続テスト
            using (SqlAccessor sqlAccessor = Accessor.AccessorFactory.GetSqlAccessor(mode, server, userId, psw, database))
            {
                if (!sqlAccessor.TryConnect())
                {
                    RSM.ShowMessage(this, RS.Exclamations.DbConnectFailed);
                    FocusControl(this.txtSqlServer);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// DB接続入力情報をチェックする(非同期で呼び出す)
        /// </summary>
        private void ValidDatabaseAsync()
        {
            //Serverが未入力の場合
            if (string.IsNullOrEmpty(this.txtSqlServer.Text))
            {
                return;
            }
            if (this.cmbAuthMode.SelectedItem == null)
            {
                return;
            }
            AuthenticateMode mode = ((ListItem<AuthenticateMode>)this.cmbAuthMode.SelectedItem).Value;
            if (mode == AuthenticateMode.SqlServer)
            {
                //DB UserIDが未入力の場合
                if (string.IsNullOrEmpty(this.txtDbUserId.Text))
                {
                    return;
                }
                //DB Passwordが未入力の場合
                if (string.IsNullOrEmpty(this.txtDbUserId.Text))
                {
                    return;
                }
            }
            string database = "";
            if (cmbDataBase.SelectedItem != null)
            {
                database = (string)cmbDataBase.SelectedItem;
            }
            string server = this.txtSqlServer.Text;
            string userId = this.txtDbUserId.Text;
            string psw = this.txtDBPassword.Text;

            //SQL Serve接続テスト
            SqlAccessor sqlAccessor = Accessor.AccessorFactory.GetSqlAccessor(mode, server, userId, psw, database);
            //データベースリスト更新
            InitDatabaseListAsync(sqlAccessor);
        }

        private bool InitDatabaseList(SqlAccessor sqlAccessor)
        {
            cmbDataBase.Items.Clear();
            if (!sqlAccessor.TryConnect()) { return false; }
            List<string> dbs = sqlAccessor.GetDatabases();
            cmbDataBase.Items.AddRange(dbs.ToArray());
            return true;
        }

        private async void InitDatabaseListAsync(SqlAccessor sqlAccessor)
        {
            cmbDataBase.Items.Clear();
            List<string> dbs = await Task.Run(() =>
            {
                if (!sqlAccessor.TryConnect()) { return null; }
                return sqlAccessor.GetDatabases();
            });
            if (dbs == null)
            {
                return;
            }
            cmbDataBase.Items.AddRange(dbs.ToArray());
        }

        /// <summary>
        /// Configファイルを更新する
        /// </summary>
        private void SaveSettings()
        {
            //Notes
            Config.NotesPassword = this.txtNotesPassword.Text;
            Config.ExportFolder = this.txtOutputFolder.Text;
            //SharePoint
            Config.SPDefaultWebSite = this.txtSPWebSite.Text;
            Config.SPUserId = this.txtSPUser.Text;
            Config.SPPassword = this.txtSPPassword.Text;
            //SqlServer
            Config.SqlServer = this.txtSqlServer.Text;
            AuthenticateMode mode = ((ListItem<AuthenticateMode>)this.cmbAuthMode.SelectedItem).Value;
            if (mode == AuthenticateMode.SqlServer)
            {
                Config.DBUserId = this.txtDbUserId.Text;
                Config.DBPassWord = this.txtDBPassword.Text;
            }
            else
            {
                Config.DBUserId = "";
                Config.DBPassWord = "";
            }
            Config.DBAuthenticateMode = (int)mode;
            Config.DataBaseName = (string)this.cmbDataBase.SelectedItem;
            //保存する
            Config.Save();
        }

        private void FocusControl(Control ctrl)
        {
            ctrl.Focus();
            TabPage tab = FindTabPage(ctrl);
            if (tab != null)
            {
                this.tabMain.SelectedTab = tab;
            }

        }

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

        #region EventHandler
        private void EnvSettingForm_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void btnTryAccessNotes_Click(object sender, EventArgs e)
        {
            string password = this.txtNotesPassword.Text;
            NotesAccessor nsAccessor = Accessor.AccessorFactory.GetNotesAccessor();
            if (nsAccessor.TryConnect(password))
            {
                this.lblUserId.Text = nsAccessor.GetCurrentUser();
                RSM.ShowMessage(this, RS.Informations.TryConnectOK);
            }
            else
            {
                RSM.ShowMessage(this, RS.Exclamations.InvalidNotesPassword);
            }
        }
        /// <summary>
        /// 設定を保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidAllSettings())
            {
                return;
            }
            this.SaveSettings();
            this.Close();
        }
        /// <summary>
        /// 出力フォルダを指定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txtOutputFolder.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// SP接続テスト
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTryAccessSP_Click(object sender, EventArgs e)
        {
            if (ValidSP())
            {
                RSM.ShowMessage(this, RS.Informations.TryConnectOK);
            }
        }

        /// <summary>
        /// DB接続テスト
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTryAccessDB_Click(object sender, EventArgs e)
        {
            if (this.ValidDatabase())
            {
                RSM.ShowMessage(this, RS.Informations.TryConnectOK);
            }
        }


        /// <summary>
        /// 認証モード変換エベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAuthMode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbAuthMode.SelectedItem == null) return;
            AuthenticateMode mode = ((ListItem<AuthenticateMode>)(this.cmbAuthMode.SelectedItem)).Value;
            if (mode == AuthenticateMode.SqlServer)
            {
                this.txtDbUserId.Enabled = true;
                this.txtDbUserId.Clear();
                this.txtDBPassword.Enabled = true;
                this.txtDBPassword.Clear();
            }
            else
            {
                this.txtDbUserId.Enabled = false;
                this.txtDbUserId.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                this.txtDBPassword.Clear();
                this.txtDBPassword.Enabled = false;
            }
            this.cmbDataBase.Items.Clear();
            this.cmbDataBase.UseWaitCursor = true;
            this.ValidDatabaseAsync();
            this.cmbDataBase.UseWaitCursor = false;
        }
        /// <summary>
        /// Sql接続設定情報を変更する処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSqlServer_Leave(object sender, EventArgs e)
        {
            TextBox senderText = sender as TextBox;
            bool isChanged = true;
            if (senderText != null && senderText.Tag != null)
            {
                isChanged = !senderText.Text.Equals(senderText.Tag);
            }
            if (!isChanged)
            {
                return;
            }
            senderText.Tag = senderText.Text;
            this.cmbDataBase.Items.Clear();
            this.cmbDataBase.UseWaitCursor = true;
            this.ValidDatabaseAsync();
            this.cmbDataBase.UseWaitCursor = false;
        }
        #endregion


    }
}
