using FluentMigrator.Builders.Create.Table;

namespace CozinhaSuburbana.Infrastructure.Migrations
{
    public static class VersaoBase
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax InserirColunasPadrao(ICreateTableWithColumnOrSchemaOrDescriptionSyntax tabela) {
            return tabela.WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString(100).NotNullable();
        }
    }
}
