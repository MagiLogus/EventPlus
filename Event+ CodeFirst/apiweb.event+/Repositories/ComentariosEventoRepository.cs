using apiweb.event_.Contexts;
using apiweb.event_.Domains;
using apiweb.event_.Interfaces;

namespace apiweb.event_.Repositories
{
    public class ComentariosEventoRepository : IComentariosEventoRepository
    {
        private readonly EventContext _eventContext;

        public ComentariosEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public ComentariosEvento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ComentariosEvento comentarioEvento)
        {
            _eventContext.ComentariosEvento.Add(comentarioEvento);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ComentariosEvento> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
