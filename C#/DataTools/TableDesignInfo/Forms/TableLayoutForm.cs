using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableDesignInfo.Controls;

namespace TableDesignInfo.Forms
{
    public partial class TableLayoutForm : Form
    {
        public TableLayoutForm()
        {
            InitializeComponent();
        }

        public TableList Table
        {
            get;
            set;
        }

        private void TableLayout_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void InitControls()
        {
            this.txtTableName.Text = Table.TableName;
            this.txtDisplayName.Text = Table.TableDisplayName;
            this.txtComment.Text = Table.Comment;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = LinqSqlHelp.GetTableLayout(this.Table.TableName);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.Table.IsChanged)
            {
                LinqSqlHelp.Update(this.Table);
            }

            EntitySet<TableLayoutInfo> columns = this.dataGridView1.DataSource as EntitySet<TableLayoutInfo>;
            if (columns != null)
            {
                var changedItems = columns.Where(T => T.IsChanged).ToList();
                LinqSqlHelp.Update(changedItems);
            }

        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            this.Table.Comment = this.txtComment.Text;
        }

        private void txtDisplayName_TextChanged(object sender, EventArgs e)
        {
            this.Table.TableDisplayName = this.txtDisplayName.Text;
        }

        private void mnuCreateSelect_Click(object sender, EventArgs e)
        {

            EntitySet<TableLayoutInfo> columns = this.dataGridView1.DataSource as EntitySet<TableLayoutInfo>;
            if (columns == null)
            {
                return;
            }
            using (InputForm form = new InputForm())
            {
                form.ForJoin = false;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    bool hasWhere = form.HasWhereCondition;
                    bool hasComment = form.HasComment;
                    string alias = form.AliasName;
                    string sql = GetSelectSql(columns, alias, hasWhere, hasComment);
                    Clipboard.SetText(sql);
                }
            }
        }
        /// <summary>
        /// 結合条件作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuJoinCondition_Click(object sender, EventArgs e)
        {
            EntitySet<TableLayoutInfo> columns = this.dataGridView1.DataSource as EntitySet<TableLayoutInfo>;
            if (columns == null)
            {
                return;
            }
            using (InputForm form = new InputForm())
            {
                form.ForJoin = true;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    string alias = form.AliasName;
                    string sql = this.GetJoinSql(columns, alias);
                    Clipboard.SetText(sql);
                }
            }
        }


        private void mnuCreateInsertSql_Click(object sender, EventArgs e)
        {
            EntitySet<TableLayoutInfo> columns = this.dataGridView1.DataSource as EntitySet<TableLayoutInfo>;
            if (columns == null)
            {
                return;
            }
            string sql = GetInsertSql(columns);
            Clipboard.SetText(sql);
        }
        private void mnuCreateSql_Click(object sender, EventArgs e)
        {
            EntitySet<TableLayoutInfo> columns = this.dataGridView1.DataSource as EntitySet<TableLayoutInfo>;
            if (columns == null)
            {
                return;
            }
            string sql = GetCreateSql(columns);
            Clipboard.SetText(sql);
        }


        private string GetSelectSql(EntitySet<TableLayoutInfo> columns, string aliasName, bool hasWhere, bool hasComment)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            int index = 0;
            foreach (TableLayoutInfo column in columns)
            {
                if (index > 0)
                {
                    sb.Append(" ,");
                }
                else
                {
                    sb.Append("  ");
                }
                if (string.IsNullOrWhiteSpace(aliasName))
                {
                    sb.Append(column.ColumnName);
                }
                else
                {
                    sb.Append(aliasName + "." + column.ColumnName);
                }
                if (hasComment)
                {
                    sb.Append("\t\t --" + column.ColumnDisplayName);
                }
                sb.AppendLine();
                index++;
            }
            sb.AppendLine(" FROM ");
            if (string.IsNullOrWhiteSpace(aliasName))
            {
                sb.AppendLine(" " + this.Table.TableName + " ");
            }
            else
            {
                sb.AppendLine(" " + this.Table.TableName + " AS " + aliasName);
            }
            if (hasWhere)
            {
                sb.AppendLine(" Where ");
                index = 0;
                foreach (TableLayoutInfo column in columns)
                {
                    if (!column.IsPrimaryKey)
                    {
                        continue;
                    }
                    if (index > 0)
                    {
                        sb.Append(" AND ");
                    }
                    else
                    {
                        sb.Append("  ");
                    }
                    if (string.IsNullOrWhiteSpace(aliasName))
                    {
                        sb.Append(column.ColumnName);
                    }
                    else
                    {
                        sb.Append(aliasName + "." + column.ColumnName);
                    }
                    sb.AppendFormat(" = @{0}", column.ColumnName);
                    sb.AppendLine();
                    index++;
                }
            }
            return sb.ToString();
        }
        private string GetJoinSql(EntitySet<TableLayoutInfo> columns, string aliasName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" INNER JOIN ");
            if (string.IsNullOrWhiteSpace(aliasName))
            {
                sb.Append(this.Table.TableName + " ");
            }
            else
            {
                sb.Append(this.Table.TableName + " AS " + aliasName);
            }
            int index = 0;
            sb.AppendLine(" ON ( ");
            index = 0;
            foreach (TableLayoutInfo column in columns)
            {
                if (!column.IsPrimaryKey)
                {
                    continue;
                }
                if (index > 0)
                {
                    sb.Append(" AND ");
                }
                else
                {
                    sb.Append("  ");
                }
                if (string.IsNullOrWhiteSpace(aliasName))
                {
                    sb.Append(column.ColumnName);
                }
                else
                {
                    sb.Append(aliasName + "." + column.ColumnName);
                }
                sb.AppendFormat(" = @{0}", column.ColumnName);
                sb.AppendLine();
                index++;
            }
            sb.AppendLine(")");
            return sb.ToString();
        }
        private string GetInsertSql(EntitySet<TableLayoutInfo> columns)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" INSERT INTO [{0}] ( ", this.Table.TableName);
            sb.AppendLine();
            int index = 0;
            foreach (TableLayoutInfo column in columns)
            {
                if (index > 0)
                {
                    sb.Append(" ,");
                }
                else
                {
                    sb.Append("  ");
                }
                sb.AppendFormat(" [{0}]", column.ColumnName);
                sb.AppendLine();
                index++;
            }
            sb.Append(" )");
            sb.AppendLine(" VALUES (");
            index = 0;
            foreach (TableLayoutInfo column in columns)
            {
                if (index > 0)
                {
                    sb.Append(" , ");
                }
                else
                {
                    sb.Append("  ");
                }

                sb.AppendFormat("@{0}", column.ColumnName);
                sb.AppendLine();
                index++;
            }
            sb.AppendLine(" ) ");
            return sb.ToString();
        }

        private string GetCreateSql(EntitySet<TableLayoutInfo> columns)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" CREATE TABLE [{0}] (", this.Table.TableName);
            sb.AppendLine();
            int index = 0;
            foreach (TableLayoutInfo column in columns)
            {
                string nullable = column.Nullable ? "" : " NOT NULL ";
                sb.AppendFormat("[{0}] {1} {2} ,", column.ColumnName, column.SqlDataType, nullable);
                sb.AppendLine();
                index++;
            }
            sb.AppendFormat("  CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED  ", this.Table.TableName);
            sb.AppendLine();
            sb.AppendLine(" (");
            index = 0;
            foreach (TableLayoutInfo column in columns)
            {
                if (!column.IsPrimaryKey)
                {
                    continue;
                }
                if (index > 0)
                {
                    sb.Append(" , ");
                }
                else
                {
                    sb.Append("  ");
                }
                sb.Append(column.ColumnName);
                sb.AppendLine();
                index++;
            }
            sb.AppendLine(") WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");
            sb.AppendLine(") ON [PRIMARY]");

            return sb.ToString();
        }

        private void ShowDataViewMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataView formView = new DataView();
                formView.Table = this.Table;
                formView.Show(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






    }
}
