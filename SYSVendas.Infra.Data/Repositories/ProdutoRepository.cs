using System.Collections.Generic;
using System.Linq;
using SYSVendas.Domain.Entities;
using SYSVendas.Domain.Interfaces.Repositories;

namespace SYSVendas.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return Db.Produtos.Where(p => p.Nome == nome);
        }

        public IEnumerable<Produto> BuscarAtivos(bool c)
        {
            return Db.Produtos.Where(p => p.Ativo.Equals(c));
        }
    }
}
