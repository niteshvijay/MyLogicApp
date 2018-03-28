using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FunctionApp1JsontoXml
{
    class SBAAddress
    {
        [JsonProperty("streetAddressLine1")]
        public string streetAddressLine1 { get; set; }
        [JsonProperty("streetAddressLine2")]
        public string streetAddressLine2 { get; set; }
        [JsonProperty("City")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string state { get; set; }
        [JsonProperty("zipCode")]
        public string zipCode { get; set; }
        [JsonProperty("county")]
        public string county { get; set; }
        [JsonProperty("timeAtAddress")]
        public string timeAtAddress { get; set; }
        [JsonProperty("residenceCode")]
        public string residenceCode { get; set; }
        [JsonProperty("monthlyHousingExpense")]
        public string monthlyHousingExpense { get; set; }


    }
}
