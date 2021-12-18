using Ateliex.Areas.Cadastro.Models;
using Ateliex.Areas.Comercial.Models;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Data
{
    public class AteliexDbContext : DbContext
    {
        public DbSet<Modelo> ModeloSet { get; set; }

        public DbSet<ModeloRecurso> ModeloRecursoSet { get; set; }

        public DbSet<ModeloRecursoTipo> ModeloRecursoTipoSet { get; set; }

        public DbSet<PlanoComercial> PlanoComercialSet { get; set; }

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Modelo>().ToTable("Modelo", "cadastro");

            //builder.Entity<Modelo>().Property(p => p.RowVersion).IsRowVersion();

            builder.Entity<ModeloRecurso>().ToTable("ModeloRecurso", "cadastro");

            builder.Entity<ModeloRecurso>().HasKey(p => new { p.ModeloCodigo, p.Id });

            builder.Entity<ModeloRecurso>().Property(p => p.Custo).HasPrecision(14, 2);

            builder.Entity<ModeloRecursoTipo>().ToTable("ModeloRecursoTipo", "cadastro");

            builder.Entity<ModeloRecursoTipo>().Property(p => p.Id).ValueGeneratedNever();

            //

            builder.Entity<PlanoComercial>().ToTable("PlanoComercial", "comercial");

            builder.Entity<PlanoComercialCusto>().ToTable("PlanoComercialCusto", "comercial");

            builder.Entity<PlanoComercialCusto>().HasKey(p => new { p.PlanoComercialCodigo, p.Id });

            builder.Entity<PlanoComercialItem>().ToTable("PlanoComercialItem", "comercial");

            builder.Entity<PlanoComercialItem>().HasKey(p => new { p.PlanoComercialCodigo, p.ModeloCodigo });

            //builder.Ignore<PlanoComercial>();
            //builder.Ignore<PlanoComercialCusto>();
            //builder.Ignore<PlanoComercialItem>();

            // Seed.

            builder.Entity<Modelo>().HasData(
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

            builder.Entity<ModeloRecursoTipo>().HasData(
                new ModeloRecursoTipo { Id = (int)Areas.Cadastro.Enums.ModeloRecursoTipo.Material, Nome = "Material" },
                new ModeloRecursoTipo { Id = (int)Areas.Cadastro.Enums.ModeloRecursoTipo.Transporte, Nome = "Transporte" },
                new ModeloRecursoTipo { Id = (int)Areas.Cadastro.Enums.ModeloRecursoTipo.Humano, Nome = "Humano" }
            );

            builder.Entity<ModeloRecurso>().HasData(
                new ModeloRecurso { ModeloCodigo = "TM01", Id = 1, TipoId = (int)Areas.Cadastro.Enums.ModeloRecursoTipo.Material, Descricao = "Tecido", Custo = 20, Unidades = 2 },
                new ModeloRecurso { ModeloCodigo = "TM01", Id = 2, TipoId = (int)Areas.Cadastro.Enums.ModeloRecursoTipo.Material, Descricao = "Linha", Custo = 4, Unidades = 20 },
                new ModeloRecurso { ModeloCodigo = "TM01", Id = 3, TipoId = (int)Areas.Cadastro.Enums.ModeloRecursoTipo.Material, Descricao = "Outros", Custo = 5, Unidades = 1 },
                new ModeloRecurso { ModeloCodigo = "TM01", Id = 4, TipoId = (int)Areas.Cadastro.Enums.ModeloRecursoTipo.Transporte, Descricao = "Transporte", Custo = 100, Unidades = 50 },
                new ModeloRecurso { ModeloCodigo = "TM01", Id = 5, TipoId = (int)Areas.Cadastro.Enums.ModeloRecursoTipo.Humano, Descricao = "Costureira", Custo = 5, Unidades = 1 }
            );

            //

            builder.Entity<PlanoComercial>().HasData(
                new PlanoComercial { Codigo = "PC01.A", Nome = "Normal", RendaBrutaMensal = 6000 },
                new PlanoComercial { Codigo = "PC01.B", Nome = "Moderado" },
                new PlanoComercial { Codigo = "PC01.C", Nome = "Ousado" }
            );

            builder.Entity<PlanoComercialCusto>().HasData(
                new PlanoComercialCusto { PlanoComercialCodigo = "PC01.A", Id = 1, Tipo = Areas.Comercial.Enums.PlanoComercialCustoTipo.Fixo, Descricao = "Prolabore", Valor = 1000 },
                new PlanoComercialCusto { PlanoComercialCodigo = "PC01.A", Id = 2, Tipo = Areas.Comercial.Enums.PlanoComercialCustoTipo.Fixo, Descricao = "Aluguel", Valor = 900 },
                new PlanoComercialCusto { PlanoComercialCodigo = "PC01.A", Id = 3, Tipo = Areas.Comercial.Enums.PlanoComercialCustoTipo.Variavel, Descricao = "Cartão", Percentual = 10 },
                new PlanoComercialCusto { PlanoComercialCodigo = "PC01.A", Id = 4, Tipo = Areas.Comercial.Enums.PlanoComercialCustoTipo.Variavel, Descricao = "Comissão", Percentual = 10 },
                new PlanoComercialCusto { PlanoComercialCodigo = "PC01.A", Id = 5, Tipo = Areas.Comercial.Enums.PlanoComercialCustoTipo.Variavel, Descricao = "Perda", Percentual = 2 }
            );

            builder.Entity<PlanoComercialItem>().HasData(
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM01", MargemPercentual = 1.93m },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM02" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM03" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM10" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM01" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM02" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM03" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM04" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM05" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM06" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM07" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM08" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM09" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM10" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM05" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM06" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM07" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM08" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM09" },
                new PlanoComercialItem { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM10" }
           );
        }
    }
}
