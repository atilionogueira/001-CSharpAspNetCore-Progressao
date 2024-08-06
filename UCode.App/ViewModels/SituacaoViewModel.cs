using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UCode.Business.Models;

namespace UCode.App.ViewModels
{
    public class SituacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [DisplayName("Status")]
        public Guid StatusId { get; set; }

        [ScaffoldColumn(false)]
        public Guid MovimentadoPorId { get; set; }

        [DisplayName("Movimentado Em")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime MovimentadoEm { get; set; }

        [DisplayName("Detalhes")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Detalhes { get; set; }

        /*EF Relations*/
        public StatusViewModel Status { get; set; }

        public IEnumerable<StatusViewModel> Statuss{ get; set; }
    }
}
