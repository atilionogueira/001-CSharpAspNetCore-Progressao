using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface IServidorSerivce : IDisposable
    {
        Task Adicionar(Servidor servidor);
        Task Atualizar(Servidor servidor);
        Task Remover(Guid id);
    }
}
