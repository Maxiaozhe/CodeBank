using GoogleService.Control;
using GoogleService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace GoogleService
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1
    {
        private static GooglePlaceService service = new GooglePlaceService();
        // HTTP GET を使用するために [WebGet] 属性を追加します (既定の ResponseFormat は WebMessageFormat.Json)。
        // XML を返す操作を作成するには、
        //     [WebGet(ResponseFormat=WebMessageFormat.Xml)] を追加し、
        //     操作本文に次の行を含めます。
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // 操作の実装をここに追加してください
            return;
        }
        [OperationContract]
        public TextSearch DoTextSearch(string key)
        {
            // 操作の実装をここに追加してください
            return service.DoTextSearch(key);
        }
        // 追加の操作をここに追加して、[OperationContract] とマークしてください
    }
}
