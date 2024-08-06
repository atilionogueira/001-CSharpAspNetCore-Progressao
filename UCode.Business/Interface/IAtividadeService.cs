using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface IAtividadeService
    {
        Task Adicionar(Atividade atividade);
        Task Atualizar(Atividade atividade);
        Task Remover(Guid id);
    }
}
