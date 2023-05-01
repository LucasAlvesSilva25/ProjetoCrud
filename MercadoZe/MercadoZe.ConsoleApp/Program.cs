using System;
using System.Collections.Generic;
using MercadoZe.Domain;
using MercadoZe.Intran.Data;

namespace MercadoZe.ConsoleApp
{

    internal class Program
    {
        //PRODUTO
        static ProdutoDao _produtoDao = new ProdutoDao();
        static List<Produto> listaTodosProdutos = new List<Produto>();
        static List<Produto> listaDescricao = new List<Produto>();

        //CLIENTE
        static ClienteDao _clienteDao = new ClienteDao();
        static List<Cliente> listaTodosClientes = new List<Cliente>();
        static List<Cliente> listaClienteNomes = new List<Cliente>();

        //PEDIDO    
        static PedidoDao _pedidoDao = new PedidoDao();
        static List<Pedido> listaPedidos = new List<Pedido>();

        static string opcao;
        static string opcaoPrincipal;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("--          MENU PRINCIPAL         --");
                Console.WriteLine(" 1 - Produto");
                Console.WriteLine(" 2 - Cliente");
                Console.WriteLine(" 3 - Pedido");
                Console.WriteLine(" 4 - Sair");
                Console.Write("=> ");
                opcaoPrincipal = Console.ReadLine();
                if (opcaoPrincipal == "1")
                {
                    Console.Clear();
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("--          MENU PRODUTO         --");
                        Console.WriteLine(" 1 - Adicionar Produto");
                        Console.WriteLine(" 2 - Editar Produto");
                        Console.WriteLine(" 3 - Deletar Produto");
                        Console.WriteLine(" 4 - Buscar todo os Produtos");
                        Console.WriteLine(" 5 - Buscar produto por descrição");
                        Console.WriteLine(" 6 - Buscar produto pelo identificador");
                        Console.WriteLine(" 7 - Sair");
                        Console.Write("=> ");
                        opcao = Console.ReadLine();
                        switch (opcao)
                        {
                            case "1":
                                Console.Clear();
                                AdicionarProduto();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                            case "2":
                                Console.Clear();
                                EditarProduto();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                            case "3":
                                Console.Clear();
                                DeletarProduto();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                            case "4":
                                Console.Clear();
                                BuscarTodosProdutos();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                            case "5":
                                Console.Clear();
                                BuscarProdutoDescricao();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                            case "6":
                                Console.Clear();
                                BuscarProdutoIdentificador();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                        }
                    } while (opcao != "7");
                }
                if (opcaoPrincipal == "2")
                {
                    do
                    {
                        Console.Clear();

                        Console.WriteLine("--          MENU Cliente         --");
                        Console.WriteLine(" 1 - Adicionar Cliente");
                        Console.WriteLine(" 2 - Editar Cliente");
                        Console.WriteLine(" 3 - Deletar Cliente");
                        Console.WriteLine(" 4 - Buscar todo os Cliente");
                        Console.WriteLine(" 5 - Buscar Cliente por CPF");
                        Console.WriteLine(" 6 - Buscar Cliente pelo nome");
                        Console.WriteLine(" 7 - Sair");
                        Console.Write("=> ");
                        opcao = Console.ReadLine();
                        switch (opcao)
                        {
                            case "1":
                                Console.Clear();
                                AdicionarCliente();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                            case "2":
                                Console.Clear();
                                EditarCliente();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                            case "3":
                                Console.Clear();
                                DeletarCliente();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                            case "4":
                                Console.Clear();
                                BuscarTodosClientes();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();

                                break;
                            case "5":
                                Console.Clear();
                                BuscarClientesCPF();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                            case "6":
                                Console.Clear();
                                BucarClientesNome();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;

                        }
                    } while (opcao != "7");
                }
                if (opcaoPrincipal == "3")
                {
                    do
                    {
                        Console.Clear();

                        Console.WriteLine("--          MENU PEDIDO         --");
                        Console.WriteLine(" 1 - Adicionar PEDIDO");
                        Console.WriteLine(" 1 - Buscar pedidos");
                        Console.WriteLine(" 7 - Sair");
                        Console.Write("=> ");
                        opcao = Console.ReadLine();
                        switch (opcao)
                        {
                            case "1":
                                Console.Clear();
                                AdicionarPedido();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                            case "2":
                                Console.Clear();
                                BuscarTodosPedidos();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                            case "3":
                                Console.Clear();
                                DeletarCliente();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                            case "4":
                                Console.Clear();
                                BuscarTodosClientes();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();

                                break;
                            case "5":
                                Console.Clear();
                                BuscarClientesCPF();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;
                            case "6":
                                Console.Clear();
                                BucarClientesNome();
                                Console.WriteLine("\nCliente em qualquer tecla para voltar ao menu..");
                                Console.ReadKey();
                                break;

                        }
                    } while (opcao != "7");
                }


            } while (opcaoPrincipal != "4");




        }

        // PRODUTO
        public static void AdicionarProduto()
        {
            Console.WriteLine("--            CADASTRO PRODUTO            --");

            Produto novoProduto = new Produto();
            Console.Write("Nome: ");
            novoProduto.Nome = Console.ReadLine();

            Console.Write("Descrição: ");
            novoProduto.Descricao = Console.ReadLine();

            Console.Write("Data de vencimento (dd/MM/yyyy):");
            novoProduto.DataVencimento = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Preço unitário:");
            novoProduto.PrecoUnitario = Convert.ToDouble(Console.ReadLine());

            Console.Write("Unidade: ");
            novoProduto.Unidade = Console.ReadLine();

            Console.Write("Quantidade em estoque: ");
            novoProduto.QuantidadeEstoque = Convert.ToInt32(Console.ReadLine());

            _produtoDao.AdicionarProduto(novoProduto);



        }
        public static void EditarProduto()
        {

            Console.WriteLine("--            EDITAR PRODUTO            --");

            Produto produtoEditado = new Produto();

            Console.Write("ID do pruduto: ");
            produtoEditado.ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n***************************************************************************************************************************************");
            BuscarProdutoIdentificador_(produtoEditado.ID);
            Console.WriteLine("***************************************************************************************************************************************\n");

            Console.Write("Nome: ");
            produtoEditado.Nome = Console.ReadLine();

            Console.Write("Descrição: ");
            produtoEditado.Descricao = Console.ReadLine();

            Console.Write("Data de vencimento (dd/MM/yyyy):");
            produtoEditado.DataVencimento = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Preço unitário:");
            produtoEditado.PrecoUnitario = Convert.ToDouble(Console.ReadLine());

            Console.Write("Unidade: ");
            produtoEditado.Unidade = Console.ReadLine();

            Console.Write("Quantidade em estoque: ");
            produtoEditado.QuantidadeEstoque = Convert.ToInt32(Console.ReadLine());

            _produtoDao.EditarProduto(produtoEditado);
        }
        public static void DeletarProduto()
        {
            Console.WriteLine("--            DELETAR PRODUTO            --");

            Produto produtoDeletado = new Produto();

            Console.Write("ID do pruduto: ");
            produtoDeletado.ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("***************************************************************************************************************************************");
            BuscarProdutoIdentificador_(produtoDeletado.ID);
            Console.WriteLine("***************************************************************************************************************************************");

            _produtoDao.DeletarProduto(produtoDeletado);
        }
        public static void BuscarTodosProdutos()
        {
            Console.WriteLine("--                LISTA PRODUTOS               --");

            listaTodosProdutos = _produtoDao.BuscarTodos();
            foreach (var item in listaTodosProdutos)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public static void BuscarProdutoDescricao()
        {

            Console.WriteLine(" --                    PRODUTO                  --");
            Console.Write("Descrição: ");
            var descricao = Console.ReadLine();

            listaDescricao = _produtoDao.BuscarProdutoDescricao(descricao);

            foreach (var item in listaDescricao)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public static void BuscarProdutoIdentificador()
        {

            Produto ProdutoId = new Produto();
            Console.WriteLine(" --                    PRODUTO                  --");
            Console.Write("ID: ");
            ProdutoId.ID = Convert.ToInt32(Console.ReadLine());

            var produto = _produtoDao.BuscarProdutoIdentificador(ProdutoId.ID);

            Console.WriteLine(produto.ToString());
            Console.ReadKey();
        }
        public static void BuscarProdutoIdentificador_(int id)
        {
            Produto ProdutoId = new Produto();

            ProdutoId.ID = id;

            var produto = _produtoDao.BuscarProdutoIdentificador(ProdutoId.ID);

            Console.WriteLine(produto.ToString());
            Console.ReadKey();



        }

        // CLIENTE

        public static void AdicionarCliente()
        {
            Console.WriteLine("--            CADASTRO CLIENTE            --");

            Cliente cliente = new Cliente();

            Console.Write("Cpf: ");
            cliente.CPF = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nome: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("Data de Nascimento (dd/MM/yyyy): ");
            cliente.DataNascimento = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Pontos de fidelidade: ");
            cliente.PontosFidelidade = Convert.ToInt32(Console.ReadLine());

            Endereco endereco = new Endereco();

            Console.Write("Rua: ");
            endereco.Rua = Console.ReadLine();

            Console.Write("Número: ");
            endereco.Numero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Bairro: ");
            endereco.bairro = Console.ReadLine();

            Console.Write("Cep: ");
            endereco.Cep = Convert.ToInt32(Console.ReadLine());

            Console.Write("Complemento: ");
            endereco.Complemento = Console.ReadLine();

            cliente.endereco = endereco;

            _clienteDao.AdicionarCliente(cliente);
        }
        public static void EditarCliente()
        {
            Console.WriteLine("--            EDITAR CLIENTE            --");

            Cliente cliente = new Cliente();

            Console.Write("Cpf do cliente que deseja realizar edição: ");
            cliente.CPF = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nome: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("Data de Nascimento (dd/MM/yyyy): ");
            cliente.DataNascimento = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Pontos de fidelidade: ");
            cliente.PontosFidelidade = Convert.ToInt32(Console.ReadLine());

            Endereco endereco = new Endereco();

            Console.Write("Rua: ");
            endereco.Rua = Console.ReadLine();

            Console.Write("Número: ");
            endereco.Numero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Bairro: ");
            endereco.bairro = Console.ReadLine();

            Console.Write("Cep: ");
            endereco.Cep = Convert.ToInt32(Console.ReadLine());

            Console.Write("Complemento: ");
            endereco.Complemento = Console.ReadLine();

            cliente.endereco = endereco;

            _clienteDao.AtualizarCliente(cliente);
        }
        public static void DeletarCliente()
        {
            Console.WriteLine("--            DELETAR CLIENTE            --");

            Cliente cliente = new Cliente();

            Console.Write("Cpf do cliente que deseja deletar: ");
            cliente.CPF = Convert.ToInt32(Console.ReadLine());

            _clienteDao.DeletarCliente(cliente);
        }
        public static void BuscarTodosClientes()
        {
            listaTodosClientes = _clienteDao.BuscarTodos();

            foreach (var item in listaTodosClientes)
            {
                Console.WriteLine(item);
            }
        }
        public static void BuscarClientesCPF()
        {
            Console.WriteLine("--            BUSCAR CLIENTE CPF            --");

            Cliente cliente = new Cliente();

            Console.Write("Cpf do cliente que deseja consultar: ");
            cliente.CPF = Convert.ToInt32(Console.ReadLine());

            var clienteBuscado = _clienteDao.BuscarPorCpf(cliente);

            Console.WriteLine(clienteBuscado);
        }
        public static Cliente BuscarClientesCpfObterId()
        {
            Console.WriteLine("--           CLIENTE             --");

            Cliente cliente = new Cliente();

            Console.Write("Cpf do cliente que deseja adicionar: ");
            cliente.CPF = Convert.ToInt32(Console.ReadLine());

            var clienteBuscado = _clienteDao.BuscarPorCpf(cliente);

            return clienteBuscado;
        }
        public static void BucarClientesNome()
        {
            Console.WriteLine("--            BUSCAR CLIENTES NOMES            --");

            Cliente cliente = new Cliente();

            Console.Write("Nome: ");
            cliente.Nome = Console.ReadLine();

            listaClienteNomes = _clienteDao.BuscarNome(cliente);

            foreach (var item in listaClienteNomes)
            {
                Console.WriteLine(item);
            }
        }

        //PEDIDO

        public static void AdicionarPedido()
        {
            Console.WriteLine("--            CADASTRO PEDIDO            --");

            Pedido pedido = new Pedido();

            Console.Write("Digite o ID do produto que deseja cadastrar: ");
            pedido.ProdutoPedido.ID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Quantidade desse produto: ");
            pedido.QuantidadeProduto = Convert.ToInt32(Console.ReadLine());

            Console.Write("Valor total do pedido: ");
            pedido.ValorTotalPedido = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Deseje adicionar um cliente ao pedido? (1 - SIM/2 - NÃO): ");
            int clienteOpcao = Convert.ToInt32(Console.ReadLine());

            if (clienteOpcao == 1)
            {
                Console.Write("Cliente já cadastrado? (1 - SIM/2 - NÃO): ");
                int Opcao = Convert.ToInt32(Console.ReadLine());

                if (Opcao == 1)
                {
                    Console.WriteLine("Digite o ID do cliente: ");
                    pedido.ClientePedido.ID = Convert.ToInt32(Console.ReadLine());

                }
                else
                {
                    Console.Clear();
                    AdicionarCliente();
                    Console.Clear();
                    var cliente = BuscarClientesCpfObterId();
                    pedido.ClientePedido.ID = cliente.ID;

                }
                pedido.CalcularPontosFidelidade();
                
            }

            _pedidoDao.AdicionarPedidoComCliente(pedido);
        }
        public static void BuscarTodosPedidos()
        {
            listaPedidos = _pedidoDao.BucarTodosPedidos();

            foreach (var item in listaPedidos)
            {
                Console.WriteLine(item);
            }
        }
    }
}
