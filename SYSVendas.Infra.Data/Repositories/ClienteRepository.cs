using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SYSVendas.Domain.Entities;
using SYSVendas.Domain.Interfaces.Repositories;

namespace SYSVendas.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {

    }
}
