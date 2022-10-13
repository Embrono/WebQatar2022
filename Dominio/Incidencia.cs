using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Incidencia
    {
        public Jugador Jugador;
        public int Minuto;
        public TipoDeIncidencia TipoDeIncidencia;


        public Incidencia(Jugador jugador, int minuto, TipoDeIncidencia tipoDeIncidencia)
        {
            Jugador = jugador;
            Minuto = minuto;
            TipoDeIncidencia = tipoDeIncidencia;
        }

        public override string ToString()
        {

            return base.ToString();
        }
    }
}