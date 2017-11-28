using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GoogleService.Entity
{
    [DataContract]
    [Serializable]
    public class TextSearch

    {
        [DataMember(Name = "results")]
        public TextSearchResult[] Results { get; set; }
        [DataMember(Name = "status")]
        public string Status { get;set;}
    }
    [DataContract]
    [Serializable]
    public class TextSearchResult
    {
        [DataMember(Name = "place_id")]
        public string PlaceId { get; set; }
        [DataMember(Name = "geometry")]
        public Geometry Geometry { get; set; }
        [DataMember(Name = "formatted_address")]
        public string FormattedAddress { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        [DataMember(Name = "photos")]
        public Photo[] Photos { get; set; }
        [DataMember(Name = "types")]
        public string[] Types { get; set; }
        [DataMember]
        public string EmbedMapUrl { get; set; }
        [DataMember]
        public string EmbedStreeViewUrl { get; set; }
        [DataMember]
        public string StaticMapUrl { get; set; }

    }
    [DataContract]
    [Serializable]
    public class Photo
    {
        [DataMember(Name = "height")]
        public int Height { get; set; }
        [DataMember(Name = "width")]
        public int Width { get; set; }
        [DataMember(Name = "html_attributions")]
        public string[] HtmlAttributes { get; set; }
    }
}