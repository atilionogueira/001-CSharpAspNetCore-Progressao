using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UCode.Business.Models;

namespace UCode.App.ViewModels
{
    public class ComprovanteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Progressao")]
        public Guid ProgressaoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Atividade")]
        public Guid AtividadeId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Quantidade")]
        public decimal Quantidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data Final")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DataFinal { get; set; }

        [DisplayName("Imagem do Produto")]
        public IFormFile ImagemUpload { get; set; }
        public string Arquivo { get; set; }
        public Guid UsuarioId { get; set; }

        /*EF Relations*/
        public Progressao Progressao { get; set; }
        public Atividade Atividade { get; set; }

        public ValidacaoViewModel Validacao { get; set; } = new ValidacaoViewModel();


        public IEnumerable<AtividadeViewModel> Atividades { get; set; }  = new List<AtividadeViewModel>();
        public IEnumerable<ProgressaoViewModel> Progressaos { get; set; } = new List<ProgressaoViewModel>();

        public IEnumerable<ValidacaoViewModel> Validacaos { get; set; } = new List<ValidacaoViewModel>();


    }
}
