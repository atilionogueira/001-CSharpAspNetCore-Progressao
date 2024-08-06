using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UCode.Business.Models;

namespace UCode.Data.Mapping
{
    public class ClasseMapping : IEntityTypeConfiguration<Classe>
    {
        public void Configure(EntityTypeBuilder<Classe> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Nivel)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(150)");

           
            builder.ToTable("Classes");
        }
    }

}
