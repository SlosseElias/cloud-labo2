
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace NMCT.IoTCloud.MyFirstServices
{
    public static class SomFunction
    {
        [FunctionName("SomFunction")]
        public static async Task<IActionResult> Som([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "calculator/som/{number1}/{number2}")]HttpRequest req, int number1, int number2, ILogger log)
        {
           
            log.LogInformation("Som function active.");
            int som = number1 + number2;
            return new OkObjectResult(som);


        }
        [FunctionName("DeelFunction")]
        public static async Task<IActionResult> Deel([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "calculator/delen/{number1}/{number2}")]HttpRequest req, int number1, int number2, ILogger log)
        {
            try
            {
                log.LogInformation("Deel function active.");
                if(number2 == 0)
                {
                    return new BadRequestResult();
                }
                decimal verschil = number1 / number2;
                return new OkObjectResult(verschil);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }

        }
    }
}
