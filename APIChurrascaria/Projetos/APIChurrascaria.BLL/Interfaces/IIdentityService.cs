using APIChurrascaria.DTO.Request;
using APIChurrascaria.DTO.Response;

namespace APIChurrascaria.BLL.Interfaces
{
    public interface IIdentityService
    {
        Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usuarioCadastro);
        Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLogin);

    }
}
