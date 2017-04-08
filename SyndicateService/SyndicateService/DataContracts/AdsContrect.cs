using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateServiceLib.DataContracts
{
    [DataContract]
    public class AdsContrect
    {
        public AdsContrect(int adsId, string imagePath)
        {
            AdsId = adsId;
            ImagePath = imagePath;
        }
        [DataMember]
        public int AdsId { get; set; }
        [DataMember]
        public string ImagePath { get; set; }
    }
}
