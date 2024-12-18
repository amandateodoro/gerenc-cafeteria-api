using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CafeManiaApi.Models
{
    [Table("Colaborador")]

    public class Relatorios
    {
        [Column("id_relatorio")]
        public int Id { get; set; }

        [Column("tipo_relatorio")]
        public string? Tipo { get; set; }

        [Column("data_relatorio")]
        public string? Data { get; set; }

        [Column("conteudo_relatorio")]
        public string? Conteudo { get; set; }
    }
}
