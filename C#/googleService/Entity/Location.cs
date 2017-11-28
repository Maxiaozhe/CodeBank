using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GoogleService.Entity
{
    [DataContract]
    public class Location
    {
        [DataMember(Name = "lat")]
        public double Lat { get; set; }
        [DataMember(Name = "lng")]
        public double Lng { get; set; }

        public override string ToString()
        {
            return Lat.ToString() + "," + Lng.ToString();
        }
    }
}