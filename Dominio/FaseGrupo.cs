using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class FaseGrupos : Partido
    {
        public string NombreGrupo;

        public FaseGrupos(Seleccion seleccionLocal, Seleccion seleccionVisitante, DateTime fechaYHora, string nombreGrupo) : base(seleccionLocal, seleccionVisitante, fechaYHora)
        {
            NombreGrupo = nombreGrupo;
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
                        if (i.Jugador.Pais.Equals(SeleccionLocal.Pais))
                        {
                            golesSeleccionLocal++;
                        }
                        else
                        {
                            golesSeleccionVisitante++;
                        }
                    }
                }

                    if (golesSeleccionVisitante == golesSeleccionLocal)
                    {
                        this.ResultadoFinal = "Empate: " + SeleccionLocal.Pais.Nombre + " " + SeleccionVisitante.Pais.Nombre;
                    }
                    if (golesSeleccionLocal > golesSeleccionVisitante)
                    {
                        this.ResultadoFinal = "Ganador: " + SeleccionLocal.Pais.Nombre;
                    }
                    if (golesSeleccionVisitante > golesSeleccionLocal)
                    {
                        this.ResultadoFinal = "Ganador: " + SeleccionVisitante.Pais.Nombre;
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

            foreach (Incidencia i in _incidencias)
            {
                if(i.TipoDeIncidencia == TipoDeIncidencia.GOL)
                {
                    if (i.Jugador.Pais.Equals(this.SeleccionLocal.Pais))
                    {
                        cantidadLocalGol++;
                    }
                    else
                    {
                        cantidadVisitanteGol++;
                    }

                }
                if (i.TipoDeIncidencia == TipoDeIncidencia.AMARILLA)
                {
                    if (i.Jugador.Pais.Equals(this.SeleccionLocal.Pais))
                    {
                        cantidadVisitanteAmarilla++;
                    }
                    else
                    {
                        cantidadVisitanteAmarilla++;
                    }
                }
                if (i.TipoDeIncidencia == TipoDeIncidencia.ROJA)
                {
                    if (i.Jugador.Pais.Equals(this.SeleccionLocal.Pais))
                    {
                        cantidadLocalRojas++;
                    }
                    else
                    {
                        cantidadVisitanteRojas++;
                    }
                }
            }
            string SeleccionLocal = $"Seleccion 1 {this.SeleccionLocal.Pais.Nombre}: Goles{cantidadLocalGol}, Amarillas{cantidadLocalAmarilla}, Rojas,{cantidadLocalRojas}";
            string SeleccionVisitante = $"Seleccion 2 {this.SeleccionVisitante.Pais.Nombre}: Goles{cantidadVisitanteGol}, Amarillas{cantidadVisitanteAmarilla}, Rojas,{cantidadVisitanteRojas}";

            retorno.Add(SeleccionLocal);
            retorno.Add(SeleccionVisitante);
            return retorno;
            
        }

        public override string FaseOEtapa()
        {
            return this.NombreGrupo;
        }
    }
}