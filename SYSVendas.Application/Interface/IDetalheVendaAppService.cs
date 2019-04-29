using System.Collections.Generic;
using SYSVendas.Domain.Entities;

namespace SYSVendas.Application.Interface
{
    public interface IDetalheVendaAppService : IAppServiceBase<DetalheVenda>
    {
        ICollection<DetalheVenda> BuscarIdVenda(int vendaId);
    }
}
