using System.ComponentModel.DataAnnotations;

namespace AM.Entities
{
    public class Objetivo
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(3, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string cd_obj { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(3, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string cd_dir { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string titulo_obj { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(500, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string resumo_obj { get; set; }     
    }  
}
