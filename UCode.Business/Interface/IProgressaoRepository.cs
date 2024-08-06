using System.Threading.Tasks;
using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface IProgressaoRepository : IRepository<Progressao>
    {
        Task<IEnumerable<Progressao>> ObterProgressaoPorClasse(Guid classeId);
        
        Task<Progressao> ObterProgressaoClasse(Guid id);          

        Task<List<Progressao>> ObterTodosComClasse();
    }
}
