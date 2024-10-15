using API_Quala_Sucursales_Entidades;
using API_Quala_Sucursales_Negocio;
using API_Quala_Sucursales_Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Threading;

namespace API_Quala_Sucursales.Controllers
{
    [ApiController]
    [Route("api/Consulta")]
    public class SucursalesController : ControllerBase
    {
        private ISucursales _iSucursales;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iSucursales"></param>
        public SucursalesController(
            ISucursales iSucursales
            )
        {
            _iSucursales = iSucursales;
        }
        /// <summary>
        /// Crear Sucursales
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost("CrearSucursal")]
        public async Task<ActionResult<AdminRespuesta>> CrearSucursal(SucursalRequestDto entidadCrear)
        {
            AdminRespuesta suc = new AdminRespuesta();
            try
            {
                if (!ValidarEntidadRequest(entidadCrear))
                {
                    suc.Msn = "Debe ingresar la información para todos los campos.";
                    suc.Estado = false;
                    return BadRequest(suc);
                }
                else
                {
                    suc = await _iSucursales.CrearSucursal(entidadCrear);
                    return Ok(suc);
                }
            }
            catch (Exception ex)
            {
                suc.Estado = false;
                suc.Msn = ex.Message;
                return BadRequest(suc);
            }
        }
        /// <summary>
        /// Consultar Sucursales
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet("ConsultarSucursales")]
        public async Task<ActionResult> ConsultarSucursales(long IdSucursal)
        {
            try
            {
                List<SucursalResponseDto> sucursales = (List<SucursalResponseDto>)await _iSucursales.ConsultarSucursales(IdSucursal);
                    return Ok(sucursales);                
            }
            catch (Exception ex)
            {
                AdminRespuesta respuesta = new AdminRespuesta
                {
                    Msn = ex.Message,
                    Estado= false
                };
                return StatusCode(500, respuesta);
            }
        }

        /// <summary>
        /// Inactivar Sucursal
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost("InactivarInactivar")]
        public async Task<ActionResult<AdminRespuesta>> InactivarSucursal(long IdSucursal)
        {
            AdminRespuesta Response = new AdminRespuesta();
            try
            {
                if (IdSucursal <= 0)
                {
                    Response.Msn = "Numero de sucursal no valido.";
                    Response.Estado = false;    
                    return BadRequest(Response);
                }
                else
                    Response = await _iSucursales.InactivarSucursal(IdSucursal);

                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.Msn = ex.Message;
                Response.Estado = false;
                return StatusCode(500, Response);
            }            
        }

        /// <summary>
        /// Actualizar Sucursal
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost("ActualizarSucursal")]
        public async Task<ActionResult<AdminRespuesta>> ActualizarSucursal(SucursalResponseDto entidadModificar)
        {
            try
            {
                AdminRespuesta Response = new AdminRespuesta();
                if (ValidarEntidadResponse(entidadModificar))
                    Response = await _iSucursales.ActualizarSucursal(entidadModificar);
                else
                {
                    Response.Msn = "Debe ingresar los datos completos para realizar la actualización.";
                    Response.Estado = false;
                    return BadRequest(Response);
                }                    
                return Ok(Response);
            }
            catch (Exception ex)
            {
                AdminRespuesta respuesta = new AdminRespuesta
                {
                    Msn = ex.Message,
                    Estado = false
                };
                return StatusCode(500, respuesta);
            }
        }

        /// <summary>
        /// Consultar Monedas
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet("ConsultarMonedas")]
        public async Task<ActionResult<object>> ConsultarMonedas()
        {
            try
            {
                return Ok(await _iSucursales.ConsultarMonedas());
            }
            catch (Exception ex)
            {
                AdminRespuesta respuesta = new AdminRespuesta
                {
                    Msn = ex.Message,
                    Estado = false
                };
                return StatusCode(500, respuesta);
            }
        }
        internal bool ValidarEntidadResponse(SucursalResponseDto entidad)
        {
            return !string.IsNullOrEmpty(entidad.Descripcion) &&
                   !string.IsNullOrEmpty(entidad.Identificacion) &&
                   entidad.IdCiudad > 0 &&
                   !string.IsNullOrEmpty(entidad.Direccion) &&
                   entidad.Telefono > 0  &&
                   entidad.IdMoneda > 0;
        }
        internal bool ValidarEntidadRequest(SucursalRequestDto entidad)
        {
            return !string.IsNullOrEmpty(entidad.Descripcion) &&
                   !string.IsNullOrEmpty(entidad.Identificacion) &&
                   entidad.IdCiudad > 0 &&
                   !string.IsNullOrEmpty(entidad.Direccion) &&
                   entidad.Telefono > 0 &&
                   entidad.IdMoneda > 0;
        }
    }
}


