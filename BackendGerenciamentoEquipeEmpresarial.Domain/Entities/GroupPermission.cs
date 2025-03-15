
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendGerenciamentoEquipeEmpresarial.Domain.Entities
{
    public class GroupPermission
    {
       
        public virtual int Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual bool IsAdmin { get; set; }
        public virtual bool TaskPermissionEdit { get; set; }
        public virtual bool TaskPermissionDelete { get; set; }
        public virtual bool TaskPermissionInsert { get; set; }

    }
}
