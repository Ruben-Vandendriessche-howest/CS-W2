using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MCT.Functions.Models;

namespace MCT.Function
{
    public static class Calculator
    {
        [FunctionName("Calculator")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "route/{getal1}/{Operator}/{getal2}")] HttpRequest req, int getal1, string Operator, int getal2,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            CalculationResult cr = new CalculationResult();
            cr.Result = getal1 + getal2;
            cr.Operator = "+";

            return new OkObjectResult(cr);
        }
    }
}
