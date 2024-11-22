using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    // Repositorio para manejar las operaciones relacionadas con la tabla TIPO_REPUESTO.
    public class TipoRepuestoRepository
    {
        private DatabaseConector databaseHelper; // Objeto para gestionar la conexión a la base de datos.

        // Constructor que inicializa el objeto de conexión con la base de datos.
        public TipoRepuestoRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper; // Se asigna el objeto de conexión.
        }

        // Método para obtener todos los tipos de repuestos activos (bd_est = 1).
        public List<TipoRepuesto> GetTipos()
        {
            List<TipoRepuesto> tipos = new List<TipoRepuesto>(); // Lista para almacenar los tipos de repuestos.

            // Se establece una conexión con la base de datos utilizando el objeto databaseHelper.
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                // Consulta SQL para obtener los tipos de repuestos activos.
                string query = "SELECT IdTipo, Descripcion FROM TIPO_REPUESTO WHERE bd_est = 1";
                SqlCommand command = new SqlCommand(query, connection); // Se crea el comando SQL con la consulta.
                connection.Open(); // Se abre la conexión a la base de datos.

                // Ejecuta la consulta y lee los resultados.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Recorre cada fila devuelta por la consulta.
                    while (reader.Read())
                    {
                        // Se crea un objeto TipoRepuesto y se asignan los valores obtenidos de la base de datos.
                        TipoRepuesto tipo = new TipoRepuesto
                        {
                            IdTipo = reader.GetInt32(0), // Se obtiene el Id del tipo.
                            Descripcion = reader.GetString(1) // Se obtiene la descripción del tipo.
                        };
                        tipos.Add(tipo); // Se añade el tipo de repuesto a la lista.
                    }
                }
            }

            return tipos; // Devolvemos la lista de tipos de repuestos obtenidos.
        }
    }
}
