
using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendGerenciamentoEquipeEmpresarial.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {

        private readonly BackendGerenciamentoEquipeEmpresarialContext _context;
        public ProjectRepository(BackendGerenciamentoEquipeEmpresarialContext context)
        {
            _context = context;
        }

        public async Task<Project> Save(Project user)
        {
            await _context.Projects.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Project> Update(Project user)
        {
            _context.Projects.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<Project>> GetAllByIdUser(int idUser)
        {
            var projectsList = await _context.UserProjects.Where(p => p.User.Id == idUser).Include(x=> x.Project).Include(x=> x.User).ToListAsync();
            return projectsList.Select(x=> x.Project);
        }

        public async Task<UserProject> AddUserInProject(User user, Project project, GroupPermission groupPermission)
        {
            UserProject userProject = new UserProject()
            {
                Project = project,
                User = user,
                GroupPermission = groupPermission
            };

            await _context.UserProjects.AddAsync(userProject);
            await _context.SaveChangesAsync();
            return userProject;
        }
    }
}
