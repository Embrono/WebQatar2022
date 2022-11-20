using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Dominio
{
    public class Jugador : IComparable
    {
        #region Atributos

        public int Id;

        public string NumeroCamiseta;

        public string Nombre;

        public DateTime FechaNacimiento;

        public double Altura;

        public string PieHabil;

        public double Precio;

        public static double ReferenciaPrecio = 10_000;

        public string Moneda;

        public Pais Pais;

        public string Puesto;

        public bool EsVip;
        #endregion

        public Jugador(int id, string numeroCamiseta, string nombre, DateTime fechaNacimiento, double altura, string pieHabil, double precio, string moneda, Pais pais, string puesto)
        {
            Id = id;
            Nombre = nombre;
            NumeroCamiseta = numeroCamiseta;
            FechaNacimiento = fechaNacimiento;
            Altura = altura;
            PieHabil = pieHabil;
            Precio = precio;
            Moneda = moneda;
            Puesto = puesto;
            Pais = pais;
            EsVip = precio >= ReferenciaPrecio;
        }

        public override string ToString()
        {
            return $"ID:{Id}Nombre:{Nombre}, Precio:{Precio}, VIP:{EsVip}, Pais:{Pais.Alpha3}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Jugador item)
            {
                return Id.Equals(item.Id);
            }
            return false;
        }

        public void AgregarIncidencia(Partido partido, TipoDeIncidencia tipoDeIncidencia, int minuto)
        {
            if (!partido.Finalizado)
            {
                Incidencia incidencia = new Incidencia(this, minuto, tipoDeIncidencia);
                partido.AgregarIncidencia(incidencia);
            }
            else
            {
                throw new Exception("EL partido termino");
            }

        }

        public int CompareTo(object other)
        {
            Jugador otro = other as Jugador;
            if (Precio.CompareTo(otro.Precio) == 0)
            {
                return Nombre.CompareTo(otro.Nombre);
            }
            return Precio.CompareTo(otro.Precio) * -1;
        }

        public Seleccion GetSeleccion()
        {
            Sistema sistema = Sistema.Instancia;
            return sistema.GetSeleccion(this.Pais.Nombre);
        }


    }
}