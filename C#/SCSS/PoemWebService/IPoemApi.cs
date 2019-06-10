using System.Collections.Generic;
using PoemWebService.Entity;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace PoemWebService
{
    [ServiceContract]
    public interface IPoemApi
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        [WebInvoke(
            Method ="POST",
            UriTemplate = "/QueryPoem",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
         )]
        List<PoemItem> QueryPoem(string key);
    }
}