using apiweb.event_.Domains;

namespace apiweb.event_.Interfaces
{
    public interface IComentariosEventoRepository
    {
        void Cadastrar(ComentariosEvento comentarioEvento);
        void Deletar(Guid id);
        List<ComentariosEvento> Listar();
        ComentariosEvento BuscarPorId(Guid id);
    }
}
