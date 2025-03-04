using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeManiaApi.Dtos
{
    public class FornecedorDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 3 caracteres")]
        public string Nome { get; set; }

        [Required]
        public string Cnpj { get; set; }

        [Required]
        public string Enredeco { get; set; }

        [Required]
        public string Telefone { get; set; }

    }
}
