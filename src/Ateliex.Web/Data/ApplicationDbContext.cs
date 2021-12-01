using Ateliex.Areas.Cadastro.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Modelo> Modelos { get; set; }

    public DbSet<ModeloRecurso> ModeloRecursos { get; set; }

    public DbSet<ModeloRecursoTipo> ModeloRecursoTipos { get; set; }

    public DbSet<ModeloRecursoTipoDescricao> ModeloRecursoTipoDesricoes { get; set; }

    public DbSet<ModeloRecursoObservacao> ModeloRecursoObservacoes { get; set; }

    public DbSet<ModeloRecursoAnexo> ModeloRecursoAnexos { get; set; }

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

        builder.Entity<ModeloRecurso>()
            .ToTable("ModeloRecursos", "cadastro");

        builder.Entity<ModeloRecurso>()
            .HasOne(a => a.Observacao)
            .WithOne(b => b.Recurso)
            .HasForeignKey<ModeloRecursoObservacao>(b => b.RecursoId);

        builder.Entity<ModeloRecurso>()
            .Property(p => p.Custo)
            .HasPrecision(14, 2);

        builder.Entity<ModeloRecursoTipo>()
            .ToTable("ModeloRecursoTipos", "cadastro");

        builder.Entity<ModeloRecursoTipo>()
            .HasOne(a => a.Descricao)
            .WithOne(b => b.Tipo)
            .HasForeignKey<ModeloRecursoTipoDescricao>(b => b.TipoId);

        builder.Entity<ModeloRecursoTipoDescricao>()
            .ToTable("ModeloRecursoTipoDescricoes", "cadastro");

        builder.Entity<ModeloRecursoObservacao>()
            .ToTable("ModeloRecursoObservacoes", "cadastro");

        builder.Entity<ModeloRecursoAnexo>()
            .ToTable("ModeloRecursoAnexos", "cadastro");

        // Seed.

        builder.Entity<Modelo>().HasData(
            new Modelo { Id = 1, Nome = "Tati Model 01" },
            new Modelo { Id = 2, Nome = "Tati Model 02" },
            new Modelo { Id = 3, Nome = "Tati Model 03" },
            new Modelo { Id = 4, Nome = "Tati Model 04" },
            new Modelo { Id = 5, Nome = "Tati Model 05" },
            new Modelo { Id = 6, Nome = "Tati Model 06" },
            new Modelo { Id = 7, Nome = "Tati Model 07" },
            new Modelo { Id = 8, Nome = "Tati Model 08" },
            new Modelo { Id = 9, Nome = "Tati Model 09" },
            new Modelo { Id = 10, Nome = "Tati Model 10" }
        );

        builder.Entity<ModeloRecursoTipo>().HasData(
            new ModeloRecursoTipo { Id = (int)Areas.Cadastro.Enums.TipoRecursoModelo.Material, Nome = "Material" },
            new ModeloRecursoTipo { Id = (int)Areas.Cadastro.Enums.TipoRecursoModelo.Transporte, Nome = "Transporte" },
            new ModeloRecursoTipo { Id = (int)Areas.Cadastro.Enums.TipoRecursoModelo.Humano, Nome = "Humano" }
        );

        builder.Entity<ModeloRecursoTipoDescricao>().HasData(
            new ModeloRecursoTipoDescricao { Id = 1, TipoId = (int)Areas.Cadastro.Enums.TipoRecursoModelo.Transporte, Texto = "Lorem ipsum urna elit aptent euismod vulputate tristique, etiam eget arcu class tempus eu id class, tristique senectus commodo aenean consequat velit. ornare nisi class torquent nunc elementum nostra elementum condimentum sapien convallis, orci aptent maecenas sed mauris pretium diam nulla quisque, metus sem integer ornare aliquam vitae taciti dictumst eros. enim sit curabitur eleifend etiam aenean quisque in quis interdum nulla dolor porta consequat etiam vehicula maecenas platea placerat vitae, bibendum nunc aenean tempor nulla ultrices nec sem sociosqu dictum iaculis aliquam vulputate pellentesque dapibus per elit. amet eu suspendisse condimentum a porttitor nulla quam proin, curabitur feugiat semper eros placerat iaculis proin, maecenas senectus quisque phasellus luctus convallis rutrum." }
        );

        builder.Entity<ModeloRecurso>().HasData(
            new ModeloRecurso { Id = 1, ModeloId = 1, TipoId = (int)Areas.Cadastro.Enums.TipoRecursoModelo.Material, Descricao = "Tecido", Custo = 20, Unidades = 2 },
            new ModeloRecurso { Id = 2, ModeloId = 1, TipoId = (int)Areas.Cadastro.Enums.TipoRecursoModelo.Material, Descricao = "Linha", Custo = 4, Unidades = 20 },
            new ModeloRecurso { Id = 3, ModeloId = 1, TipoId = (int)Areas.Cadastro.Enums.TipoRecursoModelo.Material, Descricao = "Outros", Custo = 5, Unidades = 1 },
            new ModeloRecurso { Id = 4, ModeloId = 1, TipoId = (int)Areas.Cadastro.Enums.TipoRecursoModelo.Transporte, Descricao = "Transporte", Custo = 100, Unidades = 50 },
            new ModeloRecurso { Id = 5, ModeloId = 1, TipoId = (int)Areas.Cadastro.Enums.TipoRecursoModelo.Humano, Descricao = "Costureira", Custo = 5, Unidades = 1 }
        );

        builder.Entity<ModeloRecursoObservacao>().HasData(
            new ModeloRecursoObservacao { Id = 1, RecursoId = 3, Texto = "Sit lorem torquent sociosqu molestie litora mauris commodo, inceptos vel dui fames tellus pulvinar curabitur luctus, faucibus integer augue pretium neque justo. senectus elementum pulvinar justo cubilia vivamus laoreet enim per, habitant ullamcorper condimentum elementum ultrices erat pretium neque ornare, proin quisque ultricies libero vulputate aliquet sollicitudin. accumsan porttitor aliquam conubia nec netus sapien euismod nam laoreet sociosqu, quisque semper nullam nostra euismod odio amet accumsan pellentesque, aenean elit convallis sodales elementum tristique dictumst vulputate mi. torquent aliquam augue condimentum pulvinar fames platea suscipit donec, conubia sodales ad viverra nam euismod vivamus bibendum, fermentum at rutrum semper augue egestas tortor." }
        );

        builder.Entity<ModeloRecursoAnexo>().HasData(
            new ModeloRecursoAnexo { Id = 1, RecursoId = 2, Nome = "Arquivo 1", Arquivo = new byte[] { } },
            new ModeloRecursoAnexo { Id = 2, RecursoId = 2, Nome = "Arquivo 2", Arquivo = new byte[] { } },
            new ModeloRecursoAnexo { Id = 3, RecursoId = 3, Nome = "Arquivo 1", Arquivo = new byte[] { } }
        );
    }
}
