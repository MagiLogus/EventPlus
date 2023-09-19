using apiweb.event_.Domains;

namespace apiweb.event_.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        Usuario BuscarPorId(Guid Id);
        Usuario BuscarPorEmailESenha(string email, string senha);
    }
}
