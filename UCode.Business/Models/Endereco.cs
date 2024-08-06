namespace UCode.Business.Models
{
    public class Endereco : Entity
    {
        // Se seguir o padrão de Colocar no final do Guid Id o entity frame já entende que é chave estrangeira
        public Guid CampusId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }       
        public string Estado { get; set; }

        /* EF Relation*/
        public Campus Campus { get; set; }
    }
}

