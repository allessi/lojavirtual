using Allessi.LojaVirtual.Dominio.Repositorio;
using Allessi.LojaVirtual.Web.Models;
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
        public ViewResult ListaProdutos(int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();
            //obtém os produtos por página
            //exemplo: se a página for 2, então o skip irá pular a página 1, e o take vai obter 10 produtos


            ProdutoViewModel model = new ProdutoViewModel()
            {
                Produtos = _repositorio.Produtos.OrderBy(p => p.ProdutoDescricao)//ordena por descrição do produto.            
                .Skip((pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina),
                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = _repositorio.Produtos.Count()
                }
            };

            
            
            return View(model);
        }
    }
}