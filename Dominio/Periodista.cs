using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Periodista : IValidable
    {
        private static int LastID = 0;
        public int Id { get; }
        public string Nombre;

        public string Email;
        public string Password;
        private List<Resena> _resenas;


        public Periodista(string nombre, string email, string password)
        {
            Id = LastID;
            LastID++;
            Nombre = nombre;
            Email = email;
            Password = password;

            _resenas = new List<Resena>();
        }

        public Periodista() {
            
            Id = LastID;
            LastID++;
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

    }
}