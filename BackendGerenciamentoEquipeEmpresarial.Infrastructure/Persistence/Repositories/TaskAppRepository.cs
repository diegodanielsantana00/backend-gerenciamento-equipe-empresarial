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

    }
}
