using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateMobApp.Services
{
    public class LoginMemberContrect
    {
        public LoginMemberContrect(int mMashatId, string mMashatName, int sarfnumber, object hafzano, object hafzadate, string syndicate, string subCommitte)
        {
            MMashatId = mMashatId;
            MMashatName = mMashatName;
            Sarfnumber = sarfnumber;
            Hafzano = hafzano;
            Hafzadate = hafzadate;
            Syndicate = syndicate;
            SubCommitte = subCommitte;
        }
        public int MMashatId { get; set; }
        public string MMashatName { get; set; }
        public int Sarfnumber { get; set; }
        public object Hafzano { get; set; }
        public object Hafzadate { get; set; }
        public string Syndicate { get; set; }
        public string SubCommitte { get; set; }
    }
}
