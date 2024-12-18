using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;


namespace CafeManiaApi.Models
{
    [Table("Colaborador")]

    public class Colaborador
    {
        [Column("id_colaborador")]
        public int Id { get; set; }

        [Column("nome_colaborador")]
        public string? Nome { get; set; }

        [Column("contato_colaborador")]
        public string? Contato { get; set; }

        [Column("cargo_colaborador")]
        public string? Cargo { get; set; }

        [Column("permissoes_colaborador")]
        public bool? Permissoes { get; set; }

        [Column("usuario_colaborador")]
        public string? UsuarioColaborador {  get; set; }

        [Column("senha_colaborador")]
        public string? SenhaColaborador { get; set; }

        public ICollection<Venda>? Vendas { get; set; }

    }
}
