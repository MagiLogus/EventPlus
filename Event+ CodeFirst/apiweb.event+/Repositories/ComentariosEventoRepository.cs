using apiweb.event_.Contexts;
using apiweb.event_.Domains;
using apiweb.event_.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return _eventContext.ComentariosEvento.FirstOrDefault(e => e.IdComentarioEvento == id)!;
        }

        public void Cadastrar(ComentariosEvento comentarioEvento)
        {
            _eventContext.ComentariosEvento.Add(comentarioEvento);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _eventContext.ComentariosEvento.Where(e => e.IdComentarioEvento == id).ExecuteDelete();
            _eventContext.SaveChanges();
        }

        public List<ComentariosEvento> Listar()
        {
            return _eventContext.ComentariosEvento.ToList();
        }
    }
}
