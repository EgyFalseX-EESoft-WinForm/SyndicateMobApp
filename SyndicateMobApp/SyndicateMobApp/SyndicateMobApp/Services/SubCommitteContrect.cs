using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateMobApp.Services
{
    public class SubCommitteContrect
    {
        public SubCommitteContrect(int subCommitteId, string subCommitte, int syndicateId, double lat, double Long)
        {
            SubCommitteId = subCommitteId;
            SubCommitte = subCommitte;
            SyndicateId = syndicateId;
            Lat = Lat;
            this.Long = Long;
        }
        public SubCommitteContrect()
        {
        }
        public int SubCommitteId { get; set; }
        public string SubCommitte { get; set; }
        public int SyndicateId { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public override string ToString()
        {
            return SubCommitte;
        }
    }
}
