using System.Collections.Generic;
using SYSVendas.Domain.Entities;

namespace SYSVendas.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);

        IEnumerable<Produto> BuscarAtivos(bool c);
    }
}
