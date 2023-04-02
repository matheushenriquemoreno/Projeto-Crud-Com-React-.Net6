using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoginAPI.DTO;
using LoginAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IAutentificacao _autentificacao;

        public LoginController(IAutentificacao autentificacao, IConfiguration configuration)
        {
            _autentificacao = autentificacao;
            _configuration = configuration;
        }

        [HttpPost("CriarUsuario")]
        public async Task<ActionResult> CriarUsuario([FromBody] RegisterDTO model)
        {

            if (model.Senha != model.ComfirmarSenha)
            {
                ModelState.AddModelError("ConfirmarSenha", "As senhas não conferem");
                return BadRequest(ModelState);
            }

            var result = await _autentificacao.CriarUsuario(model.Email, model.Senha);

            if (result)
            {
                return Ok();
            }

            ModelState.AddModelError("CriacaoUsuario", "Erro ao criar usuario");
            return BadRequest();
        }

        [HttpPost("LogarUsuario")]
        public async Task<ActionResult<TokenUsuario>> LogarUsuario([FromBody] LoginDTO model)
        {
            try
            {
                var result = await _autentificacao.Atentificar(model.Email, model.Senha);

                if (result)
                {
                    return CriarToken(model);
                }

                ModelState.AddModelError("CriacaoUsuario", "Erro ao criar usuario");
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet("Usuarios")]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> BuscarUsuarios()
        {
            var user = await _autentificacao.UsuariosCadastrados();

            return Ok(user);
        }

        private ActionResult<TokenUsuario> CriarToken(LoginDTO model)
        {
            var claims = new[]
            {
                new Claim("Email", model.Email),
                new Claim("Id", "AquiVaiUmID"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var expiracao = DateTime.Now.AddMinutes(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiracao,
                signingCredentials: credencial);

            return new TokenUsuario()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracao = expiracao
            };

        }
    }
}
