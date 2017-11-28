using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RJ.Tools.NotesTransfer.Engines.Design;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.SqlServer;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;
using System.Reflection;
using RJ.Tools.NotesTransfer.Engines.Notes.Entity;
using System.Collections;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Entity;
using RJ.Tools.NotesTransfer.Engines.Common;

namespace RJ.Tools.NotesTransfer.UI.Forms
{
    public partial class ViewSetting : FormBase
    {

        #region Enum
        public enum TabRegion
        {
            /// <summary>
            /// 表示列
            /// </summary>
            DisplayColumn,
            /// <summary>
            /// 並び替え
            /// </summary>
            SortColumn,
            /// <summary>
            /// グループ化
            /// </summary>
            GroupColumn,
            /// <summary>
            /// フィルター
            /// </summary>
            Filter
        }

        #endregion

        #region Constructor
        public ViewSetting()
        {
            InitializeComponent();
        }
        #endregion

        #region Field
        private IView _targetView;
        private List<IFieldRef> _AllFields;
        #endregion

        #region Property
        public IView TargetView
        {
            get
            {
                return this._targetView;
            }
            set
            {
                this._targetView = value;
            }

        }
        public List<IFieldRef> AllFields
        {
            get
            {
                if (this._AllFields == null)
                {
                    this._AllFields = this.GetAllFields(this._targetView.TaskId);
                }
                return this._AllFields;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 画面を初期化する
        /// </summary>
        private void InitControls()
        {
            if (this._targetView == null)
            {
                return;
            }
            //対象ビューのフィールド参照を更新する
            this._targetView.RefreshFieldRef(FindField);
            //対象ビューの設定
            this.InitViewSettingTab();
            //表示列設定
            this.InitDisplayColumnTab();
            //並び順列設定
            this.InitSortColumnTab();
            //グループ化設定
            this.InitGroupColumnTab();
            //フィルタ設定
            this.InitConditionTab();
            //ボタン状態を更新する
            SetButtonsStatus();
        }

        /// <summary>
        /// フィールドを取得する
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public IFieldRef FindField(string fieldName)
        {

            foreach (IFieldRef fld in this.AllFields)
            {
                if (fld.Name.Equals(fieldName, StringComparison.OrdinalIgnoreCase))
                {
                    return fld;
                }
            }
            return null;
        }

        /// <summary>
        /// すべてフィールドリストを取得する
        /// </summary>
        /// <returns></returns>
        private List<IFieldRef> GetAllFields(string taskId)
        {
            List<IFieldRef> retList = null;
            using (SqlAccessor accessor = Accessor.AccessorFactory.GetSqlAccessor())
            {
                retList = accessor.GetAllFieldRefs(taskId);
            }
            if (retList == null)
            {
                retList = new List<IFieldRef>();
            }
            return retList;
        }

        /// <summary>
        /// 対象ビューの設定
        /// </summary>
        private void InitViewSettingTab()
        {
            this.txtViewTitle.Text = this._targetView.DisplayName;
            this.txtAliases.Text = this._targetView.GetAliasesString();
            this.rdbConvert.Checked = this._targetView.IsTarget;
            this.rdbNotConvert.Checked = !this._targetView.IsTarget;
            this.numLimitRow.Value = this._targetView.RowLimit;
            this.chkDefault.Checked = this._targetView.IsDefault;
            this.chkShowCheckboxs.Checked = this._targetView.ShowChecked;
        }
        /// <summary>
        /// 表示列タブを初期化する
        /// </summary>
        private void InitDisplayColumnTab()
        {
            this.txtFormula.Text = "";
            //ノーツ列情報
            this.InitNotesColumns();
            //表示列ビューを更新する
            this.InitDisplayColumns();
        }
        /// <summary>
        /// 表示列を更新する
        /// </summary>
        private void InitDisplayColumns()
        {
            this.lsvFields.BeginUpdate();
            this.lsvColumns.BeginUpdate();
            try
            {
                //フィールド列情報
                this.InitFieldColumns(this.lsvFields, this._targetView.ViewColumns);
                //表示列情報
                this.InitViewColumns(this.lsvColumns, this._targetView.ViewColumns, false);
            }
            finally
            {
                this.lsvFields.EndUpdate();
                this.lsvColumns.EndUpdate();
            }
        }

        /// <summary>
        /// 並び順タブを初期化する
        /// </summary>
        private void InitSortColumnTab()
        {
            this.lsvFieldsForSort.BeginUpdate();
            this.lsvSortColumn.BeginUpdate();
            try
            {
                //フィールド列情報
                this.InitFieldColumns(this.lsvFieldsForSort, this._targetView.SortColumns);
                //並び列情報
                this.InitViewColumns(this.lsvSortColumn, this._targetView.SortColumns, true);
            }
            finally
            {
                this.lsvFieldsForSort.EndUpdate();
                this.lsvSortColumn.EndUpdate();
            }
        }
        /// <summary>
        /// グループタブを初期化する
        /// </summary>
        private void InitGroupColumnTab()
        {
            this.lsvFieldForGroup.BeginUpdate();
            this.lsvGroupColumns.BeginUpdate();
            try
            {
                //フィールド列情報
                this.InitFieldColumns(this.lsvFieldForGroup, this._targetView.GroupColumns);
                //グループ列情報
                this.InitViewColumns(this.lsvGroupColumns, this._targetView.GroupColumns, false);
            }
            finally
            {
                this.lsvFieldForGroup.EndUpdate();
                this.lsvGroupColumns.EndUpdate();
            }

        }
        /// <summary>
        /// フィルタ設定
        /// </summary>
        private void InitConditionTab()
        {
            //ビューの選択式
            this.txtSelectionFormula.Text = this._targetView.SelectionFormula;
            //フィールドリストを初期化する
            this.cmbFields.Items.Clear();
            this.cmbFields.DisplayMember = "Title";
            this.cmbFields.ValueMember = "Name";
            foreach (IFieldRef fld in this.AllFields)
            {
                if (fld.TargetType != Engines.Enums.SPFieldType.Invalid)
                {
                    this.cmbFields.Items.Add(fld);
                }
            }
            //条件式
            LogicItem logitem = this._targetView.ViewCondition;
            if (logitem.Nodes.Count == 0)
            {
                this.rdbAllSelect.Checked = true;
            }
            else
            {
                this.rdbHasCondition.Checked = true;
            }
            //Logicパネル
            this.rdbAnd.Checked = (logitem.Type == LogicType.And);
            this.rdbOr.Checked = (logitem.Type == LogicType.Or);
            //比較子リストを初期化
            InitOperatorList();
            //ツリー初期化
            InitConditionTree();
      
        }
        /// <summary>
        ///  条件式ツリーを初期化する
        /// </summary>
        private void InitConditionTree()
        {
            this.treeCondition.Nodes.Clear();
            TreeNode rootNode = this.treeCondition.Nodes.Add(this._targetView.ViewCondition.TagName);
            rootNode.Tag = this._targetView.ViewCondition;
            InitConditionTree(rootNode, this._targetView.ViewCondition);
            rootNode.ExpandAll();
        }

        private void InitConditionTree(TreeNode parentNode, LogicItem rootItem)
        {
            foreach (IConditionItem item in this._targetView.ViewCondition.Nodes)
            {
                if (item is ConditionItem)
                {
                    ConditionItem condiItem = (ConditionItem)item;
                    TreeNode condiNode = parentNode.Nodes.Add(item.ToString());
                    condiNode.Tag = item;
                }
                else
                {
                    //未使用
                    LogicItem logicItem = (LogicItem)item;
                    TreeNode logicNode = parentNode.Nodes.Add(logicItem.TagName);
                    logicNode.Tag = logicItem;
                    InitConditionTree(logicNode, logicItem);
                }
            }
        }

        private void InitOperatorList()
        {
            this.cmbOperator.Items.Clear();
            this.cmbOperator.DisplayMember = "DisplayName";
            this.cmbOperator.ValueMember = "EnumValue";
            var mems = typeof(OperatorType).GetMembers(BindingFlags.Public | BindingFlags.Static);
            foreach (MemberInfo info in mems)
            {
                object[] customAttributes = info.GetCustomAttributes(typeof(EnumNameAttribute), true);
                if (customAttributes.Count() > 0)
                {
                    EnumNameAttribute item = (EnumNameAttribute)customAttributes[0];
                    this.cmbOperator.Items.Add(item);
                }
            }
        }



        /// <summary>
        /// 列設定情報リストビューを初期化する
        /// </summary>
        /// <param name="lstView"></param>
        /// <param name="columns"></param>
        /// <param name="showAsc"></param>
        private void InitViewColumns(ListView lstView, List<IViewColumn> columns, bool showAsc)
        {
            lstView.Items.Clear();
            foreach (IViewColumn column in columns)
            {
                IFieldRef fld = column.FieldRef;
                if (fld == null)
                {
                    continue;
                }
                string name = string.IsNullOrEmpty(fld.Title) ? fld.Name : fld.Title;
                ListViewItem lvItem = lstView.Items.Add(name);
                lvItem.SubItems.Add(GetEnumName(fld.TargetType));
                if (showAsc)
                {
                    string desc = column.IsSortDescending ? "降順" : "昇順";
                    lvItem.SubItems.Add(desc);
                }
                lvItem.Tag = column;
            }
        }

        /// <summary>
        /// ノーツ列情報を初期化する
        /// </summary>
        private void InitFieldColumns(ListView lstView, List<IViewColumn> addedColumns)
        {
            lstView.Items.Clear();
            var addedFlds = addedColumns.Select(column => column.FieldRef).ToList();
            var LeftFlds = this.AllFields.Except(addedFlds);
            foreach (IFieldRef fld in LeftFlds)
            {
                if (fld.TargetType == Engines.Enums.SPFieldType.Invalid)
                {
                    continue;
                }
                string name = string.IsNullOrEmpty(fld.Title) ? fld.Name : fld.Title;
                ListViewItem lvItem = lstView.Items.Add(name);
                lvItem.SubItems.Add(GetEnumName(fld.TargetType));
                lvItem.Tag = fld;
            }
        }


        /// <summary>
        /// Enum項目表示名を取得する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetEnumName(Enum value)
        {
            MemberInfo[] mems = value.GetType().GetMember(value.ToString());
            if (mems != null && mems.Length > 0)
            {
                object[] customAttributes = mems[0].GetCustomAttributes(typeof(EnumNameAttribute), true);
                if (customAttributes.Count() > 0)
                {
                    EnumNameAttribute attribute = (EnumNameAttribute)customAttributes[0];
                    return attribute.DisplayName;
                }
            }
            return value.ToString();
        }
        /// <summary>
        /// データベースフィールド一覧を初期化する
        /// </summary>
        private void InitNotesColumns()
        {
            this.lsvNotesViewColumn.Items.Clear();
            foreach (IViewColumn column in this._targetView.SourceViewColumns)
            {
                string name = string.IsNullOrEmpty(column.Title) ? "無題" : column.Title;
                ListViewItem lvItem = this.lsvNotesViewColumn.Items.Add(name);
                if (column.IsField)
                {
                    lvItem.SubItems.Add(column.ItemName);
                }
                else
                {
                    lvItem.SubItems.Add("");
                }
                if (column.CanConvert)
                {
                    lvItem.SubItems.Add("可能");
                }
                else
                {
                    lvItem.SubItems.Add("不可");
                }
                lvItem.Tag = column;
            }
        }

        /// <summary>
        /// 入力内容チェック
        /// </summary>
        /// <returns></returns>
        private bool ValidateInputs()
        {
            //ビュータイトル
            if (string.IsNullOrWhiteSpace(this.txtViewTitle.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotViewTitle);
                FocusControl(this.txtViewTitle);
                return false;
            }
            //ビュー表示列
            if (this.lsvColumns.Items.Count==0)
            {
                RSM.ShowMessage(this, RS.Exclamations.NotDisplayColumn);
                FocusControl(this.txtViewTitle);
                return false;
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

        /// <summary>
        /// ボタン状態変換
        /// </summary>
        /// <param name="tabRegion"></param>
        private void SetButtonsStatus()
        {
            //表示列
            this.btnAddColumn.Enabled = (this.lsvFields.SelectedItems.Count > 0);
            bool enabledFlg = (this.lsvColumns.SelectedItems.Count > 0);
            this.btnDeleteColumn.Enabled = enabledFlg;
            this.btnColumnUp.Enabled = enabledFlg;
            this.btnColumnDown.Enabled = enabledFlg;
            //グループ列
            this.btnAddGroup.Enabled = (this.lsvFieldForGroup.SelectedItems.Count > 0);
            enabledFlg = (this.lsvGroupColumns.SelectedItems.Count > 0);
            this.btnDeleteGroup.Enabled = enabledFlg;
            this.btnGroupUp.Enabled = enabledFlg;
            this.btnGroupDown.Enabled = enabledFlg;
            //並び替え
            this.btnAddOrder.Enabled = (this.lsvFieldsForSort.SelectedItems.Count > 0);
            enabledFlg = (this.lsvSortColumn.SelectedItems.Count > 0);
            this.btnDeleteOrder.Enabled = enabledFlg;
            this.btnOrderUp.Enabled = enabledFlg;
            this.btnOrderDown.Enabled = enabledFlg;
            this.rdbAsc.Enabled = enabledFlg;
            this.rdbDesc.Enabled = enabledFlg;
            this.btnSortType.Enabled = enabledFlg;
            //フィルター
            this.btnAddFilter.Enabled = (cmbFields.SelectedIndex == -1);
            //条件式
            enabledFlg = this.rdbHasCondition.Checked;
            this.LogicPanel.Enabled = enabledFlg;
            this.ConditionPanel.Enabled = enabledFlg;
            treeCondition.Enabled = enabledFlg;
            btnSetLogicType.Enabled = enabledFlg;
            btnAddFilter.Enabled = enabledFlg;
            btnDeleteFilter.Enabled = enabledFlg;
        }
        /// <summary>
        /// リストのノードを交換する
        /// </summary>
        /// <param name="objArray"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        private void SwapNode(IList objArray, int index1, int index2)
        {
            if (objArray == null) return;
            if (index1 < 0 || index1 > objArray.Count - 1) return;
            if (index2 < 0 || index2 > objArray.Count - 1) return;
            if (index1 == index2) return;

            object obj1 = objArray[index1];
            object obj2 = objArray[index2];

            objArray.Remove(obj2);
            objArray.Remove(obj1);

            if (index1 < index2)
            {
                objArray.Insert(index1, obj2);
                objArray.Insert(index2, obj1);
            }
            else
            {
                objArray.Insert(index2, obj1);
                objArray.Insert(index1, obj2);
            }
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewSetting_Load(object sender, EventArgs e)
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



        /// <summary>
        /// 表示列追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvFields.SelectedItems.Count == 0)
                {
                    return;
                }
                IFieldRef fld = this.lsvFields.SelectedItems[0].Tag as IFieldRef;
                this._targetView.ViewColumns.Add(new ViewColumn(fld));
                InitDisplayColumns();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }


        /// <summary>
        /// 表示列削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteColumn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvColumns.SelectedItems.Count == 0)
                {
                    return;
                }
                IViewColumn column = this.lsvColumns.SelectedItems[0].Tag as IViewColumn;
                this._targetView.ViewColumns.Remove(column);
                InitDisplayColumns();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        ///　列項目UP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColumnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvColumns.SelectedItems.Count == 0) return;
                int index1 = this.lsvColumns.SelectedIndices[0];
                if (index1 == 0) return;
                int index2 = index1 - 1;
                this.SwapNode(this._targetView.ViewColumns, index1, index2);
                this.SwapNode(this.lsvColumns.Items, index1, index2);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// 列項目Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColumnDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvColumns.SelectedItems.Count == 0) return;
                int index1 = this.lsvColumns.SelectedIndices[0];
                if (index1 == this.lsvColumns.Items.Count - 1) return;
                int index2 = index1 + 1;
                this.SwapNode(this._targetView.ViewColumns, index1, index2);
                this.SwapNode(this.lsvColumns.Items, index1, index2);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }

        /// <summary>
        /// ソート項目追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvFieldsForSort.SelectedItems.Count == 0)
                {
                    return;
                }
                IFieldRef fld = this.lsvFieldsForSort.SelectedItems[0].Tag as IFieldRef;
                this._targetView.SortColumns.Add(new ViewColumn(fld, false));
                InitSortColumnTab();

            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// ソート項目削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvSortColumn.SelectedItems.Count == 0)
                {
                    return;
                }
                IViewColumn column = this.lsvSortColumn.SelectedItems[0].Tag as IViewColumn;
                this._targetView.SortColumns.Remove(column);
                InitSortColumnTab();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// ソートリスト項目選択変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsvSortColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetButtonsStatus();
            if (this.lsvSortColumn.SelectedItems.Count == 0)
            {
                return;
            }
            IViewColumn column = this.lsvSortColumn.SelectedItems[0].Tag as IViewColumn;
            this.rdbDesc.Checked = column.IsSortDescending;
            this.rdbAsc.Checked = !column.IsSortDescending;
        }

        /// <summary>
        /// ソート種別設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSortType_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvSortColumn.SelectedItems.Count == 0)
                {
                    return;
                }
                ListViewItem lvItem = this.lsvSortColumn.SelectedItems[0];
                IViewColumn column = lvItem.Tag as IViewColumn;
                column.IsSortDescending = this.rdbDesc.Checked;
                string desc = column.IsSortDescending ? "降順" : "昇順";
                lvItem.SubItems[2].Text = desc;
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// ソート項目UP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrderUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvSortColumn.SelectedItems.Count == 0) return;
                int index1 = this.lsvSortColumn.SelectedIndices[0];
                if (index1 == 0) return;
                int index2 = index1 - 1;
                this.SwapNode(this._targetView.SortColumns, index1, index2);
                this.SwapNode(this.lsvSortColumn.Items, index1, index2);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// ソート項目Dowm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrderDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvSortColumn.SelectedItems.Count == 0) return;
                int index1 = this.lsvSortColumn.SelectedIndices[0];
                if (index1 == this.lsvSortColumn.Items.Count - 1) return;
                int index2 = index1 + 1;
                this.SwapNode(this._targetView.SortColumns, index1, index2);
                this.SwapNode(this.lsvSortColumn.Items, index1, index2);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// グループ項目追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvFieldForGroup.SelectedItems.Count == 0)
                {
                    return;
                }
                IFieldRef fld = this.lsvFieldForGroup.SelectedItems[0].Tag as IFieldRef;
                this._targetView.GroupColumns.Add(new ViewColumn(fld));
                InitGroupColumnTab();

            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// グループ項目削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvGroupColumns.SelectedItems.Count == 0)
                {
                    return;
                }
                IViewColumn column = this.lsvGroupColumns.SelectedItems[0].Tag as IViewColumn;
                this._targetView.GroupColumns.Remove(column);
                InitGroupColumnTab();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// グループ項目UPへ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGroupUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvGroupColumns.SelectedItems.Count == 0) return;
                int index1 = this.lsvGroupColumns.SelectedIndices[0];
                if (index1 == 0) return;
                int index2 = index1 - 1;
                this.SwapNode(this._targetView.GroupColumns, index1, index2);
                this.SwapNode(this.lsvGroupColumns.Items, index1, index2);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// グループ項目DOWNへ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGroupDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvGroupColumns.SelectedItems.Count == 0) return;
                int index1 = this.lsvGroupColumns.SelectedIndices[0];
                if (index1 == this.lsvGroupColumns.Items.Count - 1) return;
                int index2 = index1 + 1;
                this.SwapNode(this._targetView.GroupColumns, index1, index2);
                this.SwapNode(this.lsvGroupColumns.Items, index1, index2);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// ロジックタイプ変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetLogicType_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeCondition.Nodes.Count == 0) return;
                TreeNode root = this.treeCondition.Nodes[0];
                LogicItem logitem = (LogicItem)root.Tag;
                if (this.rdbAnd.Checked)
                {
                    logitem.Type = LogicType.And;
                }
                else
                {
                    logitem.Type = LogicType.Or;
                }
                root.Text = logitem.TagName;

            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }

        /// <summary>
        /// フィルター条件追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbFields.SelectedItem == null)
                {
                    return;
                }
                if (this.cmbOperator.SelectedItem == null)
                {
                    return;
                }
                EnumNameAttribute selectedItem = (EnumNameAttribute)this.cmbOperator.SelectedItem;
                OperatorType op = (OperatorType)selectedItem.EnumValue;
                ConditionItem condiItem = new ConditionItem(op);
                condiItem.FieldRef = (IFieldRef)this.cmbFields.SelectedItem;
                condiItem.Value = this.txtValue.Text;
                this._targetView.ViewCondition.Nodes.Add(condiItem);
                InitConditionTree();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// フィルター条件削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeCondition.SelectedNode == null || 
                    this.treeCondition.SelectedNode.Tag == null)
                {
                    return;
                }
                object selectedItem = this.treeCondition.SelectedNode.Tag;
                if (selectedItem is LogicItem)
                {
                    return;
                }
                else if (selectedItem is ConditionItem)
                {
                    ConditionItem condiItem = (ConditionItem)selectedItem;
                    this._targetView.ViewCondition.Nodes.Remove(condiItem);
                }
                InitConditionTree();

            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                {
                    return;
                }
                //入力値を変更
                //表示名
                this._targetView.DisplayName = this.txtViewTitle.Text;
                //変換対象
                this._targetView.IsTarget = this.rdbConvert.Checked;
                //アイテム数
                this._targetView.RowLimit = (int)this.numLimitRow.Value;
                //既定のビュー
                this._targetView.IsTarget = this.chkDefault.Checked;
                //チェックボックス表示
                this._targetView.ShowChecked = this.chkDefault.Checked;
                using (SqlAccessor sqlAccessor = Accessor.AccessorFactory.GetSqlAccessor())
                {
                    sqlAccessor.UpdateMigrateView(this._targetView);
                }
                Log.Write(this.TargetView.TaskId, RSM.GetMessage(RS.Informations.ViewSetted, this.TargetView.Name));
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }


