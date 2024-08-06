using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UCode.Business.Models;

namespace UCode.Data.Mapping
{
    public class AtividadeMapping : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Numero)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(a => a.Descricao)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(a => a.Pontos)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(a => a.Detalhes)
                .HasColumnType("varchar(255)");

            builder.HasOne(a => a.Campo)
               .WithMany(c => c.Atividades)
               .HasForeignKey(a => a.CampoId);

            
            builder.HasMany(c => c.Comprovantes)
                 .WithOne(a => a.Atividade)
                 .HasForeignKey(a => a.AtividadeId);
            

            builder.ToTable("Atividades");
        }
    }

}
