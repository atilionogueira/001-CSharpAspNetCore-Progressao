namespace UCode.Business.Models
{
    public class Cidade : Entity
    {
        public string Nome { get; set; }
        public Guid EstadoId { get; set; }
        public Estado Estado { get; set; }
    }

}
