using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UCode.Business.Models;

namespace UCode.Data.Mapping
{
    public class ComprovanteMapping : IEntityTypeConfiguration<Comprovante>
    {
        public void Configure(EntityTypeBuilder<Comprovante> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Quantidade)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Data)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.DataFinal)
                .HasColumnType("datetime");

            builder.Property(c => c.Arquivo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            /****************************************/

            builder.HasOne(c => c.Progressao)
               .WithMany()
               .HasForeignKey(c => c.ProgressaoId);

            builder.HasOne(c => c.Atividade)
             //   .WithMany(a => a.Comprovantes)
                .WithMany()
                .HasForeignKey(c => c.AtividadeId);

            builder.HasOne(c => c.Validacao)
                .WithOne(v => v.Comprovante)
                .HasForeignKey<Validacao>(v => v.ComprovanteId);



            builder.ToTable("Comprovantes");
        }
    }

}
