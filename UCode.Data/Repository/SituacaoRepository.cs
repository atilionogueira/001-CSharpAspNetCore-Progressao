using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Data.Context;

namespace UCode.Data.Repository
{
    public class SituacaoRepository : Repository<Situacao>, ISituacaoRepository
    {
        public SituacaoRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<Situacao>> ObterSituacaosPorStatus(Guid StatusId)
        {
            return await Buscar(p => p.StatusId == StatusId);
        }

        public async Task<IEnumerable<Situacao>> ObterSituacaosStatuss()
        {
            return await Db.Situacaos.AsNoTracking()
                 .Include(f => f.Status)
                 .OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<Situacao> ObterSituacaoStatus(Guid id)
        {
            return await Db.Situacaos.AsNoTracking()
                .Include(f => f.Status)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}