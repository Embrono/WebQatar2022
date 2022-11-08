using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Collections.Generic;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        Sistema instancia = Sistema.Instancia;
        
        public IActionResult Index()
        {
            ViewBag.Mensaje = "Hola manu";
            return View();
        }

        public  IActionResult Tabla()
        {
            List<Seleccion> selecciones = instancia.GetSelecciones();
            return View(selecciones);
        }

        public IActionResult Registro()
        {
            return View();
        }
    }
}
