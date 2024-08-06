using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UCode.Business.Models;

namespace UCode.Data.Mapping
{
    public class StatusMapping : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(s => s.Descricao)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.ToTable("Statuss");
        }
    }

}
