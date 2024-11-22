using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class RepuestoRepository
    {
        private DatabaseConector databaseHelper;

        // Constructor que recibe un objeto para gestionar la conexión con la base de datos
        public RepuestoRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper; // Se asigna el objeto de conexión a la propiedad de la clase.
        }

        // Método para obtener todos los repuestos disponibles con sus detalles
        public List<Repuesto> GetRepuestos()
        {
            List<Repuesto> repuestos = new List<Repuesto>(); // Lista para almacenar los repuestos.

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                // Consulta SQL que obtiene los repuestos con detalles de marca, modelo y tipo.
                string query = @"
                SELECT r.idRepuesto, r.idMarca, r.idModelo, r.descripcion, r.idTipo, r.valor, r.cantidad, r.bd_est,
                       m.descripcion AS MarcaDescripcion, mo.descripcion AS ModeloDescripcion, t.descripcion AS TipoDescripcion
                FROM REPUESTOS r
                JOIN MARCA m ON r.idMarca = m.idMarca
                JOIN MODELO_CELULAR mo ON r.idModelo = mo.idModelo
                JOIN TIPO_REPUESTO t ON r.idTipo = t.idTipo
                WHERE r.bd_est = 1"; // Se filtra por repuestos activos (bd_est = 1).

                SqlCommand command = new SqlCommand(query, connection); // Se crea el comando SQL con la consulta.
                connection.Open(); // Se abre la conexión con la base de datos.

                // Ejecutamos la consulta y recorremos los resultados.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Creamos un objeto de tipo Repuesto y le asignamos los valores obtenidos de la base de datos.
                        Repuesto repuesto = new Repuesto
                        {
                            IdRepuesto = reader.GetInt32(0),
                            IdMarca = reader.GetInt32(1),
                            IdModelo = reader.GetInt32(2),
                            Descripcion = reader.GetString(3),
                            IdTipo = reader.GetInt32(4),
                            Valor = reader.GetDecimal(5),
                            Cantidad = reader.GetInt32(6),
                            BdEst = reader.GetInt32(7),
                            MarcaDescripcion = reader.GetString(8),
                            ModeloDescripcion = reader.GetString(9),
                            TipoDescripcion = reader.GetString(10)
                        };
                        repuestos.Add(repuesto); // Añadimos el repuesto a la lista.
                    }
                }
            }

            return repuestos; // Devolvemos la lista de repuestos obtenidos.
        }

        // Método para obtener un repuesto por su ID.
        public Repuesto ObtenerRepuestoPorId(int idRepuesto)
        {
            Repuesto repuesto = null; // Inicializamos como null el repuesto.

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                // Consulta SQL para obtener un repuesto específico por su ID.
                string query = @"
        SELECT idRepuesto, idMarca, idModelo, descripcion, idTipo, valor, bd_est, cantidad, fechaIngreso
        FROM REPUESTOS
        WHERE idRepuesto = @idRepuesto"; // Se usa el parámetro idRepuesto para buscar el repuesto.

                SqlCommand command = new SqlCommand(query, connection); // Creamos el comando SQL.
                command.Parameters.AddWithValue("@idRepuesto", idRepuesto); // Asignamos el valor del parámetro.
                connection.Open(); // Abrimos la conexión.

                // Ejecutamos la consulta y obtenemos el repuesto.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read()) // Si se encuentra el repuesto
                    {
                        repuesto = new Repuesto
                        {
                            IdRepuesto = reader.GetInt32(0),
                            IdMarca = reader.GetInt32(1),
                            IdModelo = reader.GetInt32(2),
                            Descripcion = reader.GetString(3),
                            IdTipo = reader.GetInt32(4),
                            Valor = reader.GetDecimal(5),
                            BdEst = reader.GetInt32(6),
                            Cantidad = reader.GetInt32(7),
                            FechaIngreso = reader.GetDateTime(8)
                        };
                    }
                }
            }

            return repuesto; // Devolvemos el repuesto encontrado o null si no se encuentra.
        }

        // Método para actualizar los detalles de un repuesto.
        public void ActualizarRepuesto(Repuesto repuesto)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                // Consulta SQL para actualizar los datos de un repuesto.
                string query = @"
        UPDATE REPUESTOS
        SET idMarca = @idMarca, idModelo = @idModelo, descripcion = @descripcion, idTipo = @idTipo, valor = @valor, bd_est = @bdEst, cantidad = @cantidad, fechaIngreso = @fechaIngreso
        WHERE idRepuesto = @idRepuesto"; // Usamos el ID del repuesto para encontrarlo y actualizar sus valores.

                SqlCommand command = new SqlCommand(query, connection); // Creamos el comando SQL.
                command.Parameters.AddWithValue("@idMarca", repuesto.IdMarca); // Asignamos los valores del repuesto.
                command.Parameters.AddWithValue("@idModelo", repuesto.IdModelo);
                command.Parameters.AddWithValue("@descripcion", repuesto.Descripcion);
                command.Parameters.AddWithValue("@idTipo", repuesto.IdTipo);
                command.Parameters.AddWithValue("@valor", repuesto.Valor);
                command.Parameters.AddWithValue("@bdEst", repuesto.BdEst);
                command.Parameters.AddWithValue("@cantidad", repuesto.Cantidad);
                command.Parameters.AddWithValue("@fechaIngreso", repuesto.FechaIngreso);
                command.Parameters.AddWithValue("@idRepuesto", repuesto.IdRepuesto); // Se usa el ID para identificar el repuesto a actualizar.
                connection.Open(); // Abrimos la conexión.
                command.ExecuteNonQuery(); // Ejecutamos la actualización.
            }
        }

        // Método para agregar un nuevo repuesto.
        public void AgregarRepuesto(Repuesto repuesto)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                // Consulta SQL para insertar un nuevo repuesto en la base de datos.
                string query = @"
                INSERT INTO REPUESTOS (idMarca, idModelo, descripcion, idTipo, valor, bd_est, cantidad, fechaIngreso)
                VALUES (@idMarca, @idModelo, @descripcion, @idTipo, @valor, @bdEst, @cantidad, @fechaIngreso)";

                SqlCommand command = new SqlCommand(query, connection); // Creamos el comando SQL.
                command.Parameters.AddWithValue("@idMarca", repuesto.IdMarca); // Asignamos los parámetros del nuevo repuesto.
                command.Parameters.AddWithValue("@idModelo", repuesto.IdModelo);
                command.Parameters.AddWithValue("@descripcion", repuesto.Descripcion);
                command.Parameters.AddWithValue("@idTipo", repuesto.IdTipo);
                command.Parameters.AddWithValue("@valor", repuesto.Valor);
                command.Parameters.AddWithValue("@bdEst", repuesto.BdEst);
                command.Parameters.AddWithValue("@cantidad", repuesto.Cantidad);
                command.Parameters.AddWithValue("@fechaIngreso", repuesto.FechaIngreso);
                connection.Open(); // Abrimos la conexión.
                command.ExecuteNonQuery(); // Ejecutamos la inserción del nuevo repuesto.
            }
        }

        // Método para eliminar un repuesto por su ID.
        public void EliminarRepuesto(int idRepuesto)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                // Consulta SQL para eliminar un repuesto de la base de datos.
                string query = "DELETE FROM REPUESTOS WHERE idRepuesto = @idRepuesto"; // Eliminamos por ID.
                SqlCommand command = new SqlCommand(query, connection); // Creamos el comando SQL.
                command.Parameters.AddWithValue("@idRepuesto", idRepuesto); // Asignamos el parámetro del ID.
                connection.Open(); // Abrimos la conexión.
                command.ExecuteNonQuery(); // Ejecutamos la eliminación.
            }
        }

        // Método para buscar repuestos por descripción (parcial).
        public List<Repuesto> BuscarRepuestosPorDescripcion(string descripcion)
        {
            List<Repuesto> repuestos = new List<Repuesto>(); // Lista para almacenar los resultados de búsqueda.

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                // Consulta SQL para buscar repuestos que contengan la descripción proporcionada.
                string query = @"
                SELECT idRepuesto, idMarca, idModelo, descripcion, idTipo, valor, bd_est
                FROM REPUESTOS
                WHERE bd_est = 1 AND descripcion LIKE @descripcion"; // Se usa LIKE para búsqueda parcial.

                SqlCommand command = new SqlCommand(query, connection); // Creamos el comando SQL.
                command.Parameters.AddWithValue("@descripcion", "%" + descripcion + "%"); // Asignamos el parámetro con el patrón de búsqueda.
                connection.Open(); // Abrimos la conexión.

                // Ejecutamos la consulta y recorremos los resultados.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Creamos un repuesto con los datos obtenidos.
                        Repuesto repuesto = new Repuesto
                        {
                            IdRepuesto = reader.GetInt32(0),
                            IdMarca = reader.GetInt32(1),
                            IdModelo = reader.GetInt32(2),
                            Descripcion = reader.GetString(3),
                            IdTipo = reader.GetInt32(4),
                            Valor = reader.GetDecimal(5),
                            BdEst = reader.GetInt32(6)
                        };
                        repuestos.Add(repuesto); // Añadimos el repuesto a la lista.
                    }
                }
            }

            return repuestos; // Devolvemos la lista de repuestos encontrados.
        }
    }
}
