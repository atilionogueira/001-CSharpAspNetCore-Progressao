using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface IClasseService
    {
        Task Adicionar(Classe classe);
        Task Atualizar(Classe classe);
        Task Remover(Guid id);
    }
}
