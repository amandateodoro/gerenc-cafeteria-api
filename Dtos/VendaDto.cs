using System.ComponentModel.DataAnnotations;

namespace CafeManiaApi.Dtos
{
    public class VendaDto
    {
        [Required]
        public DateTime DataHoraVenda { get; set; }

        [Required]
        public int QuantidadeProduto { get; set; }

        [Required]
        public string FormaPagamento { get; set; }

        [Required]
        public double ValorTotal { get; set; }
    }
}
