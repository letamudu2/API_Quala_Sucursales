using API_Quala_Sucursales_Entidades;
using API_Quala_Sucursales_Negocio.Interfaces;
using API_Quala_Sucursales_Datos;


namespace API_Quala_Sucursales_Negocio
{
    public class Sucursales : ISucursales
    {
        /// <summary>
        /// Crear sucursal.
        /// </summary>
        /// <returns></returns>
        public async Task<AdminRespuesta> CrearSucursal(SucursalRequestDto entidadCrear)
        {
            AdminRespuesta respuesta = new AdminRespuesta();
            try
            {
                respuesta = await API_Quala_Sucursales_Datos.Sucursales.CrearSucursal(entidadCrear);
            }
            catch (Exception Ex)
            {
                respuesta.Msn  = Ex.Message;
                respuesta.Estado= false;
            }
            return respuesta;
        }
        /// <summary>
        /// Consultar sucursal.
        /// </summary>
        /// <returns></returns>
        public async Task<object> ConsultarSucursales(long IdSucursal)
        {
            return await API_Quala_Sucursales_Datos.Sucursales.ConsultarSucursales(IdSucursal);
        }
        /// <summary>
        /// Inactivar sucursal.
        /// </summary>
        /// <returns></returns>
        public async Task<AdminRespuesta> InactivarSucursal(long IdSucursal)
        {
            return await API_Quala_Sucursales_Datos.Sucursales.InactivarSucursal(IdSucursal);
        }
        /// <summary>
        /// Actualiza sucursal.
        /// </summary>
        /// <returns></returns>
        public async Task<AdminRespuesta> ActualizarSucursal(SucursalResponseDto dtoInfo)
        {
            return await API_Quala_Sucursales_Datos.Sucursales.ActualizarSucursal(dtoInfo);
        }
        /// <summary>
        /// Consultar monedas.
        /// </summary>
        /// <returns>Retorna lista monedas.</returns>
        public async Task<object> ConsultarMonedas()
        {
            return await API_Quala_Sucursales_Datos.Sucursales.ConsultarMonedas();
        }
    }
}
