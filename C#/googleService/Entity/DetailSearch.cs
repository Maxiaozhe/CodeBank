using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GoogleService.Entity
{
    [DataContract]
    [Serializable]
    public class DetailSearch
    {
        [DataMember(Name = "result")]
        public DetailSearchResult Result { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
    [DataContract]
    [Serializable]
    public class DetailSearchResult
    {
        [DataMember(Name = "place_id")]
        public string PlaceId { get; set; }
        [DataMember(Name = "geometry")]
        public Geometry Geometry { get; set; }
        [DataMember(Name = "formatted_address")]
        public string FormattedAddress { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
    [DataContract]
    [Serializable]
    public class Geometry
    {
        [DataMember(Name = "location")]
        public Location Location { get; set; }
    }
}