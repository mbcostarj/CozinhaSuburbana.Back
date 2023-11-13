using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using CozinhaSuburbana.Domain.Extension;
using CozinhaSuburbana.Domain.Repositorios;
using CozinhaSuburbana.Infrastructure.AcessoRepositorio.Repositorio;
using CozinhaSuburbana.Infrastructure.AcessoRepositorio;
using FluentMigrator.Runner.Initialization;
using Microsoft.EntityFrameworkCore;

namespace CozinhaSuburbana.Infrastructure;

public static class Bootstrapper
{
    public static void AdicionarRepositorio(this IServiceCollection service, IConfiguration configurationManager)
    {
        AdicionarFluentMigrator(service, configurationManager);
        
        AdicionarRepositorios(service);
        AdicionarUnidadeDeTrabalho(service);
        AdicionarContexto(service, configurationManager);
    }

    private static void AdicionarContexto(IServiceCollection service, IConfiguration configurationManager)
    {
        service.AddDbContext<CozinhaSuburbanaContext>(options => {
            options.UseSqlServer(configurationManager.GetFullConnection());
        });
    }

    private static void AdicionarUnidadeDeTrabalho(IServiceCollection service) {
        service.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
    }

    private static void AdicionarRepositorios(IServiceCollection service) {
        service.AddScoped<IUsuarioWriteOnlyRepositorio, UsuarioRepositorio>()
            .AddScoped<IUsuarioReadOnlyRepositorio, UsuarioRepositorio>();
    }

    private static void AdicionarFluentMigrator(IServiceCollection service, IConfiguration configurationManager)
    {
        service.AddFluentMigratorCore().ConfigureRunner(c => 
            c.AddSqlServer()
            .WithGlobalConnectionString(configurationManager.GetFullConnection())
            .ScanIn(Assembly.Load("CozinhaSuburbana.Infrastructure"))
            .For.All() 
            );
    }

}
