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
    public class CD_Rol
    {

        public List<Rol> listar()
        {
            List<Rol> lista = new List<Rol>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT Id_Rol,descripcion_rol FROM Rol");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Rol()
                            {
                                Id_Rol = Convert.ToInt32(dr["Id_Rol"]),
                                descripcion_rol = dr["descripcion_rol"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Rol>();
                }
            }

            return lista;

        }

        public int Registrar(Rol objRol, out string Mensaje)
        {
            int IdRegistrarResultadoRol = 0;
            Mensaje = String.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {

                    /*  
                     *  CREATE PROC SP_RolNuevo(
                        @descripcion_rol VARCHAR (200),
                        @IdRegistrarResultadoRol int output,
                        @Mensaje VARCHAR (500) output
                        )
                      as*/


                    SqlCommand cmd = new SqlCommand("SP_RolNuevo", oConexion);
                    cmd.Parameters.AddWithValue("descripcion_rol", objRol.descripcion_rol);
                    cmd.Parameters.Add("IdRegistrarResultadoRol", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    IdRegistrarResultadoRol = Convert.ToInt32(cmd.Parameters["IdRegistrarResultadoRol"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {
                IdRegistrarResultadoRol = 0;
                Mensaje = ex.Message;
            }


            return IdRegistrarResultadoRol;
        }

        public bool Editar(Rol objRol, out string Mensaje)
        {
            bool RespuestaRol = false;
            Mensaje = String.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {

                    /* CREATE PROC SP_EditarRol(
                        @Id_Rol int,
                        @descripcion_rol VARCHAR (200),

                        @RespuestaRol bit output,
                        @Mensaje VARCHAR (500) output
                        )
                        as*/


                    SqlCommand cmd = new SqlCommand("SP_EditarRol", oConexion);
                    cmd.Parameters.AddWithValue("Id_Rol", objRol.Id_Rol);
                    cmd.Parameters.AddWithValue("descripcion_rol", objRol.descripcion_rol);

                    cmd.Parameters.Add("RespuestaRol", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    RespuestaRol = Convert.ToBoolean(cmd.Parameters["RespuestaRol"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {
                RespuestaRol = false;
                Mensaje = ex.Message;
            }


            return RespuestaRol;
        }



    }
}
