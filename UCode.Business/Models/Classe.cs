namespace UCode.Business.Models
{
    public class Classe : Entity
    {
        public string Nome { get; set; }
        public int Nivel { get; set; }
        public string Descricao { get; set; }

        public IEnumerable<Progressao> Progressaos { get; set; }
    }

}
