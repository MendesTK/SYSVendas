﻿using System.Collections.Generic;
using SYSVendas.Domain.Entities;
using SYSVendas.Domain.Interfaces.Repositories;
using SYSVendas.Domain.Interfaces.Services;

namespace SYSVendas.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        IEnumerable<Cliente> IClienteService.BuscarAtivos(bool cc)
        {
            return _clienteRepository.BuscarAtivos(cc);
        }
    }
}
