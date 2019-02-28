using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReplaceControl
{
    public partial class Form1 : Form
    {

        private const int MAXID = 611;
        private int idguip = MAXID;

        private int GetMaxIDGUIP()
        {
            idguip++;
            return idguip;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txtOrg = this.txtBefore.Text;
            List<string> ids=GetControlIds();
            string txtResult = txtOrg;
            foreach(string id in ids)
            {
                txtResult = ReplaceControl(txtResult, id);
            }
            this.txtAfter.Text = txtResult;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            idguip = MAXID;
            string txtOrg = this.txtBefore.Text;
            List<string> ids = GetNumericItems2();
            string txtResult = txtOrg;
            foreach (string id in ids)
            {
                txtResult = ReplaceNumericControl(txtResult, id);
            }
            this.txtAfter.Text = txtResult;
        }
        private string ReplaceControl(string text,string id)
        {
            string pattern = string.Format(@"\<INPUT\W+id={0}+\s[^\>]+\>", id);
            Regex regex = new Regex(pattern,RegexOptions.IgnoreCase);
            string retVal =regex.Replace(text, x=>
            {
                return ReplaceProperty(x);
            });
            return retVal;
        }

        private string ReplaceProperty(Match x)
        {
            string[] patterns = {
                @"GUITYPE=""\w+""",
                @"IDGUI=""10000120""",
                @"GuiTagname\=""uc1:usrRGUI0120""",
                @"datatype=""実数""",
                @"IDGUIP=""\d+""",
                @"PTGUISETPG=""RITS.RabitFlow.VGPX.FormatNumber"""
            };
            string[] values =
            {
                @"GUITYPE=""金額テキスト""",
                @"IDGUI=""250""",
                @"GuiTagname=""uc1:usrFLW0122""",
                @"datatype=""金額""",
                "",
                ""
            };
            string text = x.Value;
            for(int i = 0; i < patterns.Length; i++)
            {
                Regex regex = new Regex(patterns[i], RegexOptions.IgnoreCase);
                text= regex.Replace(text, values[i]);
            }

            return text;
            
        }
        /// <summary>
        /// フォーマット数値GUIへ変換
        /// </summary>
        /// <param name="text"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private string ReplaceNumericControl(string text, string id)
        {
            string pattern = string.Format(@"\<INPUT\W+id={0}+\s[^\>]+\>", id);
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            string retVal = regex.Replace(text, x =>
            {
                return ReplaceForFormatNumeric(x);
            });
            return retVal;
        }

        private string ReplaceForFormatNumeric(Match x)
        {
            string[] patterns = {
                @"GUITYPE=""\w+""",
                @"IDGUI=""160""",
                @"GuiTagname\=""uc1:usrFLW0112""",
                @">",
                @">"
            };
            string[] values =
            {
                @"GUITYPE=""フォーマット数値""",
                @"IDGUI=""10000120""",
                @"GuiTagname=""uc1:usrRGUI0120""",
                @" PTGUISETPG=""RITS.RabitFlow.VGPX.FormatNumber"" >",
                @"IDGUIP=""{0}"" >"
            };
            string text = x.Value;
            for (int i = 0; i < patterns.Length; i++)
            {
                string value = values[i];
                if (i == 4)
                {
                    value = string.Format(values[i], GetMaxIDGUIP());
                }
                Regex regex = new Regex(patterns[i], RegexOptions.IgnoreCase);
                text = regex.Replace(text, value);
            }

            return text;

        }

        private List<string> GetControlIds()
        {
            List<string> controlIds = new List<string>();
            using(SqlConnection conn=new SqlConnection(Properties.Settings.Default.sqlconnect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    DataTable dtt = new DataTable();
                    cmd.CommandText = SQL.SQLCMD.GetFormatNumberControls;
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    ada.Fill(dtt);
                    foreach(DataRow row in dtt.Rows)
                    {
                        string id = row["NMSYSFLD"] as string;
                        controlIds.Add(id);
                    }
                }
            }
            return controlIds;

        }

        /// <summary>
        /// 変換する
        /// </summary>
        /// <returns></returns>
        private List<string> GetNumericItems()
        {
            List<string> controlIds = new List<string>();
            controlIds.AddRange(new string[] {
                "GUIItem288",
                "GUIItem368",
                "GUIItem569",
                "GUIItem571",
                "GUIItem573",
                "GUIItem575",
                "GUIItem577",
                "GUIItem579",
                "GUIItem581",
                "GUIItem583",
                "GUIItem585"
            });
            return controlIds;
        }


        /// <summary>
        /// 変換する(内訳)
        /// </summary>
        /// <returns></returns>
        private List<string> GetNumericItems2()
        {
            List<string> controlIds = new List<string>();
            controlIds.AddRange(new string[] {
                "GUIItem210",
                "GUIItem212",
                "GUIItem214",
                "GUIItem217",
                "GUIItem219",
                "GUIItem221",
                "GUIItem223",
                "GUIItem225",
                "GUIItem228",
            });
            return controlIds;
        }

    }
}
