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
            ViewBag.ClienteId = new SelectList(_clienteApp.BuscarAtivos(true), "ClienteId", "Nome", "Sobrenome");
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
                vendaDomain.ValorTotal = 0;
                vendaDomain.StatusId = 1;
                _vendaApp.Add(vendaDomain);
                return RedirectToAction("Details/" + vendaDomain.VendaId);
            }
            return View(venda);
        }

        //GET
        public ActionResult AddProduto(int id)
        {
            ViewBag.ProdutoId = new SelectList(_produtoApp.BuscarAtivos(true), "ProdutoId", "Nome");
            ViewBag.VendaId = id;
            return PartialView();
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
                    Valor = produto.Valor,
                    Total = (produto.Valor * viewAdd.Qtd)

                };
                var detalheVendaDomain = Mapper.Map<DetalheVendaViewModel, DetalheVenda>(detalheVendaViewModel);
                _detalheVendaProduto.Add(detalheVendaDomain);

                var venda = _vendaApp.GetById(id);
                venda.ValorTotal += detalheVendaDomain.Total;
                _vendaApp.Update(venda);


                return RedirectToAction("Details/" + id);
            }
            return PartialView();
        }

        public ActionResult RemoverItem(int id, int idVenda)
        {
            var item = _detalheVendaProduto.GetById(id);
            var venda = _vendaApp.GetById(idVenda);
            if (item == null)
            {
                return HttpNotFound();
            }
            venda.ValorTotal -= item.Total;
            item.Total = 0;
            _vendaApp.Update(venda);
            _detalheVendaProduto.Update(item);
            return RedirectToAction("Details/" + idVenda);
        }

        public ActionResult CancelaVenda(int id)
        {
            var venda = _vendaApp.GetById(id);

            foreach (var iv in venda.VendasProdutos)
            {
                iv.Total = 0;
            }
            venda.ValorTotal = 0;
            venda.StatusId = 3;
            _vendaApp.Update(venda);
            return RedirectToAction("Details/" + id);
        }

        public ActionResult FinalizaVenda(int id)
        {
            var venda = _vendaApp.GetById(id);
            venda.StatusId = 2;
            _vendaApp.Update(venda);
            return RedirectToAction("Details/" + id);
        }
    }
}