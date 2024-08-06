using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;

namespace UCode.App.ViewModels
{
    public class CampusViewModel 
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }     

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(15)]
        public string Telefone { get; set; }

        /*EF Relations*/
        public EnderecoViewModel Endereco { get; set; }
        public IEnumerable<ServidorViewModel> Servidors { get; set; } = new List<ServidorViewModel>();
    }
}
