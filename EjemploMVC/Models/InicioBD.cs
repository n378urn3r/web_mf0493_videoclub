using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection; //añadida a mano
using Microsoft.EntityFrameworkCore;

namespace EjemploMVC.Models
{
    public class InicioBD

    {
        public static void Inicializar(IServiceProvider serviceProvider)
        {

            using (var context = new EjemploMVCContext(serviceProvider.GetRequiredService<DbContextOptions< EjemploMVCContext>>()))
            {
                if (context.Videos.Any())
                {
                    return;

                }

                context.Videos.AddRange(

                    new Videos
                    { Titulo = "Arma Letal",
                        FechaEstreno = DateTime.Parse("01/01/92"),
                        Genero = "Accion", Precio = 10, Stock = 12 ,
                        Rating = 0
                    },
                    new Videos
                    {
                        Titulo = "Los caballeros de la mesa cuadrada",
                        FechaEstreno = DateTime.Parse("21/02/82"),
                        Genero = "Humor", Precio = 30,
                        Stock = 1,
                        Rating = 3

                    },
                    new Videos
                    {
                        Titulo = "El lobo de wall street",
                        FechaEstreno = DateTime.Parse("24/04/34"),
                        Genero = "Accion",
                        Precio = 30,
                        Stock = 1,
                        Rating =  20



                    },
                    new Videos
                    {
                        Titulo = "La vida de brian",
                        FechaEstreno = DateTime.Parse("24/04/34"),
                        Genero = "Humor",
                        Precio = 40,
                        Stock = 1,
                        Rating =0
                        


                    },
                    new Videos
                    {
                        Titulo = "Fue a pedir trabajo y le comieron lo de abajo",
                        FechaEstreno = DateTime.Parse("14/04/34"),
                        Genero = "Porno",
                        Precio = 40,
                        Stock = 1,
                        Rating = 40



                    },
                    new Videos
                    {
                        Titulo = "Rabocop",
                        FechaEstreno = DateTime.Parse("14/04/34"),
                        Genero = "Porno",
                        Precio = 30,
                        Stock = 1,
                        Rating = 20



                    },
                    new Videos
                    {
                        Titulo = "Negrata con tres patas",
                        FechaEstreno = DateTime.Parse("14/04/34"),
                        Genero = "Porno",
                        Precio = 30,
                        Stock = 1,
                        Rating = 20



                    },
                    new Videos
                    {
                        Titulo = "Blancanieves y los 7 follanitos",
                        FechaEstreno = DateTime.Parse("14/04/34"),
                        Genero = "Porno",
                        Precio = 40,
                        Stock = 1,
                        Rating = 30



                    }

                    );
                context.SaveChanges();

            }

        }

    }
}
