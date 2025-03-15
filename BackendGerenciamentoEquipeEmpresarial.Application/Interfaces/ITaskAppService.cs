using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;

namespace BackendGerenciamentoEquipeEmpresarial.Application.Interfaces
{
    public interface ITaskAppService
    {
        Task<TaskApp> Create(TaskApp task);
        Task<TaskApp> Update(TaskApp task);
        Task<bool> UpdateStatus(int idTask, int idStatus);
    }
}
