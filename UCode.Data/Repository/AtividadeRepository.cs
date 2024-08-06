using Microsoft.EntityFrameworkCore;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Data.Context;

namespace UCode.Data.Repository
{
    public class AtividadeRepository : Repository<Atividade>, IAtividadeRepository 
    {
        public AtividadeRepository(MeuDbContext context) : base(context) { }

      
        public async Task<Atividade> ObterAtividadeCampo(Guid id)
        {
            return await Db.Atividades.AsNoTracking().Include(a => a.Campo)
                .FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<IEnumerable<Atividade>> ObterAtividadesPorCampo(Guid campoId)
        {
            return await Buscar(a => a.CampoId == campoId);
        }        

        // metodo utilizado no Index para visualiar todos os registro 
        public async Task<List<Atividade>> ObterTodosComCampo()
        {
            return await DbSet.Include(a => a.Campo).ToListAsync();
        }

    }
}
