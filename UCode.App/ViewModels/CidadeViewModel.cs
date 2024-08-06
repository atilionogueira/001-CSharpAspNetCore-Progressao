using System.ComponentModel.DataAnnotations;
using UCode.Business.Models;

namespace UCode.App.ViewModels
{
    public class CidadeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid EstadoId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
       
        /*EF Relations*/
        public EstadoViewModel Estado { get; set; }
    }
}
