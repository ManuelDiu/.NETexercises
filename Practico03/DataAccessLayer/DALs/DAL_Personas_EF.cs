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
            List<Personas> personas = _dbContext.Personas.ToList();
            List<Persona> resPersonas = new List<Persona>();
            foreach (var p in personas)
            {
                Persona persona = new Persona { Id = (int)p.Id, Documento = p.Documento, Nombre = p.Nombres, Apellido = p.Apellidos, Direccion = p.Direccion, FechaNacimiento = p.FechaNacimiento, Telefono = p.Telefono };

                List<Vehiculos> vehiculosPersona = _dbContext.Vehiculos.Where(v => v.Persona.Documento == persona.Documento).ToList();
                if (vehiculosPersona.Count > 0)
                {
                    List<Vehiculo> vehiculos = vehiculosPersona
                             .Select(p => new Vehiculo { Matricula = p.Matricula, Marca = p.Marca, Modelo = p.Modelo, PersonaId = p.Id })
                             .ToList();
                    persona.Vehiculos = vehiculos;
                }
                resPersonas.Add(persona);
            }
            return resPersonas;
        }

        public Persona Get(string documento)
        {
            Personas p = _dbContext.Personas.FirstOrDefault(x => x.Documento == documento);
            if (p == null)
            {
                return null;
            }
            Persona persona = new Persona();
            persona.Id = (int)p.Id;
            persona.Nombre = p.Nombres;
            persona.Apellido = p.Apellidos;
            persona.Documento = p.Documento;
            persona.Telefono = p.Telefono;
            persona.Direccion = p.Direccion;
            persona.FechaNacimiento = p.FechaNacimiento;

            List<Vehiculos> vehiculoPersona = _dbContext.Vehiculos.Where(v => v.Persona.Documento == persona.Documento).ToList();
            if (vehiculoPersona.Count > 0)
            {
                List<Vehiculo> vehiculos = vehiculoPersona
                         .Select(v => new Vehiculo { Id = (int)v.Id, Matricula = v.Matricula, Marca = v.Marca, Modelo = v.Modelo, PersonaId = p.Id })
                         .ToList();
                persona.Vehiculos = vehiculos;
            }
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
