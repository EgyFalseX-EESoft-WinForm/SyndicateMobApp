using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateMobApp.Services
{
    public class AdsContrect
    {
        public AdsContrect(int adsId, string imagePath)
        {
            AdsId = adsId;
            ImagePath = imagePath;
        }
        public int AdsId { get; set; }
        public string ImagePath { get; set; }
    }
}
