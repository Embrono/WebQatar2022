using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Seleccion : IComparable
    {
        public Pais Pais;
        private List<Jugador> _jugadores;
        public Seleccion(Pais p)
        {
            Pais = p;
            _jugadores = new List<Jugador>();

        }
        public void AgregarJugador(Jugador jugador)
        {
            _jugadores.Add(jugador);
        }

        public int CompareTo(object obj)
        {
            if (obj is Seleccion otro)
                return this.Pais.CompareTo(otro.Pais);
            throw new Exception();
        }

        public bool ExisteJugador(Jugador jugador)
        {
            return _jugadores.Contains(jugador);
        }
        public override string ToString()
        {
            return Pais.ToString();
        }
        public List<Jugador> GetJugadores()
        {
            return _jugadores;
        }
    }

}