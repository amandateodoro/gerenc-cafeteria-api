using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CafeManiaApi.Models
{
    [Table("Estoque")]

    public class Estoque
    {
        [Column("id_estoque")]
        public int Id { get; set; }

        [Column("quantidade_prod")]
        public int? QuantidadeProd { get; set; }

        [Column("data_validade")]
        public DateOnly? DataValidade { get; set; }

        [Column("tipo_movimento")]
        public string? EntradaSaidaProd { get; set; }

        [Column("fk_id_produto")]
        public int? ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

    }
}
