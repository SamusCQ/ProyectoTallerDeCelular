using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Controlador;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class OpcionRepository
    {
        private readonly DatabaseHelper databaseHelper;

        public OpcionRepository(DatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public List<Opcion> GetOpcionesByRol(int idRol)
        {
            List<Opcion> opciones = new List<Opcion>();
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
            SELECT O.idOpcion, O.descripcion, O.viewPath
            FROM ROL_OPCION RO
            JOIN OPCIONES O ON RO.idOpcion = O.idOpcion
            WHERE RO.idRol = @idRol";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idRol", idRol);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Opcion opcion = new Opcion
                        {
                            IdOpcion = reader.GetInt32(0),
                            Descripcion = reader.GetString(1),
                            ViewPath = reader.GetString(2)
                        };
                        opciones.Add(opcion);
                    }
                }
            }
            return opciones;
        }
    }
}


