using apiweb.event_.Contexts;
using apiweb.event_.Domains;
using apiweb.event_.Interfaces;

namespace apiweb.event_.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        private readonly EventContext _eventContext;

        public TiposEventoRepository() 
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, TiposEvento tipoEvento)
        {
            throw new NotImplementedException();
        }

        public TiposEvento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TiposEvento tipoEvento)
        {
            _eventContext.TiposEvento.Add(tipoEvento);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TiposEvento> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
