using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Permiso
    {
        private CD_Permiso objcd_permiso = new CD_Permiso();

        public List<Permiso> listar(int IdUsuario)
        {
            return objcd_permiso.listar(IdUsuario);
        }

        public int Registrar(Permiso objPermiso, out string Mensaje)
        {

            return objcd_permiso.Registrar(objPermiso, out Mensaje);

        }
    }
}
