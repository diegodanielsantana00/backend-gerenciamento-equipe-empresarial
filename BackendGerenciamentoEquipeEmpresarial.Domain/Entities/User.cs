

using BCrypt.Net;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendGerenciamentoEquipeEmpresarial.Domain.Entities
{

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; private set; }

        public void SetPassword(string password)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
    }

}
