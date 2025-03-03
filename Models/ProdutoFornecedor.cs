using System.ComponentModel.DataAnnotations.Schema;

namespace CafeManiaApi.Models
{
    [Table("Produto_fornecedor")]
    public class ProdutoFornecedor
    {
        [Column("id_produtoFornecedor")]
        public int Id { get; set; }

        [Column("fk_id_produto")]
        public int ProdutoId { get; set; }        

        [Column("fk_id_fornecedor")]
        public int FornecedorId { get; set; }

        public Produto Produto { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}