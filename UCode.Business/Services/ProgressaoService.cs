using DevIO.Business.Services;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Business.Models.Validations;

namespace UCode.Business.Services
{
    public class ProgressaoService : BaseService,IProgressaoService
    {
        private readonly IProgressaoRepository _progressaoRepository;

        public ProgressaoService(IProgressaoRepository progressaoRepository,
                                 INotificador notificador) : base(notificador) 
        {
            _progressaoRepository = progressaoRepository;
        }

        public async Task Adicionar(Progressao progressao)
        {
            if (!ExecutarValidacao(new ProgressaoValidation(), progressao)) return;

            await _progressaoRepository.Adicionar(progressao);
        }

        public async Task Atualizar(Progressao progressao)
        {
            if (!ExecutarValidacao(new ProgressaoValidation(), progressao)) return;

            await _progressaoRepository.Atualizar(progressao);
        }

        public async  Task Remover(Guid id)
        {
            var progressao = await _progressaoRepository.ObterProgressaoClasse(id);
           
            if (progressao != null && progressao.Classe != null)
            {
                Notificar("O Processao está associado a um Classe e não pode ser removido.");
                return;
            }           
           
            await _progressaoRepository.Remover(id);
        }

        public void Dispose()   
        {
            _progressaoRepository?.Dispose();       
        }
    }
}
