using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace LojaAPI.Models
{
    public class Carrinho
    {
        public int Id { get; set; }
        public List<Produto> Produtos = new List<Produto>();

        public Carrinho()
        {
            Produto produto1 = new Produto(
                6237,
                1,
                "VideoGame 4",
                4000
                );

            Produto produto2 = new Produto(
                6239,
                1,
                "VideoGame 4",
                4000
                );

            Produtos.Add(produto1);
            Produtos.Add(produto2);
        }

        public string ToXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Carrinho));
            StringWriter stringWriter = new StringWriter();

            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                xmlSerializer.Serialize(writer, this);
                return stringWriter.ToString();
            }
        }
    }
}