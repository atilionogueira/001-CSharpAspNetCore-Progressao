using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface ISituacaoRepository : IRepository<Situacao>
    {
        Task<IEnumerable<Situacao>> ObterSituacaosPorStatus(Guid StatusId);
        Task<IEnumerable<Situacao>> ObterSituacaosStatuss();
        Task<Situacao> ObterSituacaoStatus(Guid id);
    }
}
