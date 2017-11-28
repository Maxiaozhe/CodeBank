using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableDesignInfo.Controls;

namespace TableDesignInfo.Forms
{
    public partial class DataView : Form
    {
        public DataView()
        {
            InitializeComponent();
        }

        public TableList Table
        {
            get;
            set;
        }

        private void InitDataView()
        {
            DataTable dtt = LinqSqlHelp.GetTableData(Table.TableName,10000);
           this.dataGridView.DataSource = dtt;
        }

        private void DataView_Load(object sender, EventArgs e)
        {
            try
            {
                long count = LinqSqlHelp.GetTableDataCount(Table.TableName);
                string tableName = string.IsNullOrEmpty(Table.TableDisplayName) ? Table.TableName : Table.TableDisplayName;
                this.Text = tableName + "(" + count + "件)";
                InitDataView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
