using System.Collections.Generic;
using SYSVendas.Domain.Entities;

namespace SYSVendas.Domain.Interfaces.Repositories
{
    public interface IDetalheVendaRepository : IRepositoryBase<DetalheVenda>
    {
        ICollection<DetalheVenda> BuscarIdVenda(int vendaId);
    }
}
