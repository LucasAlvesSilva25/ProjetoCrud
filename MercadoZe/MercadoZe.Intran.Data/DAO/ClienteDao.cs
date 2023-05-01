using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MercadoZe.Domain;

namespace MercadoZe.Intran.Data
{
    public class ClienteDao
    {
        private const string _connectioString = @"Data Source=localhost\SQLEXPRESS;initial catalog= MercadoZe;User ID=sa;Password=123;";

        public void AdicionarCliente(Cliente cliente)
        {
            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    string sql = @"INSERT INTO CLIENTE VALUES (@CPF,@NOME,@DATA_NASCIMENTO,@PONTOS_FIDELIDADE,@RUA,@NUMERO,@BAIRRO,@CEP,@COMPLEMENTO)";

                    ConverterObjetoParaSql(cliente, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
        public void AtualizarCliente(Cliente clienteAtualizar)
        {
            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE CLIENTE SET CPF = @CPF, NOME = @NOME, DATA_NASCIMENTO = @DATA_NASCIMENTO, PONTOS_FIDELIDADE = @PONTOS_FIDELIDADE, RUA = @RUA, NUMERO = @NUMERO, BAIRRO = @BAIRRO, CEP = @CEP, COMPLEMENTO = @COMPLEMENTO WHERE CPF = @CPF_ATUALIZAR";

                    comando.Parameters.AddWithValue("@CPF_ATUALIZAR", clienteAtualizar.CPF);

                    ConverterObjetoParaSql(clienteAtualizar, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
        public void DeletarCliente(Cliente clienteDeletar)
        {
            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"DELETE FROM CLIENTE WHERE CPF = @CPF_DELETAR";

                    comando.Parameters.AddWithValue("@CPF_DELETAR", clienteDeletar.CPF);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }

        }
        public List<Cliente> BuscarTodos()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM CLIENTE";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Cliente ClienteBuscado = ConverterSqlParaObjeto(leitor);

                        listaClientes.Add(ClienteBuscado);
                    }
                }
            }

            return listaClientes;
        }
        public Cliente BuscarPorCpf(Cliente clienteCpf)
        {

            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM CLIENTE WHERE CPF = @CPF_BUSCAR";

                    comando.Parameters.AddWithValue("@CPF_BUSCAR", clienteCpf.CPF);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        clienteCpf = ConverterSqlParaObjeto(leitor);
                    }
                }
            }

            return clienteCpf;
        }
        public List<Cliente> BuscarNome(Cliente clienteNome)
        {
            List<Cliente> ListaNome = new List<Cliente>();

            using (var conexao = new SqlConnection(_connectioString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM CLIENTE WHERE NOME LIKE @NOME ";

                    comando.Parameters.AddWithValue("@NOME", $"%{clienteNome.Nome}%");

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Cliente clienteBuscado = ConverterSqlParaObjeto(leitor);
                        ListaNome.Add(clienteBuscado);
                    }
                }
            }
            return ListaNome;
        }
        private void ConverterObjetoParaSql(Cliente cliente, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@CPF", cliente.CPF);
            comando.Parameters.AddWithValue("@Nome", cliente.Nome);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@PONTOS_FIDELIDADE", cliente.PontosFidelidade);
            comando.Parameters.AddWithValue("@RUA", cliente.endereco.Rua);
            comando.Parameters.AddWithValue("@NUMERO", cliente.endereco.Numero);
            comando.Parameters.AddWithValue("@BAIRRO", cliente.endereco.bairro);
            comando.Parameters.AddWithValue("@CEP", cliente.endereco.Cep);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.endereco.Complemento);
        }
        private Cliente ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var cliente = new Cliente();
            cliente.CPF = Convert.ToInt32(leitor["CPF"].ToString());
            cliente.Nome = leitor["NOME"].ToString();
            cliente.DataNascimento = Convert.ToDateTime(leitor["DATA_NASCIMENTO"].ToString());
            cliente.PontosFidelidade = Convert.ToInt32(leitor["PONTOS_FIDELIDADE"]);
            cliente.endereco = new Endereco()
            {
                Rua = leitor["RUA"].ToString(),
                Numero = Convert.ToInt32(leitor["NUMERO"].ToString()),
                bairro = leitor["BAIRRO"].ToString(),
                Cep = Convert.ToInt32(leitor["CEP"].ToString()),
                Complemento = leitor["COMPLEMENTO"].ToString()
            };
            return cliente;
        }
    }
}

