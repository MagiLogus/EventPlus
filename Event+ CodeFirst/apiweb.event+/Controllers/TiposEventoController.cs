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
    public class TiposEventoController : ControllerBase
    {
        private ITiposEventoRepository _tiposEventoRepository;
        public TiposEventoController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(TiposEvento tipoevento)
        {
            try
            {
                _tiposEventoRepository.Cadastrar(tipoevento);
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
                _tiposEventoRepository.Deletar(id);
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
                return Ok(_tiposEventoRepository.Listar());
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
                return Ok(_tiposEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, TiposEvento tipoEvento)
        {
            try
            {
                _tiposEventoRepository.Atualizar(id, tipoEvento);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }


}
