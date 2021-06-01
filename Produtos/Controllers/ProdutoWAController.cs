using Newtonsoft.Json;
using Produtos.Class;
using Produtos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;


namespace Produtos.Controllers
{
    public class ProdutoWAController : ApiController
    {
        ProdutoDao pDao;
        static HttpClient client = new HttpClient();
        private const string URL = "https://no2gru7ua3.execute-api.us-east-1.amazonaws.com/";

        public ProdutoWAController()
        {
            pDao = new ProdutoDao();
        }

        public async Task<Root> RunAsync()
        {
            Root root;

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(URL, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                var respContent = await result.Content.ReadAsStringAsync();
                root = JsonConvert.DeserializeObject<Root>(respContent);
            }

            return root;
        }


        //GET api/<controller>
        public Root Get()
        {
            return Task.Run(() => RunAsync()).Result;
        }


        // GET api/<controller>/5
        public ProdutosD Get(int id)
        {
            try
            {
                return pDao.Listar(id);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível executar o comando SQL. --> " + e.Message);
            }
        }

        // POST api/<controller>
        public ProdutosD Post([FromBody] ProdutosD produto)
        {
            try
            {
                produto.PROD_VL_VALOR = Decimal.Parse(produto.PROD_VL_VALOR.ToString().Replace(".", ","));

                return pDao.Cadastrar(produto);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível executar o comando SQL. --> " + e.Message);
            }
        }

        // PUT api/<controller>/5
        public void Put([FromBody] ProdutosD produto)
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