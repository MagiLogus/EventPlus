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
    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository;
        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
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
                return Ok(_eventoRepository.Listar());
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
                return Ok(_eventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, Evento evento)
        {
            try
            {
                _eventoRepository.Atualizar(id, evento);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}
