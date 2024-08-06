namespace UCode.Business.Models
{
    public class Servidor : Entity
    {
        public string NomeCompleto { get; set; }
        public string Siape { get; set; }
        public string Cpf { get; set; }
        public Guid CampusId { get; set; }       
        public Guid UsuarioId { get; set; }

        /*EF Relations*/
        public Campus Campus { get; set; }

    //    public IEnumerable<Campus> Campuss { get; set; }

    }

}
