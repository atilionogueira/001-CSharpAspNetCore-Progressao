using DevIO.Business.Services;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Business.Models.Validations;

namespace UCode.Business.Services
{
    public class ServidorService : BaseService, IServidorSerivce
    {
        private readonly IServidorRepository _servidorRepository;
        public ServidorService(IServidorRepository servidorRepository,
                               INotificador notificador) : base(notificador)
        {
            _servidorRepository = servidorRepository;
        }
        public async Task Adicionar(Servidor servidor)
        {
            // Validar o estado da entidade
            if (!ExecutarValidacao(new ServidorValidation(), servidor)) return;

            // se nao existe servidor com o mesmo documento.
            if (_servidorRepository.Buscar(s => s.Cpf == servidor.Cpf).Result.Any())
            {
                Notificar("Já existe um servidor com este documento informado.");
                return;
            }

            await _servidorRepository.Adicionar(servidor);

        }
        public async Task Atualizar(Servidor servidor)
        {
            if (!ExecutarValidacao(new ServidorValidation(), servidor)) return;

            if (_servidorRepository.Buscar(s => s.Cpf == servidor.Cpf && s.Id != servidor.Id).Result.Any())
            {
                Notificar("Já existe um servidor com este CPF infomado.");
                return;
            }

            await _servidorRepository.Atualizar(servidor);

        }

        public async Task Remover(Guid id)
        {            
            var servidor = await _servidorRepository.ObterServidorCampus(id);

            if (servidor != null && servidor.Campus != null)
             {
                 Notificar("O Servidor está associado a um campus e não pode ser removido.");
                 return;
             }            

            await _servidorRepository.Remover(id);
        }
        public void Dispose()
        {
            _servidorRepository?.Dispose();
            GC.SuppressFinalize(this);
        }      

    }
}
    


