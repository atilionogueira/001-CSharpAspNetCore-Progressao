using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface IClasseRepository : IRepository<Classe>
    {
        Task<Classe> ObterClasse(Guid id);

        Task<Classe> ObterClasseProgressao(Guid id);
    }
}
