namespace UCode.Business.Models
{
    public class Campus : Entity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }


        /*EF Relations*/
      
        public IEnumerable<Servidor> Servidors { get; set; }
    }

}
