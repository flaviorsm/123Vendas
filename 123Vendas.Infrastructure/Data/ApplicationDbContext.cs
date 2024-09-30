using _123Vendas.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace _123Vendas.Infraestrutura.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Venda>()
                .HasMany(v => v.Itens)
                .WithOne()
                .HasForeignKey(i => i.VendaId);

            modelBuilder.Entity<ItemVenda>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<ItemVenda>()
                .Property(i => i.ValorTotal);

            base.OnModelCreating(modelBuilder);
        }
    }
}
