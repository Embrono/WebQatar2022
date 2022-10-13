using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

    }
}