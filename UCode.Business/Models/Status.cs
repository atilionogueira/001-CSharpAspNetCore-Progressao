namespace UCode.Business.Models
{
    public class Status : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        /*EF Relations*/
        public IEnumerable<Situacao> Situacaos { get; set; }
    }

}
