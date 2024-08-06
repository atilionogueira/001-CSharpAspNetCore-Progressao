using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UCode.Business.Models;

namespace UCode.Data.Mapping
{
    public class ProgressaoMapping : IEntityTypeConfiguration<Progressao>
    {
        public void Configure(EntityTypeBuilder<Progressao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataInicial)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.DataFinal)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.Observacao)
                .HasColumnType("varchar(255)");                       

            builder.HasOne(p=>p.Classe)
              .WithMany(c => c.Progressaos)
              .HasForeignKey(p => p.ClasseId);

            builder.ToTable("Progressaos");
        }
    }

}
