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
    public class BankWarasaContrect
    {
        public BankWarasaContrect(long autoId, int mMashatId, int personId, string visanumber, double summony, DateTime sendbankdate, double amanatmony, DateTime amanatwareddate, int newid)
        {
            AutoId = AutoId;
            MMashatId = mMashatId;
            PersonId = personId;
            Visanumber = visanumber;
            Summony = summony;
            Sendbankdate = sendbankdate;
            Amanatmony = amanatmony;
            Amanatwareddate = amanatwareddate;
            Newid = newid;
        }
        [DataMember]
        public long AutoId { get; set; }
        [DataMember]
        public int MMashatId { get; set; }
        [DataMember]
        public int PersonId { get; set; }
        [DataMember]
        public string Visanumber { get; set; }
        [DataMember]
        public double Summony { get; set; }
        [DataMember]
        public DateTime Sendbankdate { get; set; }
        [DataMember]
        public double Amanatmony { get; set; }
        [DataMember]
        public DateTime Amanatwareddate { get; set; }
        [DataMember]
        public int Newid { get; set; }
    }
}
