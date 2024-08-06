using DevIO.Business.Services;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Business.Models.Validations;

namespace UCode.Business.Services
{
    public class AtividadeService  : BaseService, IAtividadeService
    {
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IComprovanteRepository _comprovanteRepository;

        public AtividadeService(IAtividadeRepository atividadeRepository,
                                IComprovanteRepository comprovanteRepository,
                                INotificador notificador) : base(notificador)
        {
            _atividadeRepository = atividadeRepository;
            _comprovanteRepository = comprovanteRepository;
        }

        public async Task Adicionar(Atividade atividade)
        {
            if (!ExecutarValidacao(new AtividadeValidation(), atividade)) return;

            await _atividadeRepository.Adicionar(atividade);
        }

        public async Task Atualizar(Atividade atividade)
        {
            if (!ExecutarValidacao(new AtividadeValidation(), atividade)) return;

            await _atividadeRepository.Atualizar(atividade);
        }

        public async Task Remover(Guid id)
        {
            var atividadeComprovante = await _atividadeRepository.ObterAtividadeCampo(id);

            //  if (atividadeComprovante? .Comprovantes.Any() ?? false) 
            if (atividadeComprovante?.Comprovantes != null && atividadeComprovante.Comprovantes.Any())
            {
                Notificar("A Atividade possui um comprovante cadastrados");
                return;
            }

            await _atividadeRepository.Remover(id);

        }

        public void Dispose()
        {
            _atividadeRepository?.Dispose();
            _comprovanteRepository?.Dispose();          
        }

    }
}
