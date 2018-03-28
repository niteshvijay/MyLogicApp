
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Xml;

namespace FunctionApp1JsontoXml
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string json = @"{
                              '@Id': 1,
                              'Email': 'james@example.com',
                              'Active': true,
                              'CreatedDate': '2013-01-20T00:00:00Z',
                              'Roles': [
                                'User',
                                'Admin'
                              ],
                              'Team': {
                                '@Id': 2,
                                'Name': 'Software Developers',
                                'Description': 'Creators of fine software products and services.'
                              }
                            }";


            XmlDocument doc = JsonConvert.DeserializeXmlNode(json, "root");
            log.Info("C# "+doc.ToString());
            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {doc.OuterXml}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
