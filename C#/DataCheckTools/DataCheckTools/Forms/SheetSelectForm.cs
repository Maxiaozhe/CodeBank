using Excel=Microsoft.Office.Interop.Excel;
using Rex.Tools.Test.DataCheck.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rex.Tools.Test.DataCheck.Forms
{
    public partial class SheetSelectForm : BaseForm
    {
        public SheetSelectForm()
        {
            InitializeComponent();
        }

        public string ExcelFileName
        {
            get;
            set;
        }

        public string Title
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        public string[] SelectedSheets
        {
            get
            {
                return this.GetSelectSheetNames();
            }
        }

        private void SheetSelectForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.InitControls();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logging.Exception("", ex);
            }
        }

        private string[] GetSelectSheetNames()
        {
            List<string> sheetNames = new List<string>();
            foreach (object item in this.checkedListBox1.CheckedItems)
            {
                sheetNames.Add((string)item);
            }
            return sheetNames.ToArray();
          
          }

        private void InitControls()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.checkedListBox1.Items.Clear();
                using (ExcelHelp xls = new ExcelHelp(this.ExcelFileName))
                {
                    foreach (Excel.Worksheet sheet in xls.WorkBook.Sheets)
                    {
                        if (sheet.Visible == Excel.XlSheetVisibility.xlSheetVisible)
                        {
                            this.checkedListBox1.Items.Add(sheet.Name);
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

  
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           string[] sheets= this.GetSelectSheetNames();
           if (sheets.Length == 0)
           {
               return;
           }
           this.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.Close();
        }


    }
}
