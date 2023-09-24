using apiweb.event_.Domains;
using Microsoft.EntityFrameworkCore;

namespace apiweb.event_.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<ComentariosEvento> ComentariosEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencasEvento> PresencasEvento { get; set; }
        public DbSet<TiposEvento> TiposEvento { get; set; }
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-N33B0CD\\SQLEXPRESS; initial catalog=Event+; user Id=sa; pwd=sa@134; TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
