using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public Rol oRol { get; set; }
        public Empleado oEmpleado { get; set; }
        public string nombre_Usuario { get; set; }
        public string clave { get; set; }
        public bool estado { get; set; }
        public string fecha_Registro { get; set; }
    }
}
