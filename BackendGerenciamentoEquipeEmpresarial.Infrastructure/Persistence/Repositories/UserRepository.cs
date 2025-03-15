
using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces;

namespace BackendGerenciamentoEquipeEmpresarial.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly BackendGerenciamentoEquipeEmpresarialContext _context;
        public UserRepository(BackendGerenciamentoEquipeEmpresarialContext context)
        {
            _context = context;
        }

        public async Task<User> Save(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}
