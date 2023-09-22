using apiweb.event_.Domains;

namespace apiweb.event_.Interfaces
{
    public interface ITiposEventoRepository
    {
        void Cadastrar(TiposEvento tipoEvento);
        void Deletar(Guid id);
        List<TiposEvento> Listar();
        TiposEvento BuscarPorId(Guid id);
        void Atualizar(Guid id, TiposEvento tipoEvento);
    }
}
