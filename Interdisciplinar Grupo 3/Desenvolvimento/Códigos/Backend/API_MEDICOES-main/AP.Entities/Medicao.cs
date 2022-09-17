using System.ComponentModel.DataAnnotations;

namespace AM.Entities
{
    public class Medicao
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(3, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string cd_med { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(3, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string cd_dir { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(3, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string cd_proc { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um número inteiro válido")]
        public decimal versao_med { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(500, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string proposito_med { get; set; }
    }
}
