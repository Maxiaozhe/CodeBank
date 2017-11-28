using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoogleService.ProxyCredProvider
{
    public class DefProxy : System.Net.IWebProxy
    {
        public System.Net.ICredentials Credentials
        {
            get
            {
                return new NetworkCredential(
                    Properties.Settings.Default.UserId,
                    Properties.Settings.Default.Password);
            }
            set
            {

            }
        }

        public Uri GetProxy(Uri destination)
        {
            return new Uri(Properties.Settings.Default.ProxyServer);
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }
    }
}
