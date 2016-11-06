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
    public class BankMemberContrect
    {
        public BankMemberContrect(long autoId, int mMashatId, double summony, DateTime? sendbankdate, double amanatmony, DateTime? amanatwareddate, string dofatSarf)
        {
            AutoId = autoId;
            MMashatId = mMashatId;
            Summony = summony;
            Sendbankdate = sendbankdate;
            Amanatmony = amanatmony;
            Amanatwareddate = amanatwareddate;
            DofatSarf = dofatSarf;
        }
        [DataMember]
        public long AutoId { get; set; }
        [DataMember]
        public int MMashatId { get; set; }
        [DataMember]
        public double Summony { get; set; }
        [DataMember]
        public DateTime? Sendbankdate { get; set; }
        [DataMember]
        public double Amanatmony { get; set; }
        [DataMember]
        public DateTime? Amanatwareddate { get; set; }
        [DataMember]
        public string DofatSarf { get; set; }
    }
}
