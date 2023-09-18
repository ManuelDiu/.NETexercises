namespace Shared

{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "-- Sin Nombre --";
        public string Apellido { get; set; } = "-- Sin Apellido --";
        public string Direccion { get => direccion; set => direccion = value; }
        private string direccion = "-- Sin Direccion --";

        public string Telefono { get => telefono; set => telefono = value; }
        private string telefono = "-- Sin Teléfono --";
        public DateTime FechaNacimiento { get; set; }
        private string documento = "";
        public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

        public string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                if (value.Length >= 7)
                {
                    documento = value;
                }
                else
                {
                    throw new Exception("El formato del documento no es correcto.");
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("-- Persona --");
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Apellido: " + Apellido);
            Console.WriteLine("Documento: " + Documento);
        }

        public void PrintTable()
        {
            Console.WriteLine("| " + Id + " | " + Documento  +" | "+ Nombre +" | " + Apellido +" |");
        }
    }
}