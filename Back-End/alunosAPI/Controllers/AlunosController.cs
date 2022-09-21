using alunosAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alunosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {

        private readonly IServicoAluno servicoAluno;

        public AlunosController(IServicoAluno servicoAluno)
        {
            this.servicoAluno = servicoAluno;
        }






    }
}
