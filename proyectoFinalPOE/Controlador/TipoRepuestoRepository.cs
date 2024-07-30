using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class TipoRepuestoRepository
    {
        private DatabaseConector databaseHelper;

        public TipoRepuestoRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public List<TipoRepuesto> GetTipos()
        {
            List<TipoRepuesto> tipos = new List<TipoRepuesto>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT IdTipo, Descripcion FROM TIPO_REPUESTO WHERE bd_est = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TipoRepuesto tipo = new TipoRepuesto
                        {
                            IdTipo = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        tipos.Add(tipo);
                    }
                }
            }

            return tipos;
        }
    }
}
