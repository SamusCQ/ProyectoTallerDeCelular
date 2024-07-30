using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace proyectoFinalPOE.Negocio
{
    public class UsuarioService
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioService(DatabaseConector databaseHelper)
        {
            usuarioRepository = new UsuarioRepository(databaseHelper);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarioRepository.GetUsuarios();
        }

        public bool VerificarCredenciales(string nombreUsuario, string clave)
        {
            var usuarios = usuarioRepository.GetUsuarios();
            return usuarios.Any(u => u.NombreUsuario == nombreUsuario && u.Clave == clave);
        }

        public List<UserRole> GetUserRoles(string username, string password)
        {
            return usuarioRepository.GetUserRoles(username, password);
        }
    }
}
