using CommonVB.Servientrega.SOA.CommonVB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Quala_Sucursales_Utilidades
{
    public class Kriptar
    {
        public static string DesCifrar(string cadena)
        {

            cmpUtilitario objcmp = new cmpUtilitario();
            string objDeCodifica;
            try
            {
                objDeCodifica = objcmp.mDesencriptar(cadena);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("Error" + ex.Message);
            }
            return objDeCodifica;
        }
    }
}
