using Ateliex.Areas.Cadastro.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Modelo> Modelos { get; set; }
    
    public DbSet<Recurso> Recursos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>()
            .ToTable("Roles", "identity");

        builder.Entity<IdentityUser>()
            .ToTable("Users", "identity");

        builder.Entity<IdentityRoleClaim<string>>()
            .ToTable("RoleClaims", "identity");

        builder.Entity<IdentityUserClaim<string>>()
            .ToTable("UserClaims", "identity");

        builder.Entity<IdentityUserLogin<string>>()
            .ToTable("UserLogins", "identity");

        builder.Entity<IdentityUserRole<string>>()
            .ToTable("UserRoles", "identity");

        builder.Entity<IdentityUserToken<string>>()
            .ToTable("UserTokens", "identity");

        builder.Entity<Modelo>()
            .ToTable("Modelos", "cadastro");

        builder.Entity<Modelo>()
            .Ignore(p => p.State);

        builder.Entity<Recurso>()
            .ToTable("ModeloRecursos", "cadastro");

        builder.Entity<Recurso>()
            .HasKey(p => new { p.ModeloCodigo, p.Id });

        builder.Entity<Recurso>()
            .Ignore(p => p.State);

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

        builder.Entity<Recurso>().HasData(
            new Recurso { ModeloCodigo = "TM01", Id = 1, Tipo = TipoDeRecurso.Material, Descricao = "Tecido", Custo = 20, Unidades = 2 },
            new Recurso { ModeloCodigo = "TM01", Id = 2, Tipo = TipoDeRecurso.Material, Descricao = "Linha", Custo = 4, Unidades = 20 },
            new Recurso { ModeloCodigo = "TM01", Id = 3, Tipo = TipoDeRecurso.Material, Descricao = "Outros", Custo = 5, Unidades = 1 },
            new Recurso { ModeloCodigo = "TM01", Id = 4, Tipo = TipoDeRecurso.Transporte, Descricao = "Transporte", Custo = 100, Unidades = 50 },
            new Recurso { ModeloCodigo = "TM01", Id = 5, Tipo = TipoDeRecurso.Humano, Descricao = "Costureira", Custo = 5, Unidades = 1 }
        );
    }
}
