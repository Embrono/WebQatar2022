using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

    }
}