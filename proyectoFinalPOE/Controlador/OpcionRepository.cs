using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Controlador;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class OpcionRepository
    {
        private readonly DatabaseConector databaseHelper;

        public OpcionRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper; // Inyección de dependencia para manejar conexiones a la base de datos.
        }

        public List<Opcion> GetOpcionesByRol(int idRol)
        {
            List<Opcion> opciones = new List<Opcion>(); // Lista para almacenar las opciones asociadas al rol.
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
            SELECT O.idOpcion, O.descripcion, O.viewPath
            FROM ROL_OPCION RO
            JOIN OPCIONES O ON RO.idOpcion = O.idOpcion
            WHERE RO.idRol = @idRol";
                // Consulta que recupera las opciones asociadas a un rol específico.

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idRol", idRol);
                // Uso de parámetros para evitar inyección SQL al filtrar por ID de rol.

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Cada fila obtenida de la base de datos se transforma en una instancia de `Opcion`.
                        Opcion opcion = new Opcion
                        {
                            IdOpcion = reader.GetInt32(0), // ID único de la opción.
                            Descripcion = reader.GetString(1), // Descripción textual de la opción.
                            ViewPath = reader.GetString(2) // Ruta de la vista asociada a la opción.
                        };
                        opciones.Add(opcion); // Se añade la opción a la lista.
                    }
                }
            }
            return opciones; // Retorna la lista de opciones asociadas al rol.
        }
    }
}
