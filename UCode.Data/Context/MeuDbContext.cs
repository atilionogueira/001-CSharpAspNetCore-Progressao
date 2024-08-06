using Microsoft.EntityFrameworkCore;
using UCode.Business.Models;

namespace UCode.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Campo> Campos { get; set; }
        public DbSet<Campus> Campuss { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Comprovante> Comprovantes { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Progressao> Progressaos { get; set; }
        public DbSet<Servidor> Servidors { get; set; }
        public DbSet<Situacao> Situacaos { get; set; }
        public DbSet<Status> Statuss { get; set; }
        public DbSet<Validacao> Validacaos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        /*
        // Configurações de Logging Debugar
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=UCodeMvcCore;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
            optionsBuilder.EnableSensitiveDataLogging();
        }
        
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
                 relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            // Configuração específica para a relação Endereco -> Campus provisorio
            
            modelBuilder.Entity<Endereco>()
               .HasOne(e => e.Campus)
               .WithOne(c => c.Endereco)
               .HasForeignKey<Endereco>(e => e.CampusId)
               .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Campus>()
                .HasMany(c => c.Servidors)
                .WithOne(s => s.Campus)
                .HasForeignKey(s => s.CampusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Classe>()
                .HasMany(c => c.Progressaos)
                .WithOne(c => c.Classe)
                .HasForeignKey(c => c.ClasseId)
                .OnDelete(DeleteBehavior.Restrict);
         

            modelBuilder.Entity<Campo>()
                .HasMany(c => c.Atividades)
                .WithOne(a => a.Campo)
                .HasForeignKey(a => a.CampoId)
                .OnDelete(DeleteBehavior.Restrict);
            /*

               modelBuilder.Entity<Validacao>()
                  .HasOne(v => v.Comprovante)
                  .WithOne(c => c.Validacao)
                  .HasForeignKey<Comprovante>(c => c.ValidacaoId)
                  .OnDelete(DeleteBehavior.Restrict);
            */

            modelBuilder.Entity<Comprovante>()
               .HasOne(c => c.Validacao)
               .WithOne(v => v.Comprovante)
               .HasForeignKey<Validacao>(v => v.ComprovanteId);
                //.OnDelete(DeleteBehavior.Restrict);
             
         

            modelBuilder.Entity<Atividade>()
               .Property(e => e.Pontos)
               .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Comprovante>()
              .Property(c => c.Quantidade)
              .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Validacao>()
                .Property(v => v.Quantidade)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);                    
            
        }

    }      

}
    

