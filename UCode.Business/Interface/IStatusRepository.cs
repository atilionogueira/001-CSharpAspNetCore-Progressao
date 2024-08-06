using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface IStatusRepository : IRepository<Status>
    {
        Task<Status> ObterStatus(Guid StatusId);
        Task<Status> ObterStatusSituacao(Guid id);
    }
}
