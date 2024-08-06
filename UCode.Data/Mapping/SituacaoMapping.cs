using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UCode.Business.Models;

namespace UCode.Data.Mapping
{
    public class SituacaoMapping : IEntityTypeConfiguration<Situacao>
    {
        public void Configure(EntityTypeBuilder<Situacao> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.MovimentadoEm)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(s => s.Detalhes)
                .HasColumnType("varchar(255)");

            builder.HasOne(s => s.Status)
            .WithMany(c => c.Situacaos)
            .HasForeignKey(a => a.StatusId);

                

            builder.ToTable("Situacaos");
            
        }
    }

}
