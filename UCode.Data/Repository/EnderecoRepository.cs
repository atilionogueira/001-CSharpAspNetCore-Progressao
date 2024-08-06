using Microsoft.EntityFrameworkCore;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Data.Context;

namespace UCode.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoCampus(Guid CampyId)
        {
            return await Db.Enderecos.AsNoTracking()
                 .FirstOrDefaultAsync(f => f.CampusId == CampyId);
        }
    }
      
       
}
