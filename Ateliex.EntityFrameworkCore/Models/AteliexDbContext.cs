using Ateliex.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Ateliex.Models
{
    public class AteliexDbContext : DbContext
    {
        public DbSet<Modelo> Modelos { get; set; }

        public DbSet<PlanoComercial> PlanosComerciais { get; set; }

        //public AteliexDbContext()
        //{

        //}

        public AteliexDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //optionsBuilder
            //    //.UseLazyLoadingProxies()
            //    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recurso>()
                .HasKey(p => new { p.ModeloCodigo, p.Descricao });

            modelBuilder.Entity<Custo>()
                .HasKey(p => new { p.PlanoComercialCodigo, p.Descricao });

            modelBuilder.Entity<ItemDePlanoComercial>()
                .HasKey(p => new { p.PlanoComercialCodigo, p.Id });

            // Seed.

            modelBuilder.Entity<Modelo>().HasData(
                new Modelo { Codigo = "TM01", Nome = "Tati Model 01" },
                new Modelo { Codigo = "TM02", Nome = "Tati Model 02" },
                new Modelo { Codigo = "TM03", Nome = "Tati Model 03" },
                new Modelo { Codigo = "TM04", Nome = "Tati Model 04" },
                new Modelo { Codigo = "TM05", Nome = "Tati Model 05" },
                new Modelo { Codigo = "TM06", Nome = "Tati Model 06" },
                new Modelo { Codigo = "TM07", Nome = "Tati Model 07" },
                new Modelo { Codigo = "TM08", Nome = "Tati Model 08" },
                new Modelo { Codigo = "TM09", Nome = "Tati Model 09" },
                new Modelo { Codigo = "TM10", Nome = "Tati Model 10" }
            );

            modelBuilder.Entity<Recurso>().HasData(
                new Recurso { ModeloCodigo = "TM01", Tipo = TipoDeRecurso.Material, Descricao = "Tecido", Custo = 20, Unidades = 2 },
                new Recurso { ModeloCodigo = "TM01", Tipo = TipoDeRecurso.Material, Descricao = "Linha", Custo = 4, Unidades = 20 },
                new Recurso { ModeloCodigo = "TM01", Tipo = TipoDeRecurso.Material, Descricao = "Outros", Custo = 5, Unidades = 1 },
                new Recurso { ModeloCodigo = "TM01", Tipo = TipoDeRecurso.Transporte, Descricao = "Transporte", Custo = 100, Unidades = 50 },
                new Recurso { ModeloCodigo = "TM01", Tipo = TipoDeRecurso.Humano, Descricao = "Costureira", Custo = 5, Unidades = 1 }
            );

            modelBuilder.Entity<PlanoComercial>().HasData(
                new PlanoComercial { Codigo = "PC01.A", Nome = "Normal", RendaBrutaMensal = 6000 },
                new PlanoComercial { Codigo = "PC01.B", Nome = "Moderado" },
                new PlanoComercial { Codigo = "PC01.C", Nome = "Ousado" }
            );

            modelBuilder.Entity<Custo>().HasData(
                new Custo { PlanoComercialCodigo = "PC01.A", Tipo = TipoDeCusto.Fixo, Descricao = "Prolabore", Valor = 1000 },
                new Custo { PlanoComercialCodigo = "PC01.A", Tipo = TipoDeCusto.Fixo, Descricao = "Aluguel", Valor = 900 },
                new Custo { PlanoComercialCodigo = "PC01.A", Tipo = TipoDeCusto.Variavel, Descricao = "Cartão", Percentual = 10 },
                new Custo { PlanoComercialCodigo = "PC01.A", Tipo = TipoDeCusto.Variavel, Descricao = "Comissão", Percentual = 10 },
                new Custo { PlanoComercialCodigo = "PC01.A", Tipo = TipoDeCusto.Variavel, Descricao = "Perda", Percentual = 2 }
            );

            modelBuilder.Entity<ItemDePlanoComercial>().HasData(
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", Id = 1, ModeloCodigo = "TM01", MargemPercentual = 1.93m },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", Id = 2, ModeloCodigo = "TM02" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", Id = 3, ModeloCodigo = "TM03" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", Id = 10, ModeloCodigo = "TM10" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", Id = 1, ModeloCodigo = "TM01" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", Id = 2, ModeloCodigo = "TM02" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", Id = 3, ModeloCodigo = "TM03" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", Id = 4, ModeloCodigo = "TM04" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", Id = 5, ModeloCodigo = "TM05" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", Id = 6, ModeloCodigo = "TM06" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", Id = 7, ModeloCodigo = "TM07" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", Id = 8, ModeloCodigo = "TM08" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", Id = 9, ModeloCodigo = "TM09" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", Id = 10, ModeloCodigo = "TM10" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", Id = 5, ModeloCodigo = "TM05" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", Id = 6, ModeloCodigo = "TM06" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", Id = 7, ModeloCodigo = "TM07" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", Id = 8, ModeloCodigo = "TM08" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", Id = 9, ModeloCodigo = "TM09" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", Id = 10, ModeloCodigo = "TM10" }
           );
        }
    }
}
