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
    public class DAL_Personas_ADONET : IDAL_Personas
    {

        private string _connectionString = "Server=localhost;Database=practico2;User Id=sa;Password=Abcdefg*12345678910!;Encrypt=False;";

        public void Insert(Persona persona)
        {
            // Abrir la conección a la base de datos
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO persona (nombre, documento) VALUES (@nombre, @documento);", connection))
                {
                    command.Parameters.AddWithValue("@nombre", persona.Nombre);
                    command.Parameters.AddWithValue("@documento", persona.Documento);
                    command.ExecuteScalar();
                }
                connection.Close();
            }

        }

        public void Update(Persona persona)
        {
            // Abrir la conección a la base de datos
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE persona SET documento = @documento , nombre = @nombre WHERE documento = @documento;", connection))
                {
                    command.Parameters.AddWithValue("@nombre", persona.Nombre);
                    command.Parameters.AddWithValue("@documento", persona.Documento);
                    command.ExecuteScalar();
                }
                connection.Close();
            }
        }

        public List<Persona> Get()
        {
            List<Persona> personas = new List<Persona>();

            // Abrir la conección a la base de datos
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM persona;", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Persona persona = new Persona();

                            persona.Documento = reader["documento"].ToString();
                            persona.Nombre = reader["nombre"].ToString();

                            personas.Add(persona);
                        }
                    }
                }
                connection.Close();
                return personas;
            }

        }

        public void Delete(string documento)
        {
            // Abrir la conección a la base de datos
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM persona WHERE documento = @documento;", connection))
                {
                    command.Parameters.AddWithValue("@documento", documento);
                    command.ExecuteScalar();
                }
                connection.Close();
            }
        }

        public Persona Get(string documento)
        {
            Persona persona = null;
            // Abrir la conección a la base de datos
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM persona WHERE documento = @documento;", connection))
                {
                    command.Parameters.AddWithValue("@documento", documento);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            persona = new Persona();
                            persona.Documento = reader["documento"].ToString();
                            persona.Nombre = reader["nombre"].ToString();
                        }
                    }
                }
                connection.Close();
            }
            return persona;
        }
    }
}
