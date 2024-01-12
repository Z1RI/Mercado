using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Cargo
    {
        private CD_Cargo objcd_Cargo = new CD_Cargo();

        public List<Cargo> listar()
        {
            return objcd_Cargo.listar();
        }

    }
}
