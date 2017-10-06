using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateMobApp.Services
{
    
    public class LoginWarasaContrect
    {
        public LoginWarasaContrect(int personId, int mMashatId, string personName, bool yasref, bool responsiblesarf, int code60, string mMashatName, string syndicate, string subCommitte, string resPersonName
            , object hafzano, object hafzadate, object activate, object activateDate)
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
        public int PersonId { get; set; }
        public int MMashatId { get; set; }
        public string PersonName { get; set; }
        public bool Yasref { get; set; }
        public bool Responsiblesarf { get; set; }
        public int Code60 { get; set; }
        public string MMashatName { get; set; }
        public string Syndicate { get; set; }
        public string SubCommitte { get; set; }
        public string ResPersonName { get; set; }
        public object Hafzano { get; set; }
        public object Hafzadate { get; set; }
        public object Activate { get; set; }
        public object ActivateDate { get; set; }
    }
}
