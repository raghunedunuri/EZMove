using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EzMove.Models
{
    public class EZMoveAddress
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string LandMark { get; set; }
        public EZMoveCoordinates Coordinates { get; set; }

    }
}