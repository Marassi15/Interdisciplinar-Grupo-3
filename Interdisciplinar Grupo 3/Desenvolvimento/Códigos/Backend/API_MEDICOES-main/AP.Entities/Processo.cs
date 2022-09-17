using System.ComponentModel.DataAnnotations;

namespace AM.Entities
{
    public class Processo
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(3, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string cd_proc { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string titulo_proc { get; set; }
    }
}
