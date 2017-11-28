
using RJ.Tools.NotesTransfer.Engines.Common;
using RJ.Tools.NotesTransfer.Engines.Design;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.SqlServer;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;


namespace RJ.Tools.NotesTransfer.UI.Forms
{
    public partial class FormSetting : FormBase
    {

        private const string HALF_ALFA_REGEX = @"^[a-zA-Z-_]+[0-9a-zA-Z-_]*$";

        private PreViewForm previewForm = null;

        public FormSetting()
        {
            InitializeComponent();
        }

        public IForm TargetForm
        {
            get;
            set;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSetting_Load(object sender, EventArgs e)
        {
            if (this.TargetForm == null)
            {
                return;
            }
            InitControls();
        }
        /// <summary>
        /// 画面を初期化する
        /// </summary>
        private void InitControls()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.txtDisplayName.Text = TargetForm.Name;
            this.txtAliases.Text = TargetForm.GetAliasesString();
            this.rdoIsTarget.Checked = TargetForm.IsTarget;
            this.rdoNotTarget.Checked = !TargetForm.IsTarget;
            this.chkHasNewForm.Checked = TargetForm.HasNewForm;
            this.chkHasEditForm.Checked = TargetForm.HasEditForm;
            this.chkHasDispForm.Checked = TargetForm.HasDispForm;
            this.chkDefaultDisp.Checked = TargetForm.IsDefaultDispForm;
            this.chkDefaultEdit.Checked = TargetForm.IsDefaultEditForm;
            this.chkDefaultNew.Checked = TargetForm.IsDefaultNewForm;
            this.txtNewFormName.Text = GetNameWithoutExt(TargetForm.NewFormName);
            this.txtEditFormName.Text = GetNameWithoutExt(TargetForm.EditFormName);
            this.txtDispFormName.Text = GetNameWithoutExt(TargetForm.DispFormName);
            FormStateChange();
            InitFields();
        }
        /// <summary>
        /// 状態変更
        /// </summary>
        private void FormStateChange()
        {
            this.NewFormPanel.Enabled = this.chkHasNewForm.Checked;
            this.EditFormPanel.Enabled = this.chkHasEditForm.Checked;
            this.DispFormPanel.Enabled = this.chkHasDispForm.Checked;
        }
        /// <summary>
        ///  指定したパス文字列のファイル名を拡張子を付けずに返します。
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetNameWithoutExt(string fileName)
        {
            return System.IO.Path.GetFileNameWithoutExtension(fileName);
        }

        private void InitFields()
        {
            //this.lsvFields.Items.Clear();
            //foreach (IField field in TargetForm.Fields)
            //{
            //    string name = string.IsNullOrEmpty(field.Title) ? field.Name : field.Title;
            //    ListViewItem vwItem = this.lsvFields.Items.Add(name);
            //    vwItem.SubItems.Add(GetEnumName(field.SourceType));
            //    vwItem.SubItems.Add(GetEnumName(field.TargetType));
            //    vwItem.Tag = field;
            //}
            this.dataGridView1.DataSource = this.TargetForm.Fields;
        }

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
        /// 入力検証
        /// </summary>
        /// <returns></returns>
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(this.txtDisplayName.Text))
            {
                RSM.ShowMessage(this, RS.Exclamations.NotFormName);
                FocusControl(this.txtDisplayName);
                return false;
            }
            //作成フォーム
            if (this.chkHasNewForm.Checked)
            {
                if (string.IsNullOrWhiteSpace(this.txtNewFormName.Text))
                {
                    RSM.ShowMessage(this, RS.Exclamations.NotNewFormName);
                    FocusControl(this.txtNewFormName);
                    return false;
                }
                //半角チェック
                string fielName = this.txtNewFormName.Text;
                if (!Regex.Match(fielName, HALF_ALFA_REGEX).Success)
                {
                    RSM.ShowMessage(this, RS.Exclamations.InvalidateNewFormName);
                    FocusControl(this.txtNewFormName);
                    return false;
                }
            }
            //編集フォーム
            if (this.chkHasEditForm.Checked)
            {
                if (string.IsNullOrWhiteSpace(this.txtEditFormName.Text))
                {
                    RSM.ShowMessage(this, RS.Exclamations.NotEditFormName);
                    FocusControl(this.txtEditFormName);
                    return false;
                }
                //半角チェック
                string fielName = this.txtEditFormName.Text;
                if (!Regex.Match(fielName, HALF_ALFA_REGEX).Success)
                {
                    RSM.ShowMessage(this, RS.Exclamations.InvalidateEditFormName);
                    FocusControl(this.txtEditFormName);
                    return false;
                }
            }
            //表示フォーム
            if (this.chkHasDispForm.Checked)
            {
                if (string.IsNullOrWhiteSpace(this.txtDispFormName.Text))
                {
                    RSM.ShowMessage(this, RS.Exclamations.NotDispFormName);
                    FocusControl(this.txtDispFormName);
                    return false;
                }
                //半角チェック
                string fielName = this.txtDispFormName.Text;
                if (!Regex.Match(fielName, HALF_ALFA_REGEX).Success)
                {
                    RSM.ShowMessage(this, RS.Exclamations.InvalidateDispFormName);
                    FocusControl(this.txtDispFormName);
                    return false;
                }
            }
            //入力値を設定する
            IForm formItem = this.TargetForm;
            formItem.DisplayName = this.txtDisplayName.Text;
            formItem.HasNewForm = this.chkHasNewForm.Checked;
            formItem.HasEditForm = this.chkHasEditForm.Checked;
            formItem.HasDispForm = this.chkHasDispForm.Checked;
            if (formItem.HasNewForm)
            {
                formItem.NewFormName = this.txtNewFormName.Text + ".aspx";
            }

