using Microsoft.EntityFrameworkCore;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Data.Context;

namespace UCode.Data.Repository
{
    public class ClasseRepository : Repository<Classe>, IClasseRepository
    {
        public ClasseRepository(MeuDbContext context) : base(context) { }

        public async Task<Classe> ObterClasse(Guid id)
        {
            return await Db.Classes.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Classe> ObterClasseProgressao(Guid id)
        {
            return await Db.Classes.AsNoTracking()
                .Include(s => s.Progressaos)
                .FirstOrDefaultAsync(s => s.Id == id);
        }        
    }
}
