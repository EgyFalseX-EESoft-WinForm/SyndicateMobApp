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
    public class SyndicateContrect
    {
        public SyndicateContrect(int syndicateId, string syndicate)
        {
            SyndicateId = syndicateId;
            Syndicate = syndicate;
        }
        [DataMember]
        public int SyndicateId { get; set; }
        [DataMember]
        public string Syndicate { get; set; }
    }
}
