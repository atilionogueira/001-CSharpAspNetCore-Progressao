using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface IComprovanteRepository : IRepository<Comprovante>
    {
        Task<Comprovante> ObterComprovanteValidacao(Guid id);
        Task<Comprovante> ObterComprovanteAtividadeProgressao(Guid id);
        Task<List<Comprovante>> ObterTodosComprovanteAtividadeProgressao();

        Task<Comprovante> ObterComprovante(Guid id);
    }
}
