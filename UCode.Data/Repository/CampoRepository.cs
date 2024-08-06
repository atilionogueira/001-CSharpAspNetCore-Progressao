using Microsoft.EntityFrameworkCore;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Data.Context;

namespace UCode.Data.Repository
{
    public class CampoRepository : Repository<Campo>, ICampoRepository
    {
        public CampoRepository(MeuDbContext context) : base(context) { }

        public async Task<Campo>ObterCampo(Guid id) 
        {
            return await Db.Campos.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Campo> ObterCampoAtividade(Guid id)
        {
                 return await Db.Campos.AsNoTracking()
                .Include(c => c.Atividades)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
