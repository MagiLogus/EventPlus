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
    public class TiposEventoController : ControllerBase
    {
        private ITiposEventoRepository _tiposEventoRepository;
        public TiposEventoController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }

        [HttpPost]
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























    }
}
