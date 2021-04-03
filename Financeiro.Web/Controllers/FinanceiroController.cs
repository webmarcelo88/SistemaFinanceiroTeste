using Microsoft.AspNetCore.Mvc;

namespace Financeiro.Web.Controllers
{
    public class FinanceiroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }      
    }
}
