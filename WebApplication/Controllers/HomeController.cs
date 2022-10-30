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
            List<Jugador> jugadores = instancia.GetJugadores();

            return View(jugadores);
        }
    }
}
