using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Quala_Sucursales_Entidades
{
    public class AdminRespuesta
    {
        public bool Estado { get; set; } = false;
        public string Msn { get; set; } = "Defalut";
      
    }
    public class AdminRespuesta1
    {
        public bool state { get; set; } = false;
        public string msn { get; set; } = "Defalut";
        public object value { get; set; }
        public int total { get; set; } = 0;
    }

}
