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
    public class WarasaInfoContrect
    {
        public WarasaInfoContrect(string name, string syndicate, string subcommitte)
        {
            Name = name;
            Syndicate = syndicate;
            Subcommitte = subcommitte;
        }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Syndicate { get; set; }
        [DataMember]
        public string Subcommitte { get; set; }
    }
}
