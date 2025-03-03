using System.ComponentModel.DataAnnotations;

namespace CafeManiaApi.Dtos
{
    public class VendaDto
    {
        [Required]
        public DateTime DataHoraVenda { get; set; }

        [Required]
        public string FormaPagamento { get; set; }

        [Required]
        public double ValorTotal { get; set; }

        [Required]
        public int ColaboradorId { get; set; }

        public int? RelatorioVendaId { get; set; }

        [Required]
        public List<ItemVendaDto> ItensVenda { get; set; }
    }

    public class ItemVendaDto
    {
        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public double PrecoUnitario { get; set; }
    }
}
