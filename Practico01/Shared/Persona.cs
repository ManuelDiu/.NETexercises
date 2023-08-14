using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Persona
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Length < 1)
                {
                    throw new Exception("Ingrese un Nombre válido.");
                }
                else
                {
                    nombre = value;
                }
            }
        }
        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (value.Length < 1)
                {
                    throw new Exception("Ingrese un Apellido válido.");
                }
                else
                {
                    apellido = value;
                }
            }
        }

        private string documento = "";
        public string Documento {
            get { return documento; } 
            set {
                if (value.Length < 7)
                    throw new Exception("Formato de documento incorrecto.");
                else
                    documento = value.ToUpper();
            } 
        }

        private DateTime fechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set
            {
                if (value > DateTime.Now)
                    throw new Exception("La fecha de nacimiento no puede ser futura.");
                else
                    fechaNacimiento = value;
            }
        }
    }
}
