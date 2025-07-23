using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace MiPrimeraFuncion;

public static class MiFuncionHttp
{
    [Function("MiFuncionHttp")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        string name = req.Query["name"]!;
        string respuesta = string.IsNullOrEmpty(name)
            ? "Hola desde Azure Functions!"
            : $"Hola, {name}, desde Azure Functions!";
        return new OkObjectResult(respuesta);
    }
}