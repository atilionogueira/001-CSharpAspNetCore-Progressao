using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UCode.App.ViewModels
{
    public class ClasseViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Nivel { get; set; }


        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }
       
    }
}
