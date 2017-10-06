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
            Hafzano = ".";
            Hafzadate = ".";
            Activate = ".";
            ActivateDate = ".";
        }
        public MemberInfoContrect(string name, string syndicate, string subcommitte, object hafzano, object hafzadate, object activate, object activateDate)
        {
            Name = name;
            Syndicate = syndicate;
            Subcommitte = subcommitte;
            Hafzano = hafzano;
            Hafzadate = hafzadate;
            if (activate == null || activate.ToString() == string.Empty)
                activate = "لا";
            else
            {
                bool output;
                if (bool.TryParse(activate.ToString(), out output))
                    activate = output ? "نعم" : "لا";
                else
                    activate = "لا";
            }
            Activate = activate.ToString();
            ActivateDate = activateDate;
        }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Syndicate { get; set; }
        [DataMember]
        public string Subcommitte { get; set; }
        [DataMember]
        public object Hafzano { get; set; }
        [DataMember]
        public object Hafzadate { get; set; }
        [DataMember]
        public object Activate { get; set; }
        [DataMember]
        public object ActivateDate { get; set; }
    }
}
