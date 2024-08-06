using System.ComponentModel;

namespace UCode.Business.Models
{
    public class Situacao : Entity
    {
        public Guid StatusId { get; set; }
        public Guid MovimentadoPorId { get; set; }      
        public DateTime MovimentadoEm { get; set; }
        public string Detalhes { get; set; }
        public Status Status { get; set; }

    }

}
