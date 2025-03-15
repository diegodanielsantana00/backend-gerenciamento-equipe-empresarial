


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
            modelBuilder.Entity<GroupPermission>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<GroupPermission>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<GroupPermission>().HasData(
            new GroupPermission
            {
                Id = 1,
                Name = "Admin",
                IsAdmin = true,
                TaskPermissionEdit = true,
                TaskPermissionDelete = true,
                TaskPermissionInsert = true
            },
            new GroupPermission
            {
                Id = 2,
                Name = "Membro",
                IsAdmin = false,
                TaskPermissionEdit = true,
                TaskPermissionDelete = true,
                TaskPermissionInsert = true
            }
        );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<StatusTask> StatusTasks { get; set; }
        public DbSet<TaskApp> TaskApps { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
    }
}
