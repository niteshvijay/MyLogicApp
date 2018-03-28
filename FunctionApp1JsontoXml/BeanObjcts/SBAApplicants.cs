using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp1JsontoXml.BeanObjcts
{
    class SBAApplicants
    {
        
        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("lastName")]
        public string lastName { get; set; }


        [JsonProperty("currentAddress")]
        public SBAAddress currentAddress { get; set; }

        [JsonProperty("previousAddress")]
        public SBAAddress previousAddress { get; set; }

    }
}
