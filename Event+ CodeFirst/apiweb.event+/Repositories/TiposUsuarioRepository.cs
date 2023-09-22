using apiweb.event_.Contexts;
using apiweb.event_.Domains;
using apiweb.event_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apiweb.event_.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TiposUsuarioRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, TiposUsuario tipoUsuario)
        {
            TiposUsuario tipoUsuarioBuscado = _eventContext.TiposUsuario.Find(id)!;
            if (tipoUsuarioBuscado != null)
            {
                tipoUsuarioBuscado!.Titulo = tipoUsuario.Titulo;
            }
            _eventContext.TiposUsuario.Update(tipoUsuarioBuscado);
            _eventContext.SaveChanges();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            return _eventContext.TiposUsuario.FirstOrDefault(e => e.IdTipoUsuario == id)!;
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            _eventContext.TiposUsuario.Add(tipoUsuario);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _eventContext.TiposUsuario.Where(e => e.IdTipoUsuario == id).ExecuteDelete();
            _eventContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return _eventContext.TiposUsuario.ToList();
        }
    }
}
