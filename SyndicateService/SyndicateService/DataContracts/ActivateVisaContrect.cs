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
    public class ActivateVisaContrect
    {
        public ActivateVisaContrect(string visa, bool active)
        {
            Visa = visa;
            Active = active;
        }
        [DataMember]
        public string Visa { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}
