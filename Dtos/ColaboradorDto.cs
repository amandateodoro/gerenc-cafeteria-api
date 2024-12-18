using System.ComponentModel.DataAnnotations;

namespace CafeManiaApi.Dtos
{
    public class ColaboradorDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres")]
        public string Nome { get; set; }

        [Required]
        [Length(11, 11, ErrorMessage = "O cpf deve ter mínimo 11 caracteres")]
        public string Contato { get; set; }

        [Required]
        public string Cargo { get; set; }

        [Required]
        public bool Permissoes { get; set; }

        [Required]
        public string UsuarioColaborador { get; set; }

        [Required]
        public string SenhaColaborador { get; set; }

    }
}
