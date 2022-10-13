using Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qatar2022
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Sistema instancia = Sistema.Instancia;

            #region Precentacion
            Console.WriteLine(MenuTexto.Qatar);
            Console.WriteLine(MenuTexto.Separador);
            Console.WriteLine(MenuTexto.Menu);
            Console.WriteLine(MenuTexto.Separador);
            #endregion

            bool salir = false;
            string opcion;
            #region PreCarga
            try
            {
                instancia.PreCargaPais();
                instancia.PreCargaJugador();
                instancia.PreCargaSelecciones();
                instancia.PreCargaPartido();
                instancia.PrecargarPeriodista();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {

                instancia.PreCargaIncidencia();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            #endregion
            do
            {
                #region OpcionesPrincipal
                Console.WriteLine(MenuTexto.ComoElegir);
                Console.WriteLine(MenuTexto.Separador);
                Console.WriteLine(MenuTexto.OpcionesMenu);
                Console.WriteLine(MenuTexto.Separador);
                Console.WriteLine("0 - PARA SALIR");
                opcion = Console.ReadLine();
                #endregion
                switch (opcion)
                {
                    #region Caso 0 terminado
                    case "0":
                        salir = true;
                        break;
                    #endregion
                    #region Caso 1 terminado
                    case "1":
                        Console.Clear();
                        Console.WriteLine(MenuTexto.AltaPeriodista);
                        Console.WriteLine(MenuTexto.Separador);
                        Console.WriteLine("Ingrese Nombre");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese Email");
                        string email = Console.ReadLine();
                        Console.WriteLine("Ingrese Password");
                        string password = Console.ReadLine();
                        try
                        {
                            instancia.AgregarPeriodista(new Periodista(nombre, email, password));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        Console.WriteLine("Precione una tecla para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    #endregion
                    #region Caso 2 terminado
                    case "2":
                        Console.Clear();
                        Console.WriteLine(MenuTexto.CambiarReferencia);
                        Console.WriteLine(MenuTexto.Separador);
                        Console.WriteLine("Ingrese el precio");
                        string precioTexto = Console.ReadLine();
                        try
                        {
                            instancia.CambiarPrecioDeReferencia(precioTexto);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        Console.WriteLine("Precione una tecla para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    #endregion
                    #region Caso 3 terminado 
                    case "3":
                        Console.Clear();
                        List<Partido> partidos;
                        Console.WriteLine(MenuTexto.ElegirJugador);
                        Console.WriteLine(MenuTexto.Separador);
                        string id = Console.ReadLine();
                        try
                        {
                            partidos = instancia.MostrarPartidosDe(id);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("Precione una tecla para continuar");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        if ((partidos.Count == 0))
                        {
                            Console.WriteLine("NO HAY PARTIDOS");
                        }
                        else
                        {
                            foreach (Partido partido in partidos)
                            {
                                Console.WriteLine(partido.ToString());
                            }
                        }
                        Console.WriteLine("Precione una tecla para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    #endregion
                    #region Caso 4 terminado
                    case "4":
                        Console.Clear();
                        Console.WriteLine(MenuTexto.Expulsados);
                        Console.WriteLine(MenuTexto.Separador);
                        List<Jugador> listaDeJugadoresExpulsados = instancia.JugadoresExpulsados();
                        if (listaDeJugadoresExpulsados.Count != 0)
                        {
                            foreach (Jugador j in listaDeJugadoresExpulsados)
                            {
                                Console.WriteLine(j.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("NO HAY JUGADORES CON ROJA");
                        }
                        Console.WriteLine(MenuTexto.Separador);
                        Console.WriteLine("Precione una tecla para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    #endregion
                    #region Caso 5 terminado
                    case "5":
                        Console.Clear();
                        Console.WriteLine(MenuTexto.NombreSeleccion);
                        Console.WriteLine(MenuTexto.Separador);
                        string nombreSeleccion = Console.ReadLine();
                        try
                        {
                            Partido paridoConMasGoles = instancia.MasGolesDeSeleccion(nombreSeleccion);
                            Console.WriteLine(paridoConMasGoles.ToString());

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        Console.WriteLine(MenuTexto.Separador);
                        Console.WriteLine("Precione una tecla para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    #endregion
                    #region Case 6 termiando
                    case "6":
                        Console.Clear();
                        Console.WriteLine(MenuTexto.Goleadores);
                        Console.WriteLine(MenuTexto.Separador);

                        List<Jugador> jugadoresConGol = instancia.JugadoresConGol();
                        if (jugadoresConGol.Count != 0)
                        {

                            foreach (Jugador j in jugadoresConGol)
                            {
                                Console.WriteLine(j.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("NO HAY JUGADORES CON UN GOL");
                        }
                        Console.WriteLine(MenuTexto.Separador);
                        Console.WriteLine("Precione una tecla para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    #endregion
                    default:
                        Console.Clear();

                        break;
                }
            } while (!salir);
        }

    }
}