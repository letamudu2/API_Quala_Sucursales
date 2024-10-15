using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Quala_Sucursales_Entidades
{
    public class SucursalResponseDto
    {
        public int? Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Identificacion { get; set; }
        public bool? Estado { get; set; }
        public string? NombreCiudad { get; set; }
        public int? IdCiudad { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int? IdMoneda { get; set; }
        public string? NombreMoneda { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
    public class SucursalRequestDto
    {
        public string Descripcion { get; set; } 
        public string Identificacion { get; set; } 
        public int IdCiudad { get; set; } 
        public string Direccion { get; set; } 
        public int Telefono { get; set; } 
        public int IdMoneda { get; set; } 
    }
}
