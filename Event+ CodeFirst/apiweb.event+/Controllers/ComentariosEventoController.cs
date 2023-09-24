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
    public class ComentariosEventoController : ControllerBase
    {
        private IComentariosEventoRepository _comentariosEventoRepository;
        public ComentariosEventoController()
        {
            _comentariosEventoRepository = new ComentariosEventoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Aluno")]
        public IActionResult Post(ComentariosEvento comentarioevento)
        {
            try
            {
                _comentariosEventoRepository.Cadastrar(comentarioevento);
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
                _comentariosEventoRepository.Deletar(id);
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
                return Ok(_comentariosEventoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_comentariosEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}
