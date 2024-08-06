using Microsoft.EntityFrameworkCore;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Data.Context;

namespace UCode.Data.Repository
{
    public class CampusRepository : Repository<Campus>, ICampusRepository
    {
        public CampusRepository(MeuDbContext context) : base(context) { }

        public async Task<Campus> ObterCampus(Guid id)
        {
            return await Db.Campuss.AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Campus> ObterCampusEnderecoServidor(Guid id)
        {
            return await Db.Campuss.AsNoTracking()
                .Include(c => c.Endereco)
                .Include(c=>c.Servidors)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

