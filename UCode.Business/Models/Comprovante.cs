namespace UCode.Business.Models
{
    public class Comprovante : Entity
    {
        public Guid ProgressaoId { get; set; }
    
        public Guid AtividadeId { get; set; }
       
        public Guid UsuarioId { get; set; }

        public decimal Quantidade { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataFinal { get; set; }
        public string Arquivo { get; set; }
       

        /*EF Relations*/
        public Progressao Progressao { get; set; }
        public Atividade Atividade { get; set; }
        public Validacao Validacao { get; set; }

        public IEnumerable<Validacao> Valicacaos { get; set; } // Lista Produtos

    }
}


