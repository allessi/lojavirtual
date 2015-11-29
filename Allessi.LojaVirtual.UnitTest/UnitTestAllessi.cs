using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
    }
}
