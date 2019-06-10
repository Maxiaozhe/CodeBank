using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADAuthTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string server = this.txtServer.Text;
            string domain = this.txtDomain.Text;
            string user = this.txtUser.Text;
            string pwd = this.txtPwd.Text;
            AuthenticationTypes authType = AuthenticationTypes.FastBind;
            if (!string.IsNullOrEmpty((string)this.cmbAuthType.SelectedValue))
            {
                authType = (AuthenticationTypes)Enum.Parse(typeof(AuthenticationTypes), (string)this.cmbAuthType.SelectedValue);
            }

            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("ユーザーIDを入力してください。");
                return;
            }
            if (string.IsNullOrEmpty(domain))
            {
                MessageBox.Show("ドメインを入力してください。");
                return;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("パスワードを入力してください。");
                return;
            }

            if(this.Login(user, pwd, domain, server, authType))
            {
                MessageBox.Show("認証成功しました");
            }
            else
            {
                MessageBox.Show("認証失敗しました");
            }

        }

        private bool Login(string userId, string pwd, string domain, string server, AuthenticationTypes authType)
        {


            string ldapPath = string.IsNullOrWhiteSpace(server) ? "LDAP://" :"LDAP://" + server + "/";

            int index = 0;
            foreach (string dc in domain.Split('.'))
            {
                if (index > 0)
                {
                    ldapPath += ",";
                }
                ldapPath += "DC=" + dc;
                index++;
            }
            try
            {
                //該当ユーザーでログインを試みる
                using (DirectoryEntry dirEntry = new DirectoryEntry(ldapPath, userId, pwd, authType))
                {

                    Object obj = dirEntry.NativeObject;
                    DirectorySearcher search = new DirectorySearcher(dirEntry);
                    search.PropertiesToLoad.Add("cn");
                    search.Filter = "(SAMAccountName=" + userId + ")";
                    SearchResult result = search.FindOne();
                    if (result != null)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (string propName in result.Properties.PropertyNames)
                        {
                            if (result.Properties[propName] != null)
                            {
                                string value = result.Properties[propName][0] as string;
                                sb.AppendFormat("{0} = {1}\n", propName, value);
                            }

                        }
                        MessageBox.Show(sb.ToString());
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string[] names = Enum.GetNames(typeof(AuthenticationTypes));
            this.cmbAuthType.DataSource = names;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = this.txtServer.Text;
            string domain = this.txtDomain.Text;
            string user = this.txtUser.Text;
            string pwd = this.txtPwd.Text;
            string filter = this.txtfilter.Text;
            AuthenticationTypes authType = AuthenticationTypes.FastBind;
            if (!string.IsNullOrEmpty((string)this.cmbAuthType.SelectedValue))
            {
                authType = (AuthenticationTypes)Enum.Parse(typeof(AuthenticationTypes), (string)this.cmbAuthType.SelectedValue);
            }

            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("ユーザーIDを入力してください。");
                return;
            }
            if (string.IsNullOrEmpty(domain))
            {
                MessageBox.Show("ドメインを入力してください。");
                return;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("パスワードを入力してください。");
                return;
            }
            if (string.IsNullOrEmpty(filter))
            {
                filter = "(objectClass=user)";
            }
            DataTable dtt= GetUsers(user, pwd, domain, server, filter, authType);
            Form2 form2 = new Form2();
            form2.DataSource = dtt;
            form2.Show();
        }


        private DataTable GetUsers(string userId, string pwd, string domain, string server,string filter, AuthenticationTypes authType)
        {
            string ldapPath = string.IsNullOrWhiteSpace(server) ? "LDAP://" : "LDAP://" + server + "/";

            int index = 0;
            foreach (string dc in domain.Split('.'))
            {
                if (index > 0)
                {
                    ldapPath += ",";
                }
                ldapPath += "DC=" + dc;
                index++;
            }
            DataTable dtt = new DataTable();
            dtt.Columns.Add("cn", typeof(string));
            try
            {
                
                //該当ユーザーでログインを試みる
                using (DirectoryEntry dirEntry = new DirectoryEntry(ldapPath, userId, pwd))
                {

                    Object obj = dirEntry.NativeObject;
                    DirectorySearcher search = new DirectorySearcher(dirEntry);
                    search.Filter = filter;
                    //search.PropertiesToLoad.Add("cn");
                    SearchResultCollection results = search.FindAll();
                    if (results != null && results.Count>0 )
                    {
                        int count = 0;
                        foreach(SearchResult result in results)
                        {
                            if(count>1000)
                            {
                                break;
                            }
                            DataRow row = dtt.NewRow();
                            foreach (string propName in result.Properties.PropertyNames)
                            {
                                if (result.Properties[propName] != null)
                                {
                                    if (!dtt.Columns.Contains(propName))
                                    {
                                        dtt.Columns.Add(propName, typeof(string));
                                    }
                                    string value = result.Properties[propName][0] as string;
                                    row[propName] = value;
                                }
                            }
                            dtt.Rows.Add(row);
                            count++;
                        }
                    }
                }
                return dtt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }


        }
    }
}
