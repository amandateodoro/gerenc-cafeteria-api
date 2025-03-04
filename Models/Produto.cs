using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;


namespace CafeManiaApi.Models
{
    [Table("Produto")]

    public class Produto
    {
        [Column("id_produto")]
        public int Id { get; set; }

        [Column("nome_produto")]
        public string? Nome { get; set; }

        [Column("desc_produto")]
        public string? Descricao { get; set; }

        [Column("valor_un_produto")]
        public double? ValorUn { get; set; }

        [Column("quant_estoque")]
        public int? QuantidadeEstoque { get; set; }

        [Column("fk_id_estoque")]
        public int EstoqueId { get; set; }

        public Estoque Estoque { get; set; }

        public ICollection<ProdutoFornecedor>? ProdutoFornecedores { get; set; }

        public ICollection<ItemVenda>? ItensVenda { get; set; }

    }
}
