using BusinessLayer.BLs;
using BusinessLayer.IBLs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PracticoClase1
{
    public class Commands
    {
        IBL_Personas _personasBL;
        IBL_Vehiculos _vehiculosBL;

        public Commands(IBL_Personas personasBL, IBL_Vehiculos vehiculosBL)
        {
            _personasBL = personasBL;
            _vehiculosBL = vehiculosBL;
        }

        public void AddPersona()
        {
            // Pedimos los datos de la pesona.
            Persona persona = new Persona();
            Console.WriteLine("Ingrese el nombre de la persona: ");
            persona.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido de la persona: ");
            persona.Apellido = Console.ReadLine();

            Console.WriteLine("Ingrese el documento de la persona: ");
            persona.Documento = Console.ReadLine();
            
            Console.WriteLine("Ingrese el teléfono de la persona: ");
            persona.Telefono = Console.ReadLine();
            
            Console.WriteLine("Ingrese la dirección de la persona: ");
            persona.Direccion = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento de la persona: (dd/MM/AAAA)");
            persona.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            _personasBL.Insert(persona);

            _personasBL.Get(persona.Documento).Print();
        }

        public void ListPersonas()
        {
            List<Persona> personas = _personasBL.Get();

            Console.WriteLine("Listado de personas:");
            Console.WriteLine("| ID | Documento | Nombre | Apellido |");

            foreach (Persona persona in personas)
            {
                persona.PrintTable();
            }
        }

        public void RemovePersona()
        {
            Console.WriteLine("Ingrese el documento de la persona a eliminar: ");
            string documento = Console.ReadLine();

            _personasBL.Delete(documento);

            Console.WriteLine("Persona eliminada correctamente.");
        }

        public void AddVehiculo()
        {
            // Pedimos los datos de la pesona.
            Vehiculo vehiculo = new Vehiculo();
            Console.WriteLine("Ingrese la marca del vehículo: ");
            vehiculo.Marca = Console.ReadLine();

            Console.WriteLine("Ingrese el modelo del vehículo: ");
            vehiculo.Modelo = Console.ReadLine();

            Console.WriteLine("Ingrese la matricula del vehículo: ");
            vehiculo.Matricula = Console.ReadLine();

            Console.WriteLine("Ingrese el ID del dueño del vehículo: ");
            vehiculo.PersonaId = long.Parse(Console.ReadLine());

            _vehiculosBL.Insert(vehiculo);

            _vehiculosBL.Get(vehiculo.Matricula).Print();
        }

        public void ListVehiculos()
        {
            List<Vehiculo> vehiculos = _vehiculosBL.Get();

            Console.WriteLine("Listado de Vehículos:");
            Console.WriteLine("| ID | Marca | Modelo | Dueño ID |");

            foreach (Vehiculo vehiculo in vehiculos)
            {
                vehiculo.PrintTable();
            }
        }
    }
}
