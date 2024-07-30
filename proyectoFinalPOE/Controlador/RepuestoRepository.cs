using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class RepuestoRepository
    {
        private DatabaseConector databaseHelper;

        public RepuestoRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public List<Repuesto> GetRepuestos()
        {
            List<Repuesto> repuestos = new List<Repuesto>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                SELECT r.idRepuesto, r.idMarca, r.idModelo, r.descripcion, r.idTipo, r.valor, r.cantidad, r.bd_est,
                       m.descripcion AS MarcaDescripcion, mo.descripcion AS ModeloDescripcion, t.descripcion AS TipoDescripcion
                FROM REPUESTOS r
                JOIN MARCA m ON r.idMarca = m.idMarca
                JOIN MODELO_CELULAR mo ON r.idModelo = mo.idModelo
                JOIN TIPO_REPUESTO t ON r.idTipo = t.idTipo
                WHERE r.bd_est = 1";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
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
                        repuestos.Add(repuesto);
                    }
                }
            }

            return repuestos;
        }

        public Repuesto ObtenerRepuestoPorId(int idRepuesto)
        {
            Repuesto repuesto = null;

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
        SELECT idRepuesto, idMarca, idModelo, descripcion, idTipo, valor, bd_est, cantidad, fechaIngreso
        FROM REPUESTOS
        WHERE idRepuesto = @idRepuesto";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idRepuesto", idRepuesto);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
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
            return repuesto;
        }

        public void ActualizarRepuesto(Repuesto repuesto)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
        UPDATE REPUESTOS
        SET idMarca = @idMarca, idModelo = @idModelo, descripcion = @descripcion, idTipo = @idTipo, valor = @valor, bd_est = @bdEst, cantidad = @cantidad, fechaIngreso = @fechaIngreso
        WHERE idRepuesto = @idRepuesto";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idMarca", repuesto.IdMarca);
                command.Parameters.AddWithValue("@idModelo", repuesto.IdModelo);
                command.Parameters.AddWithValue("@descripcion", repuesto.Descripcion);
                command.Parameters.AddWithValue("@idTipo", repuesto.IdTipo);
                command.Parameters.AddWithValue("@valor", repuesto.Valor);
                command.Parameters.AddWithValue("@bdEst", repuesto.BdEst);
                command.Parameters.AddWithValue("@cantidad", repuesto.Cantidad);
                command.Parameters.AddWithValue("@fechaIngreso", repuesto.FechaIngreso);
                command.Parameters.AddWithValue("@idRepuesto", repuesto.IdRepuesto);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }



        public void AgregarRepuesto(Repuesto repuesto)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
        INSERT INTO REPUESTOS (idMarca, idModelo, descripcion, idTipo, valor, bd_est, cantidad, fechaIngreso)
        VALUES (@idMarca, @idModelo, @descripcion, @idTipo, @valor, @bdEst, @cantidad, @fechaIngreso)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idMarca", repuesto.IdMarca);
                command.Parameters.AddWithValue("@idModelo", repuesto.IdModelo);
                command.Parameters.AddWithValue("@descripcion", repuesto.Descripcion);
                command.Parameters.AddWithValue("@idTipo", repuesto.IdTipo);
                command.Parameters.AddWithValue("@valor", repuesto.Valor);
                command.Parameters.AddWithValue("@bdEst", repuesto.BdEst);
                command.Parameters.AddWithValue("@cantidad", repuesto.Cantidad);
                command.Parameters.AddWithValue("@fechaIngreso", repuesto.FechaIngreso);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }



        public void EliminarRepuesto(int idRepuesto)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "DELETE FROM REPUESTOS WHERE idRepuesto = @idRepuesto";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idRepuesto", idRepuesto);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Repuesto> BuscarRepuestosPorDescripcion(string descripcion)
        {
            List<Repuesto> repuestos = new List<Repuesto>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                SELECT idRepuesto, idMarca, idModelo, descripcion, idTipo, valor, bd_est
                FROM REPUESTOS
                WHERE bd_est = 1 AND descripcion LIKE @descripcion";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@descripcion", "%" + descripcion + "%");
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
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
                        repuestos.Add(repuesto);
                    }
                }
            }
            return repuestos;
        }

        public List<Repuesto> GetRepuestosPorMarcaYModelo(int idMarca, int idModelo)
        {
            List<Repuesto> repuestos = new List<Repuesto>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"SELECT * FROM REPUESTOS WHERE idMarca = @idMarca AND idModelo = @idModelo AND bd_est = 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idMarca", idMarca);
                command.Parameters.AddWithValue("@idModelo", idModelo);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Repuesto repuesto = new Repuesto
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
                        repuestos.Add(repuesto);
                    }
                }
            }

            return repuestos;
        }


        public void ActualizarCantidadRepuesto(int idRepuesto, int cantidadRestar)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "UPDATE REPUESTOS SET cantidad = cantidad - @cantidadRestar WHERE idRepuesto = @idRepuesto";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idRepuesto", idRepuesto);
                command.Parameters.AddWithValue("@cantidadRestar", cantidadRestar);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void InsertarCantidad(int idRepuesto, int cantidad)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "UPDATE REPUESTOS SET cantidad = cantidad + @cantidad WHERE idRepuesto = @idRepuesto";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cantidad", cantidad);
                command.Parameters.AddWithValue("@idRepuesto", idRepuesto);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }




    }
}

