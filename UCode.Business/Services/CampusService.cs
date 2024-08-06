using DevIO.Business.Models.Validations;
using DevIO.Business.Services;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Business.Models.Validations;

namespace UCode.Business.Services
{
    public class CampusService : BaseService, ICampusService
    {
        private readonly ICampusRepository _campusRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public CampusService(ICampusRepository campusRepository,
                             IEnderecoRepository enderecoRepository,
                             INotificador notificador) : base(notificador)
        {
            _campusRepository = campusRepository;
            _enderecoRepository = enderecoRepository; 
        }

        public async Task Adicionar(Campus campus)
        {            
            //Validar o estado da entidade
            if (!ExecutarValidacao(new CampusValidation(), campus)
                || !ExecutarValidacao(new EnderecoValidation(), campus.Endereco)) return;             

            await _campusRepository.Adicionar(campus);
           
        }


        public async Task Atualizar(Campus campus)
        {
            if (!ExecutarValidacao(new CampusValidation(), campus)) return;

            await _campusRepository.Atualizar(campus);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }


        public async Task Remover(Guid id)
        {         
            var campusEndereco = await _campusRepository.ObterCampusEnderecoServidor(id);

            if (campusEndereco?.Servidors?.Any() ?? false) 
            {
                Notificar("O Campus possui servidores cadastrados!");
                return;
            }
           
            await _campusRepository.Remover(id);
        }       
      

        public void Dispose()
        {
            _campusRepository?.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
   

}
