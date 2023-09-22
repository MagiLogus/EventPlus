using apiweb.event_.Domains;
using apiweb.event_.Interfaces;
using apiweb.event_.Repositories;
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

    }
}
