using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoFacil.Models;

[Table("campus"), PrimaryKey(nameof(Id))]
public class Campus
{
    [Column("id_cam")]
    public int Id { get; }

    [Column("nome_cam")]
    public required string Nome { get; set; }

    //[JsonIgnore]
    public ICollection<Servidor>? Servidores { get; set; }
}
