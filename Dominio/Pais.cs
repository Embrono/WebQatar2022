using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pais : IComparable
    {
        private static int LastID = 0;
        public int Id;
        public string Nombre;
        public string Alpha3;

        public Pais(string nombre, string alpha3)
        {
            Id = LastID;
            LastID++;
            Nombre = nombre;
            Alpha3 = alpha3;
        }

        public override string ToString()
        {
            return $"Id:{Id}, Nombre:{Nombre}, Alpha3:{Alpha3}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Pais item))
            {
                return false;
            }

            return Nombre.Equals(item.Nombre);
        }

        public int CompareTo(object obj)
        {
            Pais pais = obj as Pais;

            return Nombre.CompareTo(pais.Nombre);
        }
    }
}