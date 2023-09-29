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
    public static class SecondCalculator
    {
        [FunctionName("SecondCalculator")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "calculator")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            CalculationRequest rq = JsonConvert.DeserializeObject<CalculationRequest>(requestBody);
            CalculationResult cr = new CalculationResult();
            cr.Operator = rq.Operator;
            cr.Result = rq.getal1 + rq.getal2;
            return new OkObjectResult(cr);
        }
    }
}
