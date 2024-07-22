using System.Collections.Generic;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Controlador;

namespace proyectoFinalPOE.Negocio
{
    public class UsuarioService
    {
        private DatabaseHelper databaseHelper;

        public UsuarioService()
        {
            databaseHelper = new DatabaseHelper();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return databaseHelper.GetUsuarios();
        }

        public bool VerificarCredenciales(string nombreUsuario, string clave)
        {
            var usuarios = databaseHelper.GetUsuarios();
            return usuarios.Any(u => u.NombreUsuario == nombreUsuario && u.Clave == clave);
        }

        public List<UserRole> GetUserRoles(string username, string password)
        {
            return databaseHelper.GetUserRoles(username, password);
        }
    }
}
