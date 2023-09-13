using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; } = "-- Sin Marca --";
        public string Modelo { get; set; } = "-- Sin Modelo --";
        public string Matricula { get => matricula; set => matricula = value; }
        private string matricula = "-- Sin Matrícula --";

        public long PersonaId { get; set; }

        public void Print()
        {
            Console.WriteLine("-- Vehículo --");
            Console.WriteLine("Marca y modelo: " + Marca + " " + Modelo);
            Console.WriteLine("Matrícula: " + Matricula);
            Console.WriteLine("ID Dueño: " + PersonaId);
        }

        public void PrintTable()
        {
            Console.WriteLine("| " + Id + " | " + Marca + " | "+ Modelo +" | " + PersonaId + " |");
        }
    }
}
