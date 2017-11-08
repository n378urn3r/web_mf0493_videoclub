using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using EjemploMVC.Models;

namespace EjemploMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
           //BuildWebHost(args).Run(); // Modificado
            var host =  BuildWebHost(args); // Modificado para no tener que correr la cadena entera.
            using (var contexto = host.Services.CreateScope())
            {
                var services = contexto.ServiceProvider;
                try
                { /* Esta cade salta en caso de error.*/
                    InicioBD.Inicializar(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "error en la bbdd");  /* Esta cade salta en caso de error./*/

                }
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
