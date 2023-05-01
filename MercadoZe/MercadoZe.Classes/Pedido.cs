using System;

namespace MercadoZe.Domain
{
    public class Pedido
    {
        public DateTime DataHora { get; set; }
        public Produto ProdutoPedido { get; set; }
        public int QuantidadeProduto { get; set; }
        public Decimal ValorTotalPedido { get; set; }
        public Cliente ClientePedido { get; set; }

        //public Pedido(int quantidadeProduto, decimal valorTotalPedido)
        //{
        //    DataHora = DateTime.Now;
        //    ProdutoPedido = new Produto();
        //    QuantidadeProduto = quantidadeProduto;
        //    ValorTotalPedido = valorTotalPedido;
        //    ClientePedido = new Cliente();
        //    CalcularPontosFidelidade();
        //}

        //public Pedido(int quantidadeProduto, decimal valorTotalPedido)
        //{
        //    DataHora = DateTime.Now;
        //    ProdutoPedido = new Produto();
        //    QuantidadeProduto = quantidadeProduto;
        //    ValorTotalPedido = valorTotalPedido;

        //}
        public Pedido()
        {
            DataHora = DateTime.Now;
            ProdutoPedido = new Produto();
            ClientePedido = new Cliente();
         
        }

        public void CalcularPontosFidelidade()
        {
            ClientePedido.PontosFidelidade = (int)(ValorTotalPedido * 2);
        }

        public override string ToString()
        {
            return $"Data: {DataHora.ToString("MM/dd/yyyy HH:mm")}, ID produto: {ProdutoPedido.ID}, Quantidade do Produto: {QuantidadeProduto}, Nome Produto: {ProdutoPedido.Nome}, Valor Total: {ValorTotalPedido}, ID cliente: {ClientePedido.ID}, Nome Cliente: {ClientePedido.Nome}";
        }
    }
}
