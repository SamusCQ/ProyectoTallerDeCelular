using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class ReparacionRepository
    {
        private DatabaseHelper databaseHelper;

        public ReparacionRepository(DatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public int AgregarReparacion(Reparacion reparacion)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
            INSERT INTO REPARACIONES (idCliente, idCelular, idEstado, descripcion, bd_est)
            VALUES (@idCliente, @idCelular, @idEstado, @descripcion, @bd_est);
            SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idCliente", reparacion.IdCliente);
                command.Parameters.AddWithValue("@idCelular", reparacion.IdCelular);
                command.Parameters.AddWithValue("@idEstado", reparacion.IdEstado);
                command.Parameters.AddWithValue("@descripcion", reparacion.Descripcion);
                command.Parameters.AddWithValue("@bd_est", reparacion.BdEst);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void AgregarReparacionRepuesto(int idReparacion, int idRepuesto)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "INSERT INTO REPARACION_REPUESTO (idReparacion, idRepuesto) VALUES (@idReparacion, @idRepuesto)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idReparacion", idReparacion);
                command.Parameters.AddWithValue("@idRepuesto", idRepuesto);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable GetReparacionesConRepuestos()
        {
            DataTable dtReparaciones = new DataTable();
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
            SELECT 
                r.idReparacion, 
                r.descripcion AS Reparacion, 
                c.nombre AS Cliente, 
                e.descripcion AS Estado, 
                string_agg(re.descripcion, ', ') AS Repuestos,
                m.descripcion AS Modelo
            FROM 
                REPARACIONes r
            JOIN 
                CLIENTE c ON r.idCliente = c.idCliente
            JOIN 
                ESTADO e ON r.idEstado = e.idEstado
            LEFT JOIN 
                REPARACION_REPUESTO rr ON r.idReparacion = rr.idReparacion
            LEFT JOIN 
                REPUESTOS re ON rr.idRepuesto = re.idRepuesto
            JOIN
                CELULAR cel ON r.idCelular = cel.idCelular
            JOIN
                MODELO_CELULAR m ON cel.idModelo = m.idModelo
            WHERE 
                r.bd_est = 1
            GROUP BY 
                r.idReparacion, r.descripcion, c.nombre, e.descripcion, m.descripcion";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(dtReparaciones);
            }
            return dtReparaciones;
        }



        public void EliminarReparacion(int idReparacion)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                // Primero eliminar los registros en REPARACION_REPUESTO
                string deleteReparacionRepuestoQuery = "DELETE FROM REPARACION_REPUESTO WHERE idReparacion = @idReparacion";
                SqlCommand deleteReparacionRepuestoCommand = new SqlCommand(deleteReparacionRepuestoQuery, connection);
                deleteReparacionRepuestoCommand.Parameters.AddWithValue("@idReparacion", idReparacion);

                // Luego eliminar el registro en REPARACION
                string deleteReparacionQuery = "DELETE FROM REPARACIONes WHERE idReparacion = @idReparacion";
                SqlCommand deleteReparacionCommand = new SqlCommand(deleteReparacionQuery, connection);
                deleteReparacionCommand.Parameters.AddWithValue("@idReparacion", idReparacion);

                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        deleteReparacionRepuestoCommand.Transaction = transaction;
                        deleteReparacionCommand.Transaction = transaction;

                        deleteReparacionRepuestoCommand.ExecuteNonQuery();
                        deleteReparacionCommand.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al eliminar la reparación: " + ex.Message);
                    }
                }
            }
        }

        public List<Reparacion> GetReparacionesPorCliente(int idCliente)
        {
            List<Reparacion> reparaciones = new List<Reparacion>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
            SELECT r.idReparacion, r.descripcion
            FROM REPARACIONes r
            WHERE r.idCliente = @idCliente AND r.bd_est = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idCliente", idCliente);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Reparacion reparacion = new Reparacion
                    {
                        IdReparacion = reader.GetInt32(0),
                        Descripcion = reader.GetString(1)
                    };
                    reparaciones.Add(reparacion);
                }
            }

            return reparaciones;
        }


        public List<Repuesto> GetRepuestosPorReparacion(int idReparacion)
        {
            List<Repuesto> repuestos = new List<Repuesto>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
            SELECT r.idRepuesto, r.descripcion, r.valor
            FROM REPARACION_REPUESTO rr
            JOIN REPUESTOs r ON rr.idRepuesto = r.idRepuesto
            WHERE rr.idReparacion = @idReparacion";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idReparacion", idReparacion);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Repuesto repuesto = new Repuesto
                        {
                            IdRepuesto = reader.GetInt32(0),
                            Descripcion = reader.GetString(1),
                            Valor = reader.GetDecimal(2)
                        };
                        repuestos.Add(repuesto);
                    }
                }
            }

            return repuestos;
        }







    }
}
