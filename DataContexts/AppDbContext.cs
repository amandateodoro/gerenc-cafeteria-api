using CafeManiaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManiaApi.DataContexts
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Relatorios> Relatorios { get; set; }
        public DbSet<Venda> Vendas { get; set; }      
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Servidor>()
            //    .HasOne(e => e.Campus) //um campus tem muitos servidores
            //    .WithMany(e => e.Servidores) //servidor vai pegar um campus, 
            //    .HasForeignKey(e => e.CampusId)
            //    .IsRequired(false);

            modelBuilder.Entity<Venda>()
                .HasOne(e => e.Colaborador) //um colaborador faz muitas vendas
                .WithMany(e => e.Vendas) //cada venda é feita por um colaborador
                .HasForeignKey(e => e.ColaboradorId)
                .IsRequired(false);

            //relacionamento 1:N
        }
    }
}
