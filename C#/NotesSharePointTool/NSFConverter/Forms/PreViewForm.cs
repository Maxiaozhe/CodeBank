using RJ.Tools.NotesTransfer.Engines.Common;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.Notes.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;


namespace RJ.Tools.NotesTransfer.UI.Forms
{
    public partial class PreViewForm : Form
    {
        public PreViewForm()
        {
            InitializeComponent();
        }

        public IForm NotesForm
        {
            get;
            set;
        }

        private void InitHtml(IForm form)
        {
            DxlTransfer transfer = new DxlTransfer();
            string html = transfer.GetFormHtml(form.FormDxl, form.Name);
            this.webBrowser1.DocumentText = html;
            string tempDir = System.IO.Path.GetTempPath();
            string htmlFile = System.IO.Path.Combine(tempDir, "form" + form.FormNo + ".html");
            System.IO.File.WriteAllText(htmlFile, html, System.Text.Encoding.UTF8);
            this.webBrowser1.Url = new Uri(htmlFile);
        }

        private void PreViewForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitHtml(this.NotesForm);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this,ex);
            }
        }

    }
}
