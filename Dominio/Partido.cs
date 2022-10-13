﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Partido : IValidable
    {
        private static int LastID = 0;
        public int Id;
        public Seleccion SeleccionLocal;
        public Seleccion SeleccionVisitante;
        public DateTime FechaYHora;
        public bool Finalizado = false;
        protected List<Incidencia> _incidencias;
        public string ResultadoFinal = "Pendiente";

        public Partido(Seleccion seleccionLocal, Seleccion seleccionVisitante, DateTime fechaYHora)
        {
            _incidencias = new List<Incidencia>();
            Id = LastID;
            LastID++;
            SeleccionLocal = seleccionLocal;
            SeleccionVisitante = seleccionVisitante;
            FechaYHora = fechaYHora;
        }

        public override string ToString()
        {
            return $"Seleccion Local:{SeleccionLocal}, Seleccion Visitante:{SeleccionVisitante}, Fecha:{FechaYHora.ToShortDateString()}, Hora:{FechaYHora.Hour}:{FechaYHora.Minute}, Cantidad Incidencia:{_incidencias.Count}";
        }
        public List<Jugador> JugadoresExpulsados()
        {
            List<Jugador> retorno = new List<Jugador>();
            foreach (Incidencia i in _incidencias)
            {
                if (i.TipoDeIncidencia == TipoDeIncidencia.ROJA)
                {
                    retorno.Add(i.Jugador);
                }
            }
            return retorno;
        }

        public void AgregarIncidencia(Incidencia incidencia)
        {
            if (SeleccionLocal.ExisteJugador(incidencia.Jugador) || SeleccionVisitante.ExisteJugador(incidencia.Jugador))
            {
                if (CantidadDeAmarillasEnUnPartidoUnJugador(incidencia.Jugador) >= 2 && TipoDeIncidencia.AMARILLA == incidencia.TipoDeIncidencia)
                {
                    throw new Exception("YA TIENE 2 AMARILLAS");
                }
                if (TieneRojasEnEstePartido(incidencia.Jugador) && incidencia.TipoDeIncidencia == TipoDeIncidencia.ROJA)
                {
                    throw new Exception("YA TIENE ROJA");
                }
                _incidencias.Add(incidencia);
            }
            else
            {
                throw new Exception("NO PERTERNECE A LA SELECCION");
            }
        }

        public int CantidadDeAmarillasEnUnPartidoUnJugador(Jugador jugador)
        {
            int retorno = 0;
            foreach (Incidencia incidencia in _incidencias)
            {
                if (incidencia.Jugador.Equals(jugador) && incidencia.TipoDeIncidencia == TipoDeIncidencia.AMARILLA)
                {
                    retorno++;
                }
            }
            return retorno;
        }
        public bool TieneRojasEnEstePartido(Jugador jugador)
        {
            foreach (Incidencia incidencia in _incidencias)
            {
                if (incidencia.Jugador.Equals(jugador) && incidencia.TipoDeIncidencia == TipoDeIncidencia.ROJA)
                {
                    return true;
                }
            }
            return false;
        }
        public int CantidadDeUnTipoDeIncidencia(TipoDeIncidencia tipoDeIncidencia)
        {
            int retorno = 0;

            foreach (Incidencia incidencia in _incidencias)
            {
                if (incidencia.TipoDeIncidencia == tipoDeIncidencia) { retorno++; }
            }

            return retorno;
        }

        public List<Jugador> JugadoresConGol()
        {
            List<Jugador> retorno = new List<Jugador>();
            foreach (Incidencia i in _incidencias)
            {
                if (i.TipoDeIncidencia == TipoDeIncidencia.GOL)
                {
                    retorno.Add(i.Jugador);
                }
            }
            return retorno;
        }


        public bool IsValid()
        {
            return true;
        }

        public abstract void TerminarPartido();
    }
}