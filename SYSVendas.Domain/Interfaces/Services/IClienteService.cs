using System.Collections.Generic;
using SYSVendas.Domain.Entities;

namespace SYSVendas.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        IEnumerable<Cliente> BuscarAtivos(bool cc);
    }
}
