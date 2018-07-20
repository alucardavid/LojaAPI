using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaAPI.Models;

namespace LojaAPI.DAO
{
    public class CarrinhoDAO
    {
        public Carrinho Busca(int id) => new Carrinho().Produtos.Where(p => p.Id == id) as Carrinho;
        
    }
}