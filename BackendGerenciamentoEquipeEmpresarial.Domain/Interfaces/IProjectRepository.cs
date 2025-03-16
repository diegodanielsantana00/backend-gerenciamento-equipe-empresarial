using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;

namespace BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> Save(Project project);
        Task<Project> Update(Project project);
        Task<Project> GetProjectById(int id);
        Task<IEnumerable<Project>> GetAllByIdUser(int idUser);
        Task<UserProject> AddUserInProject(User user, Project project, GroupPermission groupPermission);

    }
}
