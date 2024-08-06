using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using UCode.Business.Models;

namespace UCode.App.ViewModels
{
    public class AtividadeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Campo")]
        public Guid CampoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Número")]            
        public int Numero { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Pontos { get; set; }

        [DisplayName("Detalhes")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Detalhes { get; set; }        


        /*EF Relations*/
        public CampoViewModel Campo { get; set; }

        public IEnumerable<CampoViewModel> Campos { get; set; } = new List<CampoViewModel>();
    }
}
