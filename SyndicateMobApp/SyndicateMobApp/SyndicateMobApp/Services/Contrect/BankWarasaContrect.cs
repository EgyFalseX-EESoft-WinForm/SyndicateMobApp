using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateMobApp.Services
{
    public class BankWarasaContrect
    {
        public BankWarasaContrect(long autoId, int mMashatId, int personId, string visanumber, double summony, DateTime sendbankdate, double amanatmony, object amanatwareddate, int newid)
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
        public long AutoId { get; set; }
        public int MMashatId { get; set; }
        public int PersonId { get; set; }
        public string Visanumber { get; set; }
        public double Summony { get; set; }
        public DateTime Sendbankdate { get; set; }
        public double Amanatmony { get; set; }
        public object Amanatwareddate { get; set; }
        public int Newid { get; set; }
    }
}
