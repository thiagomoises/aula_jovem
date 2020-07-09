using Microsoft.EntityFrameworkCore;

namespace Jovem.Banco
{
    public class BancoJovem: DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }

        public BancoJovem(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Pessoa>()
                .Property(x => x.Nome).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(x => x.Email).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(x => x.Idade).IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(x => x.Endereco).HasMaxLength(150).IsRequired();

            base.OnModelCreating(modelBuilder);
        }


    }
}
