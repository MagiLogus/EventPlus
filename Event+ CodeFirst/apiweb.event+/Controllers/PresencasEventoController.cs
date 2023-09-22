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
    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presencasEventoRepository;
        public PresencasEventoController()
        {
            _presencasEventoRepository = new PresencasEventoRepository();
        }

        [HttpPost]
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
    }
}
