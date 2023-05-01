using MercadoZe.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoZe.Intran.Data
{
    public class PedidoDao
    {
        private const string _connectioString = @"Data Source=localhost\SQLEXPRESS;initial catalog= MercadoZe;User ID=sa;Password=123;";

        public void AdicionarPedidoComCliente(Pedido pedido)
        {
            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT PEDIDO VALUES (@DATA_PEDIDO,@ID_PRODUTO,@QUANTIDE_PRODUTO,@VALOR_TOTAL,@ID_CLIENTE) ";


                    comando.Parameters.AddWithValue("@DATA_PEDIDO", pedido.DataHora); ;
                    comando.Parameters.AddWithValue("@ID_PRODUTO", pedido.ProdutoPedido.ID);
                    comando.Parameters.AddWithValue("@QUANTIDE_PRODUTO", pedido.QuantidadeProduto);
                    comando.Parameters.AddWithValue("@VALOR_TOTAL", pedido.ValorTotalPedido);
                    comando.Parameters.AddWithValue("@ID_CLIENTE", pedido.ClientePedido.ID);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Pedido> BucarTodosPedidos()
        {
            List<Pedido> listaTodosPedidos = new List<Pedido>();

            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT P.DATA_PEDIDO, P.ID_PRODUTO, P.QUANTIDE_PRODUTO,
                                   P.VALOR_TOTAL, P.ID_CLIENTE, C.NOME AS NOME_CLIENTE, PR.Nome AS NOME_PRODUTO FROM PEDIDO P INNER JOIN 
                                   CLIENTE C ON P.ID_CLIENTE = C.ID_CLIENTE INNER JOIN PRODUTO PR ON P.ID_PRODUTO = PR.ID_PRODUTO;";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Pedido pedidoBuscado = new Pedido();

                        pedidoBuscado.DataHora = Convert.ToDateTime(leitor["DATA_PEDIDO"].ToString());
                        pedidoBuscado.ProdutoPedido.ID = Convert.ToInt32(leitor["ID_PRODUTO"].ToString());
                        pedidoBuscado.QuantidadeProduto = Convert.ToInt32(leitor["QUANTIDE_PRODUTO"].ToString());
                        pedidoBuscado.ValorTotalPedido = Convert.ToDecimal(leitor["VALOR_TOTAL"].ToString());
                        pedidoBuscado.ClientePedido.ID = Convert.ToInt32(leitor["ID_CLIENTE"].ToString());
                        pedidoBuscado.ClientePedido.Nome = leitor["NOME_CLIENTE"].ToString();
                        pedidoBuscado.ClientePedido.Nome = leitor["NOME_PRODUTO"].ToString();

                        listaTodosPedidos.Add(pedidoBuscado);
                    }
                }
            }

            return listaTodosPedidos;

        }

    }
}
