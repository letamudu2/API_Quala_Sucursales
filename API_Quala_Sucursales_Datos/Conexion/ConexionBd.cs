using API_Quala_Sucursales_Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Quala_Sucursales_Datos.Conexion
{
    internal class ConexionBd
    {
        public string ConexionDao(int baseDatos)
        {
            string cadenaConexion = string.Empty;
            string _CadenaConexion = string.Empty;

            switch (baseDatos)
            {
                case 1:
                    _CadenaConexion = ApiConnectionStrings.ConnectionString;
                    break;
            }

            cadenaConexion = Kriptar.DesCifrar(_CadenaConexion);
            return cadenaConexion;
        }

    }   
}
