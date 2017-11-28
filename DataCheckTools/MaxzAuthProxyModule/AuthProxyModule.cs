using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Proxy認証モジュール
/// 
/// </summary>
namespace Maxz.AuthProxy
{
    public class AuthProxyModule : IWebProxy
    {
        private ICredentials crendential = null;
        private static object locker = new object();

        public ICredentials Credentials
        {
            get
            {
                lock (locker)
                {
                    if (!Properties.Settings.Default.NotUseProxy && crendential == null)
                    {
                        if (!SetProxy())
                        {
                            return null;
                        }
                    }
                    return crendential;
                }
            }

            set
            {
                this.crendential = value;
            }
        }

        public Uri GetProxy(Uri destination)
        {
            lock (locker)
            {
                string proxyServer = Properties.Settings.Default.ProxyServer;
                if (string.IsNullOrEmpty(Properties.Settings.Default.ProxyServer))
                {
                    if (!SetProxy())
                    {
                        return null;
                    }
                }

                return new Uri(proxyServer);
            }

        }

        private  bool SetProxy()
        {
                if (this.crendential != null)
                {
                    return true;
                }
                using (ProxySettingForm form = new ProxySettingForm())
                {
                    form.ProxyServer = Properties.Settings.Default.ProxyServer;
                    form.UserName = Properties.Settings.Default.UserName;
                    form.Password = Properties.Settings.Default.Password;
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Credentials = form.Credentials;
                        Properties.Settings.Default.ProxyServer = form.ProxyServer;
                        Properties.Settings.Default.UserName = form.UserName;
                        Properties.Settings.Default.Password = form.Password;
                        Properties.Settings.Default.Save();
                        return true;
                    }
                    else
                    {
                        this.crendential = null;
                    }
                }
                return false;
        }
        /// <summary>
        /// 指定したホストでプロキシ サーバーを使用するかどうかを示します。
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public bool IsBypassed(Uri host)
        {
            if (Properties.Settings.Default.NotUseProxy)
            {
                return true;
            }

            if (host.IsLoopback)
            {
                return true;
            }
            StringCollection byPassUrls = Properties.Settings.Default.ByPassAddress;
            foreach(string url in byPassUrls)
            {
                string urlPart = url.Replace("*", "");
                if (host.AbsolutePath.Contains(urlPart))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
