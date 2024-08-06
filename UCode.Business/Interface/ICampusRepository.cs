using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface ICampusRepository : IRepository<Campus>
    {
        Task<Campus> ObterCampusEnderecoServidor(Guid id);
        Task<Campus> ObterCampus(Guid campusId);
    }
}
