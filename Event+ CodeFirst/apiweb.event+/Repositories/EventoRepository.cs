using apiweb.event_.Contexts;
using apiweb.event_.Domains;
using apiweb.event_.Interfaces;

namespace apiweb.event_.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Evento evento)
        {
            throw new NotImplementedException();
        }

        public Evento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Evento evento)
        {
            _eventContext.Evento.Add(evento);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Evento> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
