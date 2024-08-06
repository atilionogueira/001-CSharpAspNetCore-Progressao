using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCode.Business.Models;

namespace UCode.Business.Interface
{
    public interface IProgressaoService
    {
        Task Adicionar(Progressao progressao);
        Task Atualizar(Progressao progressao);
        Task Remover(Guid id);
    }
}
