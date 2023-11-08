using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using CozinhaSuburbana.Domain.Extension;

namespace CozinhaSuburbana.Infrastructure;

public static class Bootstrapper
{
    public static void AdicionarRepositorio(this IServiceCollection service, IConfiguration configurationManager)
    {
        AdicionarFluentMigrator(service, configurationManager);
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
