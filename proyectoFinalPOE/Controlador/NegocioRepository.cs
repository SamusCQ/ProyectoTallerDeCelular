using System;
using System.Data.SqlClient;
using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using NegocioModel = proyectoFinalPOE.Modelo.Negocio; // Alias para evitar conflictos de nombres si existen clases similares en el proyecto.

namespace proyectoFinalPOE.Repositorio
{
    public class NegocioRepository
    {
        private readonly DatabaseConector _databaseHelper;

        public NegocioRepository(DatabaseConector databaseHelper)
        {
            _databaseHelper = databaseHelper; // Dependencia inyectada para administrar la conexión con la base de datos.
        }

        public NegocioModel GetNegocioById(int idNegocio)
        {
            NegocioModel negocio = null; // Variable para almacenar el objeto negocio si se encuentra.
            using (SqlConnection connection = _databaseHelper.GetConnection())
            {
                string query = "SELECT * FROM NEGOCIO WHERE idNegocio = @idNegocio AND bd_est = 1";
                // Consulta que obtiene los datos de un negocio activo filtrado por su ID.

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idNegocio", idNegocio);
                // Evita vulnerabilidades de inyección SQL mediante el uso de parámetros.

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Construcción del objeto NegocioModel basado en los datos del registro obtenido.
                        negocio = new NegocioModel
                        {
                            IdNegocio = reader.GetInt32(0), // Identificador único del negocio.
                            Nombre = reader.GetString(1), // Nombre del negocio.
                            Direccion = reader.GetString(2), // Dirección física del negocio.
                            Correo = reader.GetString(3), // Correo electrónico asociado al negocio.
                            BdEst = reader.GetInt32(4) // Estado lógico del registro en la base de datos.
                        };
                    }
                }
            }
            return negocio; // Retorna el objeto negocio o `null` si no se encontró.
        }
    }
}
