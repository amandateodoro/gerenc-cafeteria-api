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
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Relatorio_vendas> Relatorios { get; set; }
        public DbSet<Venda> Vendas { get; set; }     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>()
                .HasOne(e => e.Colaborador) //cada venda pertece a um colaborador
                .WithMany(e => e.Vendas) //um colaborador pode ter varias vendas
                .HasForeignKey(e => e.ColaboradorId)
                .IsRequired(true);







            /*modelBuilder.Entity<Produto>()
                .HasOne(p => p.Estoque)    // Cada PRODUTO pertence a UM ESTOQUE
                .WithMany(e => e.Produtos) // Um ESTOQUE pode ter VÁRIOS PRODUTOS
                .HasForeignKey(p => p.EstoqueId) // A chave estrangeira fica na tabela Produto
                .IsRequired(true); // O produto sempre precisa estar em um estoque*/


            //relacionamento 1:N



            //modelBuilder.Entity<Servidor>()
            //    .HasOne(e => e.Campus) //um campus tem muitos servidores
            //    .WithMany(e => e.Servidores) //servidor vai pegar um campus, 
            //    .HasForeignKey(e => e.CampusId)
            //    .IsRequired(false);
        }
    }
}
