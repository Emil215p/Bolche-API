using Microsoft.AspNetCore.Mvc;

namespace BolcheAPI.Controllers
{
    public class BolcheController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
