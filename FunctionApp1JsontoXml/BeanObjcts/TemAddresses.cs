using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FunctionApp1JsontoXml
{
    [JsonObject(Title = "Addresses")]
    class TemAddresses
    {

        [JsonProperty("Address1")]
        public string Address1 { get; set; }
        [JsonProperty("Address2")]
        public string Address2 { get; set; }
        [JsonProperty("AddressCategoryId")]
        public string AddressCategoryId { get; set; }
        [JsonProperty("AddressId")]
        public string AddressId { get; set; }
        [JsonProperty("AddressStatusId")]
        public string AddressStatusId { get; set; }
        [JsonProperty("AddressTypeId")]
        public string AddressTypeId { get; set; }
        [JsonProperty("City")]
        public string City { get; set; }
        [JsonProperty("ClassificationId")]
        public string ClassificationId { get; set; }
        [JsonProperty("CountryId")]
        public string CountryId { get; set; }
        [JsonProperty("County")]
        public string County { get; set; }
        [JsonProperty("CountyId")]
        public string CountyId { get; set; }

    }
}
