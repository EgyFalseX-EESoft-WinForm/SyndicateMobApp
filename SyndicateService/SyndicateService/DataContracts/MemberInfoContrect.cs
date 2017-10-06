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
    public class MemberInfoContrect
    {
        public MemberInfoContrect(string name, string syndicate, string subcommitte, int? hafzano, DateTime? hafzadate, bool activate, DateTime? activateDate)
        {
            Name = name;
            Syndicate = syndicate;
            Subcommitte = subcommitte;
            Hafzano = hafzano;
            Hafzadate = hafzadate;
            Activate = activate;
            ActivateDate = activateDate;
        }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Syndicate { get; set; }
        [DataMember]
        public string Subcommitte { get; set; }

        [DataMember]
        public int? Hafzano { get; set; }
        [DataMember]
        public DateTime? Hafzadate { get; set; }
        [DataMember]
        public bool Activate { get; set; }
        [DataMember]
        public DateTime? ActivateDate { get; set; }
    }
}
