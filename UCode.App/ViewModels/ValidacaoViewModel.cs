using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UCode.Business.Models;

namespace UCode.App.ViewModels
{
    public class ValidacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [HiddenInput]
        public Guid ComprovanteId { get; set; }

        public Guid UsuarioId { get; set; }        

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Validado Em")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ValidadoEm { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Quantidade")]
        public decimal Quantidade { get; set; }

        [DisplayName("Detalhes")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Justificativa { get; set; }    

    }
}