        /// <summary>
        /// キャンセル
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// 列情報選択する場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsvNotesViewColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lsvNotesViewColumn.SelectedItems.Count == 0)
            {
                this.txtFormula.Text = "";
                return;
            }
            IViewColumn column = this.lsvNotesViewColumn.SelectedItems[0].Tag as IViewColumn;
            if (column == null) return;
            this.txtFormula.Text = column.Formula;
        }

        /// <summary>
        /// 表示列リストの選択状態を変更する場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewColumnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetButtonsStatus();
        }
        /// <summary>
        /// 検索条件ツリーを選択する処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeCondition_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.treeCondition.SelectedNode == null ||
                this.treeCondition.SelectedNode.Tag == null)
            {
                return;
            }
            object selectedItem = this.treeCondition.SelectedNode.Tag;
            if (selectedItem is LogicItem)
            {
                LogicItem logItem = (LogicItem)selectedItem;
                this.rdbAnd.Checked = (logItem.Type == LogicType.And);
                this.rdbOr.Checked = (logItem.Type == LogicType.Or);
            }
            else if (selectedItem is ConditionItem)
            {
                ConditionItem condiItem = (ConditionItem)selectedItem;
                this.cmbFields.SelectedValue = condiItem.ItemName;
                this.cmbOperator.SelectedValue = condiItem.Operator;
                this.txtValue.Text = condiItem.Value.ToString();
            }
        }
        /// <summary>
        /// すべてのアイテム表示／条件付き表示の切り替え処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            this.SetButtonsStatus();
        }

        #endregion














    }
}
