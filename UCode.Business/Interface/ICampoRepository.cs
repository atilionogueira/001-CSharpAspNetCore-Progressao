using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface ICampoRepository : IRepository<Campo>
    {
        Task<Campo> ObterCampo(Guid campoId);
        Task<Campo> ObterCampoAtividade(Guid id);
    }
}
