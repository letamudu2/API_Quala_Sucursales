using API_Quala_Sucursales_Datos.Conexion;
using API_Quala_Sucursales_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Quala_Sucursales_Datos
{
    public class Sucursales
    {
        public static async Task<AdminRespuesta> CrearSucursal(SucursalRequestDto entidadCrear)
        {
            ConexionBd bd = new ConexionBd();
            AdminRespuesta Response = new AdminRespuesta();

            using (SqlConnection conn = new SqlConnection(bd.ConexionDao(1)))
            {
                SqlCommand cmd = new SqlCommand("CrearSucursal", conn);
                cmd.Parameters.AddWithValue("@DESCRIPCION", entidadCrear.Descripcion);
                cmd.Parameters.AddWithValue("@IDENTIFICACION", entidadCrear.Identificacion);
                cmd.Parameters.AddWithValue("@ID_CIUDAD", entidadCrear.IdCiudad);
                cmd.Parameters.AddWithValue("@DIRECCION", entidadCrear.Direccion);
                cmd.Parameters.AddWithValue("@TELEFONO", entidadCrear.Telefono);
                cmd.Parameters.AddWithValue("@ID_MONEDA", entidadCrear.IdMoneda);

                SqlParameter mensajeDeRespuestaParam = new SqlParameter("@mensajeDeRespuesta", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(mensajeDeRespuestaParam);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    string mensajeDeRespuesta = (string)mensajeDeRespuestaParam.Value;
                    Response.Msn = mensajeDeRespuesta;
                    Response.Estado= true; 
                }
                catch (Exception ex)
                {
                    Response.Estado = false;
                    Response.Msn = ex.Message; 
                }
                finally
                {
                    await conn.CloseAsync();
                }
            }
            return Response;
        }

        public static async Task<object> ConsultarSucursales(long IdSucursal)
        {
            List<SucursalResponseDto> lstSucursales = new List<SucursalResponseDto>();
            ConexionBd bd = new ConexionBd();

            using (SqlConnection conn = new SqlConnection(bd.ConexionDao(1)))
            {
                SqlCommand cmd = new SqlCommand("ConsultaSucursales", conn);
                cmd.Parameters.AddWithValue("@CODIGO", IdSucursal);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await conn.OpenAsync();
                    SqlDataReader Rd = await cmd.ExecuteReaderAsync();

                    if (Rd.HasRows)
                    {
                        while (Rd.Read())
                        {
                            SucursalResponseDto dtoSucursal = new SucursalResponseDto();
                            dtoSucursal.Codigo = (int)Rd["CODIGO"];
                            dtoSucursal.Descripcion = (string)Rd["DESCRIPCION"];
                            dtoSucursal.Identificacion = (string)Rd["IDENTIFICACION"];
                            dtoSucursal.Estado = (bool)Rd["ESTADO"];
                            dtoSucursal.IdCiudad = (int)Rd["ID_CIUDAD"];
                            dtoSucursal.NombreCiudad = (string)Rd["NOMBRE_CIUDAD"];
                            dtoSucursal.Direccion = (string)Rd["DIRECCION"];
                            dtoSucursal.Telefono= (int)Rd["TELEFONO"];
                            dtoSucursal.IdMoneda = (int)Rd["ID_MONEDA"];
                            dtoSucursal.NombreMoneda= (string)Rd["NOMBRE_MONEDA"];
                            dtoSucursal.FechaCreacion = (DateTime)Rd["FECHA_CREACION"];
                            dtoSucursal.FechaModificacion = (DateTime)Rd["FECHA_MODIFICACION"];
                            lstSucursales.Add(dtoSucursal);
                        }
                    }
                }
                catch (Exception ex)
                {
                    AdminRespuesta adminRespuesta = new AdminRespuesta();
                    adminRespuesta.Msn = ex.Message;
                    adminRespuesta.Estado = false;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return lstSucursales;
        }

        

        public static async Task<AdminRespuesta> InactivarSucursal(long IdSucursal)
        {
            ConexionBd bd = new ConexionBd();
            AdminRespuesta Response = new AdminRespuesta();
            using (SqlConnection conn = new SqlConnection(bd.ConexionDao(1)))
            {
                SqlCommand cmd = new SqlCommand("InactivarSucursal", conn);
                cmd.Parameters.AddWithValue("@CODIGO", IdSucursal);
                SqlParameter mensajeDeRespuestaParam = new SqlParameter("@mensajeDeRespuesta", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(mensajeDeRespuestaParam);

                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await conn.OpenAsync();
                    using (SqlDataReader Rd = await cmd.ExecuteReaderAsync())
                    {
                        Response.Estado = true;
                        Response.Msn = (string)mensajeDeRespuestaParam.Value;
                    }
                }
                catch (Exception ex)
                {
                    Response.Estado= false;
                    Response.Msn= ex.Message;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return Response;
        }

        public static async Task<AdminRespuesta> ActualizarSucursal(SucursalResponseDto dtoInfo)
        {
            ConexionBd bd = new ConexionBd();
            AdminRespuesta Response = new AdminRespuesta();
            using (SqlConnection conn = new SqlConnection(bd.ConexionDao(1)))
            {
                SqlCommand cmd = new SqlCommand("ModificarSucursal", conn);
                cmd.Parameters.AddWithValue("@CODIGO", dtoInfo.Codigo);
                cmd.Parameters.AddWithValue("@DESCRIPCION", dtoInfo.Descripcion);
                cmd.Parameters.AddWithValue("@IDENTIFICACION", dtoInfo.Identificacion);
                cmd.Parameters.AddWithValue("@ESTADO", dtoInfo.Estado);
                cmd.Parameters.AddWithValue("@ID_CIUDAD", dtoInfo.IdCiudad);
                cmd.Parameters.AddWithValue("@DIRECCION", dtoInfo.Direccion);
                cmd.Parameters.AddWithValue("@TELEFONO ", dtoInfo.Telefono);
                cmd.Parameters.AddWithValue("@ID_MONEDA", dtoInfo.IdMoneda);
                SqlParameter mensajeDeRespuestaParam = new SqlParameter("@mensajeDeRespuesta", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(mensajeDeRespuestaParam);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await conn.OpenAsync();
                    using (SqlDataReader Rd = await cmd.ExecuteReaderAsync())
                    {
                        Response.Estado = true;
                        Response.Msn = mensajeDeRespuestaParam.Value == DBNull.Value ? string.Empty : (string)mensajeDeRespuestaParam.Value;
                    }
                }
                catch (Exception ex)
                {
                    Response.Estado = true;
                    Response.Msn = ex.Message;  
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
                return Response;
            }
        }

        public static async Task<object> ConsultarMonedas()
        {
            List<MonedasDto> lstMonedas = new List<MonedasDto>();
            ConexionBd bd = new ConexionBd();

            using (SqlConnection conn = new SqlConnection(bd.ConexionDao(1)))
            {
                SqlCommand cmd = new SqlCommand("ConsultarLstMonedas", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await conn.OpenAsync();
                    SqlDataReader Rd = await cmd.ExecuteReaderAsync();

                    if (Rd.HasRows)
                    {
                        while (Rd.Read())
                        {
                            MonedasDto dtoMonedas = new MonedasDto();
                            dtoMonedas.Id = (int)Rd["ID_MONEDA"];
                            dtoMonedas.NombreMoneda = (string)Rd["NOMBRE_MONEDA"];
                            lstMonedas.Add(dtoMonedas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    AdminRespuesta adminRespuesta = new AdminRespuesta();
                    adminRespuesta.Msn = ex.Message;
                    adminRespuesta.Estado = false;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return lstMonedas;
        }
    }
}
