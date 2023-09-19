using apiweb.event_.Domains;

namespace apiweb.event_.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuario tipoUsuario);
        void Deletar(Guid Id);
        List<TiposUsuario> Listar();
        TiposUsuario BuscarPorId(Guid Id);
        void Atualizar(Guid Id, TiposUsuario tipoUsuario);
    }
}
