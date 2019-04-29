using System.Collections.Generic;
using SYSVendas.Domain.Entities;

namespace SYSVendas.Domain.Interfaces.Services
{
    public interface IDetalheVendaService : IServiceBase<DetalheVenda>
    {
        ICollection<DetalheVenda> BuscarIdVenda(int vendaId);
    }
}
