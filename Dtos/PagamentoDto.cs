using System.ComponentModel.DataAnnotations;

namespace CafeManiaApi.Dtos
{
    public class PagamentoDto
    {
        [Required]
        public string FormaDePagamento { get; set; }

        [Required]
        public double ValorPagamento { get; set; }

    }
}
