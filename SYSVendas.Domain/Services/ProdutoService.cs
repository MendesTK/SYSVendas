using System;
using System.Collections.Generic;
using SYSVendas.Domain.Entities;
using SYSVendas.Domain.Interfaces.Repositories;
using SYSVendas.Domain.Interfaces.Services;

namespace SYSVendas.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoRepository.BuscarPorNome(nome);
        }
    }
}
