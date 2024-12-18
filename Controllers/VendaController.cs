using Microsoft.AspNetCore.Mvc;

namespace CafeManiaApi.Controllers
{
    public class VendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
