using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateServiceLib
{
    [DataContract]
    public class LastDofaaInfo
    {
        public LastDofaaInfo(string memname, string syndicate, string subCommitte, float amanatmony, DateTime amanatdate)
        {
            Memname = memname;
            Syndicate = syndicate;
            SubCommitte = subCommitte;
            Amanatmony = amanatmony;
            Amanatdate = amanatdate;
        }
        [DataMember]
        public string Memname { get; set; }
        [DataMember]
        public string Syndicate { get; set; }
        [DataMember]
        public string SubCommitte { get; set; }
        [DataMember]
        public float Amanatmony { get; set; }
        [DataMember]
        public DateTime Amanatdate { get; set; }
    }
}
