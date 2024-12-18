using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;


namespace CafeManiaApi.Models
{
    [Table("Colaborador")]

    public class Produto
    {
        [Column("id_produto")]
        public int Id { get; set; }

        [Column("nome_produto")]
        public string? Nome { get; set; }

        [Column("desc_produto")]
        public string? Descicao { get; set; }

        [Column("valor_un_produto")]
        public string? ValorUn { get; set; }

        [Column("quant_estoque")]
        public bool? QuantidadeEst { get; set; }

        [Column("data_validade")]
        public string? DataValidade { get; set; }

        [Column("fk_id_fornecedor")]
        public string? FornecedorId { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

    }
}
