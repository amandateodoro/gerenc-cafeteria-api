using Microsoft.AspNetCore.Mvc;

namespace CafeManiaApi.Controllers
{
    public class RelatoriosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
