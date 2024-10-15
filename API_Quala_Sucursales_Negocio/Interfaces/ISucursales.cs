using API_Quala_Sucursales_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Quala_Sucursales_Negocio.Interfaces
{
    public interface ISucursales
    {
        /// <summary>
        /// Crea una Sucursal.
        /// </summary>
        /// <param name="entidadCrear"></param>
        /// <returns>Retorna objeto con la información del proceso.</returns>
        public Task<AdminRespuesta> CrearSucursal(SucursalRequestDto entidadCrear);
        /// <summary>
        /// Consulta Sucursal por Id o por todas las Sucursales registrados.
        /// </summary>
        /// <param name="IdSucursal">Consulta por el Id de la Sucursal.</param>
        /// <returns>Retorna el detalle de la Sucursal.</returns>
        public Task<object> ConsultarSucursales(long IdSucursal);
        /// <summary>
        /// Inactiva Sucursal por ID.
        /// </summary>
        /// <param name="IdSucursal"></param>
        /// <returns>Retorna objeto con la información del proceso.</returns>
        public Task<AdminRespuesta> InactivarSucursal(long IdSucursal);
        /// <summary>
        /// Actualiza la Sucursal.
        /// </summary>
        /// <param name="dtoInfo"></param>
        /// <returns>Retorna objeto con la información del proceso.</returns>
        public Task<AdminRespuesta> ActualizarSucursal(SucursalResponseDto dtoInfo);
        /// <summary>
        /// Consultar monedas.
        /// </summary>
        /// <returns>Retorna lista monedas.</returns>
        public Task<object> ConsultarMonedas();
    }
}
