using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendGerenciamentoEquipeEmpresarial.Infrastructure.Persistence.Repositories
{
    public class StatusTaskRepository : IStatusTaskRepository
    {
        private readonly BackendGerenciamentoEquipeEmpresarialContext _context;
        public StatusTaskRepository(BackendGerenciamentoEquipeEmpresarialContext context)
        {
            _context = context;
        }

        public async Task<StatusTask> Create(StatusTask task)
        {
            await _context.StatusTasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<StatusTask> Update(StatusTask task)
        {
            _context.StatusTasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<StatusTask> GetById(int id)
        {
            var user = await _context.StatusTasks.FirstOrDefaultAsync(p => p.Id == id);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public async Task<IEnumerable<StatusTask>> GetAllStatusByProject(int idProject)
        {
            var user = await _context.StatusTasks.Include(x=> x.Project).Where(p => p.Project.Id == idProject).ToListAsync();
            return user;
        }

        

    }
}
