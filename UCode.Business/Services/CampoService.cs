using DevIO.Business.Services;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Business.Models.Validations;

namespace UCode.Business.Services
{
    public class CampoService : BaseService, ICampoService
    {
        private ICampoRepository _campoRepository;
    //    private IAtividadeRepository _atividadeRepository;

        public CampoService(ICampoRepository campoRepository,
      //                      IAtividadeRepository atividadeRepository,
                            INotificador notificador) : base(notificador)
        {
            _campoRepository = campoRepository;
        //    _atividadeRepository = atividadeRepository;
        }

        public async Task Adicionar(Campo campo)
        {
            if (!ExecutarValidacao(new CampoValidation(), campo)) return;

            await _campoRepository.Adicionar(campo);
        }

        public async Task Atualizar(Campo campo)
        {
            if (!ExecutarValidacao(new CampoValidation(), campo)) return;

            await _campoRepository.Atualizar(campo);
        }

        public async Task Remover(Guid id)
        {
            var campoAtividade = await _campoRepository.ObterCampoAtividade(id);

            if(campoAtividade?.Atividades.Any() ?? false) 
            {
                Notificar("O Campo possui atividade cadastradas");
            }

            await _campoRepository.Remover(id);
        }

        public void Dispose()
        {
            _campoRepository?.Dispose();          
         //   GC.SuppressFinalize(this);
        }
    }
}
