using System.ComponentModel.DataAnnotations;

namespace CafeManiaApi.Dtos
{
    public class RelatoriosDto
    {
        [Required]
        public string Tipo { get; set; }

        [Required]
        public DateOnly Data { get; set; }

        [Required]
        public string Conteudo { get; set; }
    }
}
