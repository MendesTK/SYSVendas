using System.Collections.Generic;
using SYSVendas.Domain.Entities;

namespace SYSVendas.Application.Interface
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
