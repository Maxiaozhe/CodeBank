using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableDesignInfo.Forms
{
    public partial class InputForm : Form
    {

        public InputForm()
        {
            InitializeComponent();
        }

        public bool ForJoin
        {
            get;
            set;
        }

        public bool HasWhereCondition
        {
            get
            {
                return this.chkWhere.Checked;
            }
        }

        public string AliasName
        {
            get
            {
                return this.txtAlias.Text;
            }
        }

        public bool HasComment
        {
            get
            {
                return this.chkComment.Checked;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            this.chkComment.Visible = !ForJoin;
            this.chkWhere.Visible = !ForJoin;
        }

    }
}
