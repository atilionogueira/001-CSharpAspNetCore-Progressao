using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UCode.Business.Models;

namespace UCode.Data.Mapping
{
    public class CampoMapping : IEntityTypeConfiguration<Campo>
    {
        public void Configure(EntityTypeBuilder<Campo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.ToTable("Campos");
        }
    }

}
