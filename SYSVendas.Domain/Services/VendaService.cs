using SYSVendas.Domain.Entities;
using SYSVendas.Domain.Interfaces.Repositories;
using SYSVendas.Domain.Interfaces.Services;

namespace SYSVendas.Domain.Services
{
    public class VendaService : ServiceBase<Venda>, IVendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
            :base(vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

    }
}
