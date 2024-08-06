using Microsoft.EntityFrameworkCore;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Data.Context;

namespace UCode.Data.Repository
{
    public class ServidorRepository : Repository<Servidor>, IServidorRepository
    {
        public ServidorRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<Servidor>> ObterCampussServidores()
        {
            return await Db.Servidors.AsNoTracking().Include(f => f.Campus)
                 .OrderBy(p => p.NomeCompleto).ToListAsync();
        }

        public async Task<Servidor> ObterServidorCampus(Guid id)
        {
            return await Db.Servidors.AsNoTracking().
                 Include(s => s.Campus)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Servidor>> ObterServidorPorCampus(Guid campusId)
        {
            return await Buscar(s => s.CampusId == campusId);
        }

        public async Task<List<Servidor>> ObterTodosComCampo()
        {
            return await DbSet.Include(a => a.Campus).ToListAsync();
        }
    }  
}
