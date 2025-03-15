
using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users.Include(x=> x.GroupPermission).FirstOrDefaultAsync(p => p.Email == email);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public async Task<User> GetByEmailAndPassword(string email,string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(p => p.Email == email && p.Password == password);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);

            if (user != null)
            {
                return user;
            }

            return null;
        }
        



    }
}
