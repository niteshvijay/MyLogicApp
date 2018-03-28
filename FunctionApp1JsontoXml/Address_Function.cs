

using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace FunctionApp1JsontoXml
{
    public static class Address_Function
    {
        [FunctionName("Address_Function")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            var sba_adds = JsonConvert.DeserializeObject<BeanObjcts.SBAApplicants>(requestBody);

            // var sba_adds = JsonConvert.DeserializeObject<SBAAddress>(requestBody);

            // log.Info(sba_adds.City);
            List<TemAddresses> temAddresses = new List<TemAddresses>();

            log.Info(sba_adds.currentAddress.City);
            if(sba_adds.currentAddress != null) { 
                TemAddresses temAddress = new TemAddresses();
                temAddress.Address1 = sba_adds.currentAddress.streetAddressLine1;
                temAddress.Address2 = sba_adds.currentAddress.streetAddressLine2;
                temAddress.City = sba_adds.currentAddress.City;
                temAddress.County = sba_adds.currentAddress.county;
                temAddress.CountyId = sba_adds.currentAddress.zipCode;
                temAddress.AddressTypeId = "311";
                temAddresses.Add(temAddress);
              
            }
            if (sba_adds.previousAddress != null)
            {
                TemAddresses temAddress = new TemAddresses();
                temAddress.Address1 = sba_adds.previousAddress.streetAddressLine1;
                temAddress.Address2 = sba_adds.previousAddress.streetAddressLine2;
                temAddress.City = sba_adds.previousAddress.City;
                temAddress.County = sba_adds.previousAddress.county;
                temAddress.CountyId = sba_adds.previousAddress.zipCode;
                temAddress.AddressTypeId = "312";
                temAddresses.Add(temAddress);
            }

            //adding Root name to list of addresses in Temenos Address list
            var addressesWrapper = new { Addresses = temAddresses };
           // BeanObjcts.TemApplicant temApplicant = new BeanObjcts.TemApplicant();
           // temApplicant.addresses(temAddresses);


           // var json = JsonConvert.SerializeObject(addressesWrapper);

            // log.Info(sba_adds.previousAddress.City);

            //  log.Info(json);


            // dynamic data = JsonConvert.DeserializeObject(requestBody);
            // name = name ?? data?.name;

            // return name != null
            //     ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");

            return (ActionResult)new OkObjectResult($"Hello, {JsonConvert.SerializeObject(addressesWrapper)}");
        }

      //  public TemAddresses SBAtoTemAddressMapping(SBAAddress sbaAddress) {

        //    TemAddresses temAddresses = new TemAddresses();
        //    temAddresses.Address1 = sbaAddress.streetAddressLine1;
        //    temAddresses.Address2 = sbaAddress.streetAddressLine2;
        //    temAddresses.City = sbaAddress.City;

//            return temAddresses;
  //      }
    }
}
