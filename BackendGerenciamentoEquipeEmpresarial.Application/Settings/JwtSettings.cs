using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendGerenciamentoEquipeEmpresarial.Application.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; } = string.Empty;
        public int ExpirationInMinutes { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }
}
