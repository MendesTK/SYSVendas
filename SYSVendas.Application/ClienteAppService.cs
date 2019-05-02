using System.Collections.Generic;
using SYSVendas.Application.Interface;
using SYSVendas.Domain.Entities;
using SYSVendas.Domain.Interfaces.Services;

namespace SYSVendas.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _cLienteService;

        public ClienteAppService(IClienteService cLienteService)
            : base(cLienteService)
        {
            _cLienteService = cLienteService;
        }

        public IEnumerable<Cliente> BuscarAtivos(bool cc)
        {
            return _cLienteService.BuscarAtivos(cc);
        }
    }
}
