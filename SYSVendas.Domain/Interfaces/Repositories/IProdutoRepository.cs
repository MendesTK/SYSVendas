using System.Collections.Generic;
using SYSVendas.Domain.Entities;

namespace SYSVendas.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);

        IEnumerable<Produto> BuscarAtivos(bool c);

    }
}
