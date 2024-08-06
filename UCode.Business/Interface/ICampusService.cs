using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface ICampusService  : IDisposable
    {
        Task Adicionar(Campus campus);
        Task Atualizar(Campus campus);
        Task Remover(Guid id);
        Task AtualizarEndereco(Endereco endereco);

    }
}
