using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Quala_Sucursales_Utilidades
{
    public class ApiConnectionStrings
    {
        public static string ConnectionString
        {
            get
            {
                var builder = new ConfigurationBuilder();

                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builder.AddJsonFile($"appsettings.{env}.json", optional: true);

                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString("ConexionDB");
                return connectionString;
            }
        }
    }
}
