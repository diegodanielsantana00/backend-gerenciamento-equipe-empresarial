using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;

namespace BackendGerenciamentoEquipeEmpresarial.Application.Interfaces
{
    public interface IStatusTaskService
    {
        Task<StatusTask> Create(StatusTask task);
        Task<StatusTask> Update(StatusTask task);
        Task<IEnumerable<StatusTask>> GetAllStatusByProject(int idProject);
    }
}
