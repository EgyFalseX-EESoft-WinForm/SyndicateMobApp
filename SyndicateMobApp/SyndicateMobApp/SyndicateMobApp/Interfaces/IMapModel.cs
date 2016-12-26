using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateMobApp.Interfaces
{
    public interface IMapModel
    {
        string Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        string ImageUrl { get; set; }
        ILocation Location { get; set; }
        bool IsItNestle { get; set; }
        bool Validated { get; set; }
        string Channel { get; set; }
        //ExtendedMap Parent { get; set; }
    }

}
