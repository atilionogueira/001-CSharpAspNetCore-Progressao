using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface ICampoService
    {
        Task Adicionar(Campo campo);
        Task Atualizar(Campo campo);
        Task Remover(Guid id);
    }
}
