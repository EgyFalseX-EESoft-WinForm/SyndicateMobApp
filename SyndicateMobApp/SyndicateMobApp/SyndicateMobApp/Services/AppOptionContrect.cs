using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateMobApp.Services
{
    public class AppOptionContrect
    {
        public AppOptionContrect(string _option_name, string _option_value)
        {
            option_name = _option_name;
            option_value = _option_value;
        }
        public string option_name { get; set; }
        public string option_value { get; set; }
    }
}
