using DevIO.Business.Services;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Business.Models.Validations;

namespace UCode.Business.Services
{
    public class SituacaoService : BaseService, ISituacaoService
    {
        private readonly ISituacaoRepository _situacaoRepository;

        public SituacaoService(ISituacaoRepository situacaoRepository,
                               INotificador notificador) : base(notificador)
        {
            _situacaoRepository = situacaoRepository;
        }

        public async Task Adicionar(Situacao situacao)
        {
            // Validar o estado da entidade
            if (!ExecutarValidacao(new SituacaoValidation(), situacao)) return;

            await _situacaoRepository.Adicionar(situacao);

        }

        public async Task Atualizar(Situacao situacao)
        {
            if (!ExecutarValidacao(new SituacaoValidation(), situacao)) return;

            await _situacaoRepository.Atualizar(situacao);

        }

        public async Task Remover(Guid id)
        {
            var situacao = await _situacaoRepository.ObterSituacaoStatus(id);

            if (situacao != null && situacao.Status != null)
            {
                Notificar("O Situacao está associado a um Status e não pode ser removido.");
                return;
            }

            await _situacaoRepository.Remover(id);
        }

        public void Dispose()
        {
            _situacaoRepository?.Dispose();         
        }
    }
}
