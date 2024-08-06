using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Data.Context;

namespace UCode.Data.Repository
{
    public class ComprovanteRespository : Repository<Comprovante>, IComprovanteRepository
    {
        public ComprovanteRespository(MeuDbContext context) : base(context) { }



        public async Task<Comprovante> ObterComprovanteValidacao(Guid id)
        {
            return await Db.Comprovantes.AsNoTracking()
                 .Include(c => c.Validacao)
                 .FirstOrDefaultAsync(c => c.Id == id);
        }



        public async Task<Comprovante> ObterComprovanteAtividadeProgressao(Guid id)
        {
            // Utilize o método Where para filtrar o Comprovante pelo ID
            var comprovante = await Db.Comprovantes.AsNoTracking()
                .Include(c => c.Progressao)
                .Include(c => c.Atividade)               
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            return comprovante;
        }

        public async Task<List<Comprovante>> ObterTodosComprovanteAtividadeProgressao()
        {
            return await Db.Comprovantes.AsNoTracking()
                                 .Include(c => c.Progressao)
                                 .Include(c => c.Atividade)
                                 .ToListAsync();
        }

        public async Task<Comprovante> ObterComprovante(Guid id)
        {
            return await Db.Comprovantes.AsNoTracking().Include(f => f.Valicacaos)
                 .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}


