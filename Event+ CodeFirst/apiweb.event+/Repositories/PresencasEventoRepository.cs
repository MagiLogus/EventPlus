using apiweb.event_.Contexts;
using apiweb.event_.Domains;
using apiweb.event_.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            PresencasEvento presencaEventoBuscado = _eventContext.PresencasEvento.Find(id)!;
            if (presencaEventoBuscado != null)
            {
                presencaEventoBuscado!.Situacao = presencaEvento.Situacao;
            }
            _eventContext.PresencasEvento.Update(presencaEventoBuscado);
            _eventContext.SaveChanges();
        }

        public void Cadastrar(PresencasEvento presencaEvento)
        {
            _eventContext.PresencasEvento.Add(presencaEvento);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _eventContext.PresencasEvento.Where(e => e.IdPresencaEvento == id).ExecuteDelete();
            _eventContext.SaveChanges();
        }

        public List<PresencasEvento> Listar()
        {
            return _eventContext.PresencasEvento.ToList();
        }

        public List<PresencasEvento> ListarMinhas(Guid id)
        {
            try
            {
                return _eventContext.PresencasEvento.Where(e => e.IdUsuario == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
