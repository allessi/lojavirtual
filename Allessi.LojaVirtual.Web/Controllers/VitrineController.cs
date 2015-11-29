using Allessi.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allessi.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int ProdutosPorPagina = 10;

        // GET: Vitrine
        public ActionResult ListaProdutos(int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();

            //obtém os produtos por página
            //exemplo: se a página for 2, então o skip irá pular a página 1, e o take vai obter 3 produtos
            var produtos = _repositorio.Produtos.OrderBy(p => p.ProdutoDescricao)//ordena por descrição do produto.            
                .Skip((pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina);
            
            return View(produtos);
        }
    }
}