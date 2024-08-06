using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface IStatusService : IDisposable
    {
        Task Adicionar(Status status);
        Task Atualizar(Status status);
        Task Remover(Guid id);
    }
}

