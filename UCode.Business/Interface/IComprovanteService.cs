using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface IComprovanteService
    {
        Task Adicionar(Comprovante comprovante);
        Task Atualizar(Comprovante comprovante);
        Task Remover(Guid id);
    }
}
