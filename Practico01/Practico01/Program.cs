using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>();
            while(true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("* Ingresar una Nueva Persona *");
                    Persona p = new Persona();

                    Console.Write("Ingrese el Nombre (o la palabra 'exit' para finalizar): ");
                    string nombre = Console.ReadLine();

                    if (nombre.ToLower() == "exit")
                    {
                        break;
                    }
                    p.Nombre = nombre;
                    
                    Console.Write("Ingrese el Apellido: ");
                    p.Apellido = Console.ReadLine();
                    Console.Write("Ingrese el Documento: ");
                    p.Documento = Console.ReadLine();
                    Console.Write("Fecha de nacimiento (YYYY-MM-DD): ");
                    p.FechaNacimiento = DateTime.Parse(Console.ReadLine());

                    personas.Add(p);

                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Error en ejecución: " + ex.Message);
                }
            }/* while (!Console.ReadLine().Equals("EXIT"));*/
            if (personas.Count > 0)
            {
                List<Persona> personasOrdenadas = personas.OrderBy(p => p.FechaNacimiento).ToList();

                Console.Clear();
                Console.WriteLine("Lista de personas ordenadas por edad: \n");
                foreach (Persona p in personasOrdenadas)
                {
                    int edad = Utils.CalcularEdad(p.FechaNacimiento);
                    Console.WriteLine("Nombre: " + p.Nombre);
                    Console.WriteLine("Apellido: " + p.Apellido);
                    Console.WriteLine("Documento: " + p.Documento);
                    Console.WriteLine("Fecha de Nacimiento: " + p.FechaNacimiento + " (" + edad + " Años de Edad)");
                    Console.WriteLine("* - * * - * - * - * - * - * - * - * - * -");
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No se ingresaron personas.");
            }
        }
    }
}
