using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendGerenciamentoEquipeEmpresarial.Infrastructure.Persistence.Repositories
{
    public class TaskAppRepository : ITaskAppRepository
    {
        private readonly BackendGerenciamentoEquipeEmpresarialContext _context;
        public TaskAppRepository(BackendGerenciamentoEquipeEmpresarialContext context)
        {
            _context = context;
        }

        public async Task<TaskApp> Create(TaskApp task)
        {
            await _context.TaskApps.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskApp> Update(TaskApp task)
        {
            _context.TaskApps.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskApp> GetById(int id)
        {
            var user = await _context.TaskApps.FirstOrDefaultAsync(p => p.Id == id);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public async Task<List<TaskApp>> GetAllTask(int idProject, int page, int status, int orderBy)
        {
            int pageSize = 10;

            var query = _context.TaskApps.Include(x=> x.StatusTask).Include(x=> x.Project).Where(x=> x.Project.Id == idProject).AsQueryable();

            if (status != -1)
            {
                query = query.Where(t => t.StatusTask.Id == status);
            }

            query = orderBy switch
            {
                1 => query.OrderBy(t => t.Title),
                2 => query.OrderByDescending(t => t.PriorityTask),
                _ => query.OrderBy(t => t.Id)
            };

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }


    }
}
