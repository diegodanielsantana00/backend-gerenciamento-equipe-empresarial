using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;

namespace BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces
{
    public interface ITaskAppRepository
    {
        Task<TaskApp> Create(TaskApp task);
        Task<TaskApp> Update(TaskApp task);
        Task<TaskApp> GetById(int id);
        
    }
}
