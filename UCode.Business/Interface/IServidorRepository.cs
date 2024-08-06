using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface IServidorRepository : IRepository<Servidor>
    {
        Task<IEnumerable<Servidor>> ObterServidorPorCampus(Guid campusId);
        Task<IEnumerable<Servidor>> ObterCampussServidores();
        Task<Servidor> ObterServidorCampus(Guid id);
        Task<List<Servidor>> ObterTodosComCampo();
        
    }
}
