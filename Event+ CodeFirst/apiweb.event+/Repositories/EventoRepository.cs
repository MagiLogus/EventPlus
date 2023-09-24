using apiweb.event_.Contexts;
using apiweb.event_.Domains;
using apiweb.event_.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            Evento eventoBuscado = _eventContext.Evento.Find(id)!;
            if (eventoBuscado != null)
            {
                eventoBuscado!.DataEvento = evento.DataEvento;
                eventoBuscado!.NomeEvento = evento.NomeEvento;
                eventoBuscado!.Descricao = evento.Descricao;
                eventoBuscado!.IdTipoEvento = evento.IdTipoEvento;  
                eventoBuscado!.IdInstituicao = evento.IdInstituicao;
            }
            _eventContext.Evento.Update(eventoBuscado);
            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            return _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;
        }

        public void Cadastrar(Evento evento)
        {
            _eventContext.Evento.Add(evento);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _eventContext.Evento.Where(e => e.IdEvento == id).ExecuteDelete();
            _eventContext.SaveChanges();
        }

        public List<Evento> Listar()
        {
            return _eventContext.Evento.ToList();
        }
    }
}
