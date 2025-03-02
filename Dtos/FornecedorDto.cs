using System.ComponentModel.DataAnnotations;

namespace CafeManiaApi.Dtos
{
    public class FornecedorDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres")]
        public string Nome { get; set; }

        [Required]
        public string Contato { get; set; }

        [Required]
        public string Enredeco { get; set; }
    }
}
