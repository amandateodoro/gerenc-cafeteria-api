using System.ComponentModel.DataAnnotations.Schema;

namespace CafeManiaApi.Models
{
    [Table("Item_venda")]
    public class ItemVenda
    {
        [Column("id_itemVenda")]
        public int Id { get; set; }

        [Column("quantidade_produto_venda")]
        public int Quantidade { get; set; }

        [Column("valor_un_produto")]
        public decimal PrecoUnitario { get; set; }

        [Column("subtotal_venda")]
        public decimal Subtotal => Quantidade * PrecoUnitario;

        [Column("fk_id_venda")]
        public int VendaId { get; set; }

        [Column("fk_id_produto")]
        public int ProdutoId { get; set; }

        public Venda Venda { get; set; }
        public Produto Produto { get; set; }
        
    }
}