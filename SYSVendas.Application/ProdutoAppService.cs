using System.Collections.Generic;
using SYSVendas.Application.Interface;
using SYSVendas.Domain.Entities;
using SYSVendas.Domain.Interfaces.Services;

namespace SYSVendas.Application
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService)
            : base(produtoService)
        {
            _produtoService = produtoService;
        }

        public IEnumerable<Produto> BuscarAtivos(bool c)
        {
            return _produtoService.BuscarAtivos(c);
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoService.BuscarPorNome(nome);
        }

        
    }
}
