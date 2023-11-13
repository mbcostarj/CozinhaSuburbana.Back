using CozinhaSuburbana.Comunicacao.Request;

namespace CozinhaSuburbana.Application.UseCase.Usuario.Registrar;

internal class RegistrarUsuarioUseCase
{
    public Task Executar(RequestResgistrarUsuarioJson request) { }

    private void Validar(RequestResgistrarUsuarioJson request) {
        var validator = new RegistrarUsuarioValidator();
        var resultado = validator.Validate(request);
        
        if (!resultado.IsValid) {
            var mensagensDeErro = resultado.Errors.Select(err => err.ErrorMessage);    
        }
    }
}
