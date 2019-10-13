using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ateliex.Models
{
    public class AteliexDbContext: DbContext
    {
        public DbSet<Modelo> Modelos { get; set; }
        
        public DbSet<PlanoComercial> PlanosComerciais { get; set; }
    }
}
