using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
          Sistema instancia = Sistema.Instancia;

          if (instancia.Login(email, password))
          {
            HttpContext.Session.SetString("email", email);
            HttpContext.Session.SetString("permisos", "periodista");

            return RedirectToAction("Index", "Periodista");
          }
          return View();
        }

        public IActionResult NoTienePermiso() { return View(); }


        public  IActionResult Participantes()
        {    
            List<Seleccion> selecciones = instancia.GetSelecciones();
            selecciones.Sort();
            return View(selecciones);
        }

        public IActionResult Registro()
        {
            return View();
        }
        
        public IActionResult AccesoAdmin()
        {
            return View();
        }
  }
}
