using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            email = email.ToLower();
            Sistema instancia = Sistema.Instancia;
            if (instancia.Login(email, password))
            {
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("permisos", "periodista");

                return RedirectToAction("Index", "Periodista");
            }
            ViewBag.ErrorLogin = "Las credenciales no son correctas";
            return View();
        }

        public IActionResult NoTienePermiso() { return View(); }


        public IActionResult Participantes()
        {
            Sistema instancia = Sistema.Instancia;
            List<Seleccion> selecciones = instancia.GetSelecciones();
            selecciones.Sort();
            return View(selecciones);
        }
        public IActionResult Registro(string error)
        {
            ViewBag.Error = error;
            return View(new Periodista());
        }
        [HttpPost]
        public IActionResult Registro(Periodista periodista)
        {
            periodista.Email = periodista.Email.ToLower();
            Sistema instancia = Sistema.Instancia;
            try
            {
                instancia.AgregarPeriodista(periodista);
                return RedirectToAction("Registro");
            }
            catch (Exception e)
            {
                return RedirectToAction("Registro", new { error = e.Message });

            }
        }

        public IActionResult AccesoAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AccesoAdmin(string email, string password)
        {
            email = email.ToLower();
            Sistema instancia = Sistema.Instancia;
            if (instancia.LoginOperador(email, password))
            {
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("permisos", "operador");
                return RedirectToAction("Participantes", "Operador");
            }
            ViewBag.ErrorLogin = "Las credenciales no son correctas";
            return View();
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.SetString("email", "");
            HttpContext.Session.SetString("permisos", "");
            return RedirectToAction("Index", "Home");
        }
    }
}
