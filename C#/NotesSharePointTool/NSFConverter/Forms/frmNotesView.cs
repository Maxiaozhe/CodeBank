

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.Notes.Controls;


namespace RJ.Tools.NotesTransfer.UI.Forms
{
    public partial class frmNotesView : FormBase
    {
        private NotesAccessor noteAccessor;

        public frmNotesView()
        {
            InitializeComponent();
        }

   

        private void btnOpenDb_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                IDatabase db = noteAccessor.GetDataBase(this.openFileDialog1.FileName,"");
                AddForms(db);
            }
        }

        private void frmNotesView_Load(object sender, EventArgs e)
        {
            try
            {
                noteAccessor = NotesAccessor.CreateInstance();
                noteAccessor.TryConnect(Engines.Common.Config.NotesPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private TreeNode AddForms(IDatabase db)
        {
            TreeNode formRoot = this.treeView1.Nodes.Add("Form");
            List<IForm> forms =db.Forms;
            forms.ForEach(frm => AddForm(formRoot, frm));
            return formRoot;
        }

        private TreeNode AddForm(TreeNode parent, IForm form)
        {
            TreeNode node = parent.Nodes.Add(form.Name);
            node.Tag = form;
            return node;
        }
    }
}
