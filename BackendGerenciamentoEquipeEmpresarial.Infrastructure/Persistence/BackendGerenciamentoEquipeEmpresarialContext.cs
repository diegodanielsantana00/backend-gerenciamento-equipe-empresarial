


using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendGerenciamentoEquipeEmpresarial.Infrastructure.Persistence
{
    public class BackendGerenciamentoEquipeEmpresarialContext : DbContext
    {
        public BackendGerenciamentoEquipeEmpresarialContext() { }
        public BackendGerenciamentoEquipeEmpresarialContext(DbContextOptions<BackendGerenciamentoEquipeEmpresarialContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
    }
}
