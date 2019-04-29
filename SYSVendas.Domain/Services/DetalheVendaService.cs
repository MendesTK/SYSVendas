using System.Collections.Generic;
using SYSVendas.Domain.Entities;
using SYSVendas.Domain.Interfaces.Repositories;
using SYSVendas.Domain.Interfaces.Services;

namespace SYSVendas.Domain.Services
{
    public class DetalheVendaService : ServiceBase<DetalheVenda>, IDetalheVendaService
    {
        private readonly IDetalheVendaRepository _vendaProdutoRepository;

        public DetalheVendaService(IDetalheVendaRepository vendaProdutoRepository)
            : base(vendaProdutoRepository)
        {
            _vendaProdutoRepository = vendaProdutoRepository;
        }

        public ICollection<DetalheVenda> BuscarIdVenda(int vendaId)
        {
            return _vendaProdutoRepository.BuscarIdVenda(vendaId);
        }
    }
}
