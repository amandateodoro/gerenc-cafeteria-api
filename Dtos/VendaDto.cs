using System.ComponentModel.DataAnnotations;

namespace CafeManiaApi.Dtos
{
    public class VendaDto
    {
        [Required]
        public DateOnly DataVenda { get; set; }

        [Required]
        public TimeOnly HoraVenda { get; set; }

        [Required]
        public int QuantidadeProduto { get; set; }

        [Required]
        public double ValorTotal { get; set; }
    }
}
