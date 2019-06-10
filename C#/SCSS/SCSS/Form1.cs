using CsQuery;
using Maxz.PoemSystem.Engine.Modules;
using Maxz.PoemSystem.Tools.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCSS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddBookIndex_Click(object sender, EventArgs e)
        {
            DataImports imports = new DataImports();
            imports.ImportBookIndex(@"C:\Users\maxz\Downloads\QuanTangshi_Index.txt", @"全唐诗", 1);
        }

        private void btnImportPoem_Click(object sender, EventArgs e)
        {
            DataImports imports = new DataImports();
            imports.ImportBook(@"C:\Users\maxz\Downloads\QuanTangshi.txt", 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataImports imports = new DataImports();
            imports.ImportCiBook(@"C:\Users\maxz\Downloads\quansongci3.txt", 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtStart.Text) || string.IsNullOrEmpty(txtEnd.Text))
                {
                    return;
                }
                int startId = 0;
                int endId = 0;
                if (!int.TryParse(txtStart.Text, out startId) || !int.TryParse(txtEnd.Text, out endId))
                {
                    return;
                }
                
                backgroundWorker1.RunWorkerAsync(new int[]{startId, endId });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          long maxId =  LinqSqlHelp.GetMaxId();
            this.txtStart.Text = maxId.ToString();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int[] arg = (int[])e.Argument;
            int startId = arg[0];
            int endId = arg[1];
            SouYunPoemCatcher catcher = new SouYunPoemCatcher();
            catcher.Report = this.Report;
            catcher.CatchResources(startId, endId);
        }

        private void Report(int percentage, Dictionary<string, string> result)
        {
            this.backgroundWorker1.ReportProgress(percentage, result);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Dictionary<string, string> result = e.UserState as Dictionary<string, string>;
            this.toolProgressBar.Value = e.ProgressPercentage;
            if (result != null)
            {
                this.toolCount.Text = result["count"];
                this.toolMessage.Text = result["message"];
                this.txtContent.Text = result["content"];
            }
        }
    }
}
