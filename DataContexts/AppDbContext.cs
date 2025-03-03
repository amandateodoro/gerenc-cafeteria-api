using CafeManiaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManiaApi.DataContexts
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Estoque> EstoqueProd { get; set; }
        public DbSet<RelatorioVenda> Relatorios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
        public DbSet<ProdutoFornecedor> ProdutoFornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da tabela intermediária ProdutoFornecedor
            modelBuilder.Entity<ProdutoFornecedor>()
                .HasKey(pf => new { pf.ProdutoId, pf.FornecedorId });

            modelBuilder.Entity<ProdutoFornecedor>()
                .HasOne(pf => pf.Produto)
                .WithMany(p => p.ProdutoFornecedores)
                .HasForeignKey(pf => pf.ProdutoId);

            modelBuilder.Entity<ProdutoFornecedor>()
                .HasOne(pf => pf.Fornecedor)
                .WithMany(f => f.ProdutoFornecedores)
                .HasForeignKey(pf => pf.FornecedorId);

            // Configuração do relacionamento Produto-Venda via ItemVenda
            modelBuilder.Entity<ItemVenda>()
                .HasOne(iv => iv.Produto)
                .WithMany(p => p.ItensVenda)
                .HasForeignKey(iv => iv.ProdutoId);

            modelBuilder.Entity<ItemVenda>()
                .HasOne(iv => iv.Venda)
                .WithMany(v => v.ItensVenda)
                .HasForeignKey(iv => iv.VendaId);





















            /*modelBuilder.Entity<Venda>()
                .HasOne(e => e.Colaboradores) //uma venda é feita por apenas um colaborador
                .WithMany(e => e.Vendas) //um colaborador pode fazer varias vendas
                .HasForeignKey(e => e.ColaboradorId);

            modelBuilder.Entity<Venda>()
                .HasMany(v => v.Produtos) // uma venda pode ter vários produtos
                .WithMany(p => p.Vendas) // um produto pode estar em várias vendas
                .UsingEntity<Dictionary<string, object>>(
                    "venda_produto", // Nome da tabela de junção
                    j => j.HasOne<Produto>().WithMany().HasForeignKey("id_produto"), // Chave estrangeira para Produto
                    j => j.HasOne<Venda>().WithMany().HasForeignKey("id_venda"), // Chave estrangeira para Venda
                    j => j.ToTable("venda_produto") // Nome da tabela de junção
                );

            modelBuilder.Entity<Produto>()
                .HasMany(v => v.Fornecedores) // um produto pode ser fornecido por varios fornecedores
                .WithMany(p => p.Produtos) // um fornecedor pode fornecer varios produtos
                .UsingEntity<Dictionary<string, object>>(
                    "produto_fornecedor", // Nome da tabela de junção
                    j => j.HasOne<Fornecedor>().WithMany().HasForeignKey("id_fornecedor"), // Chave estrangeira para Fornecedor
                    j => j.HasOne<Produto>().WithMany().HasForeignKey("id_produto"), // Chave estrangeira para Produto
                    j => j.ToTable("produto_fornecedor") // Nome da tabela de junção
                );

            modelBuilder.Entity<Produto>()
                .HasOne(e => e.EstoqueProd) //um produto pode estar em apenas um estoque
                .WithMany(e => e.Produtos) //um estoque pode ter vários produtos
                .HasForeignKey(e => e.EstoqueId);*/


            /*modelBuilder.Entity<Produto>()
                .HasOne(p => p.Estoque)    // Cada PRODUTO pertence a UM ESTOQUE
                .WithMany(e => e.Produtos) // Um ESTOQUE pode ter VÁRIOS PRODUTOS
                .HasForeignKey(p => p.EstoqueId) // A chave estrangeira fica na tabela Produto
                .IsRequired(true); // O produto sempre precisa estar em um estoque*/

            //modelBuilder.Entity<Servidor>()
            //    .HasOne(e => e.Campus) //um campus tem muitos servidores
            //    .WithMany(e => e.Servidores) //servidor vai pegar um campus, 
            //    .HasForeignKey(e => e.CampusId)
            //    .IsRequired(false);



            /*
               Um para Um (1:1) → HasOne().WithOne()
               Um para Muitos (1:N) → HasMany().WithOne()
               Muitos para Muitos (N:N) → HasMany().WithMany()
            */

        }
    }
}
