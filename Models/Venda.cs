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

        [Column("data_hora_venda")]
        public DateTime? DataHora { get; set; }

        [Column("forma_pagamento")]
        public string? FormaPagamento { get; set; }

        [Column("valor_total")]
        public double? ValorTotal { get; set; }

        [Column("fk_id_colaborador")]
        public int? ColaboradorId { get; set; }

        [Column("fk_id_relatorioVenda")]
        public int? RelatorioVendaId { get; set; }

        public virtual Colaborador Colaboradores { get; set; }

        public virtual RelatorioVenda RelatorioVendas { get; set; }

        public ICollection<ItemVenda>? ItensVenda { get; set; }

    }
}
