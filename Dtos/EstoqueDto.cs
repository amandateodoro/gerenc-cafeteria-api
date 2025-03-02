using System.ComponentModel.DataAnnotations;

namespace CafeManiaApi.Dtos
{
    public class EstoqueDto
    {
        [Required]
        public int? QuantidadeProd { get; set; }

        [Required]
        public DateOnly? DataValidade { get; set; }

        [Required]
        public string? EntradaSaidaProd { get; set; }
    }
}
