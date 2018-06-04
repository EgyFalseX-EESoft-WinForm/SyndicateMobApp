using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateMobApp.Services
{
    public class SyndicateContrect
    {
        public SyndicateContrect(int syndicateId, string syndicate)
        {
            SyndicateId = syndicateId;
            Syndicate = syndicate;
        }
        public int SyndicateId { get; set; }
        public string Syndicate { get; set; }
        public override string ToString()
        {
            return Syndicate;
        }

    }
    
}
