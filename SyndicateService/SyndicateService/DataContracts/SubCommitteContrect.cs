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
        [DataMember]
        public int SubCommitteId { get; set; }
        [DataMember]
        public string SubCommitte { get; set; }
        [DataMember]
        public int SyndicateId { get; set; }
        [DataMember]
        public double Lat { get; set; }
        [DataMember]
        public double Long { get; set; }
    }
}
