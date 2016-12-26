using SyndicateMobApp.Models;
using SyndicateMobApp.Interfaces;

namespace SyndicateMobApp.Controls
{
    public class ExtendedPin : IMapModel
    {
        public ExtendedPin( string id, string name, string address, string channel, bool isItNestle, bool validated, double latitude, double longitude)
        {
            //ref ExtendedMap parent,
            Id = id;
            Name = name;
            Address = address;
            Channel = channel;
            IsItNestle = isItNestle;
            Validated = validated;
            //Parent = parent;
            Location = new Location { Latitude = latitude, Longitude = longitude };
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public ILocation Location { get; set; }
        public bool IsItNestle { get; set; }
        public bool Validated { get; set; }
        public string Channel { get; set; }
        //public ExtendedMap Parent { get; set; }

    }
}
