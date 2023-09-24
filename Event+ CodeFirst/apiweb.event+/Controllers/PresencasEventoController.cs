using apiweb.event_.Domains;
using apiweb.event_.Interfaces;
using apiweb.event_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presencasEventoRepository;
        public PresencasEventoController()
        {
            _presencasEventoRepository = new PresencasEventoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador, Aluno")]
        public IActionResult Post(PresencasEvento presencaEvento)
        {
            try
            {
                _presencasEventoRepository.Cadastrar(presencaEvento);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador, Aluno")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencasEventoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador, Aluno")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencasEventoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/ListarMinhas")]
        [Authorize(Roles = "Administrador, Aluno")]
        public IActionResult GetMy(Guid id)
        {
            try
            {
                return Ok(_presencasEventoRepository.ListarMinhas(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador, Aluno")]
        public IActionResult Put(Guid id, PresencasEvento presencaEvento)
        {
            try
            {
                _presencasEventoRepository.Atualizar(id, presencaEvento);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}
