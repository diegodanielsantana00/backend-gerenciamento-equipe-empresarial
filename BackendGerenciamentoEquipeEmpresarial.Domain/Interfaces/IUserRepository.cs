using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;

namespace BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Save(User User);
        Task<User> GetByEmail(string email);
        Task<User> GetById(int id);
        Task<User> GetByEmailAndPassword(string email, string password);
        
    }
}
