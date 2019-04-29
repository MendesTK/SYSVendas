using System.Collections.Generic;
using SYSVendas.Application.Interface;
using SYSVendas.Domain.Entities;
using SYSVendas.Domain.Interfaces.Services;

namespace SYSVendas.Application
{
    public class DetalheVendaAppService : AppServiceBase<DetalheVenda>, IDetalheVendaAppService
    {
        private readonly IDetalheVendaService _vendaProdutoService;

        public DetalheVendaAppService(IDetalheVendaService vendaProdutoService)
            : base(vendaProdutoService)
        {
            _vendaProdutoService = vendaProdutoService;
        }

        public ICollection<DetalheVenda> BuscarIdVenda(int vendaId)
        {
            return _vendaProdutoService.BuscarIdVenda(vendaId);
        }
    }
}
