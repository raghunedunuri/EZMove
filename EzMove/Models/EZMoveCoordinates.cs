using System;

namespace EzMove.Models
{
    public class EZMoveCoordinates
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public String Key
        {
            get
            {
                return Latitude.ToString() + "-" + Longitude.ToString();
            }
        }

    }
}