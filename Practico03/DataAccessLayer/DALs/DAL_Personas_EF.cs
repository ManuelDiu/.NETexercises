using DataAccessLayer.EFModels;
using DataAccessLayer.IDALs;
using Microsoft.Data.SqlClient;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    // IMPLEMENTAR PARA LA SEMANA QUE VIENE.
    public class DAL_Personas_EF : IDAL_Personas
    {
        private DBContextCore _dbContext;

        public DAL_Personas_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string documento)
        {
            Personas? found = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);
            if (found == null)
            {
                return;
            }
            _dbContext.Personas.Remove(found);
            _dbContext.SaveChanges();
        }

        public List<Persona> Get()
        {
            return _dbContext.Personas
                             .Select(p => new Persona { Id = (int)p.Id, Nombre = p.Nombres, Apellido = p.Apellidos, Telefono = p.Telefono, Direccion = p.Direccion, FechaNacimiento = p.FechaNacimiento, Documento = p.Documento })
                             .ToList();
        }

        public Persona? Get(string documento)
        {
            Personas? found = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);
            if (found == null)
            {
                return null;
            }
            Persona persona = new Persona { Nombre = found.Nombres, Apellido = found.Apellidos, Telefono = found.Telefono, Direccion = found.Direccion, FechaNacimiento = found.FechaNacimiento, Documento = found.Documento };

            return persona;
        }

        public void Insert(Persona persona)
        {
            Personas personaNueva = new Personas { Nombres = persona.Nombre, Apellidos = persona.Apellido, Telefono = persona.Telefono, Direccion = persona.Direccion, FechaNacimiento = persona.FechaNacimiento, Documento = persona.Documento };
            _dbContext.Personas.Add(personaNueva);
            _dbContext.SaveChanges();
        }

        public void Update(Persona persona)
        {
            Personas? found = _dbContext.Personas.FirstOrDefault(p => p.Documento == persona.Documento);
            if (found == null)
            {
                return;
            }
            found.Nombres = persona.Nombre;
            found.Apellidos = persona.Apellido;
            found.Telefono = persona.Telefono;
            found.Documento = persona.Documento;
            found.Direccion = persona.Direccion;
            found.FechaNacimiento = persona.FechaNacimiento;
            _dbContext.Update(found);
            _dbContext.SaveChanges();
        }
    }
}
