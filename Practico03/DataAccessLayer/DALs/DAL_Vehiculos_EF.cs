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
    public class DAL_Vehiculos_EF : IDAL_Vehiculos
    {
        private DBContextCore _dbContext;

        public DAL_Vehiculos_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string matricula)
        {
            Vehiculos? found = _dbContext.Vehiculos.FirstOrDefault(v => v.Matricula == matricula);
            if (found == null)
            {
                return;
            }
            _dbContext.Vehiculos.Remove(found);
            _dbContext.SaveChanges();
        }

        public List<Vehiculo> Get()
        {
            return _dbContext.Vehiculos
                             .Select(v => new Vehiculo { Id = (int)v.Id, Matricula = v.Matricula, Marca = v.Marca, Modelo = v.Modelo, PersonaId = (int)v.Persona.Id })
                             .ToList();
        }

        public Vehiculo Get(string matricula)
        {
            Vehiculos? found = _dbContext.Vehiculos.FirstOrDefault(v => v.Matricula == matricula);
            if (found == null)
            {
                return null;
            }
            Vehiculo vehiculo = new Vehiculo { Matricula = found.Matricula, Marca = found.Marca, Modelo = found.Modelo, PersonaId = found.Persona.Id };

            return vehiculo;
        }

        public void Insert(Vehiculo vehiculo)
        {
            Personas? personaFound = _dbContext.Personas.FirstOrDefault(p => p.Id == vehiculo.PersonaId);
            if (personaFound == null)
            {
                return;
            }

            Vehiculos vehNuevo = new Vehiculos { Matricula = vehiculo.Matricula, Marca = vehiculo.Marca, Modelo = vehiculo.Modelo, Persona = personaFound };
            _dbContext.Vehiculos.Add(vehNuevo);
            _dbContext.SaveChanges();
        }

        public void Update(Vehiculo vehiculo)
        {
            throw new NotImplementedException();
        }
    }
}
