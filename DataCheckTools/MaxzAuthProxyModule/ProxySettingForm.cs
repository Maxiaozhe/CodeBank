using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maxz.AuthProxy
{
    public partial class ProxySettingForm : Form
    {
        /// <summary>
        /// Auth Credentials
        /// </summary>
        public NetworkCredential Credentials { get; set; }
        /// <summary>
        /// Proxy Server Uri
        /// </summary>
        public string ProxyServer { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        
        public ProxySettingForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.txtUserName.Enabled = !this.chkDefault.Checked;
            this.txtPwd.Enabled = !this.chkDefault.Checked;
        }

        private void ProxySettingForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.ProxyServer))
            {
                this.txtProxyServer.Text = this.ProxyServer;
            }
            if (this.Credentials !=null)
            {
                this.txtUserName.Text = this.Credentials.UserName;
                this.txtPwd.Text = this.Credentials.Password;
            }
            else
            {
                this.txtUserName.Text = this.UserName;
                this.txtPwd.Text = this.Password;
            }
            this.chkDefault.Checked = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.txtProxyServer.Text))
            {
                MessageBox.Show("Please input the proxy server.");
                return;
            }
            this.ProxyServer = this.txtProxyServer.Text;
            if (!this.chkDefault.Checked)
            {
                if (string.IsNullOrWhiteSpace(this.txtUserName.Text))
                {
                    MessageBox.Show("Please input the user name.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(this.txtPwd.Text))
                {
                    MessageBox.Show("Please input the password.");
                    return;
                }
                this.UserName = this.txtUserName.Text;
                this.Password = this.txtPwd.Text;
                this.Credentials = new NetworkCredential(this.txtUserName.Text, this.txtPwd.Text);
            }
            else
            {
                this.UserName = string.Empty;
                this.Password = string.Empty;
                this.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
