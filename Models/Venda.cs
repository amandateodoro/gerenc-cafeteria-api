using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;


namespace CafeManiaApi.Models
{
    [Table("Colaborador")]

    public class Venda
    {
        [Column("id_venda")]
        public int Id { get; set; }

        [Column("data_venda")]
        public string? Data { get; set; }

        [Column("hora_venda")]
        public string? Hora { get; set; }

        [Column("quantidade_produto")]
        public string? QuantidadeProd { get; set; }

        [Column("valor_total")]
        public bool? ValorTotal { get; set; }

        [Column("fk_id_colaborador")]
        public string? ColaboradorId { get; set; }

        [Column("fk_id_produto")]
        public string? ProdutoId { get; set; }

        public virtual Colaborador Colaborador { get; set; }

        public virtual Produto Produto { get; set; }

    }
}
