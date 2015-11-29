using Allessi.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Allessi.LojaVirtual.Web.Models
{
    //Não faz parte do domínio, pois é uma classe que representa os itens do domínio.
    public class ProdutoViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }

        public Paginacao Paginacao { get; set; }
    }
}