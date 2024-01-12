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
    public class CD_Cargo
    {

        public List<Cargo> listar()
        {
            List<Cargo> lista = new List<Cargo>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT Id_Cargo,nombre_Cargo FROM Cargo");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cargo()
                            {

                                Id_Cargo = Convert.ToInt32(dr["Id_Cargo"]),
                                nombre_Cargo = dr["nombre_Cargo"].ToString()

                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Cargo>();
                }
            }

            return lista;

        }


    }
}
