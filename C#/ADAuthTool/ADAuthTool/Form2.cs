using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADAuthTool
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public DataTable DataSource { get; set; }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.DataSource;
        }
    }
}
