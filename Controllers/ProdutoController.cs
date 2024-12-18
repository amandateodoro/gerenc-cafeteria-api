using Microsoft.AspNetCore.Mvc;

namespace CafeManiaApi.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
