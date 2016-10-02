using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateMobApp.Services
{
    public class BankMemberContrect
    {
        public BankMemberContrect(long autoId, int mMashatId, double summony, DateTime sendbankdate, double amanatmony, DateTime amanatwareddate, string dofatSarf)
        {
            AutoId = autoId;
            MMashatId = mMashatId;
            Summony = summony;
            Sendbankdate = sendbankdate;
            Amanatmony = amanatmony;
            Amanatwareddate = amanatwareddate;
            DofatSarf = dofatSarf;
        }
        public long AutoId { get; set; }
        public int MMashatId { get; set; }
        public double Summony { get; set; }
        public DateTime Sendbankdate { get; set; }
        public double Amanatmony { get; set; }
        public DateTime Amanatwareddate { get; set; }
        public string DofatSarf { get; set; }
    }
}
