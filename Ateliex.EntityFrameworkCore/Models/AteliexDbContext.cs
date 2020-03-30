using Microsoft.EntityFrameworkCore;

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

            //optionsBuilder
            //    //.UseLazyLoadingProxies()
            //    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Modelo>()
            //    .HasKey(p => p.Codigo);

            modelBuilder.Entity<Modelo>()
                .Ignore(p => p.State);

            modelBuilder.Entity<Recurso>()
                .HasKey(p => new { p.ModeloCodigo, p.Id });

            modelBuilder.Entity<Recurso>()
                .Ignore(p => p.State);

            modelBuilder.Entity<PlanoComercial>()
                .Ignore(p => p.State);

            modelBuilder.Entity<Custo>()
                .HasKey(p => new { p.PlanoComercialCodigo, p.Id });

            modelBuilder.Entity<Custo>()
                .Ignore(p => p.State);

            modelBuilder.Entity<ItemDePlanoComercial>()
                .HasKey(p => new { p.PlanoComercialCodigo, p.ModeloCodigo });

            modelBuilder.Entity<ItemDePlanoComercial>()
                .Ignore(p => p.State);

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
                new Recurso { ModeloCodigo = "TM01", Id = 1, Tipo = TipoDeRecurso.Material, Descricao = "Tecido", Custo = 20, Unidades = 2 },
                new Recurso { ModeloCodigo = "TM01", Id = 2, Tipo = TipoDeRecurso.Material, Descricao = "Linha", Custo = 4, Unidades = 20 },
                new Recurso { ModeloCodigo = "TM01", Id = 3, Tipo = TipoDeRecurso.Material, Descricao = "Outros", Custo = 5, Unidades = 1 },
                new Recurso { ModeloCodigo = "TM01", Id = 4, Tipo = TipoDeRecurso.Transporte, Descricao = "Transporte", Custo = 100, Unidades = 50 },
                new Recurso { ModeloCodigo = "TM01", Id = 5, Tipo = TipoDeRecurso.Humano, Descricao = "Costureira", Custo = 5, Unidades = 1 }
            );

            modelBuilder.Entity<PlanoComercial>().HasData(
                new PlanoComercial { Codigo = "PC01.A", Nome = "Normal", RendaBrutaMensal = 6000 },
                new PlanoComercial { Codigo = "PC01.B", Nome = "Moderado" },
                new PlanoComercial { Codigo = "PC01.C", Nome = "Ousado" }
            );

            modelBuilder.Entity<Custo>().HasData(
                new Custo { PlanoComercialCodigo = "PC01.A", Id = 1, Tipo = TipoDeCusto.Fixo, Descricao = "Prolabore", Valor = 1000 },
                new Custo { PlanoComercialCodigo = "PC01.A", Id = 2, Tipo = TipoDeCusto.Fixo, Descricao = "Aluguel", Valor = 900 },
                new Custo { PlanoComercialCodigo = "PC01.A", Id = 3, Tipo = TipoDeCusto.Variavel, Descricao = "Cartão", Percentual = 10 },
                new Custo { PlanoComercialCodigo = "PC01.A", Id = 4, Tipo = TipoDeCusto.Variavel, Descricao = "Comissão", Percentual = 10 },
                new Custo { PlanoComercialCodigo = "PC01.A", Id = 5, Tipo = TipoDeCusto.Variavel, Descricao = "Perda", Percentual = 2 }
            );

            modelBuilder.Entity<ItemDePlanoComercial>().HasData(
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM01", MargemPercentual = 1.93m },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM02" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM03" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM10" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM01" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM02" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM03" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM04" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM05" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM06" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM07" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM08" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM09" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM10" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM05" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM06" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM07" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM08" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM09" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM10" }
           );
        }
    }
}
