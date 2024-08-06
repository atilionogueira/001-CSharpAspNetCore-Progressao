using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UCode.Business.Models;

namespace UCode.App.ViewModels
{
    public class ProgressaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Classe")]
        public Guid ClasseId { get; set; }

        [ScaffoldColumn(false)]
        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data Inicial")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DataInicial { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data Final")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DataFinal { get; set; }

        [DisplayName("Observação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Observacao { get; set; }

        /* EF Relations */
        public ClasseViewModel Classe { get; set; }

        public IEnumerable<ClasseViewModel> Classes { get; set; } = new List<ClasseViewModel>();
      

    }
}
