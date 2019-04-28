using SYSVendas.Application.Interface;
using SYSVendas.Domain.Entities;
using SYSVendas.Domain.Interfaces.Services;

namespace SYSVendas.Application
{
    public class VendaAppService : AppServiceBase<Venda>, IVendaAppService
    {
        private readonly IVendaService _vendaService;

        public VendaAppService(IVendaService vendaService)
            : base(vendaService)
        {
            _vendaService = vendaService;
        }
    }
}
