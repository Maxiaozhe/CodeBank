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
    [ServiceContract(Namespace = "GoogleService")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PlaceService
    {
        private static GooglePlaceService service = new GooglePlaceService();

        // HTTP GET を使用するために [WebGet] 属性を追加します (既定の ResponseFormat は WebMessageFormat.Json)。
        // XML を返す操作を作成するには、
        //     [WebGet(ResponseFormat=WebMessageFormat.Xml)] を追加し、
        //     操作本文に次の行を含めます。
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
         )]
        public TextSearch DoTextSearch(string key)
        {
            // 操作の実装をここに追加してください
            return service.DoTextSearch(key);
        }
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
         )]
        public DetailSearch DetailsSearch(string placeId)
        {
            return service.GetDetail(placeId);
        }
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
         )]
        public string GetEmbedMapUrl(string placeId)
        {
            return GooglePlaceService.GetMapUrl(placeId);
        }
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
         )]
        public string GetEmbedStreeViewUrl(string location)
        {
            return GooglePlaceService.GetStreeViewUrl(location);
        }


    }
}
