using Loja.DAO;
using Loja.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaAPI.Controllers
{
    public class CarrinhoController : ApiController
    {


        public HttpResponseMessage Get(int id)
        {
            try
            {
                var dao = new CarrinhoDAO();
                var carrinho = dao.Busca(id);
                return Request.CreateResponse(HttpStatusCode.OK, carrinho);
            }
            catch (KeyNotFoundException)
            {
                var mensagem = $"O carrinho com o id {id} não foi encontrado.";
                var error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

        public HttpResponseMessage Post([FromBody] Carrinho carrinho)
        {
            var dao = new CarrinhoDAO();
            dao.Adiciona(carrinho);

            var response =  Request.CreateResponse(HttpStatusCode.Created);
            var location = Url.Link("DefaultApi", new { controller = "carrinho", id = carrinho.Id });

            response.Headers.Location = new Uri(location);

            return response;

        }

        [Route("api/carrinho/{idCarrinho}/produto/{idProduto}")]
        public HttpResponseMessage Delete([FromUri] int idCarrinho, [FromUri] int idProduto)
        {
            var dao = new CarrinhoDAO();
            var carrinho = dao.Busca(idCarrinho);
            carrinho.Remove(idProduto);

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [Route("api/carrinho/{idCarrinho}/produto/{idProduto}/quantidade")]
        public HttpResponseMessage Put([FromBody] Produto produto, [FromUri] int idCarrinho, [FromUri] int idProduto)
        {
            var dao = new CarrinhoDAO();
            var carrinho = dao.Busca(idCarrinho);

            carrinho.TrocaQuantidade(produto);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
