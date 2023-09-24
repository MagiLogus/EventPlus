using apiweb.event_.Contexts;
using apiweb.event_.Domains;
using apiweb.event_.Interfaces;
using apiweb.event_.Utils;

namespace apiweb.event_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository() //CTOR cria o metodo construtor
        {
            _eventContext = new EventContext();
        }
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TiposUsuario
                        {
                         IdTipoUsuario = u.IdTipoUsuario,
                         Titulo = u.TipoUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TiposUsuario
                        {
                            Titulo = u.TipoUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);
                _eventContext.Usuario.Add(usuario);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

