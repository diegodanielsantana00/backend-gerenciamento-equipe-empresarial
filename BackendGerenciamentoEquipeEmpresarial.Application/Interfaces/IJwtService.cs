using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BackendGerenciamentoEquipeEmpresarial.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string role);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
