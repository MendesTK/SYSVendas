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
        // GET: Vendas
        private readonly IProdutoAppService _produtoApp;
        private readonly IVendaAppService _vendaApp;

        public VendasController(IProdutoAppService produtoApp, IVendaAppService vendaApp)
        {
            _produtoApp = produtoApp;
            _vendaApp = vendaApp;
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
            ViewBag.ProdutoId = new SelectList(_produtoApp.GetAll(), "ProdutoId", "Nome");
            return View();
        }

        // POST: Cliente/Create
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

            ViewBag.ProdutoId = new SelectList(_produtoApp.GetAll(), "ProdutoId", "Nome", venda.Produtos);
            return View(venda);
        }

        // GET: Venda/Edit/5
        public ActionResult Edit(int id)
        {
            var venda = _vendaApp.GetById(id);
            var vendaViewModel = Mapper.Map<Venda, VendaViewModel>(venda);

            ViewBag.ProdutoId = new SelectList(_produtoApp.GetAll(), "ProdutoId", "Nome", vendaViewModel.Produtos);

            return View(vendaViewModel);
        }

        // POST: Venda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VendaViewModel venda)
        {
            if (ModelState.IsValid)
            {
                var vendaDomain = Mapper.Map<VendaViewModel, Venda>(venda);
                _vendaApp.Update(vendaDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(_produtoApp.GetAll(), "ProdutoId", "Nome", venda.Produtos);
            return View(venda);
        }

        /*
        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoApp.GetById(id);
            _produtoApp.Remove(produto);

            return RedirectToAction("Index");
        }*/
    }
}