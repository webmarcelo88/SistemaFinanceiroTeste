using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;

namespace Financeiro.API.Controllers
{
    public class FinanceiroControllerBase : ControllerBase
    {
        public static ActionResult Result(HttpStatusCode statusCode, string reason) => new ContentResult
        {
            StatusCode = (int)statusCode,
            Content = FormatarMensagemRetorno(statusCode, reason)
        };

        private static string FormatarMensagemRetorno(HttpStatusCode statusCode, string reason)
        {
            return JsonConvert.SerializeObject($"StatusCode: '{(int)statusCode}'," +
                                               $"descricaoStatusCode: '{statusCode}'," +
                                               $"Mensagem: '{reason}'");
        }
    }
}
