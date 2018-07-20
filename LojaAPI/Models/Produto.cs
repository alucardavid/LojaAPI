using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaAPI.Models
{
    public class Produto
    {
        public Produto(int id, int quantidade, string nome, double preco)
        {
            Id = id;
            Quantidade = quantidade;
            Nome = nome;
            Preco = preco;
        }

        public Produto()
        {

        }

        public int Id { get; set; }
        public int Quantidade { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

    }
}