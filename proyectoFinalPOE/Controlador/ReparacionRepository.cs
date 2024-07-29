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
                r.idCliente,
                c.nombre AS Cliente,
                r.idCelular,
                m.descripcion AS Modelo,
                e.descripcion AS Estado,
                (SELECT STRING_AGG(re.descripcion, ', ') 
                 FROM REPARACION_REPUESTO rr
                 JOIN REPUESTOS re ON rr.idRepuesto = re.idRepuesto
                 WHERE rr.idReparacion = r.idReparacion) AS Repuestos
            FROM REPARACIONES r
            JOIN CLIENTE c ON r.idCliente = c.idCliente
            JOIN CELULAR ce ON r.idCelular = ce.idCelular
            JOIN MODELO_CELULAR m ON ce.idModelo = m.idModelo
            JOIN ESTADO e ON r.idEstado = e.idEstado";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dtReparaciones);
            }

            return dtReparaciones;
        }








    }
}
