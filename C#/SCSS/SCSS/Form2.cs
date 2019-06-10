using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maxz.PoemSystem.Tools
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PoemApiService.PoemApiClient poemApi = new PoemApiService.PoemApiClient();
           var result = poemApi.QueryPoem(new PoemApiService.QueryPoemRequest(this.textBox1.Text));
            this.dataGridView1.DataSource = result.QueryPoemResult;
        }
    }
}
