using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
  public class Operador
  {
    public string Email { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Password { get; set; }
    public DateTime FechaIngreso { get; set; } 


    public Operador(string email, string nombre, string apellido, string password, DateTime fechaIngreso)
    {
      Email = email;
      Nombre = nombre;
      Apellido = apellido;
      Password = password;
      FechaIngreso = fechaIngreso;
    }
  }
}
