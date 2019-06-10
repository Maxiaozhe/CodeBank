using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Maxz.PoemSystem.Tools.Controls
{
    public abstract class NetCatcher
    {
        private int retryCount = 0;

        protected int _count;

        protected virtual int Parsentage { get; }

        public delegate void ReportHandler(int percentage, Dictionary<string, string> result);
        public ReportHandler Report { get; set; }

        protected void CatchWebSource(string UrlFormat, params string[] args)
        {
            try
            {
                MemoryStream content = new MemoryStream();
                string url = GetUrl(UrlFormat, args);
                WebRequest request = (HttpWebRequest)WebRequest.Create(url);
                using (var response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        stream.CopyTo(content);
                    }

                }
                Regist(content, args);
                retryCount = 0;
            }
            catch(WebException ex)
            {
                retryCount++;
                if (retryCount > 3)
                {
                    throw new Exception("最大RETRY回数超えました。");
                }
                if (this.Report != null)
                {
                    Dictionary<string, string> result = new Dictionary<string, string>();
                    result["count"] = this._count.ToString();
                    result["message"] = ex.Message;
                    result["content"] = ex.StackTrace;
                    this.Report(this.Parsentage, result);
                }
                System.Threading.Thread.Sleep(5 * 6000);
                CatchWebSource(UrlFormat, args);
            }
        }

        protected abstract string GetUrl(string UrlFormat, params string[] args);
        protected abstract void Regist(MemoryStream contentStream,string[] args);
    }
}
