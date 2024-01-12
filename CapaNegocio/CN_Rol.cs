using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Rol
    {

        private CD_Rol objcd_Rol = new CD_Rol();

        public List<Rol> listar()
        {
            return objcd_Rol.listar();
        }

        public int Registrar(Rol objRol, out string Mensaje) 
        {

            return objcd_Rol.Registrar(objRol,out Mensaje);
        }

        public bool Editar(Rol objRol, out string Mensaje)
        {
            return objcd_Rol.Editar(objRol, out Mensaje);
        }

    }
}
