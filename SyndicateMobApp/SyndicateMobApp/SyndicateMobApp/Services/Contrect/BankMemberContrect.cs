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
        public BankMemberContrect(long autoId, int mMashatId, double summony, object sendbankdate, double amanatmony, object amanatwareddate, string dofatSarf)
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
        public object Sendbankdate { get; set; }
        public double Amanatmony { get; set; }
        public object Amanatwareddate { get; set; }
        public string DofatSarf { get; set; }
    }
}
