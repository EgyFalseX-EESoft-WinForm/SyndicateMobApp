using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateMobApp.Services
{
    [DataContract]
    public class RePrintResonContrect
    {
        public RePrintResonContrect(byte reprintresonid, string reprintreson)
        {
            Reprintresonid = reprintresonid;
            Reprintreson = reprintreson;
        }
        [DataMember]
        public int Reprintresonid { get; set; }
        [DataMember]
        public string Reprintreson { get; set; }
    }
}
