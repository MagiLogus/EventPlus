using apiweb.event_.Contexts;
using apiweb.event_.Domains;
using apiweb.event_.Interfaces;

namespace apiweb.event_.Repositories
{
    public class PresencasEventoRepository : IPresencasEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencasEventoRepository() 
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, PresencasEvento presencaEvento)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(PresencasEvento presencaEvento)
        {
            _eventContext.PresencasEvento.Add(presencaEvento);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<PresencasEvento> Listar()
        {
            throw new NotImplementedException();
        }

        public List<PresencasEvento> ListarMinhas(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
