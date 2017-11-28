using RJ.Tools.NotesTransfer.Engines.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJ.Tools.NotesTransfer.UI.Forms
{
    public partial class MenuForm : FormBase
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
         
        }

        private void EnvSetting_Click(object sender, EventArgs e)
        {
            using (EnvSettingForm form = new EnvSettingForm())
            {
                form.ShowDialog(this);
            } 
        }

        private void btnDBSetting_Click(object sender, EventArgs e)
        {
            using (NotesSettingList form = new NotesSettingList())
            {
                form.ShowDialog(this);
            } 
        }

        private void FormSetting_Click(object sender, EventArgs e)
        {
            IForm selectedForm = null;
            bool selected = false;
            using (FormSelectDialog form = new FormSelectDialog())
            {
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    selectedForm = form.SelectedForm;
                    selected = true;
                }
            }
            if (!selected)
            {
                return;
            }
            using (FormSetting formSetting = new FormSetting())
            {
                formSetting.TargetForm = selectedForm;
                formSetting.ShowDialog(this);
            } 

        }

        private void ViewSetting_Click(object sender, EventArgs e)
        {
            IView selectedView = null;
            bool selected = false;
            using (ViewSelectDialog form = new ViewSelectDialog())
            {
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    selectedView = form.SelectedView;
                    selected = true;
                }
            }
            if (!selected)
            {
                return;
            }
            using (ViewSetting form = new ViewSetting())
            {
                form.TargetView = selectedView;
                form.ShowDialog(this);
            } 
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            using (LogAdmin form = new LogAdmin())
            {
                form.ShowDialog(this);
            }
        }
        /// <summary>
        /// データ変換処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDataConvert_Click(object sender, EventArgs e)
        {
            using (ConvertTaskList taskForm = new ConvertTaskList())
            {
                taskForm.ShowDialog(this);
            }
        }

   
    }
}
