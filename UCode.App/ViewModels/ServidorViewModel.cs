using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using UCode.Business.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace UCode.App.ViewModels
{
    public class ServidorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Campus")]
        public Guid CampusId { get; set; }       

        [DisplayName("Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(9, ErrorMessage = "O campo {0} precisa ter entre {2}")]
        public string Siape { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2}")]
        public string Cpf { get; set; }

        /* EF Relations */     
        public CampusViewModel Campus { get; set; }

        // public IEnumerable<CampusViewModel> Campuss { get; set; } = new List<CampusViewModel>();
        public IEnumerable<CampusViewModel> Campuss { get; set; } 


    }
}
