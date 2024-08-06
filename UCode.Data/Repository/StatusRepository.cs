using Microsoft.EntityFrameworkCore;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Data.Context;

namespace UCode.Data.Repository
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(MeuDbContext context) : base(context) { }

        public async Task<Status> ObterStatus(Guid id)
        {         
            return await Db.Statuss.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Status> ObterStatusSituacao(Guid id)
        {
            return await Db.Statuss.AsNoTracking()
                .Include(s => s.Situacaos)               
                .FirstOrDefaultAsync(s => s.Id == id);
        }
                
    }
}
