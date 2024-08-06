using Microsoft.EntityFrameworkCore;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Data.Context;

namespace UCode.Data.Repository
{
    public class ProgressaoRepository : Repository<Progressao>, IProgressaoRepository
    {
        public ProgressaoRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<Progressao>> ObterProgressaoPorClasse(Guid classeId)
        {
            return await Buscar(a => a.ClasseId == classeId);
        }

        public async Task<IEnumerable<Progressao>> ObterProgressaoClasse()
        {
            return await Db.Progressaos.AsNoTracking()
                     .Include(p => p.Classe)
                     .OrderBy(p => p.Id).ToListAsync();
        }
        public async Task<Progressao> ObterProgressaoClasse(Guid id)
        {
                 return await Db.Progressaos.AsNoTracking()
                .Include(p => p.Classe)
                .FirstOrDefaultAsync(p => p.Id == id);                                    
        }
        
       
        // metodo utilizado no Index para visualiar todos os registro
        public async Task<List<Progressao>> ObterTodosComClasse()
        {
            return await DbSet.Include(a => a.Classe).ToListAsync();
        }

      

       
    }
}
