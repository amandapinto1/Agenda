using Agenda.Model;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data
{
    public class ContatoContexto : DbContext
    {
        public DbSet<Contato> Contato { get; set; }

        public ContatoContexto(DbContextOptions<ContatoContexto> options) : base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(x => Console.WriteLine(x))
                .EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContatoContexto).Assembly);
        }
    }
}
