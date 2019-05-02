using SYSVendas.Domain.Entities;
using SYSVendas.Domain.Interfaces.Repositories;
using SYSVendas.Domain.Interfaces.Services;

namespace SYSVendas.Domain.Services
{
    public class StatusVendasService : ServiceBase<StatusVendas>, IStatusVendasService
    {
        private readonly IStatusVendasRepository _statusVendasRepository;

        public StatusVendasService(IStatusVendasRepository statusVendasRepository)
            : base(statusVendasRepository)
        {
            _statusVendasRepository = statusVendasRepository;
        }
    }
}
