using FluentMigrator;

namespace CozinhaSuburbana.Infrastructure.Migrations.Versions;

[Migration((long)NumeroVersoes.CriarTabelaUsuario, "Cria tabela usuario")]
public class AdicionaUsuario : Migration
{
    public override void Down()
    {
        throw new NotImplementedException();
    }

    public override void Up()
    {
        var tabela = VersaoBase.InserirColunasPadrao(Create.Table("Usuario"));

        tabela
            .WithColumn("Nome").AsString(100).NotNullable()
            .WithColumn("Email").AsString(300).NotNullable()
            .WithColumn("Telefone").AsString(14).NotNullable()
            .WithColumn("Senha").AsString(2000).NotNullable();
    }
}
