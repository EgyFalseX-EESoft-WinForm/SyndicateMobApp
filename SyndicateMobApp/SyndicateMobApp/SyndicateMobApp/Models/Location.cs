using System;
using System.Collections.Generic;
using System.Linq;
using SyndicateMobApp.Interfaces;
using Xamarin.Forms.Maps;

namespace SyndicateMobApp.Models
{
    public class Location : ILocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static Position DefaultPosition
        {
            //get { return new Position(34.033897, -118.291869); }
            get { return new Position(0, 0); }
        }
    }

}
