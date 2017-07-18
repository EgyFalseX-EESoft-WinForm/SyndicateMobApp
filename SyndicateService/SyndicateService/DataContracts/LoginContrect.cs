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
    public class LoginContrect
    {
        public LoginContrect(int _user_id, string _user_name, string _user_pass, int _syndicateId)
        {
            user_id = _user_id;
            user_name = _user_name;
            user_pass = _user_pass;
            syndicateId = _syndicateId;
        }
        [DataMember]
        public int user_id { get; set; }
        [DataMember]
        public string user_name { get; set; }
        [DataMember]
        public string user_pass { get; set; }
        [DataMember]
        public int syndicateId { get; set; }

    }
}
