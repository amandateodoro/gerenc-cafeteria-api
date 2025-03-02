using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;


namespace CafeManiaApi.Models
{
    [Table("Venda")]

    public class Venda
    {
        [Column("id_venda")]
        public int Id { get; set; }

        [Column("data_venda")]
        public DateOnly? Data { get; set; }

        [Column("hora_venda")]
        public TimeOnly? Hora { get; set; }

        [Column("quantidade_produto")]
        public int? QuantidadeProd { get; set; }

        [Column("valor_total")]
        public double? ValorTotal { get; set; }

        [Column("fk_id_colaborador")]
        public int? ColaboradorId { get; set; }

        [Column("fk_id_produto")]
        public int? ProdutoId { get; set; }

        public virtual Colaborador Colaborador { get; set; }

        public virtual Produto Produto { get; set; }

    }
}
