using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Allessi.LojaVirtual.Dominio.Repositorio;
using Allessi.LojaVirtual.Dominio.Entidade;
using System.Web.Mvc;
using Allessi.LojaVirtual.Web.Models;
using Allessi.LojaVirtual.Web.HtmlHelpers;

namespace Allessi.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestAllessi
    {
        [TestMethod]
        //O operador Take é usado para selecionar os primeiros n objetos de uma coleção.
        public void Take()
        {            

            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var resultado = from num in numeros.Take(4) select num;

            int[] testeComparacao = { 1, 2, 3, 4 };

            CollectionAssert.AreEqual(resultado.ToArray(), testeComparacao);

        }

        [TestMethod]
        // O operador skip ignora os primeiros n objetos de uma coleção
        public void Skip()
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var resultado = from num in numeros.Skip(8) select num;

            int[] testeComparacao = { 9 };
            CollectionAssert.AreEqual(resultado.ToArray(), testeComparacao);

        }

        [TestMethod]
        public void Ceiling()
        {
            // Obtém o valor integral do resultado da divisão, considerando o valor máximo e o mínimo.
            var teste = Math.Ceiling((decimal)50 / (decimal)5.4);

            Assert.AreEqual(teste, 0);
        }

        [TestMethod]
        public void TestesLinq()
        {
            int pagina = 1;
            int produtosPorPagina = 10;
            var repositorio = new ProdutosRepositorio();

            //obtém os produtos por página
            //exemplo: se a página for 2, então o skip irá pular a página 1, e o take vai obter 3 produtos
            var produtos = repositorio.Produtos.OrderBy(p => p.ProdutoDescricao)//ordena por descrição do produto.            
                .Skip((pagina - 1) * produtosPorPagina)
                .Take(produtosPorPagina);

            var teste = produtos.ToList();

        }

        [TestMethod]
        public void TestarSeAPaginacaoEstaSendoGeradaCorretamente()
        {
            //Arrange
            HtmlHelper html = null;
            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            //Assert
            Assert.AreEqual(@"<a class=""btn - default"" href =""Pagina0"" > 0</a>< a class=""btn - default"" href =""Pagina1"" > 1</a><a class=""btn - default btn- primary selected"" href ""Pagina2"" > 2</a>", resultado.ToString());


        }
    }
}
