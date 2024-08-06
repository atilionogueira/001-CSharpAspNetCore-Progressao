namespace UCode.Business.Models
{
    public class Progressao : Entity
    {
        public Guid ClasseId { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Observacao { get; set; }      


        /*EF Relations*/

        public Classe Classe { get; set; }       

    }

}
