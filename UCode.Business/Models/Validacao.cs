namespace UCode.Business.Models
{
    public class Validacao : Entity
    {
        public Guid ComprovanteId { get; set; }  
        public DateTime ValidadoEm { get; set; }
        public string Justificativa { get; set; }
        public decimal Quantidade { get; set; }

        public Comprovante Comprovante { get; set; }
        public Guid UsuarioId { get; set; }
    }

}
