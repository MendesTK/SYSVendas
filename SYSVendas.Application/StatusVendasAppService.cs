using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SYSVendas.Application.Interface;
using SYSVendas.Domain.Entities;
using SYSVendas.Domain.Interfaces.Services;

namespace SYSVendas.Application
{
    public class StatusVendasAppService : AppServiceBase<StatusVendas>, IStatusVendasAppService
    {
        private readonly IStatusVendasService _statusVendasService;

        public StatusVendasAppService(IStatusVendasService statusVendasService) 
            : base(statusVendasService)
        {
            _statusVendasService = statusVendasService;
        }
    }
}
