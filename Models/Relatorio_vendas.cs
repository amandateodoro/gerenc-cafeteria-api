using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CafeManiaApi.Models
{
    [Table("Relatorio_venda")]

    public class Relatorio_vendas
    {
        [Column("id_relatorioVenda")]
        public int Id { get; set; }

        [Column("data_relatorioVenda")]
        public DateTime? DataHora { get; set; }

        [Column("dados_relatorioVenda")]
        public string? Dados { get; set; }
    }
}
