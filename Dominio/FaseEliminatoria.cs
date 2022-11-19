using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class FaseEliminatoria : Partido
    {
        public bool HayAlargue;
        public bool HayPenales;
        public string Etapa;


        public FaseEliminatoria(Seleccion seleccionLocal, Seleccion seleccionVisitante, DateTime fechaYHora, bool hayAlargue, bool hayPenales, string etapa) : base(seleccionLocal, seleccionVisitante, fechaYHora)
        {
            HayAlargue = hayAlargue;
            HayPenales = hayPenales;
            Etapa = etapa;
        }

 
        public override void TerminarPartido()
        {
            if (this.Finalizado == false)
            {
                int golesSeleccionLocal = 0;
                int golesSeleccionVisitante = 0;

                foreach (Incidencia i in _incidencias)
                {

                    if (i.TipoDeIncidencia == TipoDeIncidencia.GOL)
                    {
                        golesSeleccionLocal++;
                    }
                    else
                    {
                        golesSeleccionVisitante++;
                    }
                }

                if (!this.HayPenales && !this.HayAlargue)
                {

                    if (golesSeleccionLocal > golesSeleccionVisitante)
                    {
                        this.ResultadoFinal = "Ganador: " + SeleccionLocal.Pais.Nombre;
                    }
                    if (golesSeleccionLocal < golesSeleccionVisitante)
                    {
                        this.ResultadoFinal = "Ganador: " + SeleccionVisitante.Pais.Nombre;
                    }

                }
                else if (this.HayPenales)
                {
                    if (golesSeleccionLocal > golesSeleccionVisitante)
                    {
                        this.ResultadoFinal = "Empate en tiempo de juego. Ganador: " + SeleccionLocal.Pais.Nombre + " en tanda de penales";
                    }
                    if (golesSeleccionLocal < golesSeleccionVisitante)
                    {
                        this.ResultadoFinal = "Empate en tiempo de juego. Ganador:" + SeleccionVisitante.Pais.Nombre + " en tanda de penales";
                    }
                }
                else if (this.HayAlargue)
                {
                    if (golesSeleccionLocal > golesSeleccionVisitante)
                    {
                        this.ResultadoFinal = "Empate en tiempo de juego. Ganador: " + SeleccionLocal.Pais.Nombre + " en alargue";
                    }
                    if (golesSeleccionLocal < golesSeleccionVisitante)
                    {
                        this.ResultadoFinal = "Empate en tiempo de juego. Ganador: " + SeleccionLocal.Pais.Nombre + " en alargue";
                    }

                }
                this.Finalizado = true;

            }


        }

        public override List<String> TotalIncidencia()
        {
            List<String> retorno = new List<String>();
            int cantidadLocalGol = 0;
            int cantidadLocalAmarilla = 0;
            int cantidadLocalRojas = 0;

            int cantidadVisitanteGol = 0;
            int cantidadVisitanteAmarilla = 0;
            int cantidadVisitanteRojas = 0;
            string detalleLocal = "";
            string detalleVisitante = "";

            foreach (Incidencia i in _incidencias)
            {
                if (i.TipoDeIncidencia == TipoDeIncidencia.GOL)
                {
                    if (i.Jugador.Pais.Equals(this.SeleccionLocal.Pais))
                    {
                        cantidadLocalGol++;
                        detalleLocal += $" {i.Jugador.Nombre} Gol a los : ";
                        if(i.Minuto > 0) { detalleLocal += i.Minuto; }
                        else { detalleLocal += " En penales "; }
                    }
                    else
                    {
                        cantidadVisitanteGol++;
                        detalleVisitante += $" {i.Jugador.Nombre} Gol a los : ";
                        if (i.Minuto > 0) { detalleVisitante += i.Minuto; }
                        else { detalleVisitante += "En penales"; }
                    }

                }
                if (i.TipoDeIncidencia == TipoDeIncidencia.AMARILLA)
                {
                    if (i.Jugador.Pais.Equals(this.SeleccionLocal.Pais))
                    {
                        cantidadLocalAmarilla++;
                        detalleLocal += $" {i.Jugador.Nombre} Amarilla a los : ";
                        if (i.Minuto > 0) { detalleLocal += i.Minuto; }
                        else { detalleLocal += " En penales "; }
                    }
                    else
                    {
                        cantidadVisitanteAmarilla++;
                        detalleVisitante += $" {i.Jugador.Nombre} Amarilla a los : ";
                        if (i.Minuto > 0) { detalleVisitante += i.Minuto; }
                        else { detalleVisitante += " En penales "; }

                    }
                }
                if (i.TipoDeIncidencia == TipoDeIncidencia.ROJA)
                {
                    if (i.Jugador.Pais.Equals(this.SeleccionLocal.Pais))
                    {
                        cantidadLocalRojas++;
                        detalleLocal += $" {i.Jugador.Nombre} Roja a los : ";
                        if (i.Minuto > 0) { detalleLocal += i.Minuto; }
                        else { detalleLocal += " En penales "; }
                    }
                    else
                    {
                        cantidadVisitanteRojas++;
                        detalleVisitante += $"{i.Jugador.Nombre} Roja a los : ";
                        if (i.Minuto > 0) { detalleVisitante += i.Minuto; }
                        else { detalleVisitante += " En penales "; }
                    }
                }
            }
            string SeleccionLocal = $"Seleccion 1 {this.SeleccionLocal.Pais.Nombre}: Goles {cantidadLocalGol}, Amarillas {cantidadLocalAmarilla}, Rojas {cantidadLocalRojas}";
            string SeleccionVisitante = $"Seleccion 2 {this.SeleccionVisitante.Pais.Nombre}: Goles {cantidadVisitanteGol}, Amarillas {cantidadVisitanteAmarilla}, Rojas {cantidadVisitanteRojas}";

            retorno.Add(SeleccionLocal);
            retorno.Add(SeleccionVisitante);
            retorno.Add(detalleLocal);
            retorno.Add(detalleVisitante);

            return retorno;
        }
        public override string FaseOEtapa()
        {
            return this.Etapa;
        }
    }
}