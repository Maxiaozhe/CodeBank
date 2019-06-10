using Maxz.PoemSystem.Engine.Modules;
using PoemWebService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PoemWebService
{
    /// <summary>
    /// PoemService の概要の説明です
    /// </summary>
    [System.Web.Script.Services.ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // この Web サービスを、スクリプトから ASP.NET AJAX を使用して呼び出せるようにするには、次の行のコメントを解除します。
    public class PoemService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<PoemItem> QueryPoem(string key)
        {
            return LinqSqlHelp.QueryPoem(key).Select(p => new PoemItem(p)).ToList();
        }



        public bool AddPoem(PoemItem poem)
        {
            try
            {
                LinqSqlHelp.AddPoem2(poem.ToPoem2());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
