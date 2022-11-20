using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace WebApplication.Controllers
{
    public class OperadorController : Controller
    {
        public IActionResult Index()
        {
            Sistema intancia = Sistema.Instancia;
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");
            if (ViewBag.Permisos == "operador")
            {
                return View();
            }

            return RedirectToAction("NoTienePermiso", "Home");
        }

        public IActionResult Participantes()
        {
            Sistema instancia = Sistema.Instancia;
            List<Seleccion> selecciones = instancia.GetSelecciones();
            selecciones.Sort();
            return View(selecciones);
        }

        public IActionResult PartidosJugados()
        {
            Sistema instancia = Sistema.Instancia;
           
            List<Partido> retorno = instancia.GetPartidosTerminados();

            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");
            if (ViewBag.Permisos == "operador")
            {
                return View(retorno);
            }

            return RedirectToAction("NoTienePermiso", "Home");
        }

        public IActionResult Finalizar()
        {
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");

            if (ViewBag.Permisos == "operador")
            {
                Sistema instancia = Sistema.Instancia;
                List<Partido> retorno = instancia.GetPartidosNoTerminados();
                return View(retorno);
            }
            return RedirectToAction("NoTienePermiso", "Home");
        }

  
        public IActionResult Finalizado(string id)
        {
            Sistema instancia = Sistema.Instancia;
            ViewBag.ErrorFinalizar = "";
            int idNum = 0;
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");
            if (ViewBag.Permisos == "operador")
            {
                if(id == null) { ViewBag.ErrorFinalizar = "NO HAY PARTIDO";}
                try
                {
                    idNum = int.Parse(id);
                }
                catch
                {
                    ViewBag.ErrorFinalizar = "NO ES UN ID CORRECTO";
                }
                List<Partido> partidos = instancia.GetPartidos();
                foreach(Partido p in partidos)
                {
                    if(idNum == p.Id && !p.Finalizado)
                    {

                        p.TerminarPartido();
                        return View(p);
                    }
                    else if(idNum == p.Id && p.Finalizado)
                    {
                        ViewBag.ErrorFinalizar = "NO ES UN ID CORRECTO";
                        return View();

                    }
                }
                ViewBag.ErrorFinalizar = "NO ES UN ID CORRECTO";
                return View();
            }
            return RedirectToAction("NoTienePermiso", "Home");


        }
        
        public IActionResult PartidoFecha() 
        {
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");
            if (ViewBag.Permisos == "operador")
            {
                return View();
            }

            return RedirectToAction("NoTienePermiso", "Home");
        }
        [HttpPost]
        public IActionResult PartidoFecha(DateTime fechaInico, DateTime fechaFin)     
        {
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");
            if (ViewBag.Permisos == "operador")
            {
                Sistema instancia = Sistema.Instancia;
                List<Partido> partidos = instancia.GetPartidosTerminados();
                try
                {
                    List<Partido> partidosFecha = instancia.GetPartidosPorFecha(partidos, fechaInico, fechaFin);
                    return View(partidosFecha);
                }
                catch(Exception e)
                {
                    ViewBag.ErrorPartidoFecha = e.Message;
                    return View();
                }
            }

            return RedirectToAction("NoTienePermiso", "Home");
        }

        public IActionResult Estadistica()
        {
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");
            if (ViewBag.Permisos == "operador")
            {
                Sistema instancia = Sistema.Instancia;
                return View(instancia.GetSeleccionConMasGoles());
            }
            return RedirectToAction("NoTienePermiso", "Home");
        }

        public IActionResult PeriodistaRoja()
        {
            return View();
        }


        [HttpPost]
        public IActionResult PeriodistaRoja(string? email)
        {
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Permisos = HttpContext.Session.GetString("permisos");
            
            if (ViewBag.Permisos == "operador")
            {
                List<Resena> retorno = new List<Resena>();
                Sistema instancia = Sistema.Instancia;
                Periodista periodista = instancia.GetPeriodista(email);
                if(periodista == null) { ViewBag.ErrorPeriodistaRoja = "No existe el periodista"; }
                else
                {
                    ViewBag.NombrePeriodista = periodista.Nombre;
                List<Resena> resenaList = periodista.GetResenas;
                foreach (Resena resena in resenaList)
                {
                   if(resena.TieneRoja()) { retorno.Add(resena); }
                }
                }

                return View(retorno);

            }
            return RedirectToAction("NoTienePermiso", "Home");
        }

        public IActionResult PeriodistaResena()
        {
            Sistema instancia = Sistema.Instancia;
            List<Periodista> retorno = instancia.GetPeriodistas();
            return View(retorno) ;
        }

        public IActionResult PeriodistaResenaId(string? email)
        {
            Sistema instancia = Sistema.Instancia;

            Periodista periodista = instancia.GetPeriodista(email);

            if(periodista == null) 
            {
                ViewBag.Error = "Existe Periodistta";
                return View(); 
            }

            return View(periodista.GetResenas);
        }

    }
}
