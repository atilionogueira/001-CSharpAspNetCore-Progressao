using Microsoft.EntityFrameworkCore;
using UCode.Business.Interface;
using UCode.Business.Models;
using UCode.Data.Context;

namespace UCode.Data.Repository
{
    public class ValidacaoRepository : Repository<Validacao>, IValidacaoRepository
    {
        public ValidacaoRepository(MeuDbContext context) : base(context) { }

      
    }
}
