using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UCode.Business.Models;

namespace UCode.Data.Mapping
{
    public class EstadoMapping : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Uf)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.ToTable("Estados");
        }
    }

}
