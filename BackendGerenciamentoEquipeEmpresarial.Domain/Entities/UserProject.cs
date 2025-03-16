
namespace BackendGerenciamentoEquipeEmpresarial.Domain.Entities
{
    public class UserProject
    {
       
        public virtual int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
        public virtual GroupPermission GroupPermission { get; set; }

    }
}
