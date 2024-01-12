using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {

        private CD_Usuario objcd_usuario = new CD_Usuario();

        public List<Usuario> listar() 
        {
            return objcd_usuario.listar();
        }

        public int Registrar(Usuario objUsuario, Empleado objEmpleado, Persona objPersona, out string Mensaje)
        {
            /*///////////Restricciones ejemplo/////////*/
            Mensaje = String.Empty;
            if (objUsuario.nombre_Usuario == "")
            {
                Mensaje += "Es necesario el nombre de usuario\n";
            }

            if (objUsuario.clave == "")
            {
                Mensaje += "Es necesario la clave del usuario\n";
            }
            /*/////////////////////////////////////////*/

            return objcd_usuario.Registrar(objUsuario, objEmpleado, objPersona, out Mensaje);
        }

        public bool Editar(Usuario objUsuario, Empleado objEmpleado, Persona objPersona, out string Mensaje)
        {
            return objcd_usuario.Editar(objUsuario, objEmpleado, objPersona, out Mensaje);
        }

        public bool Eliminar(Usuario objUsuario, Empleado objEmpleado, out string Mensaje)
        {
            return objcd_usuario.Eliminar(objUsuario, objEmpleado, out Mensaje);
        }

    }
}
