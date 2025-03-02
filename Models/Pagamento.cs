using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;


namespace CafeManiaApi.Models
{
    [Table("Pagamento")]

    public class Pagamento
    {
        [Column("id_pagamento")]
        public int Id { get; set; }

        [Column("forma_pagamento")]
        public string? FormaPagamento { get; set; }

        [Column("valor_pagamento")]
        public double? ValorPagamento { get; set; }

        [Column("fk_id_venda")]
        public int? VendaId { get; set; }

        public virtual Venda Venda { get; set; }
    }
}
