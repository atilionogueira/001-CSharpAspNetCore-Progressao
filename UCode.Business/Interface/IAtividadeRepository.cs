using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface IAtividadeRepository : IRepository<Atividade>
    {
        Task<IEnumerable<Atividade>> ObterAtividadesPorCampo(Guid campoId);        
        Task<Atividade> ObterAtividadeCampo(Guid id);
        Task<List<Atividade>> ObterTodosComCampo();
      

    }
}


