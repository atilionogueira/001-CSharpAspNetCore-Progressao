                                                                                                                                                                                                                                                 using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UCode.Business.Models;

namespace UCode.Data.Mapping
{
    public class CampusMapping : IEntityTypeConfiguration<Campus>
    {
        public void Configure(EntityTypeBuilder<Campus> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");
          
            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnType("varchar(15)");

            //1 : 1 => Campus : Endereco
            builder.HasOne(c => c.Endereco)
               .WithOne(e => e.Campus)
              .HasForeignKey<Endereco>(e => e.CampusId)
              .OnDelete(DeleteBehavior.Cascade);

            // 1 : N => Campus : Servidor
            builder.HasMany(c => c.Servidors)
                  .WithOne(s => s.Campus)
                  .HasForeignKey(s => s.CampusId);

            builder.ToTable("Campuss");
        }
    }

}
