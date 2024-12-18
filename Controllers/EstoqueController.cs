using Microsoft.AspNetCore.Mvc;

namespace CafeManiaApi.Controllers
{
    public class EstoqueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
