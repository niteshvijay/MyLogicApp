using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp1JsontoXml.BeanObjcts
{
    class TemApplicant
    {
        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("addresses")]
        public string addresses { get; set; }

    }
}
