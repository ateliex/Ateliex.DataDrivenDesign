using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ateliex.Areas.Cadastro.Models;

namespace Ateliex.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().ToTable("Roles", "identity");

        builder.Entity<IdentityUser>().ToTable("Users", "identity");

        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "identity");

        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "identity");

        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "identity");

        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "identity");

        builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "identity");
    }

    public DbSet<Ateliex.Areas.Cadastro.Models.Modelo> Modelo { get; set; }

    public DbSet<Ateliex.Areas.Cadastro.Models.ModeloRecurso> ModeloRecurso { get; set; }

    public DbSet<Ateliex.Areas.Cadastro.Models.ModeloRecursoTipo> ModeloRecursoTipo { get; set; }
}
