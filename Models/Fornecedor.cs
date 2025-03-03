using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CafeManiaApi.Models
{
    [Table("Fornecedor")]

    public class Fornecedor
    {
        [Column("id_fornecedor")]
        public int Id { get; set; }

        [Column("nome_fornecedor")]
        public string? Nome { get; set; }

        [Column("cnpj_fornecedor")]
        public string? Contato { get; set; }

        [Column("endereco_fornecedor")]
        public string? Endereco { get; set; }

        [Column("telefone_fornecedor")]
        public string? Telefone { get; set; }

        public ICollection<ProdutoFornecedor>? ProdutoFornecedores { get; set; }

    }
}
