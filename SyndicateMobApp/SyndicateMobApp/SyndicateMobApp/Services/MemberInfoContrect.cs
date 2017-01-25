using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateMobApp.Services
{
    [DataContract]
    public class MemberInfoContrect
    {
        public MemberInfoContrect()
        {
            Name = ".";
            Syndicate = ".";
            Subcommitte = ".";
        }
        public MemberInfoContrect(string name, string syndicate, string subcommitte)
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
