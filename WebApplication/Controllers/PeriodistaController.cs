using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio;
namespace WebApplication.Controllers
{
    public class PeriodistaController : Controller
    {
        public IActionResult Index()
        {
            Sistema intancia = Sistema.Instancia;
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");
            if(ViewBag.Permisos == "periodista")
            {
            return View();
            }

            return RedirectToAction("NoTienePermiso", "Home");
        }
    }
}
