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
    }
}
