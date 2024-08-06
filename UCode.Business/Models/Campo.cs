namespace UCode.Business.Models
{
    public class Campo : Entity
    {     
        public string Nome { get; set; }
        public string Descricao { get; set; }

        /*EF Relations*/

        public IEnumerable<Atividade> Atividades { get; set; }
    }

}
