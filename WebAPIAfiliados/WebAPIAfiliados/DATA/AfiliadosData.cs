using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPIAfiliados.Models;

namespace WebAPIAfiliados.DATA
{
    public class AfiliadosData
    {
        public static bool Registrar(AFILIADOS oAFILIADOS)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("pro_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", oAFILIADOS.Nombres);
                cmd.Parameters.AddWithValue("@apellido", oAFILIADOS.Apellidos);
                cmd.Parameters.AddWithValue("@fechaNacimento", oAFILIADOS.Fecha_nacimineto);
                cmd.Parameters.AddWithValue("@sexo", oAFILIADOS.Sexo);
                cmd.Parameters.AddWithValue("@cedula", oAFILIADOS.Cedula);
                cmd.Parameters.AddWithValue("@numeroSeguridadSocial", oAFILIADOS.Numero_Seguridaad_Social);
                cmd.Parameters.AddWithValue("@fechaRegistro", oAFILIADOS.Fecha_Resgistro);
                cmd.Parameters.AddWithValue("@idEstatus", oAFILIADOS.idEstatus);
                cmd.Parameters.AddWithValue("@idPlan", oAFILIADOS.idPlan);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool ActualizarMonto(AFILIADOS oAFILIADOS)
        {


            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("pro_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@montoConsumido ", oAFILIADOS.Monto_Consumido);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }


        }


        public static bool Modificar(AFILIADOS oAFILIADOS)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("pro_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", oAFILIADOS.Nombres);
                cmd.Parameters.AddWithValue("@apellido", oAFILIADOS.Apellidos);
                cmd.Parameters.AddWithValue("@fechaNacimento", oAFILIADOS.Fecha_nacimineto);
                cmd.Parameters.AddWithValue("@sexo", oAFILIADOS.Sexo);
                cmd.Parameters.AddWithValue("@cedula", oAFILIADOS.Cedula);
                cmd.Parameters.AddWithValue("@numeroSeguridadSocial", oAFILIADOS.Numero_Seguridaad_Social);
                cmd.Parameters.AddWithValue("@fechaRegistro", oAFILIADOS.Fecha_Resgistro);
                cmd.Parameters.AddWithValue("@montoConsumido ", oAFILIADOS.Monto_Consumido);
                cmd.Parameters.AddWithValue("@idEstatus", oAFILIADOS.idEstatus);
                cmd.Parameters.AddWithValue("@idPlan", oAFILIADOS.idPlan);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public static List<AFILIADOS> Listar()
        {
            List<AFILIADOS> oListaafiliados = new List<AFILIADOS>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("pro_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaafiliados.Add(new AFILIADOS()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                Fecha_nacimineto = Convert.ToDateTime(dr["Fecha_nacimineto"].ToString()),
                                Sexo = dr["Sexo"].ToString(),
                                Cedula = dr["Cedula"].ToString(),
                                Numero_Seguridaad_Social = dr["Numero_Seguridaad_Social"].ToString(),
                                Fecha_Resgistro = Convert.ToDateTime(dr["Fecha_Resgistro"].ToString()),
                                Monto_Consumido = Convert.ToInt32(dr["Monto_Consumido"]),
                                idEstatus = Convert.ToInt32(dr["idEstatus"]),
                                idPlan = Convert.ToInt32(dr["idPlan"])
                                
                            });
                        }

                    }



                    return oListaafiliados;
                }
                catch (Exception ex)
                {
                    return oListaafiliados;
                }
            }
        }


        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("pro_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idafiliado", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }




    }
}