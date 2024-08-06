using DevIO.Business.Services;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Business.Models.Validations;

namespace UCode.Business.Services
{
    public class ClasseService : BaseService, IClasseService
    {
        private readonly IClasseRepository _classeRepository;
        private readonly IProgressaoRepository _progressaoRepository;

        public ClasseService(IClasseRepository classeRepository,
                      IProgressaoRepository progressaoRepository,
                      INotificador notificador) : base(notificador)
        {
            _classeRepository = classeRepository;
            _progressaoRepository = progressaoRepository;
        }

        public async Task Adicionar(Classe classe)
        {
            if (!ExecutarValidacao(new ClasseValidation(), classe)) return;

            await _classeRepository.Adicionar(classe);
        }

        public async Task Atualizar(Classe classe)
        {
            if (!ExecutarValidacao(new ClasseValidation(), classe)) return;

            await _classeRepository.Atualizar(classe);
        }

        public async Task Remover(Guid id)
        {
            var classeProgressao = await _classeRepository.ObterClasseProgressao(id);

            //if( classeProgressao?.Progressaos.Any() ?? false)
            if (classeProgressao?.Progressaos.Any() ?? false)
            {
                Notificar("A Classe possui um progressao cadastrada!");
                return;
            }           

            await _classeRepository.Remover(id);
        }

        public void Dispose()
        {
            _progressaoRepository?.Dispose();
            _classeRepository?.Dispose();
        }
    }
}
