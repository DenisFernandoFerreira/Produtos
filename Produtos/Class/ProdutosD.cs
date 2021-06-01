using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Produtos.Class
{
    public class ProdutosD
    {
        public int ID_PRODUTO { get; set; }
        public string PROD_TX_NOME { get; set; }
        public string PROD_TX_DESCRICAO { get; set; }
        public decimal PROD_VL_VALOR { get; set; }
    }
}