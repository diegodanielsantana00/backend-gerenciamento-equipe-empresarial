using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;

namespace BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces
{
    public interface IGroupPermissionRepository
    {
        Task<GroupPermission> GetById(int id);
        
    }
}
