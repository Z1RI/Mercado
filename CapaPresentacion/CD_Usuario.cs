using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Usuario
    {

        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.Id_Persona,p.nombre, p.apellido, p.correo, p.Telefono, p.ciudad_Origen, e.Id_empleado, e.persona_Id,e.cargo_Id,e.sucursal_no,u.Id_Usuario, u.rol_Id,u.empleado_Id ,u.nombre_Usuario, u.clave, u.estado , r.Id_Rol, r.descripcion_rol,c.nombre_Cargo,c.Id_Cargo FROM Usuario u");
                    query.AppendLine("inner join Empleado e on e.Id_empleado = u.empleado_Id");
                    query.AppendLine("inner join Persona p on p.Id_Persona = e.persona_Id");
                    query.AppendLine("inner join rol r on r.Id_Rol = u.rol_Id");
                    query.AppendLine("inner join Cargo c on c.Id_Cargo = e.cargo_Id");
                    


                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) {
                            lista.Add(new Usuario()
                            {
                                Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]),
                                oRol = new Rol() { Id_Rol = Convert.ToInt32(dr["Id_Rol"]), descripcion_rol = dr["descripcion_rol"].ToString() },
                                oEmpleado = new Empleado() { Id_empleado = Convert.ToInt32(dr["Id_empleado"]), oPersona = new Persona() { Id_Persona = Convert.ToInt32(dr["Id_Persona"]), nombre = dr["nombre"].ToString(), apellido = dr["apellido"].ToString(), correo = dr["correo"].ToString(), Telefono = dr["Telefono"].ToString(), ciudad_Origen = dr["ciudad_Origen"].ToString() }, oCargo = new Cargo() { Id_Cargo = Convert.ToInt32(dr["Id_Cargo"]), nombre_Cargo = dr["nombre_Cargo"].ToString()}, sucursal_no = Convert.ToInt32(dr["sucursal_no"]) },
                                nombre_Usuario = dr["nombre_Usuario"].ToString(),
                                clave = dr["clave"].ToString(),
                                estado = Convert.ToBoolean(dr["estado"]),  
                            });
                        }
                    } 

                }
                catch (Exception ex)
                {
                    lista = new List<Usuario>();
                }
            }

            return lista;

        }

        
        public int Registrar(Usuario objUsuario,Empleado objEmpleado,Persona objPersona, out string Mensaje) 
        {
            int IdUsuarioGenerado = 0;
            Mensaje = String.Empty;

            try {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {

                    /*  CREATE PROC SP_UsuarioNuevo(
                        @nombre VARCHAR (100) ,
                        @apellido VARCHAR (100),
                        @correo VARCHAR (100),
                        @telefono VARCHAR (20),
                        @ciudad_Origen VARCHAR (100),

                        @persona_Id int,
                        @cargo_Id int,
                        @sucursal_no int,

                        @rol_Id int,
                        @empleado_Id int,
                        @nombre_Usuario VARCHAR(50),
                        @clave VARCHAR(200),
                        @estado BIT,

                        @IdRegistrarResultado int output,
                        @Mensaje VARCHAR (500) output
                      as*/


                    SqlCommand cmd = new SqlCommand("SP_UsuarioNuevo", oConexion);
                    cmd.Parameters.AddWithValue("nombre",objPersona.nombre);
                    cmd.Parameters.AddWithValue("apellido", objPersona.apellido);
                    cmd.Parameters.AddWithValue("correo", objPersona.correo);
                    cmd.Parameters.AddWithValue("telefono", objPersona.Telefono);
                    cmd.Parameters.AddWithValue("ciudad_Origen", objPersona.ciudad_Origen);

                    cmd.Parameters.AddWithValue("persona_Id", objEmpleado.oPersona.Id_Persona);
                    cmd.Parameters.AddWithValue("cargo_Id", objEmpleado.oCargo.Id_Cargo);
                    cmd.Parameters.AddWithValue("sucursal_no", objEmpleado.sucursal_no);

                    cmd.Parameters.AddWithValue("rol_Id", objUsuario.oRol.Id_Rol);
                    cmd.Parameters.AddWithValue("empleado_Id", objUsuario.oEmpleado.Id_empleado);
                    cmd.Parameters.AddWithValue("nombre_Usuario", objUsuario.nombre_Usuario);
                    cmd.Parameters.AddWithValue("clave", objUsuario.clave);
                    cmd.Parameters.AddWithValue("estado", objUsuario.estado);

                    cmd.Parameters.Add("IdRegistrarResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    IdUsuarioGenerado = Convert.ToInt32(cmd.Parameters["IdRegistrarResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {
                IdUsuarioGenerado = 0;
                Mensaje = ex.Message;
            }


            return IdUsuarioGenerado;
        }


        public bool Editar(Usuario objUsuario, Empleado objEmpleado, Persona objPersona, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = String.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {

                    /* @Id_Usuario int,
                        @nombre VARCHAR (100) ,
                        @apellido VARCHAR (100),
                        @correo VARCHAR (100),
                        @telefono VARCHAR (20),
                        @ciudad_Origen VARCHAR (100),

                        @persona_Id int,
                        @cargo_Id int,
                        @sucursal_no int,

                        @rol_Id int,
                        @empleado_Id int,
                        @nombre_Usuario VARCHAR(50),
                        @clave VARCHAR(200),
                        @estado BIT,


                        @Respuesta bit output,
                        @Mensaje VARCHAR (500) output
                        )
                        as*/


                    SqlCommand cmd = new SqlCommand("SP_EditarUsuario", oConexion);
                    cmd.Parameters.AddWithValue("Id_Usuario", objUsuario.Id_Usuario);

                    cmd.Parameters.AddWithValue("nombre", objPersona.nombre);
                    cmd.Parameters.AddWithValue("apellido", objPersona.apellido);
                    cmd.Parameters.AddWithValue("correo", objPersona.correo);
                    cmd.Parameters.AddWithValue("telefono", objPersona.Telefono);
                    cmd.Parameters.AddWithValue("ciudad_Origen", objPersona.ciudad_Origen);

                    cmd.Parameters.AddWithValue("persona_Id", objEmpleado.oPersona.Id_Persona);
                    cmd.Parameters.AddWithValue("cargo_Id", objEmpleado.oCargo.Id_Cargo);
                    cmd.Parameters.AddWithValue("sucursal_no", objEmpleado.sucursal_no);

                    cmd.Parameters.AddWithValue("rol_Id", objUsuario.oRol.Id_Rol);
                    cmd.Parameters.AddWithValue("empleado_Id", objUsuario.oEmpleado.Id_empleado);
                    cmd.Parameters.AddWithValue("nombre_Usuario", objUsuario.nombre_Usuario);
                    cmd.Parameters.AddWithValue("clave", objUsuario.clave);
                    cmd.Parameters.AddWithValue("estado", objUsuario.estado);

                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }


            return Respuesta;
        }

        public bool Eliminar(Usuario objUsuario, Empleado objEmpleado, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = String.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    /* Aun estamos resolviendo esta parte jejej*/
                }
            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }


            return Respuesta;
        } 

    }
}
