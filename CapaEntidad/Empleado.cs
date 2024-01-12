using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Empleado
    {
        public int Id_empleado { get; set; }

        public Persona oPersona { get; set; }
        public Cargo oCargo { get; set; }
        public int sucursal_no { get; set; }

    }
}
