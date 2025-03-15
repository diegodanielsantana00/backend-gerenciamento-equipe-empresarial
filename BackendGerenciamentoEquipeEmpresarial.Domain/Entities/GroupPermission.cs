
namespace BackendGerenciamentoEquipeEmpresarial.Domain.Entities
{
    public class GroupPermission
    {
        public virtual int Id { get; set; }
        public virtual required string Name { get; set; }
        public virtual required bool TaskPermissionEdit { get; set; }
        public virtual required bool TaskPermissionDelete { get; set; }
        public virtual required bool TaskPermissionInsert { get; set; }

    }
}
