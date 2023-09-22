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
    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository;
        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        [HttpPost]
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

    }
}
