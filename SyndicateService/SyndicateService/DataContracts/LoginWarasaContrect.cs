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
    public class LoginWarasaContrect
    {
        public LoginWarasaContrect(int personId, int mMashatId, string personName, bool yasref, bool responsiblesarf, int code60, string mMashatName, string syndicate, string subCommitte, string resPersonName
            , int? hafzano, DateTime? hafzadate, bool activate, DateTime? activateDate)
        {
            PersonId = personId;
            MMashatId = mMashatId;
            PersonName = personName;
            Yasref = yasref;
            Responsiblesarf = responsiblesarf;
            Code60 = code60;
            MMashatName = mMashatName;
            Syndicate = syndicate;
            SubCommitte = subCommitte;
            ResPersonName = resPersonName;
            Hafzano = hafzano;
            Hafzadate = hafzadate;
            Activate = activate;
            ActivateDate = activateDate;
        }
        [DataMember]
        public int PersonId { get; set; }
        [DataMember]
        public int MMashatId { get; set; }
        [DataMember]
        public string PersonName { get; set; }
        [DataMember]
        public bool Yasref { get; set; }
        [DataMember]
        public bool Responsiblesarf { get; set; }
        [DataMember]
        public int Code60 { get; set; }
        [DataMember]
        public string MMashatName { get; set; }
        [DataMember]
        public string Syndicate { get; set; }
        [DataMember]
        public string SubCommitte { get; set; }
        [DataMember]
        public string ResPersonName { get; set; }
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
