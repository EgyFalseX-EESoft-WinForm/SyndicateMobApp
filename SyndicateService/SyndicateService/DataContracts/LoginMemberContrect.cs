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
    public class LoginMemberContrect
    {
        public LoginMemberContrect(int mMashatId, string mMashatName, int sarfnumber, int hafzano, DateTime hafzadate, string syndicate, string subCommitte)
        {
            MMashatId = mMashatId;
            MMashatName = mMashatName;
            Sarfnumber = sarfnumber;
            Hafzano = hafzano;
            Hafzadate = hafzadate;
            Syndicate = syndicate;
            SubCommitte = subCommitte;
        }
        [DataMember]
        public int MMashatId { get; set; }
        [DataMember]
        public string MMashatName { get; set; }
        [DataMember]
        public int Sarfnumber { get; set; }
        [DataMember]
        public int Hafzano { get; set; }
        [DataMember]
        public DateTime Hafzadate { get; set; }
        [DataMember]
        public string Syndicate { get; set; }
        [DataMember]
        public string SubCommitte { get; set; }
    }
}
