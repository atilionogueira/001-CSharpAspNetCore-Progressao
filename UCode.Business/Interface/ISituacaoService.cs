using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface ISituacaoService
    {
        Task Adicionar(Situacao situacao);
        Task Atualizar(Situacao situacao);
        Task Remover(Guid id);
    }
}
