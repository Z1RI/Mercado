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
    public class CD_Permiso
    {
        public List<Permiso> listar(int idUsuario)
        {
            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT P.rol_Id, P.nombreMenu FROM Permiso P");
                    query.AppendLine("inner join Rol R ON R.Id_Rol = P.rol_Id");
                    query.AppendLine("inner join Usuario u ON u.rol_Id = R.Id_Rol");
                    query.AppendLine("where u.Id_Usuario = @idUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                oRol = new Rol() { Id_Rol =  Convert.ToInt32(dr["rol_Id"])} ,
                                nombreMenu = dr["nombreMenu"].ToString(),
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();
                }
            }

            return lista;

        }

        public int Registrar(Permiso objPermiso, out string Mensaje)
        {
            int IdUsuarioGenerado = 0;
            Mensaje = String.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {

                    /*  CREATE PROC SP_DarPermisos(
                        @rol_Id int,
                        @nombreMenu VARCHAR(200),
                        @IdRegistrarResultadoPermiso int output,
                        @Mensaje VARCHAR (500) output
                        )
                      as*/


                    SqlCommand cmd = new SqlCommand("SP_DarPermisos", oConexion);
                    cmd.Parameters.AddWithValue("rol_Id", objPermiso.oRol.Id_Rol);
                    cmd.Parameters.AddWithValue("nombreMenu", objPermiso.nombreMenu);;

                    cmd.Parameters.Add("IdRegistrarResultadoPermiso", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    IdUsuarioGenerado = Convert.ToInt32(cmd.Parameters["IdRegistrarResultadoPermiso"].Value);
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

    }
}
