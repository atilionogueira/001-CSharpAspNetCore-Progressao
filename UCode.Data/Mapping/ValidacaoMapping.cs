using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UCode.Business.Models;

namespace UCode.Data.Mapping
{
    public class ValidacaoMapping : IEntityTypeConfiguration<Validacao>
    {
        public void Configure(EntityTypeBuilder<Validacao> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.ValidadoEm)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(v => v.Quantidade)
                .IsRequired()
                .HasPrecision(5, 2);

            builder.Property(v => v.Justificativa)
                .HasColumnType("varchar(255)");           
            
            
            builder.HasOne(v => v.Comprovante)
                  .WithOne(c => c.Validacao)
                  .HasForeignKey<Validacao>(c => c.ComprovanteId);
            

            builder.ToTable("Validacaos");
        }
    }

}
