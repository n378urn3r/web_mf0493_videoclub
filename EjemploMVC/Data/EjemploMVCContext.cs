using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EjemploMVC.Models
{
    public class EjemploMVCContext : DbContext
    {
        public EjemploMVCContext (DbContextOptions<EjemploMVCContext> options)
            : base(options)
        {
        }

        public DbSet<EjemploMVC.Models.Videos> Videos { get; set; }
    }
}
