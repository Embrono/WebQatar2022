 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Collections.Generic;
using System;

namespace WebApplication.Controllers
{
    public class PeriodistaController : Controller
    {
        public IActionResult Index()
        {
            Sistema intancia = Sistema.Instancia;
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");
            if (ViewBag.Permisos == "periodista")
            {
                Sistema instancia = Sistema.Instancia;
                List<Seleccion> selecciones = instancia.GetSelecciones();
                selecciones.Sort();
                return View(selecciones);
            }

            return RedirectToAction("NoTienePermiso", "Home");
        }
        public IActionResult Resena()
        {
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");
            if(ViewBag.Permisos == "periodista")
            {
                Sistema instancia = Sistema.Instancia;
                List<Partido> partidos = instancia.GetPartidosTerminados();
                return View(partidos);
            }

            return RedirectToAction("NoTienePermiso", "Home");
        }
        [HttpPost]
        public IActionResult Resena(string partido, string titulo, string contenido)
        {
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");
            if (ViewBag.Permisos == "periodista")
            {
                    Sistema instancia = Sistema.Instancia;
                string email = HttpContext.Session.GetString("email");
                Partido unPartido = instancia.GetPartido(partido);
                Periodista periodista = instancia.GetPeriodista(email);


                if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(contenido))
                {
                    ViewBag.ErrorResena = "Hay un error";

                }
                else
                {
                    ViewBag.ExitoResena = "RESENA CREADA CON EXITO";
                    periodista.AgregarResena(DateTime.Now, unPartido, titulo, contenido);
                }

                List<Partido> partidos = instancia.GetPartidosTerminados();
                return View(partidos);
            }

            return RedirectToAction("NoTienePermiso", "Home");

        }
        public IActionResult PartidoFinalizado()
        {
            Sistema instancia = Sistema.Instancia;

            List<Partido> retorno = instancia.GetPartidosTerminados();

            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");
            if (ViewBag.Permisos == "periodista")
            {
                return View(retorno);
            }

            return RedirectToAction("NoTienePermiso", "Home");
        }
        public IActionResult ResenasRealizadas()
        {
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");
            if (ViewBag.Permisos == "periodista")
            {
                Sistema instancia = Sistema.Instancia;

                string email = HttpContext.Session.GetString("email");
                Periodista periodista = instancia.GetPeriodista(email);
                return View(periodista.GetResenas);
            }

            return RedirectToAction("NoTienePermiso", "Home");
            
        }

    }
}