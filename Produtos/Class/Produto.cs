using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Produtos.Class
{
    public class Produto
    {
        public string produto { get; set; }
        public double valor { get; set; }
        public string imagem { get; set; }
        public List<string> eans { get; set; }
    }
}