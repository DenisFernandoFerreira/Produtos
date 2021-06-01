using Npgsql;
using Produtos.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Produtos.Models
{
    public class ProdutoDao
    {
        NpgsqlConnection conn;
        NpgsqlCommand command;

        public ProdutoDao()
        {
            conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432; User Id=postgres; Password=egati@123; Database=Desafio;");
            conn.Open();
        }

        public ProdutosD Cadastrar(ProdutosD produto)
        {
            command = new NpgsqlCommand("SELECT * FROM public.FUNCT_INSERIR_PRODUTO('" + produto.PROD_TX_NOME + "', '" + produto.PROD_TX_DESCRICAO + "', " + produto.PROD_VL_VALOR.ToString().Replace(",", ".") + ")", conn);

            try
            {
                produto.ID_PRODUTO = int.Parse(command.ExecuteScalar().ToString());
            }
            finally
            {
                conn.Close();
            }

            return produto;
        }

        public void Editar(ProdutosD produto)
        {
            command = new NpgsqlCommand("CALL public.pr_alterar_produto(" + produto.ID_PRODUTO + ", '" + produto.PROD_TX_NOME + "', '" + produto.PROD_TX_DESCRICAO + "', " + produto.PROD_VL_VALOR.ToString().Replace(",", ".") + ")", conn);
            command.ExecuteScalar();
            conn.Close();
        }

        public List<ProdutosD> Listar()
        {
            List<ProdutosD> list = new List<ProdutosD>();

            command = new NpgsqlCommand("SELECT * FROM FUNCT_LISTAR_PRODUTO()", conn);

            try
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(GetObjeto(reader));
                    }
                }
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        public ProdutosD Listar(int id)
        {
            ProdutosD obj = new ProdutosD();

            command = new NpgsqlCommand("SELECT * FROM funct_listar_produto_id(" + id + ")", conn);

            try
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj = GetObjeto(reader);
                    }
                }
            }
            finally
            {
                conn.Close();
            }

            return obj;
        }

        public void Deletar(int id)
        {
            command = new NpgsqlCommand("CALL public.pr_deletar_produto(" + id + ")", conn);
            command.ExecuteScalar();
            conn.Close();
        }

        public ProdutosD GetObjeto(NpgsqlDataReader reader)
        {
            ProdutosD obj = new ProdutosD();

            obj.ID_PRODUTO = int.Parse(reader["ID_PRODUTO"].ToString());

            obj.PROD_TX_NOME = reader["PROD_TX_NOME"].ToString();
            obj.PROD_TX_DESCRICAO = reader["PROD_TX_DESCRICAO"].ToString();

            obj.PROD_VL_VALOR = Decimal.Parse(reader["PROD_VL_VALOR"].ToString() == "" ? "0" : reader["PROD_VL_VALOR"].ToString());

            return obj;
        }
    }
}