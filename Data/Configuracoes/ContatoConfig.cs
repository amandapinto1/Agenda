using Agenda.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Data.Configuracoes
{
    public class ContatoConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Agenda");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).IsUnicode(false).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Email).IsUnicode(false).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();

        }
    }
}
