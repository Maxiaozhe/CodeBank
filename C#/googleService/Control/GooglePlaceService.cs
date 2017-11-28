using GoogleService.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;

namespace GoogleService.Control
{
    public class GooglePlaceService
    {
        /// <summary>
        /// Google Place Web Service Url
        /// </summary>
        private const string serviceUrl = @"https://maps.googleapis.com/maps/api/place/{0}/{1}?";
        /// <summary>
        /// Google Embed Api Map View
        /// </summary>
        private const string ViewUrl = @"https://www.google.com/maps/embed/v1/place?";
        /// <summary>
        /// Google Embed Api Stree View
        /// </summary>
        private const string StreeViewUrl = @"https://www.google.com/maps/embed/v1/streetview?";
        /// <summary>
        /// Google Static Api
        /// </summary>
        private const string StaticMapUrl = @"https://maps.googleapis.com/maps/api/staticmap?key={0}";
        /// <summary>
        /// Google Place Web Service Text Search
        /// </summary>
        private const string textSearch = "textsearch";
        /// <summary>
        /// Google Place Web Service Details Search
        /// </summary>
        private const string detailSearch = "details";
        /// <summary>
        /// API Key
        /// </summary>
        private static string _Apikey;

        private OutputType format;

        public static string ApiKey
        {
            get
            {
                if (string.IsNullOrEmpty(_Apikey))
                {
                    _Apikey = Properties.Settings.Default.GoogleApiKey;
                }
                return _Apikey;
            }
        }

        public enum OutputType
        {
            Json,
            Xml
        }

        public enum MethodType
        {
            textSearch,
            detailSearch
        }

        public enum MapType
        {
            roadmap,
            satellite,
            terrain,
            hybrid
        }

        public GooglePlaceService()
        {
            this.format = OutputType.Json ;
        }

        private string GetPoseUrl(MethodType methodtype)
        {
            string outputType = this.format == OutputType.Json ? "json" : "xml";
            switch (methodtype)
            {
                case MethodType.textSearch:
                    return string.Format(serviceUrl, textSearch, outputType);
                case MethodType.detailSearch:
                    return string.Format(serviceUrl, detailSearch, outputType);
                default:
                    return string.Empty;
            }
        }


        public TextSearch DoTextSearch(string query)
        {
            string getUrl = GetPoseUrl(MethodType.textSearch);
            string param = "key=" + ApiKey;
            param += "&query=" + HttpUtility.UrlDecode(query);
            param += "&types=address";
            param += "&language=ja";
            string url = getUrl + param;
            TextSearch result = ExecRequest<TextSearch>(url);
            if (result.Status.Equals("OK"))
            {
                foreach (TextSearchResult place in result.Results)
                {
                    place.EmbedMapUrl = GetMapUrl(place.PlaceId);
                    place.EmbedStreeViewUrl = GetStreeViewUrl(place.Geometry.Location.ToString());
                    place.StaticMapUrl = GetStaticMapUrl(place.Geometry.Location.ToString(), 15, 600, 400, MapType.roadmap);
                }
            }

            return result;
        }

        public DetailSearch GetDetail(string placeId)
        {
            string getUrl = GetPoseUrl(MethodType.detailSearch);
            string param = "key=" + ApiKey;
            param += "&placeid=" + placeId;
            string url = getUrl + param;
            DetailSearch result = ExecRequest<DetailSearch>(url);
            return result;
        }

        public static string GetMapUrl(TextSearch result)
        {
            string url = ViewUrl;
            string param = "key=" + ApiKey;
            param += "&q=place_id:" + result.Results[0].PlaceId;
            return url + param;
        }


        public static string GetMapUrl(string placeId)
        {
            string url = ViewUrl;
            string param = "key=" + ApiKey;
            param += "&q=place_id:" + placeId;
            return url + param;
        }


        public static string GetStreeViewUrl(TextSearch result)
        {
            string url = StreeViewUrl;
            string param = "key=" + ApiKey;
            param += "&location=" + result.Results[0].Geometry.Location.ToString();
            param += "&heading=34&pitch=10";
            return url + param;
        }


        public static string GetStreeViewUrl(string location)
        {
            string url = StreeViewUrl;
            string param = "key=" + ApiKey;
            param += "&location=" + location;
            param += "&heading=0&pitch=10";
            return url + param;
        }
        

        public static string GetStaticMapUrl(TextSearch result,int zoom,int width,int height)
        {
            return GetStaticMapUrl(result.Results[0].Geometry.Location.ToString(), zoom, width, height, MapType.roadmap);
        }

        public static string GetStaticMapUrl(string center, int zoom, int width, int height, MapType maptype)
        {
            if (zoom < 0 || zoom > 24)
            {
                zoom = 15;
            }
            if (width < 200 || width > 2048 || height < 200 || height > 2048)
            {
                width = 600;
                height = 400;
            }
            string mType = "";
            switch (maptype)
            {
                case MapType.satellite:
                    mType = "satellite";
                    break;
                case MapType.terrain:
                    mType = "terrain";
                    break;
                case MapType.hybrid:
                    mType = "hybrid";
                    break;
                default:
                    mType = "roadmap";
                    break;
            }
            string url = string.Format(StaticMapUrl, ApiKey);
            string param = "&zoom=" + zoom;
            param += "&size=" + width + "x" + height;
            param += "&center=" + center;
            param += "&maptype=" + mType;
            param += "&markers=size:big|color:red|label:A";
            param += "|" + center;
            return url + param;
        }

        private T ExecRequest<T>(string url)
        {
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Timeout = 50000;
            webRequest.Method = "GET";
            T result ;
            using (var response = webRequest.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                    result = (T)serializer.ReadObject(stream);
                    return result;
                }
            }
           
        }

    }
}