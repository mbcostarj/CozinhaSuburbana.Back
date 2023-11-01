using Microsoft.Extensions.Configuration;

namespace CozinhaSuburbana.Domain.Extension;

public static class RepositorioExtension
{
    public static string GetConnectionString(this IConfiguration configurationManager)
    {
        var conexao = configurationManager.GetConnectionString("Conexao");
        return conexao;
    }
    public static string GetNomeDatabase(this IConfiguration configurationManager) {
        var nome = configurationManager.GetConnectionString("nomeDatabase");
        return nome;
    }
}
