
using CozinhaSuburbana.Domain.Entidades;

namespace CozinhaSuburbana.Domain.Repositorios;

public interface IUsuarioWriteOnlyRepositorio
{
    Task Adicionar(Usuario usuario);
}
