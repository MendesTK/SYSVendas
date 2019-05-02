using System.Collections.Generic;
using SYSVendas.Domain.Entities;

namespace SYSVendas.Application.Interface
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<Cliente> BuscarAtivos(bool cc);
    }
}
