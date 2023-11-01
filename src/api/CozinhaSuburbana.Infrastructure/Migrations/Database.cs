using Dapper;
using Microsoft.Data.SqlClient;

namespace CozinhaSuburbana.Infrastructure.Migrations;

public static class Database
{

    public static void CriarDatabase(string conexao, string nomeDatabase)
    {
        using var minhaConexao = new SqlConnection(conexao);

        var parametros = new DynamicParameters(minhaConexao);
        parametros.Add("nome", nomeDatabase);

        var registros = minhaConexao.Query("SELECT * FROM sys.databases WHERE name = @nome", parametros);

        if (!registros.Any())
        {
            minhaConexao.Execute($"CREATE DATABASE {nomeDatabase}");
        }

    }

}
