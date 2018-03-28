
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Xml;
using System.Collections.Generic;

// below function app taking json in post and convert to uppercase to it and return 
namespace FunctionApp1JsontoXml
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = new StreamReader(req.Body).ReadToEnd();
           //  dynamic data = JsonConvert.DeserializeObject(requestBody);

            var e_in = JsonConvert.DeserializeObject<Person_in>(requestBody);

            var e_out = new Person_out();
                e_out.FullAddress = string.Concat(e_in.Address[0].AddLine1, " ", e_in.Address[0].AddLine2, " ", e_in.Address[0].City, " ", e_in.Address[0].Zip);
            e_out.FirstName = e_in.FirstName;
            e_out.LastName = e_in.LastName;
            e_out.Age = e_in.Age;

            // string jsonString = JsonConvert.SerializeObject(data);

            return (ActionResult)new OkObjectResult($"Hello, {JsonConvert.SerializeObject(e_out)}");
            string 
           // XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonString, "root");

            // name = name ?? data?.name;
            //name = jsonString;
            // name = name.ToUpper();
           // name = doc.OuterXml.ToUpper();

            //return name != null
            //    ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }


        public class Person_in
        {
            [JsonProperty("FirstName")]
            public string FirstName { get ; set; }
            [JsonProperty("LastName")]
            public string LastName { get; set; }
            [JsonProperty("Age")]
            public int Age { get; set; }
            [JsonProperty("Address")]
            public List<Address> Address { get; set; }
            [JsonProperty("FullAddress")]
            public string FullAddress { get; set; }

        }

        public class Person_out
        {
            [JsonProperty("GivenName")]
            public string FirstName { get; set; }
            [JsonProperty("FamilyName")]
            public string LastName { get; set; }
            [JsonProperty("Age")]
            public int Age { get; set; }
            [JsonProperty("FullAddress")]
            public string FullAddress { get; set; }

        }

        public class Address
        {

            [JsonProperty("AddLine1")]
            public string AddLine1  { get; set; }
            [JsonProperty("AddLine2")]
            public string AddLine2 { get; set; }
            [JsonProperty("City")]
            public string City { get; set; }
            [JsonProperty("Zip")]
            public int Zip { get; set; }
        }


    }
}
