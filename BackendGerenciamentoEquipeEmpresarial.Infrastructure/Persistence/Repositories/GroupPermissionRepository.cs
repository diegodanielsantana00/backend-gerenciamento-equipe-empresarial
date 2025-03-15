using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendGerenciamentoEquipeEmpresarial.Infrastructure.Persistence.Repositories
{
    public class GroupPermissionRepository : IGroupPermissionRepository
    {
        private readonly BackendGerenciamentoEquipeEmpresarialContext _context;
        public GroupPermissionRepository(BackendGerenciamentoEquipeEmpresarialContext context)
        {
            _context = context;
        }

        public async Task<GroupPermission> GetById(int id)
        {
            var groupPermission = await _context.GroupPermissions.FirstOrDefaultAsync(p => p.Id == id);

            if (groupPermission != null)
            {
                return groupPermission;
            }

            return null;
        }
    }
}
