using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UCode.Business.Models;

namespace UCode.Data.Mapping
{
    public class ServidorMapping : IEntityTypeConfiguration<Servidor>
    {
        public void Configure(EntityTypeBuilder<Servidor> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.NomeCompleto)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(s => s.Siape)
                .IsRequired()
                .HasColumnType("varchar(9)");

            builder.Property(s => s.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            /**********************/
            builder.HasOne(s => s.Campus)
               .WithMany(c => c.Servidors)
               .HasForeignKey(s => s.CampusId);

            builder.ToTable("Servidors");

        }
    }
}
