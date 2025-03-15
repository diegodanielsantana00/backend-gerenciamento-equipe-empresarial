using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;

namespace BackendGerenciamentoEquipeEmpresarial.Application.Interfaces
{
    public interface IAuthServices
    {
        Task<User> Register(User user);
        Task<User> Login(string email, string password);
        Task<bool> IsRegisterWithEmail(string email);
        

    }
}
