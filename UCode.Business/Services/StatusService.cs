using DevIO.Business.Services;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Business.Models.Validations;

namespace UCode.Business.Services
{
    public class StatusService : BaseService, IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly ISituacaoRepository _situacaoRepository; // Adicionado


        public StatusService(IStatusRepository statusRepository,
                             ISituacaoRepository situacaoRepository,
                             INotificador notificador) : base(notificador)
        {
            _statusRepository = statusRepository;
            _situacaoRepository = situacaoRepository; // Adicionado
        }
        public async Task Adicionar(Status status)
        {
            if (!ExecutarValidacao(new StatusValidation(), status)) return;

            await _statusRepository.Adicionar(status);
        }

        public async Task Atualizar(Status status)
        {
            if (!ExecutarValidacao(new StatusValidation(), status)) return;

            await _statusRepository.Atualizar(status);
        }

        public async Task Remover(Guid id)
        {
            var statusSituacao = await _statusRepository.ObterStatusSituacao(id);

            if (statusSituacao?.Situacaos.Any() ?? false)
            {
                Notificar("O Status possui um situação cadastradas!");
                return;
            }

            await _statusRepository.Remover(id);

        }

        public void Dispose()
        {
            _situacaoRepository?.Dispose();
            _statusRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
