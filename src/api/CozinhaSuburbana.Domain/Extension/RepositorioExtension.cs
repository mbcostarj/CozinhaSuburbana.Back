using Microsoft.Extensions.Configuration;

namespace CozinhaSuburbana.Domain.Extension;

public static class RepositorioExtension
{

    public static string GetConnection(this IConfiguration configurationManager)
    {
        var conexao = configurationManager.GetConnectionString("Conexao");
        return conexao;
    }

    public static string GetNomeDatabase(this IConfiguration configurationManager) {
        var nome = configurationManager.GetConnectionString("nomeDatabase");
        return nome;
    }

    public static string GetFullConnection(this IConfiguration configurationManager) {
        var nomeDatabase = configurationManager.GetNomeDatabase();
        var conexao = configurationManager.GetConnection();
        return $"{conexao}Database={nomeDatabase}";
    }

}
