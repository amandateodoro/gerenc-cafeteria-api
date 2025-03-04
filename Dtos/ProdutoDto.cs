using System.ComponentModel.DataAnnotations;

namespace CafeManiaApi.Dtos
{
    public class ProdutoDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public double ValorUn { get; set; }

        [Required]
        public int QuantidadeEstoque { get; set; }
    }
}
