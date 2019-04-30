using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using SYSVendas.Application.Interface;
using SYSVendas.Domain.Entities;
using SYSVendas.MVC.ViewModels;

namespace SYSVendas.MVC.Controllers
{
    public class VendasController : Controller
    {
        private readonly IClienteAppService _clienteApp;
        private readonly IProdutoAppService _produtoApp;
        private readonly IVendaAppService _vendaApp;
        private readonly IDetalheVendaAppService _detalheVendaProduto;
       
        // GET: Vendas
        public VendasController(IProdutoAppService produtoApp, IVendaAppService vendaApp,
            IDetalheVendaAppService detalheVendaAppService, IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
            _produtoApp = produtoApp;
            _vendaApp = vendaApp;
            _detalheVendaProduto = detalheVendaAppService;
        }

        // GET: Venda
        public ActionResult Index()
        {
            var vendaViewModel = Mapper.Map<IEnumerable<Venda>, IEnumerable<VendaViewModel>>(_vendaApp.GetAll());

            return View(vendaViewModel);
        }

        // GET: Venda/Details/5
        public ActionResult Details(int id)
        {
            var venda = _vendaApp.GetById(id);
            var vendaViewModel = Mapper.Map<Venda, VendaViewModel>(venda);

            return View(vendaViewModel);
        }

        // GET: Venda/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome",  "Sobrenome");
            return View();
        }

        // POST: Venda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendaViewModel venda)
        {
            if (ModelState.IsValid)
            {
                var vendaDomain = Mapper.Map<VendaViewModel, Venda>(venda);
                _vendaApp.Add(vendaDomain);
                return RedirectToAction("Index");
            }
            return View(venda);
        }

        // Index de produtos da venda
        public ActionResult AddProdutosNaVendaIndex(int id)
        {
            var produtoViewModel = Mapper.Map<IEnumerable<DetalheVenda>, 
                IEnumerable<DetalheVendaViewModel>>(_detalheVendaProduto.BuscarIdVenda(id));
            ViewBag.VendaId = id;
            return View(produtoViewModel);
        }

        //GET
        public ActionResult AddProduto(int id)
        {
            ViewBag.ProdutoId = new SelectList(_produtoApp.GetAll(), "ProdutoId", "Nome");
            ViewBag.VendaId = id;
            return View();
        }

        
        //POST
        [HttpPost]
        public ActionResult AddProduto(AddProdutoViewModel viewAdd, int id)
        {
            if (ModelState.IsValid)
            {
                var produto = _produtoApp.GetById(viewAdd.ProdutoId);
                var detalheVendaViewModel = new DetalheVendaViewModel
                {
                    VendaId = id,
                    ProdutoId = produto.ProdutoId,
                    Qtd = viewAdd.Qtd,
                    Valor = (produto.Valor * viewAdd.Qtd)

                };
                var detalheVendaDomain = Mapper.Map<DetalheVendaViewModel, DetalheVenda>(detalheVendaViewModel);
                _detalheVendaProduto.Add(detalheVendaDomain);

                var venda = _vendaApp.GetById(id);
                venda.ValorTotal += detalheVendaDomain.Valor;
                _vendaApp.Update(venda);


                return RedirectToAction("AddProdutosNaVendaIndex/" + detalheVendaViewModel.VendaId);
            }

            ViewBag.ProdutoId = new SelectList(_produtoApp.GetAll(), "ProdutoId", "Nome");
            return View();
        }
    }
}