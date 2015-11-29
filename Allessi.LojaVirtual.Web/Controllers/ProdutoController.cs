using Allessi.LojaVirtual.Dominio.Entidade;
using Allessi.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allessi.LojaVirtual.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        // GET: Produto
        public ActionResult Index()
        {
            _repositorio = new ProdutosRepositorio();
            //var produtos = _repositorio.Produtos.Take(3); //pega apenas dez produtos
            var produto = new Produto
            {
                ProdutoId = 1,
                CorCodigo = "AZ",
                MarcaDescricao = "Marca1",
                ModeloDescricao = "Modelo1",
                Preco = 15.50M,
                ProdutoCodigo = "1",
                ProdutoDescricao = "Produto1",
                ProdutoDescricaoResumida = "prod1",                
                ProdutoModeloCodigo = "ModeloCodigo1"                                
            };
            var produtos = new List<Produto>();
            produtos.Add(produto);


            return View(produtos);
        }
    }
}