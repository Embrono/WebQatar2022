using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Mensaje = "Hola manu";
            return View();
        }

        public  IActionResult Tabla()
        {
            return View();
        }
    }
}