            if (formItem.HasEditForm)
            {
                formItem.EditFormName = this.txtEditFormName.Text + ".aspx";
            }
            if (formItem.HasDispForm)
            {
                formItem.DispFormName = this.txtDispFormName.Text + ".aspx";
            }
            formItem.IsDefaultDispForm = this.chkDefaultDisp.Checked;
            formItem.IsDefaultEditForm = this.chkDefaultEdit.Checked;
            formItem.IsDefaultNewForm = this.chkDefaultNew.Checked;
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


        private IField GetFieldTypeDescriptor(IField field)
        {
            var provider = TypeDescriptor.GetProvider(typeof(IField));
            TypeDescriptor.AddProvider(new FieldDescriptionProvider(provider), field);
            return field;
        }

        private void HasNewForm_CheckedChanged(object sender, EventArgs e)
        {
            FormStateChange();
        }

        private void HasEditForm_CheckedChanged(object sender, EventArgs e)
        {
            FormStateChange();
        }

        private void HasDispForm_CheckedChanged(object sender, EventArgs e)
        {
            FormStateChange();
        }

        private void CloseBUtton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// フィールド属性変更された場合
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void OnPropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if ((this.propertyGrid1.SelectedObject == null) ||
               !(this.propertyGrid1.SelectedObject is IField))
            {
                return;
            }
            IField selectedFld = (IField)this.propertyGrid1.SelectedObject;
            this.dataGridView1.DataSource = this.TargetForm.Fields;

            switch (e.ChangedItem.PropertyDescriptor.Name)
            {
                case "Name":
                case "Title":
                case "TargetType":
                    this.propertyGrid1.SelectedObject = selectedFld;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 設定を保存する
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
                using (SqlAccessor sqlAccessor = Accessor.AccessorFactory.GetSqlAccessor())
                {
                    sqlAccessor.UpdateMigrateForm(this.TargetForm);
                }
                Log.Write(RSM.GetMessage(RS.Informations.FormSetted, this.TargetForm.Name));
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            IField fld = this.TargetForm.Fields[e.RowIndex];
            switch (e.ColumnIndex)
            {
                case 0:
                    //Required
                    break;
                case 1:
                    //TargetType
                    if (fld.TargetType != SPFieldType.Invalid)
                    {
                        e.Value = true;
                    }
                    else
                    {
                        e.Value = false;
                    }
                    break;
                case 2:
                    //Name
                    e.Value = fld.Name;
                    break;
                case 3:
                    //SourceType
                    e.Value = GetEnumName(fld.SourceType);
                    break;
                case 4:
                    //TargetType
                    e.Value = GetEnumName(fld.TargetType);
                    break;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var row = this.dataGridView1.SelectedRows[0];
            IField selField = this.TargetForm.Fields[row.Index];
            this.propertyGrid1.SelectedObject = GetFieldTypeDescriptor(selField);
        }

        private void Preview_Click(object sender, EventArgs e)
        {
            previewForm = new PreViewForm();
            previewForm.NotesForm = this.TargetForm;
            previewForm.Show(this);
        }

    }
}
