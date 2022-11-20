using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Resena
    {

        private static int LastID = 0;
        public int Id;
        public DateTime FechaResena { get; set; }
        public Partido Partido { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }

        public Resena(DateTime fechaResena, Partido partido, string titulo, string contenido)
        {

            if (partido.Finalizado)
            {
                Id = LastID;
                LastID = LastID + 1;
                FechaResena = fechaResena;
                Partido = partido;
                Titulo = titulo;
                Contenido = contenido;
            }
            else
            {
                throw new Exception("EL PARTIDO NO TERMINO");
            }
        }

        public bool TieneRoja()
        {
            return this.Partido.CantidadDeUnTipoDeIncidencia(TipoDeIncidencia.ROJA) > 0;
        }
    }
}