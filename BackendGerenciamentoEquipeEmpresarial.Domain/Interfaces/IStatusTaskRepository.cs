using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;

namespace BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces
{
    public interface IStatusTaskRepository
    {
        Task<StatusTask> Create(StatusTask task);
        Task<StatusTask> Update(StatusTask task);
        Task<StatusTask> GetById(int id);
        
    }
}
