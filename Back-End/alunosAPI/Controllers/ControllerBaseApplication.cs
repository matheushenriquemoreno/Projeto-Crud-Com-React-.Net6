using System.Security.Claims;
using alunosAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace alunosAPI.Controllers
{
    public abstract class ControllerBaseApplication : ControllerBase
    {
        protected USerAtual User()
        {
            var claims = HttpContext?.User.Claims;

            var user = new USerAtual
            {
                Email = claims.FirstOrDefault(c => c.Type == "Email")?.Value,
                Id = claims.FirstOrDefault(c => c.Type == "Id")?.Value
            };

            return user;
        }

    }
}
