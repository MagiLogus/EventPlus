using apiweb.event_.Contexts;
using apiweb.event_.Domains;
using apiweb.event_.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            TiposEvento tipoEventoBuscado = _eventContext.TiposEvento.Find(id)!;
            if (tipoEventoBuscado != null)
            {
                tipoEventoBuscado!.Titulo = tipoEvento.Titulo;
            }
            _eventContext.TiposEvento.Update(tipoEventoBuscado);
            _eventContext.SaveChanges();
        }

        public TiposEvento BuscarPorId(Guid id)
        {
            return _eventContext.TiposEvento.FirstOrDefault(e => e.IdTipoEvento == id)!;
        }

        public void Cadastrar(TiposEvento tipoEvento)
        {
            _eventContext.TiposEvento.Add(tipoEvento);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _eventContext.TiposEvento.Where(e => e.IdTipoEvento == id).ExecuteDelete();
            _eventContext.SaveChanges();
        }

        public List<TiposEvento> Listar()
        {
            return _eventContext.TiposEvento.ToList();
        }
    }
}
