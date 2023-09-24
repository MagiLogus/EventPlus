using apiweb.event_.Domains;
using apiweb.event_.Interfaces;
using apiweb.event_.Repositories;
using apiweb.event_.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace apiweb.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email, usuario.Senha);
                if (usuarioBuscado != null)
                {
                    return NotFound("Email ou senha inválidos!");
                }

                //Caso encontre o usuario, prossegue para criação do token

                var claims = new[]
                {
                        new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                        new Claim("IdTiposUsuario",usuarioBuscado.IdTipoUsuario.ToString()),
                        new Claim(JwtRegisteredClaimNames.Name,usuarioBuscado.Nome),
                        new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
                        new Claim(ClaimTypes.Role,usuarioBuscado.TiposUsuario.Titulo)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("apiweb-event+"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
              (
                  //emissor do token (ver em program)
                  issuer: "apiweb.event+",

                  //Destinatario do token
                  audience: "apiweb.event+",

                  //Dados definidos nas claims(informações)
                  claims: claims,

                  //tempo de expiração
                  expires: DateTime.Now.AddMinutes(10),

                  //credenciais token
                  signingCredentials: creds
              );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }

}

