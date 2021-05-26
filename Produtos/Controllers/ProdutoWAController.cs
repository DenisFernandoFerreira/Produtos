using Produtos.Class;
using Produtos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Produtos.Controllers
{
    public class ProdutoWAController : ApiController
    {
        ProdutoDao pDao;

        public ProdutoWAController()
        {
            pDao = new ProdutoDao();
        }

        // GET api/<controller>
        public List<Produto> Get()
        {
            return pDao.Listar();
        }

        // GET api/<controller>/5
        public Produto Get(int id)
        {
            return pDao.Listar(id);
        }

        // POST api/<controller>
        public Produto Post([FromBody] Produto produto)
        {
            produto.PROD_VL_VALOR = Decimal.Parse(produto.PROD_VL_VALOR.ToString().Replace(".", ","));

            return pDao.Cadastrar(produto);
        }

        // PUT api/<controller>/5
        public void Put([FromBody] Produto produto)
        {
            produto.PROD_VL_VALOR = Decimal.Parse(produto.PROD_VL_VALOR.ToString().Replace(".", ","));

            pDao.Editar(produto);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            pDao.Deletar(id);
        }
    }
}