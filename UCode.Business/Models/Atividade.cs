namespace UCode.Business.Models
{
    public class Atividade : Entity
    {
        public Guid CampoId { get; set; }      
        public int Numero { get; set; }
        public string Descricao { get; set; }
        public decimal Pontos { get; set; }
        public string Detalhes { get; set; }

        /*EF Relations*/
        public Campo Campo { get; set; }

        public IEnumerable<Progressao> Progressaos { get; set; }
        public IEnumerable<Comprovante> Comprovantes { get; set; }
    }

}
