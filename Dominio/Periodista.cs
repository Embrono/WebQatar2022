using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Periodista : IValidable, IComparable
    {
        private static int LastID = 0;
        public int Id { get; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        private List<Resena> _resenas;


        public Periodista(string nombre, string apellido, string email, string password)
        {
            Id = LastID;
            LastID++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;

            _resenas = new List<Resena>();
        }

        public Periodista() {
            
            Id = LastID;
            LastID++;
            _resenas = new List<Resena>();

        }


        public override string ToString()
        {
            return $"Id:{Id}, Nombre:{Nombre}, Email:{Email}, Password:{Password}";
        }

        public void AgregarResena(DateTime dateTime, Partido partido, string titulo, string contenido)
        {
            _resenas.Add(new Resena(dateTime, partido, titulo, contenido));
        }

        public bool IsValid()
        {
            if (Nombre.Length == 0)
            {
                throw new Exception("Nombre vacio");
            }
            if (Apellido.Length == 0)
            {
                throw new Exception("Apellido vacio");
            }
            if (Password.Length == 0 || Password.Length < 8)
            {
                throw new Exception(" Password invalido");
            }
            if (Email[0] == '@' || Email[Email.Length - 1] == '@')
            {
                throw new Exception("Email invalido");
            }

            if (!Email.Contains('@'))
            {
                throw new Exception("Email invalido");
            }
            return true;
        }

        public int CompareTo(object obj)
        {
            Periodista periodista = obj as Periodista;
            if (Apellido.CompareTo(periodista.Apellido) == 0)
            {
                return Nombre.CompareTo(periodista.Nombre);
            }
            return Apellido.CompareTo(periodista.Apellido);
        }

        public List<Resena> GetResenas { get { return _resenas; } }

    }
}