using apiweb.event_.Contexts;
using apiweb.event_.Domains;
using apiweb.event_.Interfaces;

namespace apiweb.event_.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Cadastrar(Instituicao instituicao)
        {
            _eventContext.Instituicao.Add(instituicao);
            _eventContext.SaveChanges();
        }
    }
}
