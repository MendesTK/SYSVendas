using System.Collections.Generic;
using System.Linq;
using SYSVendas.Domain.Entities;
using SYSVendas.Domain.Interfaces.Repositories;

namespace SYSVendas.Infra.Data.Repositories
{
    public class DetalheVendaRepository : RepositoryBase<DetalheVenda>, IDetalheVendaRepository
    {
        public ICollection<DetalheVenda> BuscarIdVenda(int vendaId)
        {
            return Db.VendasProdutos.Where(vp => vp.VendaId == vendaId).ToList();
        }
    }
}
