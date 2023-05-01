using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MercadoZe.Domain;

namespace MercadoZe.Intran.Data
{
    public class ProdutoDao
    {
        private const string _connectioString = @"Data Source=localhost\SQLEXPRESS;initial catalog= MercadoZe;User ID=sa;Password=123;";

        public ProdutoDao()
        {
        }

        private void ConverteObjetoParaSql(Produto produto, SqlCommand comand)
        {
            comand.Parameters.AddWithValue("@NOME", produto.Nome);
            comand.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
            comand.Parameters.AddWithValue("@DATA_VENCIMENTO", produto.DataVencimento.ToString("yyyy/MM/dd"));
            comand.Parameters.AddWithValue("@PRECO_UNITARIO", produto.PrecoUnitario);
            comand.Parameters.AddWithValue("@UNIDADE", produto.Unidade);
            comand.Parameters.AddWithValue("@QUANTIDADE_ESTOQUE", produto.QuantidadeEstoque);

        }
        private Produto ConverteSqlParaObjeto(SqlDataReader leitor)
        {
            Produto produtoBuscado = new Produto();

            produtoBuscado.Nome = leitor["NOME"].ToString();
            produtoBuscado.Descricao = leitor["DESCRICAO"].ToString();
            produtoBuscado.DataVencimento = Convert.ToDateTime(leitor["DATA_VENCIMENTO"]);
            produtoBuscado.PrecoUnitario = Convert.ToDouble(leitor["PRECO_UNITARIO"]);
            produtoBuscado.Unidade = leitor["UNIDADE"].ToString();
            produtoBuscado.QuantidadeEstoque = Convert.ToInt32(leitor["QUANTIDADE_ESTOQUE"]);

            return produtoBuscado;
        }

        public void AdicionarProduto(Produto novoProduto)
        {
            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT PRODUTO VALUES (@NOME, @DESCRICAO, @DATA_VENCIMENTO, @PRECO_UNITARIO, @UNIDADE, @QUANTIDADE_ESTOQUE);";

                    ConverteObjetoParaSql(novoProduto, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void EditarProduto(Produto produtoEditado)
        {
            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                   string sql = @"UPDATE PRODUTO SET NOME = @NOME,DESCRICAO = @DESCRICAO,DATA_VENCIMENTO = @DATA_VENCIMENTO,PRECO_UNITARIO = @PRECO_UNITARIO,UNIDADE = @UNIDADE,QUANTIDADE_ESTOQUE = @QUANTIDADE_ESTOQUE 
                                  WHERE @ID = ID_Produto;";
                    comando.Parameters.AddWithValue("@ID", produtoEditado.ID);
                    comando.CommandText = sql;
                    ConverteObjetoParaSql(produtoEditado, comando);

                    comando.ExecuteNonQuery();

                }

            }

        }

        public void DeletarProduto(Produto produto)
        {
            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    string sql = @"DELETE FROM PRODUTO WHERE ID_Produto = @ID";
                    comando.Parameters.AddWithValue("@ID", produto.ID);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();

                }

            }
        }

        public List<Produto> BuscarTodos()
        {
            var listaProduto = new List<Produto>();

            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    string sql = @"SELECT * FROM PRODUTO";
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Produto produtoBuscado = ConverteSqlParaObjeto(leitor);
                        listaProduto.Add(produtoBuscado);
                    }

                }

            }
            return listaProduto;
        }

        public List<Produto> BuscarProdutoDescricao(string descricao)
        {
            var listaProduto = new List<Produto>();
            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"SELECT * FROM PRODUTO WHERE DESCRICAO LIKE @DESCRICAO ";
                    comando.Parameters.AddWithValue("@DESCRICAO", $"%{descricao}%");

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Produto produtoBuscado = ConverteSqlParaObjeto(leitor);

                        listaProduto.Add(produtoBuscado);

                    }
                }

            }
            return listaProduto;
        }

        public Produto BuscarProdutoIdentificador(int ID)
        {
            Produto produto = null;
            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = comando.CommandText = @"SELECT * FROM PRODUTO WHERE ID_PRODUTO = @ID ";
                    comando.Parameters.AddWithValue("@ID", ID);


                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        produto = ConverteSqlParaObjeto(leitor);

                    }
                }

            }
            return produto;
        }

    }
}
