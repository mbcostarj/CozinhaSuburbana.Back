using CozinhaSuburbana.Domain.Entidades;
using CozinhaSuburbana.Domain.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace CozinhaSuburbana.Infrastructure.AcessoRepositorio.Repositorio;

internal class UsuarioRepositorio : IUsuarioReadOnlyRepositorio, IUsuarioWriteOnlyRepositorio
{

    private readonly CozinhaSuburbanaContext _contexto;

    public UsuarioRepositorio(CozinhaSuburbanaContext contexto) {
        _contexto = contexto;
    }

    public async Task Adicionar(Usuario usuario)
    {
        await _contexto.Usuarios.AddAsync(usuario);
    }

    public async Task<bool> ExisteUsuarioComEmail(string email)
    {
        return await _contexto.Usuarios.AnyAsync(e => e.Equals(email));
    }
}
