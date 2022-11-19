using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Collections.Generic;

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
                Sistema instancia = Sistema.Instancia;
                List<Seleccion> selecciones = instancia.GetSelecciones();
                selecciones.Sort();
                return View(selecciones);
            }

            return RedirectToAction("NoTienePermiso", "Home");
        }
    }
}
