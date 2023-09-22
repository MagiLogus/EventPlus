using apiweb.event_.Domains;

namespace apiweb.event_.Interfaces
{
    public interface IPresencasEventoRepository
    {
        void Cadastrar(PresencasEvento presencaEvento);
        void Deletar(Guid id);
        List<PresencasEvento> Listar();
        void Atualizar(Guid id, PresencasEvento presencaEvento);
        List<PresencasEvento> ListarMinhas(Guid id);
    }
}
