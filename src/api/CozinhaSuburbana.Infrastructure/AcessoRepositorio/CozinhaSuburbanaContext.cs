using CozinhaSuburbana.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CozinhaSuburbana.Infrastructure.AcessoRepositorio;

public class CozinhaSuburbanaContext : DbContext
{
    public CozinhaSuburbanaContext(DbContextOptions<CozinhaSuburbanaContext> options) : base(options) 
    { }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CozinhaSuburbanaContext).Assembly);
    }

}
