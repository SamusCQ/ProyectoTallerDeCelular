using System;
using System.Data.SqlClient;
using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using NegocioModel = proyectoFinalPOE.Modelo.Negocio;

namespace proyectoFinalPOE.Repositorio
{
    public class NegocioRepository
    {
        private readonly DatabaseConector _databaseHelper;

        public NegocioRepository(DatabaseConector databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public NegocioModel GetNegocioById(int idNegocio)
        {
            NegocioModel negocio = null;
            using (SqlConnection connection = _databaseHelper.GetConnection())
            {
                string query = "SELECT * FROM NEGOCIO WHERE idNegocio = @idNegocio AND bd_est = 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idNegocio", idNegocio);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        negocio = new NegocioModel
                        {
                            IdNegocio = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Direccion = reader.GetString(2),
                            Correo = reader.GetString(3),
                            BdEst = reader.GetInt32(4)
                        };
                    }
                }
            }
            return negocio;
        }
    }
}
